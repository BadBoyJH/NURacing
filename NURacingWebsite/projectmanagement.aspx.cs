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
        Label lblProjSubmit = new Label();
        Label lblActive = new Label();
        CheckBox activeChkBx = new CheckBox();

        protected void Page_Load(object sender, EventArgs e)
        {
            createForm();
        }

        private void createForm()
        {
            createProjFrm.Controls.Clear();

            createProjFrm.Controls.Add(new LiteralControl("<p>"));
            lblProjSubmit.Visible = false;
            lblProjSubmit.CssClass = "submitLbl";
            createProjFrm.Controls.Add(lblProjSubmit);
            createProjFrm.Controls.Add(new LiteralControl("</p> <br />"));


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
            projNameDrpList.BackColor = System.Drawing.ColorTranslator.FromHtml("#2D2D2D");
            projNameDrpList.ForeColor = System.Drawing.ColorTranslator.FromHtml("#7E7E7E");
            projNameDrpList.Font.Name = "Lucida Sans Unicode";
            projNameDrpList.Font.Size = 11;
            projNameDrpList.BorderStyle = BorderStyle.None;
            projNameDrpList.Height = 25;
            createProjFrm.Controls.Add(new LiteralControl("</p> <br />"));
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
            createProjFrm.Controls.Add(new LiteralControl("</p> <br />"));
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
            projStatusDrpList.BackColor = System.Drawing.ColorTranslator.FromHtml("#2D2D2D");
            projStatusDrpList.ForeColor = System.Drawing.ColorTranslator.FromHtml("#7E7E7E");
            projStatusDrpList.Font.Name = "Lucida Sans Unicode";
            projStatusDrpList.Font.Size = 11;
            projStatusDrpList.BorderStyle = BorderStyle.None;
            projStatusDrpList.Height = 25;
            createProjFrm.Controls.Add(new LiteralControl("</p> <br />"));
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
            createProjFrm.Controls.Add(new LiteralControl("</p> <br />"));

            createProjFrm.Controls.Add(new LiteralControl("<p>"));
            lblActive.Text = "Is Project Active?";
            lblActive.Visible = false;
            activeChkBx.Visible = false;
            createProjFrm.Controls.Add(lblActive);
            createProjFrm.Controls.Add(activeChkBx);
            createProjFrm.Controls.Add(new LiteralControl("</p> <br />"));

            createProjFrm.Controls.Add(new LiteralControl("<p>"));
            lblDesc.Text = "Description: ";
            createProjFrm.Controls.Add(lblDesc);
            createProjFrm.Controls.Add(carDescTxtBx);
            carDescTxtBx.CssClass = "textareaPassword";
            carDescTxtBx.TextMode = TextBoxMode.MultiLine;
            createProjFrm.Controls.Add(new LiteralControl("</p> <br />"));
        }

        protected void submitProjBtn_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.Project.addDefaultCar(carNameTxtBx.Text, Convert.ToInt32(yearMadeTxtBx.Text), carDescTxtBx.Text);
            lblProjSubmit.Text = "Project submitted.";
            lblProjSubmit.Visible = true;
        }

        protected void updateSubmitBtn_Click(object sender, EventArgs e)
        {
            int projID = 0;

            foreach (ProjectInfo info in ProjectInfo.getProjects())
            {
                if (info.Name == projNameDrpList.SelectedItem.ToString())
                {
                    projID = info.ProjectID;
                }
            }

            BusinessLogicLayer.ProjectInfo editProj = BusinessLogicLayer.ProjectInfo.getProject(projID);
            if (carNameTxtBx.Text != "")
            {
                editProj.Name = carNameTxtBx.Text;
            }

            if (yearMadeTxtBx.Text != "")
            {
                editProj.YearMade = Convert.ToInt32(yearMadeTxtBx.Text);
            }

            if (carDescTxtBx.Text != "")
            {
                editProj.Description = carDescTxtBx.Text;
            }

            editProj.IsActive = activeChkBx.Checked;

            editProj.Status = projStatusDrpList.SelectedItem.ToString();


            
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
            //lblCarName.Visible = false;
            //carNameTxtBx.Visible = false;
            //lblDesc.Visible = false;
            //carDescTxtBx.Visible = false;
            //lblYearMade.Visible = false;
            //yearMadeTxtBx.Visible = false;
            lblActive.Visible = true;
            activeChkBx.Visible = true;
            createProjFrm.Visible = true;
            submitProjBtn.Visible = false;
            updateSubmitBtn.Visible = true;
            projStatusDrpList.Visible = true;
            lblStatus.Visible = true;
            update = true;
          
        }
    }
}