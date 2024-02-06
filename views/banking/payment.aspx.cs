using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mini_Banking_App.views.banking
{
    public partial class payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnPay_Click(object sender, EventArgs e)
        {
           
            string accountNumber = "";

            string savingsBalance = "";
            double Balance;
            double amountpayed;

            string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            try
            {

                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                int UserId = (int)Session["UserId"];
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM account " +
                    "WHERE " +
                    "users_id = @UserId;", con);
                cmd.Parameters.AddWithValue("@UserId", UserId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        accountNumber = reader["account_number"].ToString();
                        savingsBalance = reader["savings_balance"].ToString();
                    }

                    amountpayed = double.Parse(txtAmountPayed.Text.Trim());
                    Balance = double.Parse(savingsBalance);



                }
                if (Balance > (double)amountpayed)
                {

                    if (findAccount(txtAccountNumber.Text.Trim(), con))
                    {
                        SqlCommand command = new SqlCommand(
                        "INSERT INTO payments (senders_account_number ,receivers_account_number,amount  )" +
                        "VALUES (@senders_account_number, @receivers_account_number, @amount);" +
                        "UPDATE account " +
                        "SET " +
                        "savings_balance = @amount_left " +
                        "WHERE " +
                        "users_id = @UserId; " +
                        "UPDATE account " +
                        "SET " +
                        "savings_balance = @amount " +
                        "WHERE " +
                        "account_number = @receivers_account_number", con);
                        double amount_left = Balance - amountpayed;
                        command.Parameters.AddWithValue("@senders_account_number", accountNumber);
                        command.Parameters.AddWithValue("@UserId", UserId);
                        command.Parameters.AddWithValue("@receivers_account_number", txtAccountNumber.Text.Trim());
                        command.Parameters.AddWithValue("@amount", amountpayed);
                        command.Parameters.AddWithValue("@amount_left", amount_left);

                        command.ExecuteNonQuery();
                        Response.Write("<script>alert('Payment Successful ');</script>");

                        txtAccountNumber.Text = "";
                        txtCardholders.Text = "";
                        txtAmountPayed.Text = "";
                    }
                    else
                    {
                        Response.Write("<script>alert('Account does not exist');</script>");
                        txtAccountNumber.Text = "";
                        txtCardholders.Text = "";
                        txtAmountPayed.Text = "";
                    }

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    Response.Write("<script>alert('Insufficient Balance');</script>");
                    txtAccountNumber.Text = "";
                    txtCardholders.Text = "";
                    txtAmountPayed.Text = "";
                }


            }




            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script)");
            }
            
           
        }
        bool findAccount(string receivers_account_number, SqlConnection con)
        {
            SqlCommand findcommand = new SqlCommand(
                "SELECT * from account " +
                "WHERE " +
                "account_number = @receivers_account_number"
                , con);

            findcommand.Parameters.AddWithValue("@receivers_account_number", receivers_account_number);
            using (SqlDataReader reader = findcommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        
        protected void txtAccountNumber_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtCardholders_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtAmountPayed_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

    }
}