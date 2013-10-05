using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

namespace NURacingWebsite
{
    public partial class todo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.getData("SELECT assignedtask.Task_Name, assignedtask.duedate FROM assignedtask, [work] WHERE work.User_Username = assignedtask.User_Username_AssignedTo");
        }

        public DataSet getData(String query)
        {
            //test database to test out the formatting.
            String sConn = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source = \"" + "C:/Users/Callan/Source/Repos/NURacing/NURacingWebsite/testDB.accdb" + "\"";
            OleDbConnection dbConn = new OleDbConnection(sConn);
            dbConn.Open();
            OleDbCommand dbCommand = new OleDbCommand(query, dbConn);
            OleDbDataAdapter dbAdapter = new OleDbDataAdapter(dbCommand);
            DataSet table = new DataSet();
            dbAdapter.Fill(table);
            todoTable.DataSource = table;
            todoTable.DataBind();
            return table;
        }

    }
}