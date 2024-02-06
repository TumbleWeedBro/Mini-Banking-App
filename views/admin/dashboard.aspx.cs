using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mini_Banking_App.views.admin
{
    public partial class dashboard : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["status"] != "admin" )
                {

                    Response.Redirect("/views/home/bank.aspx");
           
                }
                else
                {
                    BindGridView();
                }
                
            }
            
        }

        
        private void BindGridView()
        {



            using (SqlConnection con = new SqlConnection(strcon))
            {
                SqlCommand cmd = new SqlCommand("SELECT users.id, users.first_name, users.surname, users.email, users.mobile_number, " +
                    "users.employment, users.account_status,account.account_number " +
                    "FROM users " +
                    "LEFT JOIN account ON users.id= account.users_id " +
                    "ORDER BY users.id; "
                    , con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();

                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    GridView1.DataSource = table;
                    GridView1.DataBind();
                }
                else
                {
                    // Handle no data found
                }
            }

        }
 

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                string userId = row.Cells[0].Text;
                string account_number = row.Cells[1].Text;

                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM payments " +
                    "WHERE " +
                    "senders_account_numbers = @account_number" +
                    "DELETE FROM account " +
                    "WHERE " +
                    "users_id = @userId  AND account_status != 'admin';" +
                    "DELETE FROM users " +
                    "WHERE " +
                    "id = @userId AND account_status != 'admin'"
                    , con);

                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@account_number", account_number);
                cmd.ExecuteNonQuery();

               
                Response.Redirect("/views/admin/dashboard.aspx");
                Response.Write("<script>alert('Account Deleted');</script>");
            }
        }

        protected void btnSuspend_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                string userId = row.Cells[0].Text;

                SqlCommand cmd = new SqlCommand(
                    "UPDATE users " +
                    "SET account_status = 'suspended' " +
                    "WHERE " +
                    "id = @userId  AND account_status != 'admin'"
                    , con);

                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.ExecuteNonQuery();

                
                Response.Redirect("/views/admin/dashboard.aspx");
                Response.Write("<script>alert('Account Suspended');</script>");
            }
        }

        protected void btnActivate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                string userId = row.Cells[0].Text;

                SqlCommand cmd = new SqlCommand(
                    "UPDATE users " +
                    "SET account_status = 'active' " +
                    "WHERE " +
                    "id = @userId  AND account_status != 'admin'"
                    , con);

                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.ExecuteNonQuery();

                
                Response.Redirect("/views/admin/dashboard.aspx");
                Response.Write("<script>alert('Account Active');</script>");
            }
            
  
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}