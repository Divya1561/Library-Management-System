using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.librarian
{
    public partial class add_books : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Library_Management_System\LibraryManagementSystem\LibraryManagementSystem\App_Data\lms.mdf;Integrated Security=True");

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
            string path2 = "";
            string path3 = "";

            fo1.SaveAs(Request.PhysicalApplicationPath + "/librarian/books_images/" + fo1.FileName.ToString());
            path = "books_images/"+fo1.FileName.ToString();

            if(fo2.FileName.ToString() != "")
            {
               
                fo2.SaveAs(Request.PhysicalApplicationPath + "/librarian/books_pdf/" + fo2.FileName.ToString());
                path2 = "books_pdf/" + fo2.FileName.ToString();

            }

            if (fo2.FileName.ToString() != "")
            {
                
                fo3.SaveAs(Request.PhysicalApplicationPath + "/librarian/books_video/" + fo3.FileName.ToString());
                path3 = "books_video/" + fo3.FileName.ToString();
            }
                

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into books values('"+ bookstitle.Text +"','"+ path.ToString() +"','"+ path2.ToString() +"','"+ path3.ToString() +"','"+ authorname.Text +"','"+ isbn.Text +"','"+qty.Text +"')";
            cmd.ExecuteNonQuery();

            msg.Style.Add("display", "block");
        }
    }
}