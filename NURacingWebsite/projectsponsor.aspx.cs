using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NURacingWebsite
{
    public partial class projectsponsors : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            validateParameters();

            createForm();
        }

        private void createForm()
        {
            BusinessLogicLayer.ProjectInfo projectInfo = BusinessLogicLayer.ProjectInfo.getProject(Convert.ToInt32(Request.Params.Get("id")));
            ProjectName.InnerText = projectInfo.Name;

            hasSponsors.Visible = projectInfo.Sponsors.Count != 0;

            SponsorList.Items.Clear();
            ddlRemoveSponsor.Items.Clear();
            foreach (BusinessLogicLayer.UserInfo user in projectInfo.Sponsors)
            {
                SponsorList.Items.Add(user.UserName);
                ddlRemoveSponsor.Items.Add(user.UserName);
                noSponsors.Visible = false;
            }

            ddlAddSponsor.Items.Clear();
            foreach (string username in BusinessLogicLayer.Role.getUsersInRole("Sponsor"))
            {
                bool found = false;
                foreach (BusinessLogicLayer.UserInfo userInfo in projectInfo.Sponsors)
                {
                    if (userInfo.UserName == username)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    ddlAddSponsor.Items.Add(username);
                }
            }

            btnRemoveSponsor.Visible = ddlRemoveSponsor.Items.Count != 0;
        }

        private void validateParameters()
        {
            try
            {
                int ProjectID = Convert.ToInt32(Request.Params.Get("id"));
                BusinessLogicLayer.ProjectInfo project = BusinessLogicLayer.ProjectInfo.getProject(ProjectID);
                if (project.Name == "Workshop")
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

        protected void btnAddSponsor_Click(object sender, EventArgs e)
        {
            if (ddlAddSponsor.Items.Count == 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ALERT", "<script>alert('Either all the sponsors registered in the server are already registered on this project, or there are no sponsors in the system.')</script>");
                Response.AddHeader("REFRESH", "1;URL=/section.aspx?id=" + Request.Params.Get("id"));
            }
            else
            {
                divAddSponsor.Visible = true;
                divRemoveSponsor.Visible = false;
            }
        }

        protected void btnRemoveSponsor_Click(object sender, EventArgs e)
        {
            divRemoveSponsor.Visible = true;
            divAddSponsor.Visible = false;

        }

        protected void btnSubmitAdd_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.Sponsor.AddSponsor(ddlAddSponsor.SelectedValue, Convert.ToInt32(Request.Params.Get("id")));
            createForm();
            divAddSponsor.Visible = false;
            divRemoveSponsor.Visible = false;
        }

        protected void btnSubmitRemove_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.Sponsor.RemoveSponsor(ddlRemoveSponsor.SelectedValue, Convert.ToInt32(Request.Params.Get("id")));
            createForm();
            divAddSponsor.Visible = false;
            divRemoveSponsor.Visible = false;
        }
    }
}