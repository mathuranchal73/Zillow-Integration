using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Xml;
using System.Net.Mail;

public partial class Step1 : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        step.Text = "Step 1";
    }

    protected void email_TextChanged(object sender, EventArgs e)
    {
        if (emailid.Text == "")
        {
            Label4.Text = "**Mandatory Field";
        }
        String str = emailid.Text;

        if (IsValidEmail(str) == false)
        {
            Label4.Text = "Incorrect EmailId";

        }
        
    }

    private static bool IsValidEmail(string email)
    {

        var r = new Regex(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");

        return !string.IsNullOrEmpty(email) && r.IsMatch(email);

    }
    protected void submit(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Session["firstname"] = firstname.Text;
            Session["lastname"] = lastname.Text;
            Session["emailid"] = emailid.Text;
            Response.Redirect("Step 2.aspx");
        }
    }


}