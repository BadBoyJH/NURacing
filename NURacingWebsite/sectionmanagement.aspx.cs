using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace NURacingWebsite
{
    public partial class sectionmanagement : System.Web.UI.Page
    {
        Label lblCarName = new Label();
        TextBox carNameTxtBx = new TextBox();
        Label lblYearMade = new Label();
        TextBox yearMadeTxtBx = new TextBox();
        Label lblDesc = new Label();
        TextBox carDescTxtBx = new TextBox();
        Label lblStatus = new Label();
        DropDownList projStatusDrpList = new DropDownList();
        Label lblCarNameList = new Label();
        DropDownList projNameDrpList = new DropDownList();

        protected void Page_Load(object sender, EventArgs e)
        {
            createForm();
        }

        private void createForm()
        {
             

             projNameDrpList.Items.Clear();

            foreach (ProjectInfo project in BusinessLogicLayer.ProjectInfo.getProjects())
            {
                projNameDrpList.Items.Add(project.Name);
            }
            createProjFrm.Controls.Add(new LiteralControl("<p>"));
            lblCarNameList.Text = "Project Name: ";
            createProjFrm.Controls.Add(lblCarNameList);
            foreach (WorkTypeInfo type in BusinessLogicLayer.WorkTypeInfo.getAllWorkTypes())
            {
                if (type.Project.Name != type.Name)
                {
                    projNameDrpList.Items.Add(type.Project.Name + " - " + type.Name);
                }
                else
                {
                }
            }
            createProjFrm.Controls.Add(projNameDrpList);
            projNameDrpList.CssClass = "drpList";
            createProjFrm.Controls.Add(new LiteralControl("</p>"));

            projStatusDrpList.Items.Clear();
            projStatusDrpList.Items.Add("Completed");
            projStatusDrpList.Items.Add("In Progress");
            projStatusDrpList.Items.Add("Ongoing");

            createProjFrm.Controls.Add(new LiteralControl("<p>"));
            lblStatus.Text = "Set Section Status: ";
            createProjFrm.Controls.Add(lblStatus);
            createProjFrm.Controls.Add(projStatusDrpList);
            projStatusDrpList.CssClass = "drpList";
            createProjFrm.Controls.Add(new LiteralControl("</p>"));
          
        }

    }
}