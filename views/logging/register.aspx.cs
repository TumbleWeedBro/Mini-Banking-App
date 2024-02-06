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
    public partial class register : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        int account_number_int;
        string account_number;
        bool HasRead;
        int userId;
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        //sign up button is clicked

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {

            try
            {
                //Response.Write("<script>alert('Testing');</script>");
                //creating a "con" object... strcon is a parameter
                SqlConnection con = new SqlConnection(strcon);
                //check if connection is open
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string email = txtEmailAddress.Text.Trim();
                // Check if email already exists in the database
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM users WHERE email = @email", con);
                checkCmd.Parameters.AddWithValue("@email", email);
                int emailCount = (int)checkCmd.ExecuteScalar();

                if (emailCount > 0)
                {
                    Response.Write("<script>alert('Email already exists')</script>)");
                    // Handle the case where the email already exists

                }
                else
                {
                    if(txtPassword.Text.Trim() == txtRepeatPassword.Text.Trim())
                    {
                        //fire the sql query (insert)
                        SqlCommand cmd = new SqlCommand(
                        "INSERT INTO users " +
                        "(first_name, surname, email, mobile_number, employment, password_hash, account_status) " +
                        "VALUES " +
                        "(@first_name, @surname, @email, @mobile_number, @employment, dbo.HashPassword(@password), @account_status); " +
                        "SELECT SCOPE_IDENTITY() As id;"
                        , con);

                        //getting stuff from the textboxes
                        cmd.Parameters.AddWithValue("@first_name", txtFirstName.Text.Trim());
                        cmd.Parameters.AddWithValue("@surname", txtSurname.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtEmailAddress.Text.Trim());

                        string mobileNumber = ddlCountryCode.SelectedValue + txtPhoneNumber.Text.Trim();
                        cmd.Parameters.AddWithValue("@mobile_number", mobileNumber);

                        cmd.Parameters.AddWithValue("@employment", ddlEmployment.SelectedValue);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                        cmd.Parameters.AddWithValue("@account_status", "pending");

                        userId = Convert.ToInt32(cmd.ExecuteScalar());

                        account_number_int = RandomAccountNumber();
                        account_number = account_number_int.ToString();

                        while (true)
                        {
                            account_number_int = RandomAccountNumber();
                            account_number = account_number_int.ToString();

                            using (cmd = new SqlCommand("SELECT 1 FROM account WHERE account_number = @account_number", con))
                            {
                                cmd.Parameters.AddWithValue("@account_number", account_number);

                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (!reader.Read())
                                    {
                                        HasRead = true;
                                        break;
                                    }
                                }
                            }
                        }

                        if (HasRead)
                        {
                            MakeAccount(cmd, con);
                        }

                        con.Close();
                        Response.Write("<script>alert('Sign up successful. Go to user login to login')</script>)");
                        Response.Redirect("/views/logging/login.aspx");

                    }
                    else
                    {
                        Response.Write("<script>alert('Passwords Don't Match')</script>)");
                    }

                }
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>)");
            }
        }
        
        int RandomAccountNumber()
        {
            Random rnd = new Random();
            int randomNum = rnd.Next(100000000, 999999999);
            return randomNum; 

        }

        int AccountPin()
        {

            Random rnd = new Random();
            int randomNum = rnd.Next(0000,9999);
            return randomNum;
        }

        void MakeAccount(SqlCommand cmd, SqlConnection con)
        {
            
            string account_password = AccountPin().ToString();

            cmd = new SqlCommand(
                "INSERT INTO account(account_number, users_id, account_password, savings_balance)" +
                "VALUES (@account_number, @userId, @account_password, 0)", con);

            cmd.Parameters.AddWithValue("@account_number", account_number);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@account_password", account_password);

            cmd.ExecuteNonQuery();
            
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

        protected void txtRepeatPassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            string repeatPassword = txtRepeatPassword.Text;

            if (string.IsNullOrWhiteSpace(repeatPassword))
            {
                Response.Write("<script>alert('Passwords Cannot be empty');</script>");
            }
            else if (password != repeatPassword)
            {
                Response.Write("<script>alert('Passwords dont match');</script>");
            }
            else
            {
                // Password and repeat password match
                // Continue with validation or other logic
            }
        }
    }
}