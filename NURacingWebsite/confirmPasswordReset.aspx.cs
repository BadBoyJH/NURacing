using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BusinessLogicLayer;

namespace NURacingWebsite
{
    public partial class createNewPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            confirmResetSuccess.Visible = false;
            confirmResetFail.Visible = false;

            if (Request.Params.Get("rrid") == null)
            {
                confirmResetFail.Visible = true;
            }

            else
            {
                try
                {
                    if (BusinessLogicLayer.User.generateNewPassword(Request.Params.Get("rrid"))) //Email sent
                    {
                        confirmResetSuccess.Visible = true;
                    }

                    else //Email not sent
                    {
                        confirmResetFail.Visible = true;
                    }
                }

                catch //Argumemt exception for expired reset link
                {
                    confirmResetFail.Visible = true;
                }
            }
        }
    }
}