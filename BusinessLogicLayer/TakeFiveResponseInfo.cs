using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using DataAccessLayer.NuRacingDataSetTableAdapters;

namespace BusinessLogicLayer
{
    class TakeFiveResponseInfo
    {
        private string responseTo;
        private string response;

        public string ResponseTo
        {
            get
            {
                return responseTo;
            }
        }

        public string Response
        {
            get
            {
                return response;
            }
        }

        public TakeFiveResponseInfo(NuRacingDataSet.takefiveresponseRow row)
        {
            responseTo = TakeFive.getTakeFiveQuestion(row.TakeFive_UID);
            response = row.TakeFiveResponse_Reason;
        }

        // Created by James Hibbard
        /// <summary>
        ///     Returns all resposnes for a given WorkID
        /// </summary>
        /// <param name="WorkID">The WorkID to get the responses for</param>
        /// <returns>A list of the responses, and their question</returns>
        public static List<TakeFiveResponseInfo> getWorkResponses(int WorkID)
        {
            if (!Work.WorkExists(WorkID))
            {
                throw new ArgumentException("Work ID wasn't valid");
            }
            List<TakeFiveResponseInfo> result = new List<TakeFiveResponseInfo>();

            takefiveresponseTableAdapter responseAdapter = new takefiveresponseTableAdapter();
            NuRacingDataSet.takefiveresponseDataTable responseTable = responseAdapter.GetDataByWorkID(WorkID);

            foreach (NuRacingDataSet.takefiveresponseRow responseRow in responseTable.Rows)
            {
                result.Add(new TakeFiveResponseInfo(responseRow));
            }

            return result;
        }
    }
}
