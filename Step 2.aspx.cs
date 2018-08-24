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
using System;
using System.Collections.Generic;
using System.Data;



public partial class Step_2 : System.Web.UI.Page
{
    DataTable table = new DataTable();
    
   
    protected void Page_Load(object sender, EventArgs e)
    {
        Label4.Text = "Welcome" + "" + Session["firstname"] + " " + Session["lastname"];
        firstname.Text = Session["firstname"].ToString();
        step.Text = "Step 2  ";
        emailid.Text = Session["emailid"].ToString();
    }

    protected void download(object sender, EventArgs e)
    {
        Response.Redirect("sample.csv");
    }

    public void btn_ImportCSV_Click(object sender, EventArgs e)
    {
        

        string filePath = Path.GetFileName(fu_ImportCSV.PostedFile.FileName);


        if (fu_ImportCSV.HasFile == false)
        {
            lbl_ErrorMsg.Text = "Please select a file";
            lbl_ErrorMsg.Visible = true;
        }
        else if (fu_ImportCSV.HasFile && fu_ImportCSV.PostedFile.ContentType.Equals("application/vnd.ms-excel"))
        {
            fu_ImportCSV.SaveAs(Server.MapPath("Upload/" + fu_ImportCSV.PostedFile.FileName));
            gv_GridView.DataSource = (DataTable)ReadToEnd(fu_ImportCSV.PostedFile.FileName);
            gv_GridView.DataBind();
            if ((gv_GridView.HeaderRow.Cells[0].Text == "Property Address") && (gv_GridView.HeaderRow.Cells[1].Text == "Property State") && (gv_GridView.HeaderRow.Cells[2].Text == "Property City") && (gv_GridView.HeaderRow.Cells[3].Text == "Property Zipcode"))
            {
                Session["recordcount"] = gv_GridView.Rows.Count.ToString();
                Session["filename"] = fu_ImportCSV.PostedFile.FileName;
                Session["emailid"] = emailid.Text;
                Session["firstname"] = firstname.Text;
                lbl_ErrorMsg.Visible = false;
                Response.Redirect("Step 3.aspx");
            }
            else
            {
                lbl_ErrorMsg.Visible = true;
                lbl_ErrorMsg.Text = "Your CSV does not match our criteria. Please check the Column Header Values";
            }
        }
        else
        {
            lbl_ErrorMsg.Text = "Please check the selected file type";
            lbl_ErrorMsg.Visible = true;
        }

    }
    
    private object ReadToEnd(string filePath)
    {
        filePath = "C:/Users/Anchal/Documents/Visual Studio 2012/WebSites/Zillow Integration/Upload/" + fu_ImportCSV.PostedFile.FileName;
        DataTable dtDataSource = new DataTable();
        string[] fileContent = File.ReadAllLines(filePath);


        if (fileContent.Count() > 0)
        {
            //Create data table columns
            string[] columns = fileContent[0].Split(',');
            for (int i = 0; i < columns.Count(); i++)
            {
                dtDataSource.Columns.Add(columns[i]);
            }

            //Add row data
            Decimal abc = fileContent.Count();
            for (int i = 1; i < fileContent.Count(); i++)
            {
                string[] rowData = fileContent[i].Split(',');
                dtDataSource.Rows.Add(rowData);
            } 

        }

        return dtDataSource;


    }

   
}