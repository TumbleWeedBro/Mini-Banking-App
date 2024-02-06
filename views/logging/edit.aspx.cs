using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mini_Banking_App.views.logging
{


    public partial class edit : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public bool correct_pass;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string first_name = "";
                string surname = "";
                string email = "";
                string mobile_number = "";
                string employment = "";

                try
                {
                    SqlConnection con = new SqlConnection(strcon);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
    ;               
                    if (Session["UserId"] != null)
                    {
                        int UserId = (int)Session["UserId"];
                        SqlCommand cmd = new SqlCommand(
                            "SELECT * FROM users " +
                            "WHERE " +
                            "id = @UserId", con);
                        cmd.Parameters.AddWithValue("@UserId", UserId);



                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                first_name = reader["first_name"].ToString();
                                surname = reader["surname"].ToString();
                                email = reader["email"].ToString();
                                mobile_number = reader["mobile_number"].ToString();
                                employment = reader["employment"].ToString();
                            }
                        }

                        con.Close();

                        txtFirstName.Text = first_name;
                        txtSurname.Text = surname;
                        txtEmailAddress.Text = email;
                        txtPhoneNumber.Text = mobile_number;
                        ddlEmployment.Text = employment;

                    }
                    else
                    {
                        Response.Redirect("/views/logging/login.aspx");
                    }

                }


                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script)");
                }
            }
           
        }



        protected void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            string first_name = txtFirstName.Text.Trim();
            string surname = txtSurname.Text.Trim();
            string email = txtEmailAddress.Text.Trim();
            string mobile_number = txtPhoneNumber.Text.Trim();
            string employment = ddlEmployment.SelectedValue;
            int UserId = (int)Session["UserId"];

            string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                
                SqlCommand cmd = new SqlCommand(
                    "UPDATE users " +
                    "SET " +
                    "first_name = @first_name, " +
                    "surname = @surname, " +
                    "email = @email, " +
                    "mobile_number = @mobile_number, " +
                    "employment = @employment " +
                    "WHERE " +
                    "id = @UserId"
                    , con);
                cmd.Parameters.AddWithValue("@first_name", first_name);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@mobile_number", mobile_number);
                cmd.Parameters.AddWithValue("@employment", employment);
                cmd.Parameters.AddWithValue("@UserId", UserId);

                

                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    //just assume they dont want to change the password
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('ACCOUNT DETAILS UPDATED');</script>");
                   
                    Response.Redirect("/views/home/bank.aspx");
                }
                else
                {
                    //Query to get password_hash and match the passwords and only then is Update password allowed
                    string password = txtPassword.Text.Trim();
                    string newpassword = txtNewPassword.Text.Trim();
                    using (SqlCommand command = new SqlCommand("SELECT * FROM users WHERE id = @UserId AND dbo.HashPassword(@password) = password_hash", con))
                    {
                        command.Parameters.AddWithValue("@UserId", UserId);
                        command.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {

                                correct_pass = true;
                               
                                
                            }
                            else
                            {
                                con.Close();
                                Response.Write("<script>alert('OLD PASSWORD INCORRECT');</script>");
                                
                                Response.Redirect("/views/logging/edit.aspx");

                            }
                        }

                    }

                    if (correct_pass)
                    {
                        
                        SqlCommand command = new SqlCommand(
                                   "UPDATE users " +
                                   "SET " +
                                   "password_hash = dbo.HashPassword(@newpassword) " +
                                   "WHERE " +
                                   "@UserId = id", con);
                        command.Parameters.AddWithValue("@newpassword", newpassword);
                        command.Parameters.AddWithValue("@UserId", UserId);


                        command.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('ACCOUNT DETAILS UPDATED');</script>");
                        Response.Redirect("/views/logging/edit.aspx", false);
                    }


                }
                

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script)");

            }




        }
        protected void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtSurname_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtEmailAddress_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCountryCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlEmployment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

    }
}