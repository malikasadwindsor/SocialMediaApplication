using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace SocialMediaApplication
{
    public partial class ImageGallery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    lblVerify.Visible = false;
                    LoadImages();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void LoadImages()
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            using(SqlConnection con = new SqlConnection(mainconn))
            {
                SqlCommand cmd = new SqlCommand("Select * From dbo.Image Order by ID desc", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                GridView1.DataSource = rdr;
                GridView1.DataBind();


            }
        }

        private void SearchImages()
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(mainconn))
            {
                SqlCommand cmd = new SqlCommand("Select * From dbo.Image where Tag='"+DropDownList1.SelectedValue+"'", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                GridView1.DataSource = rdr;
                GridView1.DataBind();

            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                HttpPostedFile postedFile =  FileUpload1.PostedFile;
                string fileName = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(fileName);
                int fileSize = postedFile.ContentLength;

                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp" || fileExtension.ToLower() == ".gif")
                {
                    Stream stream = postedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(mainconn))
                    {
                        SqlCommand cmd = new SqlCommand("spUploadImage",con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter paramName = new SqlParameter()
                        {
                            ParameterName = "@Name",
                            Value = fileName
                        };
                        cmd.Parameters.Add(paramName);
                        
                        SqlParameter paramTag = new SqlParameter()
                        {
                            ParameterName = "@Tag",
                            Value = txtTag.Text.ToString()
                        };
                        cmd.Parameters.Add(paramTag);

                        SqlParameter paramPicture = new SqlParameter()
                        {
                            ParameterName = "@Picture",
                            Value = bytes
                        };
                        cmd.Parameters.Add(paramPicture);

                        SqlParameter paramNewId = new SqlParameter()
                        {
                            ParameterName = "@NewId",
                            Value = -1,
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(paramNewId);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        lblVerify.Visible = true;
                        lblVerify.Text = "Image uploaded successfully";
                        lblVerify.ForeColor = System.Drawing.Color.Green;
                        LoadImages();
                    }
                    
                        
                }
                else
                {
                    lblVerify.Visible = true;
                    lblVerify.Text = "Only jpg,png,gif and bmp images are allowed to upload";
                    lblVerify.ForeColor = System.Drawing.Color.Red;
                }

                


            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchImages();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            try
            {
                string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(mainconn))
                {
                    SqlCommand cmd = new SqlCommand("Select * From dbo.Image Order by ID desc", con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();


                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

       

        protected void OnRowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(mainconn);
            SqlCommand cmd = new SqlCommand("DeleteImage", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.ExecuteNonQuery();
            LoadImages();
        }
        
    }

}