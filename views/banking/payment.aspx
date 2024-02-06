<%@ Page Title="" Language="C#" MasterPageFile="~/views/layout.Master" AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="Mini_Banking_App.views.banking.payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .gradient-custom {
        background-image: url(https://mdbcdn.b-cdn.net/img/Photos/Others/background3.webp);
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="gradient-custom">
  <div class="container">
    <div class="row d-flex justify-content-center py-5">
      <div class="col-md-7 col-lg-5 col-xl-4">
        <div class="card" style="border-radius: 15px;">
          <div class="card-body p-4">
            <form runat="server"> 
              <div class="d-flex justify-content-between align-items-center mb-3">
                <div class="form-outline">
                  <asp:Textbox runat="server" type="text" id="txtAccountNumber" class="form-control form-control-lg" siez="17"
                    placeholder="123 567 901" minlength="9" maxlength="9" />
                  <label class="form-label" for="typeText">Account Number</label>
                </div>
                
              </div>

              <div class="d-flex justify-content-between align-items-center mb-4">
                <div class="form-outline">
                  <asp:Textbox runat="server" type="text" id="txtCardholders" class="form-control form-control-lg" siez="17"
                    placeholder="Cardholder's First Name    " />
                  <label class="form-label" for="typeName">Cardholder's Name</label>
                </div>
              </div>

              <div class="d-flex justify-content-between align-items-center pb-2">
                <div class="form-outline">
                  <asp:Textbox runat="server" type="text" id="txtAmountPayed" class="form-control form-control-lg" placeholder="R"
                    size="7" minlength="1" maxlength="7" />
                  <label class="form-label" for="typeExp">Pay Amount</label>
                </div>
                <div class="form-outline">
                  <asp:Button runat="server" class="btn btn-success btn-lg" id="btnPay" style="padding-left: 0.5rem; padding-right: 0.5rem;" Text="Pay" OnClick="btnPay_Click"/>
                      <label class="form-label" for="typeText2">Pay</label>
                </div>
     
               
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>
</asp:Content>
