<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ComplaintMessages.aspx.cs" Inherits="RegisterComplaint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" lang="en" xml:lang="en">
<head>
	<meta http-equiv="content-type" content="text/html; charset=utf-8" />
	<meta name="description" content="Your description goes here" />
	<meta name="keywords" content="your,keywords,goes,here" />
	<meta name="author" content="Your Name" />
	<link rel="stylesheet" type="text/css" href="style.css" media="screen,projection" />
	<title>Complaint registered - Saatphere</title>
    <style type="text/css">

        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 78px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
<div id="container" >
	<div id="header">
		<h1>Saatphere Customer Support</h1>
		<h2>Version 1.0</h2>
	</div>
	<div id="navigation">
		<ul>
			<li class="selected"><a href="Default.aspx">Complaint has registered!!</a></li>
			<%--<li><a href="#">About us</a></li>--%>
			<!--<li><a href="#">Third</a></li>
			<li><a href="#">Fourth</a></li>
			<li><a href="#">Fifth</a></li>
			<li><a href="#">And the last one</a></li>-->
		</ul>
	</div><div class="inner_copy"><div class="inner_copy">All <a href="http://www.magentothemesworld.com" title="Best Magento Templates">premium Magento themes</a> at magentothemesworld.com!</div></div>
	<div id="content">
		<h2>Enter complaint details below:</h2>
<table cellpadding="0" cellspacing="0" class="style1">
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    
        </td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            You can track the status of the complaint with the Ticket id given above.</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    </table>
		<p>&nbsp;</p>
	</div>
	<div id="subcontent">
		<div class="small box">
			<strong>Note: </strong>We take minimum of 48 hours in the complaint resolution. 
            Please bear with us or contact us directly to get any update.
		</div>
	</div>
	<div id="footer">
		<div class="fcenter">
			<div class="fleft"><p>&nbsp;</p></div>
			<div class="fright"><p>Powered by: <a href="http://www.krayknot.com" target="_blank">krayknot</a></p></div>
			<div class="fcenter"></div>
		</div>
	</div>

</div>
    </form>
</body>
</html>
