using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace AAITschool {
    public partial class Student : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            LoadGridView();
            LoadDDlClass();
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
        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e) {
            if (ddlClass.SelectedIndex > 0) {
                int id = Convert.ToInt32(ddlClass.SelectedValue);
                LoadDDlTeacher(id);
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

        protected void btnAdd_Click(object sender, EventArgs e) {
            Response.Redirect("~/StudentRegistration.aspx");
        }

        protected void LoadGridView() {
            var db = new DBAccess();
            DataTable dt = db.GetStudent();
            gvView.DataSource = dt;
            gvView.DataBind();
            gvView.Visible = true;
        }




        private int GetId(object sender) {
            GridViewRow gvRow = (GridViewRow)((Control)sender).Parent.Parent;//getting the row on which button was clicked
            int index = gvRow.RowIndex;
            int Id = ((int)this.gvView.DataKeys[index]["StudentID"]);// getting the ID from this row that was clicked
            return Id;
        }
        // DETAILS LOGIC 
        protected void Details_Click(object sender, EventArgs e) {
            var Id = GetId(sender);
            string confirmValue = Request.Form["confirm_value"];
            Response.Redirect("~/StudentRegistration.aspx?StudentId=" + Id);
        }
        // EDIT LOgic 
        protected void Edit_Click(object sender, EventArgs e) {
            var Id = GetId(sender);
            //  Response.Redirect("~/Edit.aspx?KittyId=" + Id);
        }

        //DELETE logic
        protected void Delete_Click(object sender, EventArgs e) {
            var Id = GetId(sender);
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes") {
                var db = new DBAccess();
                db.DeleteStudent(Id);
                LoadGridView();
            }
            else {
            }
        }

        protected void gvView_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            gvView.PageIndex = e.NewPageIndex++;
            // LoadGridView(Convert.ToInt32(ddlCat.SelectedValue)); 
        }

        protected void gvView_SelectedIndexChanged(object sender, EventArgs e) {

        }

        protected void gvView_PageIndexChanged(object sender, EventArgs e) {

        }

    }

}