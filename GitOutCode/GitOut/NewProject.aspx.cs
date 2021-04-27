using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace GitOut
{
    public partial class NewProject : System.Web.UI.Page
    {
        // Folder that the project is being saved to
        string folderName = @"C:\Users\sdean\Desktop\CSC440\TeamProject\gitout\GitOutCode\Files";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Create_Project(object sender, EventArgs e)
        {
            string ProName = NewProjectName.Text;
            string ProDescription = ProjectDescription.Text;
            DateTime firstCreated = DateTime.Today;
            string proCreatedDate = firstCreated.ToString("yyyy-MM-dd");

            
            // Checks if user has made the project public or private
            /*
            bool isPublic = true;
            bool isPrivate = false;
            if(Page.Request.Form["view"].ToString() == "Public")
            {
                isPublic = true;
                isPrivate = false;
            }
            else
            {
                isPublic = false;
                isPrivate = true;
            }
            */
            string connStr = "server=csdatabase.eku.edu;user=stu_csc440;database=csc440_db;port=3306;password=Maroons18;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "INSERT INTO gitoutfiles (fileName, fileDescription, dateAdded) VALUES (@fName, @fDescription, @dAdded)";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@fName", ProName);
                cmd.Parameters.AddWithValue("@fDescription", ProDescription);
                cmd.Parameters.AddWithValue("@dAdded", proCreatedDate);
                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");

            string pathString = System.IO.Path.Combine(folderName, ProName);
            System.IO.Directory.CreateDirectory(pathString);

            ReturnToProject(sender, e);
        }
        protected void ReturnToProject(object sender, EventArgs e)
        {
            Response.Redirect("ProjectPage.aspx");
        }
    }
}