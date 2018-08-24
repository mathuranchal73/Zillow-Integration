<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Step 2.aspx.cs" Inherits="Step_2" %>
 <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
    html, body, h1, form, fieldset, input {
  margin: 0;
  padding: 0;
  border: none;
  }

body { font-family: Helvetica, Arial, sans-serif; font-size: 12px; }

        #registration {
			color: #fff;
            background: #2d2d2d;
            background: -webkit-gradient(
                            linear,
                            left bottom,
                            left top,
                            color-stop(0, rgb(60,60,60)),
                            color-stop(0.74, rgb(43,43,43)),
                            color-stop(1, rgb(60,60,60))
                        );
            background: -moz-linear-gradient(
                            center bottom,
                            rgb(60,60,60) 0%,
                            rgb(43,43,43) 74%,
                            rgb(60,60,60) 100%
                        );
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
			border-radius: 10px;
            
			width: 800px;
            margin-left:60px;
            margin-right:40px;
            
            }

 #registration a {
      color: #8c910b;
      text-shadow: 0px -1px 0px #000;
      }
	  
#registration fieldset {
      padding: 20px;
      }
	  
input.text {
      -webkit-border-radius: 15px;
      -moz-border-radius: 15px;
      border-radius: 15px;
      border:solid 1px #444;
      font-size: 14px;
      width: 40%;
      padding: 7px 30px 7px 30px;
      -moz-box-shadow: 0px 1px 0px #777;
      -webkit-box-shadow: 0px 1px 0px #777;
	  background: #ddd url('img/inputSprite.png') no-repeat 4px 5px;
	  background: url('img/inputSprite.png') no-repeat 4px 5px, -moz-linear-gradient(
           center bottom,
           rgb(225,225,225) 0%,
           rgb(215,215,215) 54%,
           rgb(173,173,173) 100%
           );
	  background:  url('img/inputSprite.png') no-repeat 4px 5px, -webkit-gradient(
          linear,
          left bottom,
          left top,
          color-stop(0, rgb(225,225,225)),
          color-stop(0.54, rgb(215,215,215)),
          color-stop(1, rgb(173,173,173))
          );
      color:#333;
      text-shadow:0px 1px 0px #FFF;
}	  

 input#email { 
 	background-position: 4px 5px; 
	background-position: 4px 5px, 0px 0px;
	}
	
 input#password { 
 	background-position: 4px -20px; 
	background-position: 4px -20px, 0px 0px;
	}
	
 input#name { 
 	background-position: 4px -46px; 
	background-position: 4px -46px, 0px 0px; 
	}
	
 input#tel { 
 	background-position: 4px -76px; 
	background-position: 4px -76px, 0px 0px; 
	}
        input#button {
            color:#8c910b;outline:none;display:inline-block;position:relative;border-radius:5px;-moz-border-radius:5px;-webkit-border-radius:5px;background-color:#3A3A00;background:-webkit-gradient(linear, 0 0, 0 70%, from(#ed2800), to(#b21e00));background:-moz-linear-gradient(#ed2800, #b21e00 70%);background:linear-gradient(#ed2800, #b21e00 70%);-pie-background:linear-gradient(#ed2800, #b21e00 70%);behavior:url(../js/PIE.htc);padding:0 18px 0 18px;line-height:35px;color:#3A3A00;font-weight:bold;text-decoration:none;-webkit-transition-duration:0.5s;
        }
	
#registration h2 {
	color: #fff;
	text-shadow: 0px -1px 0px #000;
	border-bottom: solid #181818 1px;
	-moz-box-shadow: 0px 1px 0px #3a3a3a;
	text-align: center;
	padding: 18px;
	margin: 0px;
	font-weight: normal;
	font-size: 24px;
	font-family: Lucida Grande, Helvetica, Arial, sans-serif;
	}
	
#registerNew {
	width: 203px;
	height: 40px;
	border: none;
	text-indent: -9999px;
	background: url('img/createAccountButton.png') no-repeat;
	cursor: pointer;
	float: right;
	}
	
	#registerNew:hover { background-position: 0px -41px; }
	#registerNew:active { background-position: 0px -82px; }
	
 #registration p {
      position: relative;
      }
 #registration a {
      position: relative;
      }
	  
fieldset label.infield /* .infield label added by JS */ {
    color: #333;
    text-shadow: 0px 1px 0px #fff;
    position: absolute;
    text-align: left;
    top: 3px !important;
    left: 35px !important;
    line-height: 29px;
    }
        .auto-style3 {}
    </style>
     <body>
 <div id="registration">   
<form id="RegisterUserForm" runat="server">
        
  <asp:Label ID="firstname" runat="server" ForeColor="White" Font-Bold="True" Font-Size="Large" Visible="False"></asp:Label><asp:Label ID="step" runat="server" CssClass="right" Font-Bold="True" Font-Size="Medium" ForeColor="White"></asp:Label>
    <asp:Label ID="Label4" runat="server"></asp:Label>
    <br/>
                    <asp:label runat="server" id="emailid" ForeColor="#FF3300"></asp:label><br/>                        
        </p>
    </fieldset>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
        
        <ContentTemplate>
            <div style="padding-left:60px;">
            <asp:FileUpload ID="fu_ImportCSV"  runat="server" /></div>
            <asp:label  ID="lbl_ErrorMsg" runat="server" Visible="false" ForeColor="#FF3300"></asp:label><br/>
      
    
        
         <a>         
        <center><asp:Button ID="button"  runat="server" Text="Upload CSV" CssClass="infield" onClick="btn_ImportCSV_Click" /></center><asp:LinkButton  ID="LinkButton1" runat="server" CssClass="right" OnClick="download">Download Sample CSV</asp:LinkButton>
</a>
    <br/>
    <div>
        <asp:gridview ID="gv_GridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="auto-style3" Width="264px">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
            </asp:gridview>
    </div>
    
    </form>
     </div>
</body>
   
 
</asp:Content>

 

