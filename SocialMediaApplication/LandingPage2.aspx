<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LandingPage2.aspx.cs" Inherits="SocialMediaApplication.LandingPage2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="Helper/css/style.default.css" rel="stylesheet" />
    <link href="Helper/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
</head>

<body>
    <div class="topnav" style="text-align:right">
         <a class="active" href="LoginPage.aspx">Logout</a>
         <a class="active" href="Gallery.aspx">Image Gallery</a>
    </div>
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
                        <h1 class="text-base text-primary text-uppercase mb-4">Welcome!</h1>
                        <h2 class="mb-4">Profile Page</h2>
                       
                        <div class="form-group m-4">
                        Email: <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-group m-4">
                        First Name: <asp:Label ID="lblFirstName" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-group m-4">
                        Last Name: <asp:Label ID="lblLastName" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-group m-4">
                        Date of Birth: <asp:Label ID="lblDob" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-group m-4">
                        Profile Image: <asp:Image ID="imgprofile" runat="server" Height="287px" Width="356px" />
                        </div>
                        
                    </div>
            
                     <div class="col-lg-5 px-lg-4" style="text-align:right">
                        <h2 class="mb-4">Profile Update!</h2>
                        <div class="container">
                            <div class="form-group m-4">
                                Email:<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                            </div>
                             <div class="form-group m-4">
                                Password:<asp:TextBox ID="txtPassword"  runat="server" TextMode="Password"></asp:TextBox>
                            </div>
                            <div class="form-group m-4">
                                First Name:<asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group m-4">
                                Last Name:<asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                            </div>
                             <div class="form-group m-4">
                                DOB:<asp:TextBox ID="txtDOB"  runat="server" TextMode="Date"></asp:TextBox>
                            </div>
                            <div class="form-group m-4">
                                <asp:FileUpload ID="profileImage" runat="server" />
                            </div>

                            <asp:Button Text="Update Profile" CssClass="btn btn-primary" Height="50px" Width="200px" runat="server" id="updateProfile" OnClick="updateProfile_Click" />
                        
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
                                <p class="mb-0">DEsign by <a href="#">Group 41</a></p>

                            </div>
                        </div>
                    </div>
                </footer>
            </div>
            
        </div>
    </form>
</body>
</html>
