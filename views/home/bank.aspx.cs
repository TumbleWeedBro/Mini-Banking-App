using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mini_Banking_App.views.home
{
    public partial class bank : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string accountNumber = "";

            string savingsBalance = "";

            string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            try
            {
                if (Session["UserId"] != null)
                {
                    if (!IsPostBack)
                    {
                        SqlConnection con = new SqlConnection(strcon);

                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }

                        int UserId = (int)Session["UserId"];
                        SqlCommand cmd = new SqlCommand(
                            "SELECT * FROM account WHERE users_id = @UserId"
                            , con);

                        cmd.Parameters.AddWithValue("@UserId", UserId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                accountNumber = reader["account_number"].ToString();
;
                                savingsBalance = reader["savings_balance"].ToString();
                            }


                        }

                        con.Close();

                        txtAccountNumber.Text = accountNumber;

                        txtSavingsBalance.Text = savingsBalance;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script)");
            }
            
           
        }

        protected void txtAccountNumber_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtChequeBalance_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtSavingsBalance_TextChanged(object sender, EventArgs e)
        {

        }
    }
}