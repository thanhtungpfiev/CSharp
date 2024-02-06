using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    internal class TableFoodDAO
    {
        private static TableFoodDAO instance;

        public static int TableWidth = 90;
        public static int TableHeight = 90;

        internal static TableFoodDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new TableFoodDAO();
                return instance;
            }
            private set => instance = value;
        }

        private TableFoodDAO()
        {

        }

        public List<TableFood> LoadListTable()
        {
            string query = "USP_GetTableList";
            List<TableFood> listTable = new List<TableFood>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                TableFood table = new TableFood(row);
                listTable.Add(table);
            }
            return listTable;
        }
    }
}
