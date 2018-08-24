<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Step1.aspx.cs" Inherits="Step1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">

/* Add whatever you need to your CSS reset */
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
	  background: #ddd  no-repeat 4px 5px;
	  background:  no-repeat 4px 5px, -moz-linear-gradient(
           center bottom,
           rgb(225,225,225) 0%,
           rgb(215,215,215) 54%,
           rgb(173,173,173) 100%
           );
	  background:   no-repeat 4px 5px, -webkit-gradient(
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
	
 input#company { 
 	background-position: 4px -20px; 
	background-position: 4px -20px, 0px 0px;
	}
	
 input#firstname { 
 	background-position: 4px -46px; 
	background-position: 4px -46px, 0px 0px; 
	}
 input#lastname { 
 	background-position: 4px -46px; 
	background-position: 4px -46px, 0px 0px; 
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

</style>
    
    
 <div id="registration">   
<form id="RegisterUserForm" runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>  
    
    <asp:Panel ID="Panel1" runat="server">
        <asp:Label ID="step" runat="server" CssClass="right" Font-Bold="True" Font-Size="Medium" ForeColor="White"></asp:Label>
        
                         <fieldset>
                     <p>
                                <center> <strong><span class="auto-style1"><em class="auto-style2">Firstname </em></span></strong>
                                 <asp:TextBox ID="firstname" runat="server" CssClass="text"></asp:TextBox>
                                </center>
                                <p>
                                </p>
                                <p>
                                    <center>
                                        <strong><span class="auto-style1"><em class="auto-style2">Lastname </em></span></strong>
                                        <asp:TextBox ID="lastname" runat="server" CssClass="text"></asp:TextBox>
                                    </center>
                                    <p>
                                    </p>
                                    <p>
                                        <center>
                                            <strong><span class="auto-style1"><em class="auto-style2">Company </em></span></strong>:<asp:TextBox ID="company" runat="server" CssClass="text"></asp:TextBox>
                                        </center>
                                        <p>
                                        </p>
                                        <p>
                                            <center>
                                                <strong><span class="auto-style1"><em class="auto-style2">Email ID </em></span></strong>:<asp:TextBox ID="emailid" runat="server" AutoPostBack="True" CausesValidation="True" CssClass="text" OnTextChanged="email_TextChanged" ViewStateMode="Enabled"></asp:TextBox>
                                            </center>
                                            <center>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="emailid" ErrorMessage="**Email Mandatory" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <br/>
                                                <asp:Label ID="Label4" runat="server" ForeColor="#FF3300"></asp:Label>
                                            </center>
                                        </p>
                                    </p>
                                </p>
                                </p>
                                
                                            </fieldset></asp:Panel>
    <center>
        <asp:Button ID="Button1" runat="server" Text="Proceed" OnClick="submit"></asp:Button>
    <br/>       </center>
        </form>
     </div>
</asp:Content>

