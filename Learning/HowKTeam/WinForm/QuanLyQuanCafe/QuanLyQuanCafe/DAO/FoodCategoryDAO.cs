using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    internal class FoodCategoryDAO
    {
        private static FoodCategoryDAO instance;

        internal static FoodCategoryDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new FoodCategoryDAO();
                return instance;
            }
            private set => instance = value;
        }

        private FoodCategoryDAO()
        {

        }

        internal List<FoodCategory> GetListFoodCategory()
        {
            string query = "Select * from FoodCategory";
            List<FoodCategory> listFoodCategory = new List<FoodCategory>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                FoodCategory categoryFood = new FoodCategory(row);
                listFoodCategory.Add(categoryFood);
            }
            return listFoodCategory;
        }
    }
}
