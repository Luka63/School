<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="tryControl1.aspx.cs" Inherits="AAITschool.tryControl1" %>
<%@ Register Src="~/UserControll/UserControl1.ascx" TagName="uc1" TagPrefix="ucPref" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
                <ucPref:uc1 id="thisId" text="wooooow" runat="server"/>

</asp:Content>
