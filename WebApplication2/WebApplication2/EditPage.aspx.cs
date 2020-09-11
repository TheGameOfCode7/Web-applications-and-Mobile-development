using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class EditPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int logid = int.Parse(Request.QueryString["logid"]);
            if (!Page.IsPostBack)
            {
                BindData(logid);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int logid = int.Parse(Request.QueryString["logid"]);
            var db = new AdventureWorks2019Entities();
            var item = db.DatabaseLogs.Where(x => x.DatabaseLogID == logid).FirstOrDefault();
            try
            {
                item.PostTime = DateTime.Parse(txtTimeStamp.Text);
                item.DatabaseUser = txtDatabaseUser.Text;
                item.Object = txtObject.Text;
                item.Event = txtEvent.Text;

                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
            Response.Redirect("~/AdventureWorks");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdventureWorks");
        }

        private void BindData(int logid)
        {
            var db = new AdventureWorks2019Entities();
            var item = db.DatabaseLogs.Where(x => x.DatabaseLogID == logid).First();
            txtTimeStamp.Text = item.PostTime.ToString();
            txtDatabaseUser.Text = item.DatabaseUser;
            txtObject.Text = item.Object;
            txtEvent.Text = item.Event;
        }
    }
}