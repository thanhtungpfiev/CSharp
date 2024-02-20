using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    internal class BillDAO
    {
        private static BillDAO instance;

        internal static BillDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillDAO();
                return instance;
            }
            private set => instance = value;
        }

        private BillDAO()
        {

        }

        public int GetUncheckBillIDByTableId(int id)
        {
            string query = "SELECT * FROM dbo.Bill WHERE idTable = " + id + " AND status = 0";
            object result = DataProvider.Instance.ExecuteScalar(query);
            return result == null ? -1 : (int)result;
        }

        internal void InsertBillByTableId(int tableId)
        {
            string query = "exec USP_InsertBill @idTable";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { tableId });
        }

        internal int GetMaxIdBill()
        {
            string query = "SELECT MAX(id) FROM dbo.Bill";
            object result = DataProvider.Instance.ExecuteScalar(query);
            return result == null ? -1 : (int)result;
        }

        internal void CheckOut(int idBill)
        {
            string query = "UPDATE dbo.Bill SET status = 1 WHERE id = " + idBill;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
