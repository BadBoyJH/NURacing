using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using DataAccessLayer.NuRacingDataSetTableAdapters;

namespace BusinessLogicLayer
{
    class PurchaseInfo
    {
        public PurchaseInfo(NuRacingDataSet.PurchaseRow purchaseRow)
        {
        }

        public static PurchaseInfo GetPurchase(int PurchaseID)
        {
            if (!Purchase.purchaseExists(PurchaseID))
            {
                throw new ArgumentException("Purchase doesn't exist");
            }
            
            PurchaseTableAdapter purchaseAdapter = new PurchaseTableAdapter();
            NuRacingDataSet.PurchaseDataTable purchaseTable = purchaseAdapter.GetDataByWorkTypeID(PurchaseID);

            return new PurchaseInfo((NuRacingDataSet.PurchaseRow) purchaseTable[0]);
        }

	    public static List<PurchaseInfo> GetProjectPurchases(int ProjectID)
        {
            List<PurchaseInfo> result = new List<PurchaseInfo>();

            PurchaseTableAdapter purchaseAdapter = new PurchaseTableAdapter();
            NuRacingDataSet.PurchaseDataTable purchaseTable = purchaseAdapter.GetDataByProjectID(ProjectID);

            foreach (NuRacingDataSet.PurchaseRow purchaseRow in purchaseTable.Rows)
            {
                result.Add(new PurchaseInfo(purchaseRow));
            }

            return result;
        }

	    public static List<PurchaseInfo> GetWorkTypePurchases(int WorkTypeID)
        {
            List<PurchaseInfo> result = new List<PurchaseInfo>();

            PurchaseTableAdapter purchaseAdapter = new PurchaseTableAdapter();
            NuRacingDataSet.PurchaseDataTable purchaseTable = purchaseAdapter.GetDataByWorkTypeID(WorkTypeID);

            foreach (NuRacingDataSet.PurchaseRow purchaseRow in purchaseTable.Rows)
            {
                result.Add(new PurchaseInfo(purchaseRow));
            }

            return result;
        }

        public static List<PurchaseInfo> GetUserPurchases(string Username)
        {
            List<PurchaseInfo> result = new List<PurchaseInfo>();

            PurchaseTableAdapter purchaseAdapter = new PurchaseTableAdapter();
            NuRacingDataSet.PurchaseDataTable purchaseTable = purchaseAdapter.GetDataByUsername(Username);

            foreach (NuRacingDataSet.PurchaseRow purchaseRow in purchaseTable)
            {
                result.Add(new PurchaseInfo(purchaseRow));
            }

            return result;
        }

	    public static List<PurchaseInfo> GetUserWorkTypePurchases(int WorkTypeID, string Username)
        {
            List<PurchaseInfo> WorkTypePurchases = GetWorkTypePurchases(WorkTypeID);
            List<PurchaseInfo> UserPurchases = GetUserPurchases(Username);

            return (List<PurchaseInfo>)UserPurchases.Intersect<PurchaseInfo>(WorkTypePurchases);

        }

        public static List<PurchaseInfo> GetUserProjectPurchases(int ProjectID, string Username)
        {
            List<PurchaseInfo> ProjectPurchases = GetProjectPurchases(ProjectID);
            List<PurchaseInfo> UserPurchases = GetUserPurchases(Username);

            return (List<PurchaseInfo>)UserPurchases.Intersect<PurchaseInfo>(ProjectPurchases);
        }
    }
}
