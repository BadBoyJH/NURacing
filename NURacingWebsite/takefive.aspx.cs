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
        int redCount = 0;
        string[] usernames;
        TakeFiveResponse response;
        TakeFiveResponse[] responseArray;

        protected void Page_Load(object sender, EventArgs e)
        {
            takeFiveUserLstBx.SelectionMode = ListSelectionMode.Multiple;

            foreach (WorkTypeInfo type in BusinessLogicLayer.WorkTypeInfo.getAllWorkTypes())
            {
                if (type.Project.Name == type.Name)
                {
                    tkfvWorktypeDrpList.Items.Add(type.Project.Name);
                }
                else
                {
                    tkfvWorktypeDrpList.Items.Add(type.Project.Name + " - " + type.Name);
                }
            }

            foreach (UserInfo user in BusinessLogicLayer.UserInfo.getAllUsers())
            {
                takeFiveUserLstBx.Items.Add(user.UserName);
            }
        }

        protected void b1_CheckedChanged(object sender, EventArgs e)
        {
            red = true;
            redCount++;
        }

        protected void submitTakefiveBtn_Click(object sender, EventArgs e)
        {
            List<string> usernameList = new List<string>();
            List<TakeFiveResponse> responseList = new List<TakeFiveResponse>();
            bool updatable = true;

            foreach (ListItem item in takeFiveUserLstBx.Items)
            {
                if (item.Selected)
                {
                    usernameList.Add(item.ToString());
                }
            }

            int workID = 0;

            foreach (WorkTypeInfo type in BusinessLogicLayer.WorkTypeInfo.getAllWorkTypes())
            {
                if (type.Project.Name == type.Name)
                {
                    if (type.Project.Name == tkfvWorktypeDrpList.SelectedItem.ToString())
                    {
                        workID = type.WorkTypeID;
                        break;
                    }
                }
                else if (type.Project.Name + " - " + type.Name == tkfvWorktypeDrpList.SelectedItem.ToString())
                {
                    workID = type.WorkTypeID;
                    break;
                }
            }

            if (minWordTxtBx.Text != "")
            {
                updatable = false;
            }

            if (red)
            {

                if (b1.Checked && reason1TxtBx.Text != "")
                {
                    response.TakeFiveID = 1;
                    response.Response = reason1TxtBx.Text;
                    responseList.Add(response);
                }

                else if (b2.Checked && reason2TxtBx.Text != "")
                {
                    response.TakeFiveID = 2;
                    response.Response = reason2TxtBx.Text;
                    responseList.Add(response);
                }

                else if (b3.Checked && reason3TxtBx.Text != "")
                {
                    response.TakeFiveID = 3;
                    response.Response = reason3TxtBx.Text;
                    responseList.Add(response);
                }

                else if (b4.Checked && reason4TxtBx.Text != "")
                {
                    response.TakeFiveID = 4;
                    response.Response = reason4TxtBx.Text;
                    responseList.Add(response);
                }

                else if (b5.Checked & reason5TxtBx.Text != "")
                {
                    response.TakeFiveID = 5;
                    response.Response = reason5TxtBx.Text;
                    responseList.Add(response);
                }

                else if (a6.Checked && reason6TxtBx.Text != "")
                {
                    response.TakeFiveID = 6;
                    response.Response = reason6TxtBx.Text;
                    responseList.Add(response);
                }

                else if (a7.Checked && reason7TxtBx.Text != "")
                {
                    response.TakeFiveID = 7;
                    response.Response = reason7TxtBx.Text;
                    responseList.Add(response);
                }

                else if (b8.Checked && reason8TxtBx.Text != "")
                {
                    response.TakeFiveID = 8;
                    response.Response = reason8TxtBx.Text;
                    responseList.Add(response);
                }

                else if (a9.Checked && reason9TxtBx.Text != "")
                {
                    response.TakeFiveID = 9;
                    response.Response = reason9TxtBx.Text;
                    responseList.Add(response);
                }

                else if (b10.Checked && reason10TxtBx.Text != "")
                {
                    response.TakeFiveID = 10;
                    response.Response = reason10TxtBx.Text;
                    responseList.Add(response);
                }

                else if (b11.Checked && reason11TxtBx.Text != "")
                {
                    response.TakeFiveID = 11;
                    response.Response = reason11TxtBx.Text;
                    responseList.Add(response);
                }

                else if (a12.Checked && reason12TxtBx.Text != "")
                {
                    response.TakeFiveID = 12;
                    response.Response = reason12TxtBx.Text;
                    responseList.Add(response);
                }

                else if (b13.Checked && reason13TxtBx.Text != "")
                {
                    response.TakeFiveID = 13;
                    response.Response = reason13TxtBx.Text;
                    responseList.Add(response);
                }

                else
                {
                    updatable = false;
                }
            }


            if (updatable)
            {
                usernames = usernameList.ToArray();
                responseArray = responseList.ToArray();

                BusinessLogicLayer.Work.AddWork(usernames, takeFiveCal.SelectedDate, descTxtBx.Text, workID, Convert.ToInt32(minWordTxtBx.Text), responseArray);
                takeFiveSubmit.Visible = true;
            }
            else
            {
                takeFiveSubmit.Visible = false;
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ALERT", "<script>alert('Please enter a reason(s) for your answers.')</script>");
            }
        }
    }
}