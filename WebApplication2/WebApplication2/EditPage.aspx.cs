using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class EditPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["logid"], out int logid);
            if (!Page.IsPostBack)
            {
                if (logid > 0)
                {
                    BindData(logid);
                    btnCreate.Visible = false;
                    btnUpdate.Visible = true;
                }
                else
                {
                    txtPostTime.Text=DateTime.Now.ToString();
                    btnCreate.Visible = true;
                    btnUpdate.Visible = false;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["logid"], out int logid);
            var db = new AdventureWorks2019Entities();
            var item = db.DatabaseLogs.Where(x => x.DatabaseLogID == logid).FirstOrDefault();
            try
            {
                item.PostTime = DateTime.Parse(txtPostTime.Text);
                item.DatabaseUser = txtDatabaseUser.Text;
                item.Object = txtObject.Text;
                item.Event = txtEvent.Text;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
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
            txtPostTime.Text = item.PostTime.ToString();
            txtDatabaseUser.Text = item.DatabaseUser;
            txtObject.Text = item.Object;
            txtEvent.Text = item.Event;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            var db = new AdventureWorks2019Entities();
            var item = new DatabaseLog();
            item.PostTime = DateTime.Now;
            item.DatabaseUser = txtDatabaseUser.Text;
            item.Object = txtObject.Text;
            item.Event = txtEvent.Text;
            item.Schema = "";
            item.TSQL = "";
            item.XmlEvent = "";

            db.DatabaseLogs.Add(item);
            db.SaveChanges();

            Response.Redirect("~/AdventureWorks");
        }
    }
}