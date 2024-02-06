using System.Data;

namespace QuanLyQuanCafe.DTO
{

    public class BillInfo
    {
        public int Id { get; set; }
        public int IdBill { get; set; }
        public int IdFood { get; set; }
        public int Count { get; set; }

        public BillInfo(int id, int idBill, int idFood, int count)
        {
            Id = id;
            IdBill = idBill;
            IdFood = idFood;
            Count = count;
        }

        public BillInfo(DataRow row)
        {
            Id = (int)row["id"];
            IdBill = (int)row["idBill"];
            IdFood = (int)row["idFood"];
            Count = (int)row["count"];
        }

    }
}