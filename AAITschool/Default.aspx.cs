using System;
using System.Web.UI;


namespace AAITschool {
    public partial class _Default : Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                loadLookups();
            }

        }

        private void loadLookups() {
            string str;

            var db = new DBAccess();
            Session["students"] = db.GetStudent();
            Session["LookUps"] = db.GetLookup();
            Session["Teachers"] = db.GetTeacher();
            Response.Redirect("~/Student.aspx");
        }

        //protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlClass.SelectedIndex>0)
        //    {
        //        int ClassID = ddlClass.SelectedIndex;
        //        LoadDDlTeacher(ClassID);
        //        ddlTeacher.Visible = true;

        //    }

        //}

        //private void LoadDDlTeacher(int classID)
        //{
        //    DBAccess db = new DBAccess();
        //    DataTable dt = db.GetTeacher(classID);
        //    Session["Teacher"] = dt;
        //    ddlTeacher.DataSource = dt;
        //    ddlTeacher.DataValueField = "TeacherID";
        //    ddlTeacher.DataTextField = "FullName";
        //    ddlTeacher.DataBind();
        //    ddlTeacher.Items.Insert(0, "Select Teacher");

        //}

        //protected void btnRegister_Click(object sender, EventArgs e)
        //{
        //    if (ddlTeacher.SelectedIndex > 0)
        //    {
        //        int ClassID = ddlClass.SelectedIndex;
        //        Response.Redirect("~/Registration.aspx?ClassID="+ClassID);
        //    }
        //}
        //private void LoadDDlClass()
        //{
        //    var db = new DBAccess();
        //    DataSet ds = db.GetLookup();
        //    DataTable dt = ds.Tables[0];
        //    ddlClass.DataSource = dt;
        //    ddlClass.DataValueField = "ClassID";
        //    ddlClass.DataTextField = "ClassName";
        //    ddlClass.DataBind();
        //    ddlClass.Items.Insert(0, "Select Class");


        //}
    }
}