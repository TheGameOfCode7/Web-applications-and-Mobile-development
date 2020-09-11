using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class AdventureWorks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
                Response.Redirect("~/");

            Lbl1.Text = "Hello " + User.Identity.Name;

            if (!Page.IsPostBack)
                BindData();
        }

        protected void Gv1_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gv1.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void Gv1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gv1.EditIndex = e.NewEditIndex;
            BindData();
        }

        protected void Gv1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gv1.EditIndex = -1;
            BindData();
        }

        protected void Gv1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = int.Parse(Gv1.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = Gv1.Rows[e.RowIndex];

            TextBox textPostTime = (TextBox)row.FindControl("txtPostTime");
            TextBox textDatabaseUser = (TextBox)row.FindControl("txtDbUser");
            TextBox textObject = (TextBox)row.FindControl("txtObject");
            TextBox textEvent = (TextBox)row.FindControl("txtEvent");

            Gv1.EditIndex = -1;

            var db = new AdventureWorks2019Entities();
            var item = db.DatabaseLogs.Where(x => x.DatabaseLogID == id).First();
            item.PostTime = DateTime.Parse(textPostTime.Text);
            item.DatabaseUser = textDatabaseUser.Text;
            item.Object = textObject.Text;
            item.Event = textEvent.Text;
            
            db.SaveChanges();
            BindData();
        }

        protected void Gv1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(Gv1.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = Gv1.Rows[e.RowIndex];

            var db = new AdventureWorks2019Entities();
            var item = db.DatabaseLogs.Where(x => x.DatabaseLogID == id).First();
            db.DatabaseLogs.Remove(item);
            db.SaveChanges();
            BindData();
        }

        protected void Gv1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName=="Insert")
            {
                var db = new AdventureWorks2019Entities();
                var item = new DatabaseLog();
                item.PostTime = DateTime.Now;
                item.DatabaseUser = ((TextBox)Gv1.FooterRow.FindControl("txtNewDbUser")).Text;
                item.Object= ((TextBox)Gv1.FooterRow.FindControl("txtNewObject")).Text;
                item.Event= ((TextBox)Gv1.FooterRow.FindControl("txtNewEvent")).Text;
                item.Schema = "";
                item.TSQL = "";
                item.XmlEvent = "";

                db.DatabaseLogs.Add(item);
                db.SaveChanges();
            }

            BindData();
        }

        private void BindData()
        {
            var db = new AdventureWorks2019Entities();
            var dblog = from log in db.DatabaseLogs orderby log.PostTime descending select log;
            if (dblog != null)
            {
                Gv1.DataSource = dblog.ToList();
                Gv1.DataBind();
            }
        }
    }
}