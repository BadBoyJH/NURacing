﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using DataAccessLayer.NuRacingDataSetTableAdapters;

namespace BusinessLogicLayer
{
    public class TakeFive
    {
        // Written By James Hibbard
        /// <summary>
        ///     Returns the Question associated with the TakeFiveID
        /// </summary>
        /// <param name="TakeFiveID">A Unique ID from the TakeFive table</param>
        /// <returns>The related Question</returns>
        public static string getTakeFiveQuestion(int TakeFiveID)
        {
            TakeFiveTableAdapter takefiveAdapter = new TakeFiveTableAdapter();
            NuRacingDataSet.TakeFiveDataTable takeFiveTable = takefiveAdapter.GetTakeFive(TakeFiveID);

            if (takeFiveTable.Rows.Count == 0)
            {
                throw new ArgumentException("Take Five record doesn't exist");
            }
            else
            {
                return ((NuRacingDataSet.TakeFiveRow)(takeFiveTable.Rows[0])).TakeFive_Question;
            }
        }
    }
}
