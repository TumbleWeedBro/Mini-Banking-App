<%@ Page Title="" Language="C#" MasterPageFile="~/views/layout.Master" AutoEventWireup="true" CodeBehind="bank.aspx.cs" Inherits="Mini_Banking_App.views.home.bank" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container pt-2">
        <form runat="server">
             <table class="table table-light">
              <thead>
                <tr>

                  <th scope="col"><a href="/views/banking/payment.aspx">Pay</a></th>
                  
                </tr>
              </thead>
              <tbody>
                <tr>
                  <th scope="row">Account Number</th>
                  <td> <asp:TextBox ReadOnly="true" runat="server" ID="txtAccountNumber" CssClass="form-control" type="text" OnTextChanged="txtAccountNumber_TextChanged"></asp:TextBox></td>

                </tr>
                <tr>

                  <th scope="row">Savings</th>
                  <td><asp:TextBox ReadOnly="true" runat="server" ID="txtSavingsBalance" CssClass="form-control" type="text" OnTextChanged="txtSavingsBalance_TextChanged"></asp:TextBox></td>

                </tr>

              </tbody>
        </table>

        </form>
       
    </div>
    
</asp:Content>
