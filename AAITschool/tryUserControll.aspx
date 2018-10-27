<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tryUserControll.aspx.cs" Inherits="AAITschool.tryUserControll" %>
<%@ Register Src="~/UserControll/UserControl1.ascx" TagName="uc1" TagPrefix="ucPref" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ucPref:uc1 id="thisId" text="wooooow" runat="server"/>
        </div>
    </form>
</body>
</html>
