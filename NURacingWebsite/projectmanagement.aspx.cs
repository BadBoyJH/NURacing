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
        Label lblProjSubmit = new Label();
        Label lblActive = new Label();
        CheckBox activeChkBx = new CheckBox();

        bool update;

        protected void Page_Init(object sender, EventArgs e)
        {
            createForm();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.Params.Get("create") == "true")
            {
                submitProj.Text = "Project created.";
                submitProj.Visible = true;
            }

            if (Request.Params.Get("update") == "true")
            {
                submitProj.Text = "Project updated.";
                submitProj.Visible = true;
            }

            if (Request.Params.Get("bigredcar") == "toottootchuggachugga")
            {
                Response.Redirect("http://www.youtube.com/watch?v=BUINIvlJf2Y");
            }
        }

        private void createForm()
        {
            createProjFrm.Controls.Clear();

            createProjFrm.Controls.Add(new LiteralControl("<p>"));
            lblProjSubmit.CssClass = "submitLbl";
            lblProjSubmit.Visible = true;
            createProjFrm.Controls.Add(lblProjSubmit);
            createProjFrm.Controls.Add(new LiteralControl("</p> "));

            projNameDrpList.Items.Clear();

            foreach (ProjectInfo project in BusinessLogicLayer.ProjectInfo.getProjects(false))
            {
                if (project.Name != "Workshop")
                {
                    projNameDrpList.Items.Add(project.Name);
                }
            }

            projNameDrpList.SelectedIndexChanged += projNameDrpList_SelectedIndexChanged;
            projNameDrpList.AutoPostBack = true;
            createProjFrm.Controls.Add(new LiteralControl("<p>"));
            lblCarNameList.Text = "Project: ";
            createProjFrm.Controls.Add(lblCarNameList);
            createProjFrm.Controls.Add(projNameDrpList);
            projNameDrpList.SelectedIndex = 0;
            projNameDrpList.CssClass = "drpList";
            projNameDrpList.BackColor = System.Drawing.ColorTranslator.FromHtml("#2D2D2D");
            projNameDrpList.ForeColor = System.Drawing.ColorTranslator.FromHtml("#7E7E7E");
            projNameDrpList.Font.Name = "Lucida Sans Unicode";
            projNameDrpList.Font.Size = 11;
            projNameDrpList.BorderStyle = BorderStyle.None;
            projNameDrpList.Height = 25;
            createProjFrm.Controls.Add(new LiteralControl("</p> "));
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
            createProjFrm.Controls.Add(new LiteralControl("</p> "));
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
            projStatusDrpList.Items.Add("Not Started");
            projStatusDrpList.Items.Add("Planning");
            projStatusDrpList.Items.Add("Designing");
            projStatusDrpList.Items.Add("Design Completed");
            projStatusDrpList.Items.Add("Building Commenced");
            projStatusDrpList.Items.Add("Bulding Finished");
            projStatusDrpList.Items.Add("Fit and Finish Completed");
            projStatusDrpList.Items.Add("Ready For Assembly");
            projStatusDrpList.Items.Add("Testing");
            projStatusDrpList.Items.Add("Complete");
            projStatusDrpList.Items.Add("Ongoing");
            projStatusDrpList.Items.Add("On Hold");

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
            createProjFrm.Controls.Add(new LiteralControl("</p> "));
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
            createProjFrm.Controls.Add(new LiteralControl("</p> "));

            createProjFrm.Controls.Add(new LiteralControl("<p>"));
            lblActive.Text = "Is Project Active? ";
            lblActive.Visible = false;
            activeChkBx.Visible = false;
            createProjFrm.Controls.Add(lblActive);
            createProjFrm.Controls.Add(activeChkBx);
            createProjFrm.Controls.Add(new LiteralControl("</p> "));

            createProjFrm.Controls.Add(new LiteralControl("<p>"));
            lblDesc.Text = "Description: ";
            createProjFrm.Controls.Add(lblDesc);
            createProjFrm.Controls.Add(carDescTxtBx);
            carDescTxtBx.CssClass = "textareaPassword";
            carDescTxtBx.TextMode = TextBoxMode.MultiLine;
            createProjFrm.Controls.Add(new LiteralControl("</p> "));
            updateProjBtn.Visible = projNameDrpList.Items.Count != 0;
        }

        protected void submitProjBtn_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.Project.addDefaultCar(carNameTxtBx.Text, Convert.ToInt32(yearMadeTxtBx.Text), carDescTxtBx.Text);
            lblProjSubmit.Text = "Project submitted.";
            lblProjSubmit.ForeColor = System.Drawing.ColorTranslator.FromHtml("#7E7E7E");
            lblProjSubmit.Visible = true;
            submitProj.Visible = true;
            submitProjBtn.Visible = false;
            updateProjBtn.Visible = false;
            Response.Redirect("/projectmanagement.aspx?create=true");
        }

        protected void updateSubmitBtn_Click(object sender, EventArgs e)
        {
            int projID = 0;

            foreach (ProjectInfo info in ProjectInfo.getProjects(false))
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

            editProj.updateDatabase();

            lblProjSubmit.Text = "Project updated.";

            submitProj.Visible = true;

            createProjFrm.Controls.Clear();

            submitProjBtn.Visible = false;
            updateProjBtn.Visible = false;
            Response.Redirect("/projectmanagement.aspx?update=" + "true");
        }

        protected void createProjBtn_Click(object sender, EventArgs e)
        {
            submitProj.Visible = false;
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
            update = false;

            carNameTxtBx.Text = "";
            projStatusDrpList.SelectedIndex = 0;
            yearMadeTxtBx.Text = "";
            activeChkBx.Checked = false;
            carDescTxtBx.Text = "";
        }

        public void formUpdateProjectShowing()
        {
            submitProj.Visible = false;
            lblCarNameList.Visible = true;
            projNameDrpList.Visible = true;
            lblCarName.Visible = true;
            carNameTxtBx.Visible = true;
            lblActive.Visible = true;
            activeChkBx.Visible = true;
            createProjFrm.Visible = true;
            submitProjBtn.Visible = false;
            updateSubmitBtn.Visible = true;
            projStatusDrpList.Visible = true;
            lblStatus.Visible = true;
            update = true;
        }

        protected void updateProjBtn_Click(object sender, EventArgs e)
        {
            formUpdateProjectShowing();
            fillData();
        }

        public void fillData()
        {
            int projID = 0;

            foreach (ProjectInfo info in ProjectInfo.getProjects(false))
            {
                if (info.Name == projNameDrpList.SelectedItem.ToString())
                {
                    projID = info.ProjectID;
                }
            }

            BusinessLogicLayer.ProjectInfo editProj = BusinessLogicLayer.ProjectInfo.getProject(projID);

            carNameTxtBx.Text = editProj.Name;
            yearMadeTxtBx.Text = editProj.YearMade.HasValue ? Convert.ToString(editProj.YearMade.Value) : "";
            carDescTxtBx.Text = editProj.Description;
            activeChkBx.Checked = editProj.IsActive;
            projStatusDrpList.SelectedValue = editProj.Status;
        }

        void projNameDrpList_SelectedIndexChanged(object sender, EventArgs e)
        {
            formUpdateProjectShowing();
            fillData();
        }

    }
}