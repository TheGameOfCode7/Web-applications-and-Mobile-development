using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication6
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write("<!-- Hello world! --><br>");
            //Response.Write("<!-- DEBUGVALUE: " + System.Configuration.ConfigurationManager.AppSettings["DEBUGVALUE"] + "-->");
            if (!Page.IsPostBack)
            {
                //for (int person = 0; person < 10; person++)
                //{
                //    names.Add("Mr Smith " + person.ToString());
                //    //ddlPeople.Items.Add(new ListItem("Mr Smith " + person.ToString(), person.ToString()));
                //}
                //gvPeople.DataSource = names;
                //gvPeople.DataBind();
                BindMyData();
                txtFirstName.Focus();
            }
            else
            {
                Response.Write("Allt var redan inlagt hörru!");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ltrUtdata.Text = "Hej " + txtFirstName.Text;

            var xmlFile = Server.MapPath("~/App_Data/Persons.xml");
            var persons = XElement.Load(xmlFile);
            var nextId = persons.Elements().Max(x => int.Parse(x.Element("Id").Value)) + 1;

            var newPerson = new XElement("Person",
                                    new XElement("Id", nextId),
                                    new XElement("FirstName", txtFirstName.Text)
                                );
            persons.Add(newPerson);
            persons.Save(Server.MapPath("~/App_Data/Persons.xml"));
            BindMyData();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileUpload1.HasFile)
            {
                string filename = System.IO.Path.GetFileName(fileUpload1.FileName);
                fileUpload1.SaveAs(Server.MapPath("~/Upload/" + filename));
            }
        }

        private void BindMyData()
        {
            var names = new List<string>();
            var xmlFile = Server.MapPath("~/App_Data/Persons.xml");
            var persons = XElement.Load(xmlFile);
            foreach (var person in persons.Elements().OrderBy(x => x.Elements("FirstName").First().Value))
            {
                names.Add(person.Element("FirstName").Value);
            }

            lbPeople.DataSource = names;
            lbPeople.DataBind();

            ltrMessage.Text = "Sista id: " + persons.Elements().Last().Value;

        }

    }
}