using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Owin;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data;

namespace GitOut
{
    public partial class ProjectPage : System.Web.UI.Page
    {
        public string projectTitle;
        public ArrayList eList;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoadNewPage(object sender, EventArgs e)
        {
            
            Response.Redirect("NewProject.aspx");
        }


        protected void AddData(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                ArrayList eventList = new ArrayList(); //a list to save the events
                                                       //prepare an SQL query to retrieve all the events on the same, specified date
                DataTable myTable = new DataTable();

                string connStr = "server=csdatabase.eku.edu;user=stu_csc440;database=csc440_db;port=3306;password=Maroons18;";

                MySqlConnection conn = new MySqlConnection(connStr);

                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();
                    string sql = "SELECT * FROM gitoutfiles";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                    myAdapter.Fill(myTable);
                    Console.WriteLine("Table is ready.");
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                conn.Close();

                //convert the retrieved data to events and save them to the list

                foreach (DataRow row in myTable.Rows)
                {
                    Event newEvent = new Event();
                    newEvent.eventTitle = row["projectName"].ToString();
                    eventList.Add(newEvent);
                }

                eList = eventList; //return the event list

                // HtmlGenericControl li;
                HtmlGenericControl a, br;
                for (int i = 0; i < eventList.Count; i++)
                {
                    Event thisFile = (Event)eList[i];
                    a = new HtmlGenericControl("a");
                    br = new HtmlGenericControl("br /");
                    a.Attributes.Add("href", "/IndividualProjectPage");
                    a.Attributes.Add("id", "text" + i);
                    a.InnerText = thisFile.getEventTitle();

                    ProjectList.Controls.Add(a);
                    ProjectList.Controls.Add(br);
                }
            }
            else
            {
                HtmlGenericControl p, a;
                p = new HtmlGenericControl("p");
                p.InnerText = "There are currently no projects displayed. If you are looking for your projects, you can sign in ";
                a = new HtmlGenericControl("a");
                a.Attributes.Add("href", "/Account/Login");
                a.InnerText = " here";

                ProjectList.Controls.Add(p);
                ProjectList.Controls.Add(a);

            }
        }
    }
}