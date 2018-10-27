using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AAITschool
{
    public partial class Registration : System.Web.UI.Page
    {
  

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                LoadDropDowns();
                int ClassID = Convert.ToInt32(Request.QueryString["ClassID"]);
                hdClassID.Value = ClassID.ToString();
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string DDLNum = txtDDL.Text;
            int genderID = Convert.ToInt32(ddlGender.SelectedValue);
            int raceID = Convert.ToInt32(ddlRace.SelectedValue);
            string address = txtAddress.Text;
            string city = txtCity.Text;
            string stateID = ddlState.SelectedValue;
            string zip = txtZip.Text;
            string diploma;
            string diplomatype;
            int Id=0;
            int ClassID = Convert.ToInt32(hdClassID.Value);
            if (rdbYes.Checked)
            {
                 diploma = txtDiploma.Text;
                 diplomatype = ddlDiplomaType.SelectedValue;
            }

            var db = new DBAccess();

           // int studentID = db.SetStudent("Insert", firstName, lastName, genderID, raceID, ClassID, address, city, stateID, zip, Id);
        }

        private void LoadDropDowns()
        {
            var db = new DBAccess();
            DataSet ds = db.GetLookup();

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

        protected void rdbYes_CheckedChanged(object sender, EventArgs e)
        {
            pnlDiploma.Visible = true;
        }

        protected void rdbNo_CheckedChanged(object sender, EventArgs e)
        {
            pnlDiploma.Visible = false;
        }
    }
}