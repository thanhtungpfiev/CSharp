using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    internal class FoodDAO
    {
        private static FoodDAO instance;

        internal static FoodDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new FoodDAO();
                return instance;
            }
            private set => instance = value;
        }

        private FoodDAO()
        {

        }

        public List<Food> LoadListFood()
        {
            string query = "";
            List<Food> listFood = new List<Food>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                Food food = new Food(row);
                listFood.Add(food);
            }
            return listFood;
        }

        internal List<Food> GetListFoodByCategoryId(int foodCategoryId)
        {
            string query = "SELECT * FROM Food WHERE idFoodCategory = " + foodCategoryId;
            List<Food> listFood = new List<Food>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                Food food = new Food(row);
                listFood.Add(food);
            }
            return listFood;
        }
    }
}
