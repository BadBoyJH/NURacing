using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using DataAccessLayer.NuRacingDataSetTableAdapters;

namespace BusinessLogicLayer
{
    class TakeFive
    {
        public static string getTakeFiveQuestion(int TakeFiveID)
        {
            takefiveTableAdapter takefiveAdapter = new takefiveTableAdapter();
            NuRacingDataSet.takefiveDataTable takeFiveTable = takefiveAdapter.GetTakeFive(TakeFiveID);

            if (takeFiveTable.Rows.Count == 0)
            {
                throw new ArgumentException("Take Five record doesn't exist");
            }
            else
            {
                return ((NuRacingDataSet.takefiveRow)(takeFiveTable.Rows[0])).TakeFive_Question;
            }
        }
    }
}
