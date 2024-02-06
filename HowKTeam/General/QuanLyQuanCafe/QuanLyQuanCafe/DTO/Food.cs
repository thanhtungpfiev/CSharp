using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    internal class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdFoodCategory { get; set; }
        public double Price { get; set; }

        public Food(int id, string name, int idFoodCategory, double price)
        {
            Id = id;
            Name = name;
            IdFoodCategory = idFoodCategory;
            Price = price;
        }
        public Food(DataRow row)
        {
            Id = (int)row["id"];
            Name = row["name"].ToString();
            IdFoodCategory = (int)row["idFoodCategory"];
            Price = Convert.ToDouble(row["price"]);
        }
    }
}
