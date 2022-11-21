<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageGallery.aspx.cs" Inherits="SocialMediaApplication.ImageGallery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SocialMedia</title>
    <link href="Helper/css/style.default.css" rel="stylesheet" />
    <link href="Helper/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center">
            <h1 style="color:mediumpurple">Image Gallery</h1>
            <br/>
            <br/>
            <asp:Label ID="Label3" runat="server" Text="Tag"></asp:Label>
            <br/>
            <br/>
            <asp:TextBox ID="txtTag" runat="server" ></asp:TextBox>
            <br/>
            <br/>
            <asp:Label ID="Label2" runat="server" Text="Upload Image"></asp:Label>
            <br />
            <br/>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            <asp:Label ID="lblVerify" runat="server" ></asp:Label>

            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        </div>
        <div style="text-align:center">
            <h1>View Uploaded Images!</h1>
            <p>Search by Tag
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Tag" DataValueField="Tag" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Myconnection %>" ProviderName="<%$ ConnectionStrings:Myconnection.ProviderName %>" SelectCommand="SELECT DISTINCT [Tag] FROM [Image]"></asp:SqlDataSource>
            </p>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            <asp:Button ID="btnShowAll" runat="server" Text="Show All" OnClick="btnShowAll_Click" />
            <br />
            <asp:GridView ID="GridView1" runat="server"  HorizontalAlign="Center" DataKeyNames="ID" OnRowDeleting="OnRowDeleting" Width ="40%" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField ="ID" HeaderText ="ID" />
                    <asp:BoundField DataField ="Tag" HeaderText ="Tag" />
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Height="200px" Width="200px" 
                                imageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("Picture")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowDeleteButton="true" HeaderText="Delete Operation" ButtonType="Button"  />
                </Columns>

            </asp:GridView>

        </div>
    </form>
</body>
</html>
