using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;

namespace GitOut
{
    public partial class IndividualProjectPage : System.Web.UI.Page
    {
        public string folderName, pathString, fileName, fileTitle;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProjectPage pp = new ProjectPage();
            fileTitle = pp.projectTitle;
        }
        protected void listLoad(object sender, EventArgs e)
        {
            folderName = @"C:\Users\sdean\Desktop\CSC440\TeamProject\gitout\GitOutCode\Files";
            pathString = System.IO.Path.Combine(folderName, "This is cool");
            string[] fileArray = Directory.GetFiles(pathString);

            HtmlGenericControl a, br;
            foreach (string name in fileArray)
            {
                a = new HtmlGenericControl("a");
                br = new HtmlGenericControl("br /");
                fileName = Path.GetFileName(name);
                a.InnerText = fileName;

                ProjectFiles.Controls.Add(a);
                ProjectFiles.Controls.Add(br);
            }
        }

        protected void downloadFiles(object sender, EventArgs e)
        {
            
        }
        protected void uploadFiles(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                try
                {
                    FileUpload1.SaveAs(pathString);
                    StatusLabel.Text = "Upload Status: File uploaded!";
                }
                catch(Exception ex)
                {
                    StatusLabel.Text = "Upload Status: File could not be uploaded. The following error occurred: " + ex.Message;
                }
            }
        }
        protected void displayText(object sender, EventArgs e)
        {

        }
    }
}