<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ToDoList._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script src="Scripts/DefaultContent.js"></script>
    <br />
        <h1>To Do List</h1>
    <br />
    <div>
        <asp:TextBox ID="txtNewTask" runat="server" BackColor="White" placeholder="New Task...">
        </asp:TextBox>
        <asp:Button ID="btnAddTask" runat="server" Text="Add Task" OnClick="btnAddTask_Click"/>
    </div>
    <div>
        <asp:GridView ID="gvTODOList" runat="server" AutoGenerateColumns="false" OnRowDeleting="gvTODOList_RowDeleting"
            EmptyDataText="No records have been added." BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CellSpacing="2"
            ShowHeader="false">
            <Columns>              
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkTaskComplete" runat="server" AutoPostBack="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TaskDescription" />
                <asp:ButtonField ButtonType="Button" Text="Remove" CommandName="Delete" />
            </Columns>          
        </asp:GridView>
        <br />
    </div>    
</asp:Content>

