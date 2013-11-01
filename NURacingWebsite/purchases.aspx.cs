using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Web.Security;

namespace NURacingWebsite
{
    public partial class purchase : System.Web.UI.Page
    {
        bool addedItem = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            purchaseCal.DayRender += purchaseCal_DayRender;
            if (!IsPostBack || addedItem)
            {
                workTypeDrpList.Items.Clear();

                foreach (WorkTypeInfo type in BusinessLogicLayer.WorkTypeInfo.getAllWorkTypes())
                {
                    if (type.Project.Name == type.Name)
                    {
                        workTypeDrpList.Items.Add(type.Project.Name);
                    }
                    else
                    {
                        workTypeDrpList.Items.Add(type.Project.Name + " - " + type.Name);
                    }
                }

                addedItem = false;
            }
        }

        void purchaseCal_DayRender(object sender, DayRenderEventArgs e)
        {
            e.Day.IsSelectable = e.Day.Date <= DateTime.Now;
        }

        protected void purchaseBtn_Click(object sender, EventArgs e)
        {
            int workID = 0;

            foreach (WorkTypeInfo type in BusinessLogicLayer.WorkTypeInfo.getAllWorkTypes())
            {
                if (type.Project.Name == type.Name)
                {
                    if (type.Project.Name == workTypeDrpList.SelectedItem.ToString())
                    {
                        workID = type.WorkTypeID;
                        break;
                    }
                }
                else if(type.Project.Name + " - " + type.Name == workTypeDrpList.SelectedItem.ToString())
                {
                    workID = type.WorkTypeID;
                    break;
                }
            }
            
            if (workID == 0)
            {
            }

            BusinessLogicLayer.Purchase.addPurchase(Membership.GetUser().UserName, suppTxtBx.Text, goodTxtBx.Text, Convert.ToDecimal(priceTxtBx.Text), purchaseCal.SelectedDate, workID);

            addedItem = true;
        }
    }
}