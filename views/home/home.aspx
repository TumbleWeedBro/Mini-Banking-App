<%@ Page Title="" Language="C#" MasterPageFile="~/views/layout.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Mini_Banking_App.views.home.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style> #LandingView
 {
     height:85vh;
     width:100%;
     background-image:linear-gradient( rgba(0, 0, 0, 0.7), rgba(0, 0, 0, 0.7) ), url('../../images/pexels-karolina-grabowska-4968384.jpg');
     background-position:center top;
 }
     body {
        margin: 0;
        padding: 0;
        font-family: Arial, sans-serif;
        background-color: #f0f0f0;
    }

    .welcome-container {

        text-align: center;
       padding-top:200px;
    }

    h1 {
        font-size: 36px;
        color: #f0f0f0;
    }

    p {
        font-size: 18px;
        color: #666;
        margin-bottom:8vh;
    }

    .btn {
        display: inline-block;
        padding: 10px 20px;
        margin-top: 20px;
        text-decoration: none;
        color: #fff;
        background-color: #007bff;
        border-radius: 5px;
        transition: background-color 0.3s;
    }

    .btn:hover {
        background-color: #0056b3;
    }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


 <div id="LandingView" class="container-fluid" >

                <div class="welcome-container">
                    <h1>Welcome to Mini Bank</h1>
                    <p>We are glad to have you here!</p>
                    <form runat="server">
                        <asp:Button runat="server" class="btn btn-primary btn-lg" style="padding-left: 2.5rem; padding-right: 2.5rem;" Text="Start Banking" OnClick="btnStartBanking_Click"/>
                       
                    </form>
                    
                </div>

 </div>
    
    
</asp:Content>
