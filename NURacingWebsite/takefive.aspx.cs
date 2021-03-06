﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BusinessLogicLayer;

namespace NURacingWebsite
{
    public partial class takefive : System.Web.UI.Page
    {
        string[] usernames;
        TakeFiveResponse response;
        TakeFiveResponse[] responseArray;

        protected void Page_Load(object sender, EventArgs e)
        {
            takeFiveUserLstBx.SelectionMode = ListSelectionMode.Multiple;

            try
            {
                TaskInfo task = task = TaskInfo.getAssignedTask(Convert.ToInt32(Request.Params.Get("taskID")));

                bool found = false;

                foreach (UserInfo user in task.UserAssignedInfo)
                {
                    if (user.UserName == Membership.GetUser().UserName)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Response.Redirect("accessdenied.aspx");
                }

                taskInfo.InnerText = String.Format("You are logging work done for task {0:s}.", task.TaskName);
                taskInfo.Visible = true;
                if (task.TakeFiveNeeded)
                {
                    takeFiveNo.Enabled = false;
                    takeFiveYes.Checked = true;
                    takeFiveYes.Enabled = false;
                }
                else
                {
                    takeFiveNo.Checked = true;
                }
            }
            catch(Exception)
            {
                Response.Redirect("/index.aspx");
            }

            takeFiveUserLstBx.Items.Clear();
            foreach (UserInfo user in BusinessLogicLayer.UserInfo.getAllUsers())
            {
                if (user.UserName != Membership.GetUser().UserName && user.UserRole != "Sponsor")
                {
                    takeFiveUserLstBx.Items.Add(user.UserName);
                }
            }
        }

        protected void submitTakefiveBtn_Click(object sender, EventArgs e)
        {
            List<string> usernameList = new List<string>();
            List<TakeFiveResponse> responseList = new List<TakeFiveResponse>();

            usernameList.Add(Membership.GetUser().UserName);

            foreach (ListItem item in takeFiveUserLstBx.Items)
            {
                if (item.Selected)
                {
                    usernameList.Add(item.ToString());
                }
            }
            
            bool validTakeFive = true;
            if (takeFiveYes.Checked)
            {
                if (b1.Checked && reason1TxtBx.Text != "")
                {
                    response.TakeFiveID = 1;
                    response.Response = reason1TxtBx.Text;
                    responseList.Add(response);
                }
                else if (b1.Checked)
                {
                    validTakeFive = false;
                }

                if (b2.Checked && reason2TxtBx.Text != "")
                {
                    response.TakeFiveID = 2;
                    response.Response = reason2TxtBx.Text;
                    responseList.Add(response);
                }
                else if (b2.Checked)
                {
                    validTakeFive = false;
                }

                if (b3.Checked && reason3TxtBx.Text != "")
                {
                    response.TakeFiveID = 3;
                    response.Response = reason3TxtBx.Text;
                    responseList.Add(response);
                }
                else if (b3.Checked)
                {
                    validTakeFive = false;
                }

                if (b4.Checked && reason4TxtBx.Text != "")
                {
                    response.TakeFiveID = 4;
                    response.Response = reason4TxtBx.Text;
                    responseList.Add(response);
                }
                else if (b4.Checked)
                {
                    validTakeFive = false;
                }

                if (b5.Checked & reason5TxtBx.Text != "")
                {
                    response.TakeFiveID = 5;
                    response.Response = reason5TxtBx.Text;
                    responseList.Add(response);
                }
                else if (b5.Checked)
                {
                    validTakeFive = false;
                }

                if (a6.Checked && reason6TxtBx.Text != "")
                {
                    response.TakeFiveID = 6;
                    response.Response = reason6TxtBx.Text;
                    responseList.Add(response);
                }
                else if (a6.Checked)
                {
                    validTakeFive = false;
                }

                if (a7.Checked && reason7TxtBx.Text != "")
                {
                    response.TakeFiveID = 7;
                    response.Response = reason7TxtBx.Text;
                    responseList.Add(response);
                }
                else if (a7.Checked)
                {
                    validTakeFive = false;
                }

                if (b8.Checked && reason8TxtBx.Text != "")
                {
                    response.TakeFiveID = 8;
                    response.Response = reason8TxtBx.Text;
                    responseList.Add(response);
                }
                else if (b8.Checked)
                {
                    validTakeFive = false;
                }

                if (a9.Checked && reason9TxtBx.Text != "")
                {
                    response.TakeFiveID = 9;
                    response.Response = reason9TxtBx.Text;
                    responseList.Add(response);
                }
                else if (a9.Checked)
                {
                    validTakeFive = false;
                }

                if (b10.Checked && reason10TxtBx.Text != "")
                {
                    response.TakeFiveID = 10;
                    response.Response = reason10TxtBx.Text;
                    responseList.Add(response);
                }
                else if (b10.Checked)
                {
                    validTakeFive = false;
                }

                if (b11.Checked && reason11TxtBx.Text != "")
                {
                    response.TakeFiveID = 11;
                    response.Response = reason11TxtBx.Text;
                    responseList.Add(response);
                }
                else if (b11.Checked)
                {
                    validTakeFive = false;
                }

                if (a12.Checked && reason12TxtBx.Text != "")
                {
                    response.TakeFiveID = 12;
                    response.Response = reason12TxtBx.Text;
                    responseList.Add(response);
                }
                else if (a12.Checked)
                {
                    validTakeFive = false;
                }

                if (b13.Checked && reason13TxtBx.Text != "")
                {
                    response.TakeFiveID = 13;
                    response.Response = reason13TxtBx.Text;
                    responseList.Add(response);
                }
                else if (b13.Checked)
                {
                    validTakeFive = false;
                }
            }

            if (validTakeFive)
            {
                usernames = usernameList.ToArray();
                responseArray = responseList.ToArray();

                int TaskID = 0;
                int MinsWorked = 0;
                bool didConvert = true;

                try
                {
                    TaskID = Convert.ToInt32(Request.Params.Get("taskID"));
                    MinsWorked = Convert.ToInt32(minWordTxtBx.Text);
                }
                catch (Exception)
                {
                    didConvert = false;
                    takeFiveSubmit.Visible = false;
                    takeFiveFail.InnerText = "Please input a valid number for minutes worked";
                    takeFiveFail.Visible = true;
                }
                if(didConvert)
                {
                    if(takeFiveCal.SelectedDate != null)
                    {
                        if (takeFiveYes.Checked)
                        {
                            BusinessLogicLayer.Work.CompleteTask(usernames, takeFiveCal.SelectedDate, TaskID, descTxtBx.Text, MinsWorked, responseArray);
                        }
                        else
                        {
                            BusinessLogicLayer.Work.CompleteTask(usernames, takeFiveCal.SelectedDate, TaskID, descTxtBx.Text, MinsWorked, false);
                        }

                        takeFiveSubmit.Visible = true;
                    }
                    else
                    {
                    takeFiveSubmit.Visible = false;
                    takeFiveFail.InnerText = "Please select a date.";
                    takeFiveFail.Visible = true;
                    }
                }
            }
            else
            {
                takeFiveSubmit.Visible = false;
                takeFiveFail.InnerText = "Please enter a reason(s) for take five responses.";
                takeFiveFail.Visible = true;
            }
        }
    }
}