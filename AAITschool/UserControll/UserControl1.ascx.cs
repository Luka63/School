using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AAITschool.UserControll
{
    public partial class UserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadUserCtrl1();
        }

        private void loadUserCtrl1()
        {
            var db = new DBAccess();
        }
    }
}