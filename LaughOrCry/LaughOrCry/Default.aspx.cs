using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace LaughOrCry
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                EmptyFile("~/Files/Laughing list.xml");
                EmptyFile("~/Files/Crying list.xml");
            }
        }

        private void EmptyFile(string path)
        {
            XmlDocument document = new XmlDocument();
            document.Load(Server.MapPath(path));
            XmlNode objXNode = document.DocumentElement;
            objXNode.RemoveAll();
            document.Save(Server.MapPath(path));
        }

        protected void btnTry_Click(object sender, EventArgs e)
        {
            int rndNumber = GetRandomNumber();
            if (rndNumber == 1)
            {
                SaveData("Laughing");
            }
            else
            {
                SaveData("Crying");
            }

            ResultLrt.Text = $"{GetCounter("~/Files/Laughing list.xml")} Laughing / {GetCounter("~/Files/Crying list.xml")} Crying";
        }

        private void SaveData(string status)
        {
            Image.ImageUrl = $"~/Image/{status} emoji.jpg";
            StatusLtr.Text = status;
            var xmlFile = Server.MapPath($"~/Files/{status} list.xml");
            XElement statusList = null;
            var nextId = 0;
            try
            {
                statusList = XElement.Load(xmlFile);
                nextId = statusList.Elements().Max(x => int.Parse(x.Element("Id").Value)) + 1;
            }
            catch (Exception)
            {
                nextId = 1;
            }
            var newStatus = new XElement($"{status}",
                                    new XElement("Id", nextId),
                                    new XElement("Time", $"{status} - {DateTime.Now.ToString("HH:mm:ss")}")
                                );
            statusList.Add(newStatus);
            statusList.Save(Server.MapPath($"~/Files/{status} list.xml"));
            BindData($"~/Files/{status} list.xml");
        }

        private int GetCounter(string path)
        {
            var cryingList = XElement.Load(Server.MapPath(path));
            return cryingList.Elements().Count();
        }

        private void BindData(string path)
        {
            List<string> outputData = new List<string>();
            var xmlFile = Server.MapPath(path);
            var allData = XElement.Load(xmlFile);
            foreach (var data in allData.Elements())
            {
                outputData.Add(data.Element("Id").Value + ". " + data.Element("Time").Value);
            }
            if (path.Contains("Laughing"))
            {
                LbLaughing.DataSource = outputData;
                LbLaughing.DataBind();
                LbLaughing.SelectedIndex = LbLaughing.Items.Count - 1;
            }
            else
            {
                LbCrying.DataSource = outputData;
                LbCrying.DataBind();
                LbCrying.SelectedIndex = LbCrying.Items.Count - 1;
            }
        }

        private int GetRandomNumber()
        {
            Random rnd = new Random();
            return rnd.Next(1, 3);
        }
    }
}