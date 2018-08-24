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

public partial class Step_3 : System.Web.UI.Page
{
    DataTable table = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

        recordcount.Text = "Number Of Records:" + "" + Session["recordcount"];
        filename.Text = "Filename:" + "" + Session["filename"];
    }

    public string DoWebRequest(string address)
    {
        var request = (HttpWebRequest)WebRequest.Create("http://www.zillow.com/webservice/GetDeepSearchResults.htm?zws-id=X1-ZWz1b941p9efwr_9bpwi&address=" + address);
        request.Method = "Post";
        request.PreAuthenticate = true;

        var requestBody = Encoding.UTF8.GetBytes("");
        request.ContentLength = requestBody.Length;
        request.ContentType = "application/json";
        using (var requestStream = request.GetRequestStream())
        {
            requestStream.Write(requestBody, 0, requestBody.Length);
        }
        request.Timeout = 15000;
        string output = string.Empty;
        try
        {
            using (var response = request.GetResponse())
            {
                using (var stream = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(1252)))
                {
                    output = stream.ReadToEnd();
                }
            }
        }
        catch (WebException ex)
        {
            if (ex.Status == WebExceptionStatus.ProtocolError)
            {
                using (var stream = new StreamReader(ex.Response.GetResponseStream()))
                {

                    output = stream.ReadToEnd();
                }
            }
            else if (ex.Status == WebExceptionStatus.Timeout)
            {
                output = "Request timeout is expired.";
            }
        }

        //label1.Text = output;
        return output;
    }
    

    private object ReadToEnd()
    {
        
        String filePath = "C:/Users/Anchal/Documents/Visual Studio 2012/WebSites/Zillow Integration/Upload/" + Session["filename"];
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
            String a = string.Empty;
            String b = string.Empty;
            table.Merge(dtDataSource);
            table.Columns.AddRange(new[] { new DataColumn("Response") });
            table.Columns.AddRange(new[] { new DataColumn("ZpId") });
            table.Columns.AddRange(new[] { new DataColumn("homedetails") });
            table.Columns.AddRange(new[] { new DataColumn("graphsanddata") });
            table.Columns.AddRange(new[] { new DataColumn("mapthishome") });
            table.Columns.AddRange(new[] { new DataColumn("comparables") });
            table.Columns.AddRange(new[] { new DataColumn("street") });
            table.Columns.AddRange(new[] { new DataColumn("zipcode") });
            table.Columns.AddRange(new[] { new DataColumn("city") });
            table.Columns.AddRange(new[] { new DataColumn("state") });
            table.Columns.AddRange(new[] { new DataColumn("latitude") });
            table.Columns.AddRange(new[] { new DataColumn("longitude") });
            table.Columns.AddRange(new[] { new DataColumn("FIPScounty") });
            table.Columns.AddRange(new[] { new DataColumn("useCode") });
            table.Columns.AddRange(new[] { new DataColumn("taxAssessmentYear") });
            table.Columns.AddRange(new[] { new DataColumn("taxAssessment") });
            table.Columns.AddRange(new[] { new DataColumn("yearBuilt") });
            table.Columns.AddRange(new[] { new DataColumn("lotSizeSqFt") });
            table.Columns.AddRange(new[] { new DataColumn("finishedSqFt") });
            table.Columns.AddRange(new[] { new DataColumn("bathrooms") });
            table.Columns.AddRange(new[] { new DataColumn("bedrooms") });
            table.Columns.AddRange(new[] { new DataColumn("lastSoldDate") });
            table.Columns.AddRange(new[] { new DataColumn("lastSoldPrice") });
            table.Columns.AddRange(new[] { new DataColumn("amount") });
            table.Columns.AddRange(new[] { new DataColumn("last-updated") });
            table.Columns.AddRange(new[] { new DataColumn("valueChange") });
            table.Columns.AddRange(new[] { new DataColumn("low") });
            table.Columns.AddRange(new[] { new DataColumn("high") });
            table.Columns.AddRange(new[] { new DataColumn("percentile") });
            table.Columns.AddRange(new[] { new DataColumn("overview") });
            table.Columns.AddRange(new[] { new DataColumn("forSaleByOwner") });
            table.Columns.AddRange(new[] { new DataColumn("forSale") });


            for (int j = 1; j < fileContent.Count(); j++)
            {
                string[] newrowData = fileContent[j].Split(',');
                int k = 0;

                b = newrowData[k] + "&citystatezip=" + newrowData[k + 1] + " " + newrowData[k + 2];

                a = DoWebRequest(b);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(a);
                XmlNodeList zpIdList = xmlDoc.GetElementsByTagName("zpid");
                for (int i = 0; i < zpIdList.Count; i++)
                {
                    table.Rows[j - 1]["ZpId"] = zpIdList[i].InnerXml;
                }
                XmlNodeList homedetailsList = xmlDoc.GetElementsByTagName("homedetails");
                for (int i = 0; i < homedetailsList.Count; i++)
                {
                    table.Rows[j - 1]["homedetails"] = homedetailsList[i].InnerXml;
                }
                XmlNodeList graphsanddataList = xmlDoc.GetElementsByTagName("graphsanddata");
                for (int i = 0; i < graphsanddataList.Count; i++)
                {
                    table.Rows[j - 1]["graphsanddata"] = graphsanddataList[i].InnerXml;
                }
                XmlNodeList mapthishomeList = xmlDoc.GetElementsByTagName("mapthishome");
                for (int i = 0; i < mapthishomeList.Count; i++)
                {
                    table.Rows[j - 1]["mapthishome"] = mapthishomeList[i].InnerXml;
                }
                XmlNodeList comparablesList = xmlDoc.GetElementsByTagName("comparables");
                for (int i = 0; i < comparablesList.Count; i++)
                {
                    table.Rows[j - 1]["comparables"] = comparablesList[i].InnerXml;
                }
                XmlNodeList streetList = xmlDoc.GetElementsByTagName("street");
                for (int i = 0; i < streetList.Count; i++)
                {
                    table.Rows[j - 1]["street"] = streetList[i].InnerXml;
                }
                XmlNodeList zipcodeList = xmlDoc.GetElementsByTagName("zipcode");
                for (int i = 0; i < zipcodeList.Count; i++)
                {
                    table.Rows[j - 1]["zipcode"] = zipcodeList[i].InnerXml;
                }
                XmlNodeList cityList = xmlDoc.GetElementsByTagName("city");
                for (int i = 0; i < cityList.Count; i++)
                {
                    table.Rows[j - 1]["city"] = cityList[i].InnerXml;
                }
                XmlNodeList stateList = xmlDoc.GetElementsByTagName("state");
                for (int i = 0; i < stateList.Count; i++)
                {
                    table.Rows[j - 1]["state"] = stateList[i].InnerXml;
                }
                XmlNodeList latitudeList = xmlDoc.GetElementsByTagName("latitude");
                for (int i = 0; i < latitudeList.Count; i++)
                {
                    table.Rows[j - 1]["latitude"] = latitudeList[i].InnerXml;
                }
                XmlNodeList longitudeList = xmlDoc.GetElementsByTagName("longitude");
                for (int i = 0; i < longitudeList.Count; i++)
                {
                    table.Rows[j - 1]["longitude"] = longitudeList[i].InnerXml;
                }
                XmlNodeList FIPScountyList = xmlDoc.GetElementsByTagName("FIPScounty");
                for (int i = 0; i < FIPScountyList.Count; i++)
                {
                    table.Rows[j - 1]["FIPScounty"] = FIPScountyList[i].InnerXml;
                }
                XmlNodeList useCodeList = xmlDoc.GetElementsByTagName("useCode");
                for (int i = 0; i < useCodeList.Count; i++)
                {
                    table.Rows[j - 1]["useCode"] = useCodeList[i].InnerXml;
                }
                XmlNodeList taxAssessmentYearList = xmlDoc.GetElementsByTagName("taxAssessmentYear");
                for (int i = 0; i < taxAssessmentYearList.Count; i++)
                {
                    table.Rows[j - 1]["taxAssessmentYear"] = taxAssessmentYearList[i].InnerXml;
                }
                XmlNodeList taxAssessmentList = xmlDoc.GetElementsByTagName("taxAssessment");
                for (int i = 0; i < taxAssessmentList.Count; i++)
                {
                    table.Rows[j - 1]["taxAssessment"] = taxAssessmentList[i].InnerXml;
                }
                XmlNodeList yearBuiltList = xmlDoc.GetElementsByTagName("yearBuilt");
                for (int i = 0; i < yearBuiltList.Count; i++)
                {
                    table.Rows[j - 1]["yearBuilt"] = yearBuiltList[i].InnerXml;
                }
                XmlNodeList lotSizeSqFtList = xmlDoc.GetElementsByTagName("lotSizeSqFt");
                for (int i = 0; i < lotSizeSqFtList.Count; i++)
                {
                    table.Rows[j - 1]["lotSizeSqFt"] = lotSizeSqFtList[i].InnerXml;
                }
                XmlNodeList finishedSqFtList = xmlDoc.GetElementsByTagName("finishedSqFt");
                for (int i = 0; i < finishedSqFtList.Count; i++)
                {
                    table.Rows[j - 1]["finishedSqFt"] = finishedSqFtList[i].InnerXml;
                }
                XmlNodeList bathroomsList = xmlDoc.GetElementsByTagName("bathrooms");
                for (int i = 0; i < bathroomsList.Count; i++)
                {
                    table.Rows[j - 1]["bathrooms"] = bathroomsList[i].InnerXml;
                }
                XmlNodeList bedroomsList = xmlDoc.GetElementsByTagName("bedrooms");
                for (int i = 0; i < bedroomsList.Count; i++)
                {
                    table.Rows[j - 1]["bedrooms"] = bedroomsList[i].InnerXml;
                }
                XmlNodeList lastSoldDateList = xmlDoc.GetElementsByTagName("lastSoldDate");
                for (int i = 0; i < lastSoldDateList.Count; i++)
                {
                    table.Rows[j - 1]["lastSoldDate"] = lastSoldDateList[i].InnerXml;
                }
                XmlNodeList lastSoldPriceList = xmlDoc.GetElementsByTagName("lastSoldPrice");
                for (int i = 0; i < lastSoldPriceList.Count; i++)
                {
                    table.Rows[j - 1]["lastSoldPrice"] = lastSoldPriceList[i].InnerXml;
                }
                XmlNodeList amountList = xmlDoc.GetElementsByTagName("amount");
                for (int i = 0; i < amountList.Count; i++)
                {
                    table.Rows[j - 1]["amount"] = amountList[i].InnerXml;
                }
                XmlNodeList lastupdatedList = xmlDoc.GetElementsByTagName("last-updated");
                for (int i = 0; i < lastupdatedList.Count; i++)
                {
                    table.Rows[j - 1]["last-updated"] = lastupdatedList[i].InnerXml;
                }
                XmlNodeList valueChangeList = xmlDoc.GetElementsByTagName("valueChange");
                for (int i = 0; i < valueChangeList.Count; i++)
                {
                    table.Rows[j - 1]["valueChange"] = valueChangeList[i].InnerXml;
                }
                XmlNodeList lowList = xmlDoc.GetElementsByTagName("low");
                for (int i = 0; i < lowList.Count; i++)
                {
                    table.Rows[j - 1]["low"] = lowList[i].InnerXml;
                }
                XmlNodeList highList = xmlDoc.GetElementsByTagName("high");
                for (int i = 0; i < highList.Count; i++)
                {
                    table.Rows[j - 1]["high"] = highList[i].InnerXml;
                }
                XmlNodeList percentileList = xmlDoc.GetElementsByTagName("percentile");
                for (int i = 0; i < percentileList.Count; i++)
                {
                    table.Rows[j - 1]["percentile"] = percentileList[i].InnerXml;
                }
                XmlNodeList overviewList = xmlDoc.GetElementsByTagName("overview");
                for (int i = 0; i < overviewList.Count; i++)
                {
                    table.Rows[j - 1]["overview"] = overviewList[i].InnerXml;
                }
                XmlNodeList forSaleByOwnerList = xmlDoc.GetElementsByTagName("forSaleByOwner");
                for (int i = 0; i < forSaleByOwnerList.Count; i++)
                {
                    table.Rows[j - 1]["forSaleByOwner"] = forSaleByOwnerList[i].InnerXml;
                }
                XmlNodeList forSaleList = xmlDoc.GetElementsByTagName("forSale");
                for (int i = 0; i < forSaleList.Count; i++)
                {
                    table.Rows[j - 1]["forSale"] = forSaleList[i].InnerXml;
                }



                //label1.Text = a;

                if (a != "" && a != null)
                {
                    table.Rows[j - 1]["Response"] = a;
                    //Read the XML and pull the fields
                }
                else
                {
                    table.Rows[j - 1]["Response"] = "Error";
                }
            }

            // This actually makes your HTML output to be downloaded as .xls file
            Response.Clear();
            Response.ClearContent();
            
            

            // Create a dynamic control, populate and render it
            GridView excel = new GridView();
            excel.DataSource = table;
            excel.DataBind();
            /*excel.RenderControl(new HtmlTextWriter(Response.Output));
            excel.DataSource = table;*/
            
            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
            excel.RenderControl(htw);
            string dwnldfilePath = Server.MapPath("~/OutputCSV/");
            string fileName = "Output" + "ExcelFile" + ".xls";
            string renderedGridView = sw.ToString();
            System.IO.File.WriteAllText(dwnldfilePath + fileName, renderedGridView);
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            string msg = string.Empty;
            try
            {
                String emailid=Session["emailid"].ToString();
                String firstname = Session["firstname"].ToString();
                MailAddress fromAddress = new MailAddress("anchal.mathur@softappspro.com");
                message.From = fromAddress;
                message.To.Add(emailid);
                //if (ccList != null && ccList != string.Empty)
                message.CC.Add("anchal.mathur@softappspro.com");
                message.Subject = "Test Mail";
                message.IsBodyHtml = true;
                message.Body = "Hello" + "" + firstname + ",\n" + "\t We have processed your records of input";
                smtpClient.Host = "smtp.gmail.com";   // We use gmail as our smtp client
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential("anchal.mathur@softappspro.com", "p@sworD123#");
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(dwnldfilePath + fileName);
                message.Attachments.Add(attachment);
                smtpClient.Send(message);
                msg = "Successful<BR>";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            Response.Redirect("Thanks.aspx");
            Response.Flush();
            Response.End();



        }

        return dtDataSource;


    }


    


    protected void Button2_Click(object sender, EventArgs e)
    {
        String file = Session["filename"].ToString();
        GridView1.DataSource = (DataTable)ReadToEnd();
        GridView1.DataBind();
        
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("Step 2.aspx");
    }
}