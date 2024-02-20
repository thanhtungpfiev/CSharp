using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    internal class AccountDAO
    {
        private static AccountDAO instance;

        internal static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountDAO();
                return instance;
            }
            private set => instance = value;
        }

        private AccountDAO()
        {

        }

        public bool Login(string userName, string passWord)
        {
            string query = "USP_Login @userName , @passWord";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[]
            {
                userName, passWord
            }
                );
            return data.Rows.Count > 0;
        }
    }
}
