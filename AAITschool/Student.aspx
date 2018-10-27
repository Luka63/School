<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="AAITschool.Student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <script src="Scripts/jquery-1.10.2.js"></script>
    <script src="Scripts/jquery-1.10.2.min.js"></script>

    <div class="push-right">
        <asp:Button ID="btnAdd" runat="server" Text="Add Student" OnClick="btnAdd_Click" />
    </div>

    <div>
        <asp:DropDownList ID="ddlClass" runat="server" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"></asp:DropDownList>
        <asp:DropDownList ID="ddlTeacher" runat="server" Visible="False"></asp:DropDownList>
    </div>
   



    <asp:GridView ID="gvView" runat="server" AutoGenerateColumns="false" DataKeyNames="StudentID"
        class="pull-right"
        PageSize="3"
        AllowPaging="true"
        AllowSorting="false"
        PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt"
        Visible="false"
        Width="100%"
        
        OnPageIndexChanging="gvView_PageIndexChanging" OnSelectedIndexChanged="gvView_SelectedIndexChanged" OnPageIndexChanged="gvView_PageIndexChanged">

        <Columns>
            <asp:BoundField DataField="FullName"
                HeaderText="Student"
                ItemStyle-HorizontalAlign="Left"
                ItemStyle-BorderColor="Black"
                ReadOnly="true">
                <HeaderStyle CssClass="gridHeader" />
                <ItemStyle Width="100px" Wrap="False" />
            </asp:BoundField>

            <asp:BoundField DataField="ClassName"
                HeaderText="Class & Teacher"
                ItemStyle-HorizontalAlign="Left"
                ItemStyle-BorderColor="Black"
                ReadOnly="true">
                <HeaderStyle CssClass="gridHeader" />
                <ItemStyle Width="200px" Wrap="False" />
            </asp:BoundField>

            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton3" CommandName="Details" OnClick="Details_Click" runat="server" Text="Details" />
                    <asp:LinkButton ID="LinkButton2" CommandName="Edit" OnClick="Edit_Click" runat="server" Text="Edit" />
                    <asp:LinkButton ID="LinkButton1" CommandName="Delete" OnClick="Delete_Click" runat="server" Text="Delete" OnClientClick="Confirm()" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>


    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";

            if (confirm("are u sure?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</asp:Content>
