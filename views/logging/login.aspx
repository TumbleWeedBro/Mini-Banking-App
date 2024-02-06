<%@ Page Title="" Language="C#" MasterPageFile="~/views/layout.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Mini_Banking_App.views.logging.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">





       
<section class="bg-light">
  <!-- Jumbotron -->
  <div class="px-4 py-5 px-md-5 text-center text-lg-start  ">
    <div class="container">
      <div class="row gx-lg-5 align-items-center">
        <div class="col-lg-6 mb-5 mb-lg-0">
          <h1 class="my-5 display-3 fw-bold ls-tight">
            The best offer <br />
            <span class="text-primary">for your business</span>
          </h1>
          <p style="color: hsl(217, 10%, 50.8%)">
            Welcome to Mini Bank Business Online Banking! Log in to efficiently manage your business finances.
            At Mini Bank, we prioritize the security of your financial data, ensuring confidentiality with our advanced encryption technology. 
            Need help? Contact 
            our dedicated customer support team for prompt assistance. Thank you for choosing Mini Bank for your business banking needs.
          </p>
        </div>

        <div class="col-lg-6 mb-5 mb-lg-0 ">
          <div class="card bg-dark text-white">
            <div class="card-body py-5 px-md-5">
                   <form runat="server" id="form1">

                <!-- Email input -->
                <div class="form-outline mb-4">
                   <asp:Textbox id="Email" runat="server" type="email" class="form-control form-control-lg bg-dark text-light"
             />
                  <label class="form-label" for="form3Example3">Email address</label>
                </div>

                <!-- Password input -->
                <div class="form-outline mb-4">
                  <asp:Textbox runat="server" type="password" id="password" class="form-control form-control-lg bg-dark text-light"
            />
                  <label class="form-label" for="form3Example4">Password</label>
                </div>


                <!-- Submit button -->
          <div class="text-center text-lg-start mt-4 pt-2">
            <asp:Button runat="server" ID="btnlogin" text="Login" type="submit" class="btn btn-primary btn-lg"
              style="padding-left: 2.5rem; padding-right: 2.5rem;" OnClick="btnlogin_Click"/>

            <p class="small fw-bold mt-2 pt-1 mb-0">Don't have an account? <a href="/views/logging/register.aspx"
                class="link-danger">Register</a></p>
          </div>

              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <!-- Jumbotron -->
</section>
<!-- Section: Design Block -->

</asp:Content>
