using System;
using System.Data;


namespace AAITschool {
    public partial class StudentRegistration : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (!string.IsNullOrEmpty(Request.QueryString["StudentId"])) {
                    int sID = Convert.ToInt32(Request.QueryString["StudentId"]);
                    LoadStudent(sID);
                }
                else {
                    LoadDropDowns();
                    LoadDDlClass();
                }
            }

        }

        private void LoadStudent(int sID) {
            DBAccess db = new DBAccess();
            DataTable dt = db.GetStudent(sID);
            ddlClass.DataSource = dt;
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataBind();
        }

        protected void LoadDDlClass(int? id = null) {
            DataSet ds = (DataSet)Session["LookUps"];
            DataTable dt = ds.Tables[0];
            ddlClass.DataSource = dt;
            ddlClass.DataValueField = "ClassID";
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, "Select Class");
        }

        private void LoadDropDowns(int? id = null) {
            // var db = new DBAccess();
            //DataSet ds = db.GetLookup();
            DataSet ds = (DataSet)Session["LookUps"];
            DataTable dt = ds.Tables[1];
            ddlGender.DataSource = dt;
            ddlGender.DataValueField = "GenderID";
            ddlGender.DataTextField = "Gender";
            ddlGender.DataBind();
            ddlGender.Items.Insert(0, "Select Gender");

            dt = ds.Tables[2];
            ddlRace.DataSource = dt;
            ddlRace.DataValueField = "RaceID";
            ddlRace.DataTextField = "Race";
            ddlRace.DataBind();
            ddlRace.Items.Insert(0, "Select Race");


            dt = ds.Tables[3];
            ddlDiplomaType.DataSource = dt;
            ddlDiplomaType.DataValueField = "DiplomaTypeID";
            ddlDiplomaType.DataTextField = "DiplomaType";
            ddlDiplomaType.DataBind();
            ddlDiplomaType.Items.Insert(0, "Select Diploma Type");

            dt = ds.Tables[4];
            ddlState.DataSource = dt;
            ddlState.DataValueField = "StateID";
            ddlState.DataTextField = "State";
            ddlState.DataBind();
            ddlState.Items.Insert(0, "Select State");
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e) {
            if (ddlClass.SelectedIndex > 0) {
                pnlRegistration.Visible = false;
                int ClassID = ddlClass.SelectedIndex;
                LoadDDlTeacher(ClassID);
                ddlTeacher.Visible = true;
            }
        }

        protected void LoadDDlTeacher(int classID) {
            // DBAccess db = new DBAccess();
            DataTable dt = (DataTable)Session["Teachers"];
            string exp = "ClassID = " + classID;
            DataRow[] dt2 = dt.Select(exp);
            ddlTeacher.DataSource = dt2.CopyToDataTable();
            ddlTeacher.DataValueField = "TeacherID";
            ddlTeacher.DataTextField = "FullName";
            ddlTeacher.DataBind();
            ddlTeacher.Items.Insert(0, "Select Teacher");
        }


        protected void ddlTeacher_SelectedIndexChanged(object sender, EventArgs e) {

            if (ddlTeacher.SelectedIndex > 0) {
                if (pnlRegistration.Visible == false) {
                    pnlRegistration.Visible = true;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e) {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string DDLNum = txtDDL.Text;
            int genderID = Convert.ToInt32(ddlGender.SelectedValue);
            int raceID = Convert.ToInt32(ddlRace.SelectedValue);
            string address = txtAddress.Text;
            string city = txtCity.Text;
            string stateID = ddlState.SelectedValue;
            string zip = txtZip.Text;
            string diploma = null;
            string diplomatype = null;
            int Id = 0;
            int ClassID = Convert.ToInt32(ddlClass.SelectedValue);
            int TeacherID = Convert.ToInt32(ddlTeacher.SelectedValue);
            if (rdbYes.Checked) {
                diploma = txtDiploma.Text;
                diplomatype = ddlDiplomaType.SelectedValue;
            }

            var db = new DBAccess();

            int studentID = db.SetStudent("Insert", firstName, lastName, genderID, raceID, ClassID, TeacherID, diploma, diplomatype, address, city, stateID, zip, Id);
            Response.Redirect("~/Student.aspx");
        }

        protected void rdbYes_CheckedChanged(object sender, EventArgs e) {
            pnlDiploma.Visible = true;
        }

        protected void rdbNo_CheckedChanged(object sender, EventArgs e) {
            pnlDiploma.Visible = false;
        }

    }
}