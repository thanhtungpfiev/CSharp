using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    internal class TableFood
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public TableFood(int id, string name, string status)
        {
            Id = id;
            Name = name;
            Status = status;
        }
        public TableFood(DataRow row)
        {
            Id = (int)row["id"];
            Name = row["name"].ToString();
            Status = row["status"].ToString();
        }
    }
}
