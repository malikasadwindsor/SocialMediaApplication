<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="SocialMediaApplication.Signup" %>

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
                        <h1 class="text-base text-primary text-uppercase mb-4">Sign up Here</h1>
                        <h2 class="mb-4">Registration Page</h2>

                        <div class ="form-group mb-4">
                            <asp:TextBox required= "true" ID="txtFirstName" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="First Name" runat="server" ></asp:TextBox>

                        </div>
                         <div class ="form-group mb-4">
                            <asp:TextBox required= "true" ID="txtLastName" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Last Name" runat="server" ></asp:TextBox>

                        </div>
                        <div class ="form-group mb-4">
                            <asp:TextBox required= "true" ID="txtEmail" TextMode="Email" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Email" runat="server" ></asp:TextBox>

                        </div>
                             <div class ="form-group mb-4">
                            <asp:TextBox required= "true" ID="txtPassword" TextMode="Password" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Password" runat="server" ></asp:TextBox>

                        </div>
                           <div class ="form-group mb-4">
                            <asp:TextBox required= "true" ID="txtConfirmPassword" TextMode="Password" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Confirm Password" runat="server" ></asp:TextBox>

                        </div>

                        <div class ="form-group mb-4">
                            <label>Date of Birth</label>
                            <asp:TextBox required= "true" ID="txtDateOfBirth" TextMode="Date" CssClass="form-control border-0 shadow form-control-lg text-base" placeholder="Date of birth" runat="server" ></asp:TextBox>
                        </div>
                            <label>Profile picture</label>
                        <div class ="form-group mb-4">
                            <asp:FileUpload ID="profilePic" required ="true" CssClass="form-control border-0 shadow form-control-lg text-base" runat="server" />
                        </div>

                        <asp:Button Text="Sign up" ID="btnRegistration" CssClass="btn btn-primary" Height="50px" Width="400px" runat="server" OnClick="btnRegistration_Click" />
                        <a href="LoginPage.aspx">Login Page</a>  
                        <asp:Label ID="Label1" runat="server" ></asp:Label>
                    </div>

                </div>
               
                <footer class="footer bg-white shadow align-self-end py-3 px-xl-5 w-100 " style="text-align:end;margin-top:390px">
                    <div class="container-fluid">
                        <div class="row">   
                            <div class="col-md-6 text-center text-md-left text-primary">
                                <p class  ="mb-2 mb-md-0">Asad Mehmood &copy;2021</p>
                            </div>
                            <div class="col-md-6 text-center text-md-right text-gray-400">
                                <p class="mb-0">DEsign by <a href="#">Asad Mehmood</a></p>

                            </div>
                        </div>
                    </div>
                </footer>
            </div>
            
        </div>
    </form>
</body>
</html>