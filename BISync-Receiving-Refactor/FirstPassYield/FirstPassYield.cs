using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstPassYield
{
    public partial class FirstPassYield : Form
    {
        public static string bldrsql = "Data Source=172.16.4.27;Initial Catalog=MfgTraveler;Persist Security Info=True;User ID=travelmfg;Password=Tr@vel@mfg";

        public FirstPassYield()
        {
            InitializeComponent();
        }

        private void FirstPassYield_Load(object sender, EventArgs e)
        {
            LoadComboOptions();
        }

        private void LoadComboOptions()
        {
            SqlConnection con = new SqlConnection(bldrsql);
            SqlCommand cmd = new SqlCommand(@"
                    Select * from (select distinct Product from Processes WITH (nolock) where LEN(Product) > 1
                    UNION
                    Select 'All') t(val)
                    Where ISNULL(t.val, '') != ''
                    Order by case when t.val = 'All' Then 1 else 0 END DESC, t.val ASC

                    Select* from(select distinct Process[Operation] from Processes WITH (nolock) where LEN(Process) > 1
                    UNION
                    Select 'All') t(val)
                    Where ISNULL(t.val, '') != ''
                    Order by case when t.val = 'All' Then 1 else 0 END DESC, t.val ASC
                    ",con);

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            cmbProduct.DataSource = DS.Tables[0];
            cmbProduct.DisplayMember = "val";
            cmbProduct.ValueMember = "val";
            cmbProduct.SelectedIndex = 0;

            cmbOperation.DataSource = DS.Tables[1];
            cmbOperation.DisplayMember = "val";
            cmbOperation.ValueMember = "val";
            cmbOperation.SelectedIndex = 0;

        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(bldrsql);
            SqlCommand cmd = new SqlCommand(@"
                    ; with  FirstPass as
                    (
	                    Select
		                    Product, Operation, COUNT([Serial Number]) as count 
	                    from 
		                    Operations
	                    Where
		                    (@prod = 'All' OR (Product = @prod))
		                    and Datetime between @start and  DATEADD(dd,1, @end)
                            and (@op = 'All' OR (Operation = @op))
		                    and Operation not like 'Retest%' 
		                    and Resolution = 'Pass'
	                    Group By
		                    Product, Operation
                    )


                    , FailedRetest as
                    (
	                    Select
		                    Product, substring(Operation,10,50) as operation, COUNT([Serial Number]) as count
	                    from 
		                    Operations o
	                    Where
		                    (@prod = 'All' OR (o.Product = @prod))
		                    and Datetime between @start and  DATEADD(dd,1, @end)
		                    and Operation like 'Retest%'
		                    and Resolution = 'Fail'
		                    and [Serial Number] in (select [Serial Number] from 
								                        Operations o2
							                        Where
								                        (@prod = 'All' OR (Product = @prod))
		                                                and Datetime between @start and  DATEADD(dd,1, @end)
                                                        and (@op = 'All' OR (Operation = @op))
		                                                and Operation not like 'Retest%' 
		                                                and Resolution = 'Pass' 
								                        and o.Operation like '%'+o2.Operation 
								                        and Cast(o.DateTime as date) = Cast(o2.DateTime as date))
	                    Group By
		                    Product, Operation

                    )


                    , total as
                    (
	                    Select
		                    Product, Operation, Count([Serial Number]) as count
	                    from 
		                    Operations
	                    Where
		                    (@prod = 'All' OR (Product = @prod))
		                    and Datetime between @start and  DATEADD(dd,1, @end)
                            and (@op = 'All' OR (Operation = @op))
		                    --and Operation not like 'Retest%' 
	                    Group by 
		                    Product, Operation

                    )

                    Select 
                        p.Product,
	                    p.Operation, 
	                    p.count [grossFirstPass], 
	                    ISNULL(r.count,0) [failedRetest], 
	                    p.count - ISNULL(r.count,0) [netFirstPass], 
	                    t.count [total], 
	                    Cast(Cast(p.count - ISNULL(r.count,0) as decimal) /Cast(t.count as decimal)*100 as decimal(10,2)) [firstPassYield]
                    From 
	                    FirstPass p
                    Left Join
	                    FailedRetest r
	                    on r.operation = p.Operation and r.Product = p.Product
                    Left Join
	                    total t
	                    on t.Operation = p.Operation and t.Product = p.Product
                    ", con);

            cmd.Parameters.AddWithValue("@Start", dtStart.Value.ToShortDateString());
            cmd.Parameters.AddWithValue("@End", dtEnd.Value.ToShortDateString());
            cmd.Parameters.AddWithValue("@prod", cmbProduct.Text);
            cmd.Parameters.AddWithValue("@op", cmbOperation.Text);

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            dgvFirstPassYield.DataSource = DT;
        }
    }
}
