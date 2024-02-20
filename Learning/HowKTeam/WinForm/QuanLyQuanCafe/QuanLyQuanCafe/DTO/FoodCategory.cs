using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    internal class FoodCategory
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public FoodCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public FoodCategory(DataRow row)
        {
            Id = (int)row["id"];
            Name = row["name"].ToString();
        }

    }
}
