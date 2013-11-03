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
        Label secSub = new Label();

        protected void Pre_Init(object sender, EventArgs e)
        {
            createForm();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            verifyParameters();
        }

        private void createForm()
        {
            projNameDrpList.Items.Clear();

            createProjFrm.Controls.Add(new LiteralControl("<p>"));
            secSub.Text = "Section updated.";
            secSub.Visible = false;
            secSub.CssClass = "submitLbl";
            createProjFrm.Controls.Add(secSub);
            createProjFrm.Controls.Add(new LiteralControl("</p>"));

            foreach (ProjectInfo project in BusinessLogicLayer.ProjectInfo.getProjects())
            {
                projNameDrpList.Items.Add(project.Name);
            }
            createProjFrm.Controls.Add(new LiteralControl("<p>"));
            lblCarNameList.Text = "Project Name: ";
            createProjFrm.Controls.Add(lblCarNameList);
            foreach (WorkTypeInfo type in BusinessLogicLayer.WorkTypeInfo.getProjectWorkTypes(Convert.ToInt32(Request.Params.Get("id"))))
            {
                if (type.Project.Name != type.Name && type.Name != null)
                {
                    projNameDrpList.Items.Add(type.Project.Name + " - " + type.Name);
                }
            }
            createProjFrm.Controls.Add(projNameDrpList);
            projNameDrpList.CssClass = "drpList";
            projNameDrpList.BackColor = System.Drawing.ColorTranslator.FromHtml("#2D2D2D");
            projNameDrpList.ForeColor = System.Drawing.ColorTranslator.FromHtml("#7E7E7E");
            projNameDrpList.Font.Name = "Lucida Sans Unicode";
            projNameDrpList.Font.Size = 11;
            projNameDrpList.BorderStyle = BorderStyle.None;
            projNameDrpList.Height = 25;
            createProjFrm.Controls.Add(new LiteralControl("</p> <br />"));

            projStatusDrpList.Items.Clear();
            projStatusDrpList.Items.Add("Not Started");
            projStatusDrpList.Items.Add("Planning");
            projStatusDrpList.Items.Add("Designing");
            projStatusDrpList.Items.Add("Design Completed");
            projStatusDrpList.Items.Add("Building Commenced");
            projStatusDrpList.Items.Add("Bulding Finished");
            projStatusDrpList.Items.Add("Completed");
            projStatusDrpList.Items.Add("Fit and Finish Completed");
            projStatusDrpList.Items.Add("Ready For Assembly");
            projStatusDrpList.Items.Add("Testing");
            projStatusDrpList.Items.Add("Complete");
            projStatusDrpList.Items.Add("Ongoing");
            projStatusDrpList.Items.Add("On Hold");

            createProjFrm.Controls.Add(new LiteralControl("<p>"));
            lblStatus.Text = "Set Section Status: ";
            createProjFrm.Controls.Add(lblStatus);
            createProjFrm.Controls.Add(projStatusDrpList);
            projStatusDrpList.BackColor = System.Drawing.ColorTranslator.FromHtml("#2D2D2D");
            projStatusDrpList.ForeColor = System.Drawing.ColorTranslator.FromHtml("#7E7E7E");
            projStatusDrpList.Font.Name = "Lucida Sans Unicode";
            projStatusDrpList.Font.Size = 11;
            projStatusDrpList.BorderStyle = BorderStyle.None;
            projStatusDrpList.Height = 25;
            createProjFrm.Controls.Add(new LiteralControl("</p> <br />"));
          
        }

        private void verifyParameters()
        {
            try
            {
                int ID = Convert.ToInt32(Request.Params.Get("id"));
                if (!Project.projectExists(ID))
                {
                    Response.Clear();
                    Response.StatusCode = 400;
                    Response.End();
                }
            }
            catch (Exception)
            {
                Response.Clear();
                Response.StatusCode = 400;
                Response.End();
            }
        }

        protected void updateSubmitBtn_Click(object sender, EventArgs e)
        {
            int workID = 0;
            foreach (WorkTypeInfo type in BusinessLogicLayer.WorkTypeInfo.getAllWorkTypes())
            {
                if (type.Project.Name == type.Name)
                {
                    if (type.Project.Name == projNameDrpList.SelectedItem.ToString())
                    {
                        workID = type.WorkTypeID;
                        break;
                    }
                }
                else if (type.Project.Name + " - " + type.Name == projNameDrpList.SelectedItem.ToString())
                {
                    workID = type.WorkTypeID;
                    break;
                }
            }

            WorkType.ChangeStatus(workID, projStatusDrpList.SelectedItem.ToString());

            secSub.Visible = true;

        }

    }
}