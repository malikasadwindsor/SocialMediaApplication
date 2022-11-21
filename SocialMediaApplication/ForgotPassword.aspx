<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="SocialMediaApplication.ForgotPassword" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Helper/css/style.default.css" rel="stylesheet" />
    <link href="Helper/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class=" page-holder d-flex align-items-center">
            <div class="container">
                <div class="row align-items-center py-5">
                    <div class="col-5 col-lg-7 mx-auto mb-5 mb-lg-0">
                    
                        <div class="pr-lg-5">
                            <img src="illustration.svg" alt="" class="img-fluid" />     
                        </div>
                    </div>
                    <div class="col-lg-5 px-lg-4">
                        
                        <h2 class="mb-4">Reset Password!</h2>

                        <div class ="form-group mb-4">
                            <asp:TextBox  CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Email" runat="server" ID="txtEmail" ></asp:TextBox>

                        </div>
                            <div class ="form-group mb-4">
                            <asp:TextBox ID ="txtPassword"  TextMode="Password" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Password" runat="server" ></asp:TextBox>

                        
                        </div>
                            <div class ="form-group mb-4">
                            <asp:TextBox ID ="txtCnPassword"  TextMode="Password" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Confirm Password" runat="server" ></asp:TextBox>

                        </div>

                        <div class="form-group mb-4">
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        </div>
                        
                        <asp:Button id="btnSubmiy" Text="Submit" CssClass="btn btn-primary" Height="50px" Width="200px" runat="server" OnClick="btnSubmiy_Click"  />
                        
                    </div>
                </div>
                </div>
                
                <footer class="footer bg-white shadow align-self-end py-3 px-xl-5 w-100 " style="text-align:end;margin-top:390px">
                    <div class="container-fluid">
                        <div class="row">   
                            <div class="col-md-6 text-center text-md-left text-primary">
                                <p class  ="mb-2 mb-md-0">Group 41 &copy;2021</p>
                            </div>
                            <div class="col-md-6 text-center text-md-right text-gray-400">
                                <p class="mb-0">Design by <a href="#">Group 41</a></p>

                            </div>
                        </div>
                    </div>
                </footer>
      </div>
            
       
    </form>
</body>
</html>
