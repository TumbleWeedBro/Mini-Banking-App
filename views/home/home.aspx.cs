﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mini_Banking_App.views.home
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnStartBanking_Click(object sender, EventArgs e)
        {
       
            if (Session["UserId"] == null)
            {
             
                Response.Redirect("/views/logging/login.aspx");
            }
            else
            {

                Response.Redirect("/views/home/bank.aspx");
            }
        }
    }
}