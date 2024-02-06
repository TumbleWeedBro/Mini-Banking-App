<%@ Page Title="" Language="C#" MasterPageFile="~/views/layout.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="Mini_Banking_App.views.admin.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    

<link href="https://cdn.datatables.net/1.10.25/css/jquery.dataTables.min.css" rel="stylesheet" />
<script src="https://cdn.datatables.net/1.10.25/js/jquery.dataTables.min.js"></script>
​


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid pt-2 ">
        <form runat="server">
             <h2>Accounts</h2>

              <asp:GridView class="table table-striped table-bordered table-light" ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="Id" />
                    <asp:BoundField DataField="account_number" HeaderText="Account Number" />
                    <asp:BoundField DataField="first_name" HeaderText="First Name" />
                    <asp:BoundField DataField="surname" HeaderText="Surname" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:BoundField DataField="employment" HeaderText="Employment" />
                    <asp:BoundField DataField="account_status" HeaderText="Account Status" />
                     <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button runat="server" class="btn btn-success btn-md" style="padding-left: 0.5rem; padding-right: 0.5rem;" Text="Activate" OnClick="btnActivate_Click"/>
                            <asp:Button runat="server" class="btn btn-warning btn-md" style="padding-left: 0.5rem; padding-right: 0.5rem;" Text="Suspend" OnClick="btnSuspend_Click"/>
                            <asp:Button runat="server" class="btn btn-danger btn-md" style="padding-left: 0.5rem; padding-right: 0.5rem;" Text="Delete" OnClick="btnDelete_Click"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
 
        </form>
       
    </div>
    

    
</asp:Content>
