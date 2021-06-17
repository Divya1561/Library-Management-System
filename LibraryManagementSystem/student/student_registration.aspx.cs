using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.student
{
    public partial class student_registration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\lms.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        protected void b1_Click(object sender, EventArgs e)
        {
           
            string path = "";
            f1.SaveAs(Request.PhysicalApplicationPath + "/student/student_img/" + f1.FileName.ToString());
            path = "/student_img" + f1.FileName.ToString();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into student_registration values('"+ firstname.Text +"','"+ lastname.Text +"','"+ studentid.Text +"','"+ username.Text +"','"+ password.Text +"','"+ email.Text +"','"+ contact.Text +"','"+ path.ToString() +"','no')";
            cmd.ExecuteNonQuery();
            

           
                Response.Redirect("student_login.aspx");
           
        }
    }
}