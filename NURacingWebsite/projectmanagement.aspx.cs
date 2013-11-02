using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace NURacingWebsite
{
    public partial class project : System.Web.UI.Page
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
        bool update;

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
            createProjFrm.Controls.Add(projNameDrpList);
            projNameDrpList.CssClass = "drpList";
            createProjFrm.Controls.Add(new LiteralControl("</p>"));
            if (update)
            {
                lblCarNameList.Visible = true;
                projNameDrpList.Visible = true;
            }
            else
            {
                lblCarNameList.Visible = false;
                projNameDrpList.Visible = false;
            }


            createProjFrm.Controls.Add(new LiteralControl("<p>"));
            lblCarName.Text = "Project Name: ";
            createProjFrm.Controls.Add(lblCarName);
            createProjFrm.Controls.Add(carNameTxtBx);
            carNameTxtBx.CssClass = "textareaPassword";
            createProjFrm.Controls.Add(new LiteralControl("</p>"));
            if (update)
            {
                lblCarName.Visible = false;
                carNameTxtBx.Visible = false;
            }
            else
            {
                lblCarName.Visible = true;
                carNameTxtBx.Visible = true;
            }


            projStatusDrpList.Items.Clear();
            projStatusDrpList.Items.Add("Completed");
            projStatusDrpList.Items.Add("In Progress");
            projStatusDrpList.Items.Add("Ongoing");

            createProjFrm.Controls.Add(new LiteralControl("<p>"));
            lblStatus.Text = "Set Project Status: ";
            createProjFrm.Controls.Add(lblStatus);
            createProjFrm.Controls.Add(projStatusDrpList);
            projStatusDrpList.CssClass = "drpList";
            createProjFrm.Controls.Add(new LiteralControl("</p>"));
            if (update)
            {
                lblStatus.Visible = true;
                projStatusDrpList.Visible = true;
            }
            else
            {
                lblStatus.Visible = false;
                projStatusDrpList.Visible = false;
            }

            createProjFrm.Controls.Add(new LiteralControl("<p>"));
            lblYearMade.Text = "Year Made: ";
            createProjFrm.Controls.Add(lblYearMade);
            createProjFrm.Controls.Add(yearMadeTxtBx);
            yearMadeTxtBx.CssClass = "textareaPassword";
            createProjFrm.Controls.Add(new LiteralControl("<p>"));

            createProjFrm.Controls.Add(new LiteralControl("<p>"));
            lblDesc.Text = "Description: ";
            createProjFrm.Controls.Add(lblDesc);
            createProjFrm.Controls.Add(carDescTxtBx);
            carDescTxtBx.CssClass = "textareaPassword";
            carDescTxtBx.TextMode = TextBoxMode.MultiLine;
            createProjFrm.Controls.Add(new LiteralControl("</p>"));
        }

        protected void submitProjBtn_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.Project.addDefaultCar(carNameTxtBx.Text, Convert.ToInt32(yearMadeTxtBx.Text), carDescTxtBx.Text);
        }

        protected void updateSubmitBtn_Click(object sender, EventArgs e)
        {
            if (carNameTxtBx.Text != "")
            {

            }

            if (yearMadeTxtBx.Text != "")
            {

            }

            if (carDescTxtBx.Text != "")
            {

            }
        }

        protected void createProjBtn_Click(object sender, EventArgs e)
        {
            lblCarName.Visible = true;
            carNameTxtBx.Visible = true;
            lblCarNameList.Visible = false;
            projNameDrpList.Visible = false;
            createProjFrm.Visible = true;
            submitProjBtn.Visible = true;
            updateSubmitBtn.Visible = false;
            lblDesc.Visible = true;
            projStatusDrpList.Visible = false;
            lblYearMade.Visible = true;
            yearMadeTxtBx.Visible = true;
            carDescTxtBx.Visible = true;
            lblStatus.Visible = false;
            update = false;
        }

        protected void updateProjBtn_Click(object sender, EventArgs e)
        {
            lblCarNameList.Visible = true;
            projNameDrpList.Visible = true;
            lblCarName.Visible = false;
            carNameTxtBx.Visible = false;
            lblDesc.Visible = false;
            carDescTxtBx.Visible = false;
            lblYearMade.Visible = false;
            yearMadeTxtBx.Visible = false;
            createProjFrm.Visible = true;
            submitProjBtn.Visible = false;
            updateSubmitBtn.Visible = true;
            projStatusDrpList.Visible = true;
            lblStatus.Visible = true;
            update = true;
          
        }
    }
}