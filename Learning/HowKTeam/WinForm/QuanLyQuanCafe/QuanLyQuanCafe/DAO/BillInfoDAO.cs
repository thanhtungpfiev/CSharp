using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    internal class BillInfoDAO
    {
        private static BillInfoDAO instance;

        internal static BillInfoDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillInfoDAO();
                return instance;
            }
            private set => instance = value;
        }

        private BillInfoDAO()
        {

        }

        public List<BillInfo> GetListBillInfo(int id)
        {
            string query = "SELECT * FROM dbo.BillInfo WHERE idBill = " + id;
            List<BillInfo> listBillInfo = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                BillInfo info = new BillInfo(row);
                listBillInfo.Add(info);
            }
            return listBillInfo;
        }

        internal void InsertBillInfo(int idBill, int idFood, int count)
        {
            string query = "USP_InsertBillInfo @idBill , @idFood , @count";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { idBill, idFood, count });
        }
    }
}
