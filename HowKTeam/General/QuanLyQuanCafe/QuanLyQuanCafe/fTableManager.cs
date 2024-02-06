using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fTableManager : Form
    {
        int currentBtnIndex = 0;
        public fTableManager()
        {
            InitializeComponent();
            LoadListTableFood();
            LoadListFoodCategory();
        }

        private void LoadListTableFood()
        {
            flowLayoutPanelTableFood.Controls.Clear();
            List<TableFood> listTableFood = TableFoodDAO.Instance.LoadListTable();
            foreach (TableFood tableFood in listTableFood)
            {
                Button btn = new Button()
                {
                    Width = TableFoodDAO.TableWidth,
                    Height = TableFoodDAO.TableHeight,
                };
                btn.Text = tableFood.Name + Environment.NewLine + tableFood.Status;
                switch (tableFood.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.LightPink;
                        break;
                }
                btn.Click += Btn_Click;
                btn.Tag = tableFood;
                flowLayoutPanelTableFood.Controls.Add(btn);
            }
        }

        void ShowBill(int tableId)
        {
            listViewBill.Items.Clear();
            List<DTO.Menu> listMenu = MenuDAO.Instance.GetListMenuByTableId(tableId);
            double totalPrice = 0;
            foreach (DTO.Menu menu in listMenu)
            {
                ListViewItem listViewItem = new ListViewItem(menu.Name.ToString());
                listViewItem.SubItems.Add(menu.Count.ToString());
                listViewItem.SubItems.Add(menu.Price.ToString());
                listViewItem.SubItems.Add(menu.TotalPrice.ToString());
                totalPrice += menu.TotalPrice;
                listViewBill.Items.Add(listViewItem);
            }
            textBoxTotalPrice.Text = totalPrice.ToString("c");

        }

        private void LoadListFoodCategory()
        {
            List<FoodCategory> listFoodCategory = new List<FoodCategory>();
            listFoodCategory = FoodCategoryDAO.Instance.GetListFoodCategory();
            comboBoxFoodCategory.DataSource = listFoodCategory;
            comboBoxFoodCategory.DisplayMember = "Name";
        }

        private void LoadListFoodByFoodCategoryId(int foodCategoryId)
        {
            List<Food> listFood = new List<Food>();
            listFood = FoodDAO.Instance.GetListFoodByCategoryId(foodCategoryId);
            comboBoxFood.DataSource = listFood;
            comboBoxFood.DisplayMember = "Name";
        }

        #region Methods

        #endregion

        #region Events
        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile();
            f.ShowDialog();

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.ShowDialog();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int index = flowLayoutPanelTableFood.Controls.IndexOf(clickedButton);
            currentBtnIndex = index;

            TableFood tableFood = (sender as Button).Tag as TableFood;
            int tableFoodId = tableFood.Id;
            listViewBill.Tag = tableFood;
            ShowBill(tableFoodId);
        }
        #endregion

        private void comboBoxFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int foodCategoryId = (comboBoxFoodCategory.SelectedItem as FoodCategory).Id;
            LoadListFoodByFoodCategoryId(foodCategoryId);
        }

        private void buttonAddFood_Click(object sender, EventArgs e)
        {
            TableFood tableFood = listViewBill.Tag as TableFood;
            if (tableFood != null)
            {
                int tableFoodId = tableFood.Id;

                int idBill = BillDAO.Instance.GetUncheckBillIDByTableId(tableFoodId);
                int idFood = (comboBoxFood.SelectedItem as Food).Id;
                int count = (int)numericUpDownFoodCount.Value;

                if (idBill == -1)
                {
                    BillDAO.Instance.InsertBillByTableId(tableFoodId);
                    BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIdBill(), idFood, count);
                }
                else
                {
                    BillInfoDAO.Instance.InsertBillInfo(idBill, idFood, count);
                }

                ShowBill(tableFoodId);

                LoadListTableFood();
            }
            
        }

        private void buttonCheckout_Click(object sender, EventArgs e)
        {
            TableFood tableFood = listViewBill.Tag as TableFood;

            if (tableFood != null)
            {
                int idBill = BillDAO.Instance.GetUncheckBillIDByTableId(tableFood.Id);
                if (idBill != -1)
                {
                    if (MessageBox.Show("Bạn có chắc thanh toán hóa đơn cho " + tableFood.Name, "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        BillDAO.Instance.CheckOut(idBill);
                        ShowBill(tableFood.Id);
                        LoadListTableFood();
                    }
                }
            }
            
        }

        private void fTableManager_Shown(object sender, EventArgs e)
        {
            if (flowLayoutPanelTableFood.Controls.Count > 0)
            {
                Button currentBtn = flowLayoutPanelTableFood.Controls[0] as Button;
                currentBtn.PerformClick();
            }
        }
    }
}
