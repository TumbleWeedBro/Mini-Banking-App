<%@ Page Title="" Language="C#" MasterPageFile="~/views/layout.Master" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="Mini_Banking_App.views.logging.edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
      <form id="form1" runat="server" method="post" class="container-fluid">
        <div class="card bg-light">
            <div class="card-body mx-auto" style="max-width: 400px; ">
                <h4 class="card-title mt-3 text-center align-items-center">Update Account</h4>
      
                <div class="form" runat="server">
                    <div class="form-group input-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text"> <i class="fa fa-user"></i> </span>
                        </div>
                        <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" placeholder="First Name" type="text" OnTextChanged="txtFirstName_TextChanged"></asp:TextBox>
                    </div>
                    <div class="form-group input-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text"> <i class="fa fa-envelope"></i> </span>
                        </div>
                        <asp:TextBox runat="server" ID="txtSurname" CssClass="form-control" placeholder="Surname" type="text"></asp:TextBox>
                    </div>
                    <div class="form-group input-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text"> <i class="fa fa-envelope"></i> </span>
                        </div>
                        <asp:TextBox runat="server" ID="txtEmailAddress" CssClass="form-control" placeholder="Email address" type="email"></asp:TextBox>
                    </div>
                    <div class="form-group input-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text"> <i class="fa fa-phone"></i> </span>
                        </div>
                        <asp:DropDownList runat="server" ID="ddlCountryCode" CssClass="custom-select" style="max-width: 100px;">
                            <asp:ListItem Text="+27" Value="+27" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="+263" Value="+263"></asp:ListItem>
                            <asp:ListItem Text="+234" Value="+234"></asp:ListItem>
                            <asp:ListItem Text="+260" Value="+260"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox runat="server" ID="txtPhoneNumber" CssClass="form-control" placeholder="Phone Number" type="text"></asp:TextBox>
                    </div>
                    <div class="form-group input-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text"> <i class="fa fa-building"></i> </span>
                        </div>
                        <asp:DropDownList runat="server" ID="ddlEmployment" CssClass="form-control" ClientIDMode="Static">
                            <asp:ListItem Text="Employment" Value="Employment" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Employed" Value="Employed"></asp:ListItem>
                            <asp:ListItem Text="Self employed" Value="Self employed"></asp:ListItem>
                            <asp:ListItem Text="Unemployed" Value="Unemployed"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group input-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text"> <i class="fa fa-lock"></i> </span>
                        </div>
                        <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" placeholder="Old Password" type="password"></asp:TextBox>
                    </div>
                    <div class="form-group input-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text"> <i class="fa fa-lock"></i> </span>
                        </div>
                        <asp:TextBox runat="server" ID="txtNewPassword" CssClass="form-control" placeholder="New Password" type="password"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button runat="server" ID="btnUpdateAccount" class="btn btn-primary btn-lg" style="padding-left: 2.5rem; padding-right: 2.5rem;" Text="Update Account" OnClick="btnUpdateAccount_Click" />
                    </div>
              
                </div>
            </div>
        </div>
    </form>
</asp:Content>
