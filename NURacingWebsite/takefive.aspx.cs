using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace NURacingWebsite
{
    public partial class takefive : System.Web.UI.Page
    {
        bool red = false;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void b1_CheckedChanged(object sender, EventArgs e)
        {
            red = true;
        }

        protected void takefiveBtn_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.TakeFiveResponse response = new BusinessLogicLayer.TakeFiveResponse();
            if (red && reasonTxtBx.Text != "")
            {

            }
            else
            {
                response.Response = reasonTxtBx.Text;
                BusinessLogicLayer.Work.
            }
        }
    }
}