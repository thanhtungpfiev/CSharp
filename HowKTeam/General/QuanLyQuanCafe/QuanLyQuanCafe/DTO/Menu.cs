using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    internal class Menu
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }

        public Menu(string name, int count, double price, double totalPrice = 0)
        {
            Name = name;
            Count = count;
            Price = price;
            TotalPrice = totalPrice;
        }

        public Menu(DataRow row)
        {
            Name = row["name"].ToString();
            Count = (int)row["count"];
            Price = Convert.ToDouble(row["price"]);
            TotalPrice = Convert.ToDouble(row["totalPrice"]);
        }


    }
}
