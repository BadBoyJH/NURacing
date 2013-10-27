using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using DataAccessLayer.NuRacingDataSetTableAdapters;

namespace BusinessLogicLayer
{
    class Purchase
    {
        public static bool purchaseExists(int PurchaseID)
        {
            return ((new PurchaseTableAdapter()).GetPurchase(PurchaseID).Rows.Count != 0);
        }

        public static void addPurchase(string Username, string Supplier, string GoodPurchased, decimal totalPrice, int WorkTypeID)
        {
            PurchaseTableAdapter purchaseAdapter = new PurchaseTableAdapter();
            NuRacingDataSet.PurchaseDataTable purchaseTable = purchaseAdapter.GetData();

            NuRacingDataSet.PurchaseRow newPurchaseRow = purchaseTable.NewPurchaseRow();

            newPurchaseRow.Purchase_Good = GoodPurchased;
            newPurchaseRow.Purchase_Supplier = Supplier;
            newPurchaseRow.Purchase_TotalPrice = totalPrice;
            newPurchaseRow.User_Username = Username;
            newPurchaseRow.WorkType_UID = WorkTypeID;

            purchaseTable.AddPurchaseRow(newPurchaseRow);
            purchaseAdapter.Update(purchaseTable);
        }
    }
}
