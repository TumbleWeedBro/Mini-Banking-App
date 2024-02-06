using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mini_Banking_App.views
{
    public partial class layout1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] is null && !IsHomePage())
                {
                    Response.Redirect("/views/home/home.aspx");
                }
            }

            bool IsHomePage()
            {
                string currentPage = Request.Url.AbsolutePath;
                return currentPage.EndsWith("/views/home/home.aspx", StringComparison.OrdinalIgnoreCase)
                    || currentPage.EndsWith("/views/logging/login.aspx", StringComparison.OrdinalIgnoreCase)
                    || currentPage.EndsWith("/views/logging/register.aspx", StringComparison.OrdinalIgnoreCase)
                    || currentPage.EndsWith("/views/home/services.aspx", StringComparison.OrdinalIgnoreCase);
            }
 
        }
    }
}