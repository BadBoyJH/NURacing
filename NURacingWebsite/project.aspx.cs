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

        protected void Page_Load(object sender, EventArgs e)
        {
            createForm();
        }

        private void createForm()
        {
            createProjFrm.Controls.Add(new LiteralControl("<p>"));
            lblCarName.Text = "Car name: ";
            createProjFrm.Controls.Add(lblCarName);
            createProjFrm.Controls.Add(carNameTxtBx);
            carNameTxtBx.CssClass = "textareaPassword";
            createProjFrm.Controls.Add(new LiteralControl("</p>"));

            createProjFrm.Controls.Add(new LiteralControl("<p>"));
            lblYearMade.Text = "Year made: ";
            createProjFrm.Controls.Add(lblYearMade);
            createProjFrm.Controls.Add(yearMadeTxtBx);
            yearMadeTxtBx.CssClass = "textareaPassword";
            createProjFrm.Controls.Add(new LiteralControl("<p>"));

            createProjFrm.Controls.Add(new LiteralControl("<p>"));
            lblDesc.Text = "Car description: ";
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
    }
}