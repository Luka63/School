<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="AAITschool.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="hdClassID" runat="server"></asp:HiddenField>
        <div>
            <asp:Panel ID="pnlRegistration" runat="server">
               Name: <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
               Last Name: <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                <br />
               Driver's License #: <asp:TextBox ID="txtDDL" runat="server"></asp:TextBox>
                <br />                
               Gender: <asp:DropDownList ID="ddlGender" runat="server" ></asp:DropDownList> 
                <br />
               Race: <asp:DropDownList ID="ddlRace" runat="server"></asp:DropDownList>
                <br />
                 address: <asp:TextBox ID="txtAddress" runat="server" Width="235px"></asp:TextBox><br />
                 City: <asp:TextBox ID="txtCity" runat="server" Width="159px"></asp:TextBox> &nbsp
                 State:<asp:DropDownList ID="ddlState" runat="server"></asp:DropDownList>&nbsp
                Zip:<asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                <br />

             School Diploma: 
                Yes<asp:RadioButton runat="server" ID="rdbYes" GroupName="Diploma"  OnCheckedChanged="rdbYes_CheckedChanged" AutoPostBack="True"></asp:RadioButton>&nbsp
                No<asp:RadioButton ID="rdbNo" runat="server" GroupName="Diploma" AutoPostBack="true" OnCheckedChanged="rdbNo_CheckedChanged" />
              
                <br />
                <asp:Panel ID="pnlDiploma" runat="server" Visible="false">
             Diploma: <asp:TextBox ID="txtDiploma" runat="server"></asp:TextBox>
             Diploma Type: <asp:DropDownList ID="ddlDiplomaType" runat="server"></asp:DropDownList>
                </asp:Panel>
                <asp:Button ID="btnSave" runat="server" Text="Register" OnClick="btnSave_Click" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
