using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    partial class fTableManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanelTableFood = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numericUpDownFoodCount = new System.Windows.Forms.NumericUpDown();
            this.buttonAddFood = new System.Windows.Forms.Button();
            this.comboBoxFood = new System.Windows.Forms.ComboBox();
            this.comboBoxFoodCategory = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listViewBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTotalPrice = new System.Windows.Forms.TextBox();
            this.comboBoxSwitchTable = new System.Windows.Forms.ComboBox();
            this.buttonSwitchTable = new System.Windows.Forms.Button();
            this.numericUpDownDiscount = new System.Windows.Forms.NumericUpDown();
            this.buttonDiscount = new System.Windows.Forms.Button();
            this.buttonCheckout = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFoodCount)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDiscount)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanelTableFood);
            this.panel1.Location = new System.Drawing.Point(12, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 617);
            this.panel1.TabIndex = 0;
            // 
            // flowLayoutPanelTableFood
            // 
            this.flowLayoutPanelTableFood.AutoScroll = true;
            this.flowLayoutPanelTableFood.Location = new System.Drawing.Point(3, 4);
            this.flowLayoutPanelTableFood.Name = "flowLayoutPanelTableFood";
            this.flowLayoutPanelTableFood.Size = new System.Drawing.Size(543, 610);
            this.flowLayoutPanelTableFood.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinTàiKhoảnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1074, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(151, 24);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.numericUpDownFoodCount);
            this.panel2.Controls.Add(this.buttonAddFood);
            this.panel2.Controls.Add(this.comboBoxFood);
            this.panel2.Controls.Add(this.comboBoxFoodCategory);
            this.panel2.Location = new System.Drawing.Point(567, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(495, 64);
            this.panel2.TabIndex = 2;
            // 
            // numericUpDownFoodCount
            // 
            this.numericUpDownFoodCount.Location = new System.Drawing.Point(427, 21);
            this.numericUpDownFoodCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownFoodCount.Name = "numericUpDownFoodCount";
            this.numericUpDownFoodCount.Size = new System.Drawing.Size(56, 22);
            this.numericUpDownFoodCount.TabIndex = 3;
            this.numericUpDownFoodCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonAddFood
            // 
            this.buttonAddFood.AutoSize = true;
            this.buttonAddFood.Location = new System.Drawing.Point(335, 4);
            this.buttonAddFood.Name = "buttonAddFood";
            this.buttonAddFood.Size = new System.Drawing.Size(86, 54);
            this.buttonAddFood.TabIndex = 2;
            this.buttonAddFood.Text = "Thêm món";
            this.buttonAddFood.UseVisualStyleBackColor = true;
            this.buttonAddFood.Click += new System.EventHandler(this.buttonAddFood_Click);
            // 
            // comboBoxFood
            // 
            this.comboBoxFood.FormattingEnabled = true;
            this.comboBoxFood.Location = new System.Drawing.Point(4, 34);
            this.comboBoxFood.Name = "comboBoxFood";
            this.comboBoxFood.Size = new System.Drawing.Size(325, 24);
            this.comboBoxFood.TabIndex = 1;
            // 
            // comboBoxFoodCategory
            // 
            this.comboBoxFoodCategory.FormattingEnabled = true;
            this.comboBoxFoodCategory.Location = new System.Drawing.Point(4, 4);
            this.comboBoxFoodCategory.Name = "comboBoxFoodCategory";
            this.comboBoxFoodCategory.Size = new System.Drawing.Size(325, 24);
            this.comboBoxFoodCategory.TabIndex = 0;
            this.comboBoxFoodCategory.SelectedIndexChanged += new System.EventHandler(this.comboBoxFoodCategory_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.listViewBill);
            this.panel3.Location = new System.Drawing.Point(567, 101);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(498, 463);
            this.panel3.TabIndex = 3;
            // 
            // listViewBill
            // 
            this.listViewBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewBill.GridLines = true;
            this.listViewBill.HideSelection = false;
            this.listViewBill.Location = new System.Drawing.Point(3, 3);
            this.listViewBill.Name = "listViewBill";
            this.listViewBill.Size = new System.Drawing.Size(492, 457);
            this.listViewBill.TabIndex = 0;
            this.listViewBill.UseCompatibleStateImageBehavior = false;
            this.listViewBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món";
            this.columnHeader1.Width = 140;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.Width = 80;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.textBoxTotalPrice);
            this.panel4.Controls.Add(this.comboBoxSwitchTable);
            this.panel4.Controls.Add(this.buttonSwitchTable);
            this.panel4.Controls.Add(this.numericUpDownDiscount);
            this.panel4.Controls.Add(this.buttonDiscount);
            this.panel4.Controls.Add(this.buttonCheckout);
            this.panel4.Location = new System.Drawing.Point(567, 571);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(498, 74);
            this.panel4.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(214, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tổng tiền";
            // 
            // textBoxTotalPrice
            // 
            this.textBoxTotalPrice.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotalPrice.Location = new System.Drawing.Point(217, 41);
            this.textBoxTotalPrice.Name = "textBoxTotalPrice";
            this.textBoxTotalPrice.ReadOnly = true;
            this.textBoxTotalPrice.Size = new System.Drawing.Size(175, 28);
            this.textBoxTotalPrice.TabIndex = 7;
            this.textBoxTotalPrice.Text = "$0.00";
            this.textBoxTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // comboBoxSwitchTable
            // 
            this.comboBoxSwitchTable.FormattingEnabled = true;
            this.comboBoxSwitchTable.Location = new System.Drawing.Point(4, 46);
            this.comboBoxSwitchTable.Name = "comboBoxSwitchTable";
            this.comboBoxSwitchTable.Size = new System.Drawing.Size(94, 24);
            this.comboBoxSwitchTable.TabIndex = 2;
            // 
            // buttonSwitchTable
            // 
            this.buttonSwitchTable.AutoSize = true;
            this.buttonSwitchTable.Location = new System.Drawing.Point(4, 5);
            this.buttonSwitchTable.Name = "buttonSwitchTable";
            this.buttonSwitchTable.Size = new System.Drawing.Size(94, 38);
            this.buttonSwitchTable.TabIndex = 6;
            this.buttonSwitchTable.Text = "Chuyển bàn";
            this.buttonSwitchTable.UseVisualStyleBackColor = true;
            // 
            // numericUpDownDiscount
            // 
            this.numericUpDownDiscount.Location = new System.Drawing.Point(113, 47);
            this.numericUpDownDiscount.Name = "numericUpDownDiscount";
            this.numericUpDownDiscount.Size = new System.Drawing.Size(89, 22);
            this.numericUpDownDiscount.TabIndex = 6;
            this.numericUpDownDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonDiscount
            // 
            this.buttonDiscount.AutoSize = true;
            this.buttonDiscount.Location = new System.Drawing.Point(113, 5);
            this.buttonDiscount.Name = "buttonDiscount";
            this.buttonDiscount.Size = new System.Drawing.Size(89, 38);
            this.buttonDiscount.TabIndex = 5;
            this.buttonDiscount.Text = "Giảm giá";
            this.buttonDiscount.UseVisualStyleBackColor = true;
            // 
            // buttonCheckout
            // 
            this.buttonCheckout.AutoSize = true;
            this.buttonCheckout.Location = new System.Drawing.Point(397, 5);
            this.buttonCheckout.Name = "buttonCheckout";
            this.buttonCheckout.Size = new System.Drawing.Size(86, 66);
            this.buttonCheckout.TabIndex = 4;
            this.buttonCheckout.Text = "Thanh toán";
            this.buttonCheckout.UseVisualStyleBackColor = true;
            this.buttonCheckout.Click += new System.EventHandler(this.buttonCheckout_Click);
            // 
            // fTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 660);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fTableManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý quán cafe";
            this.Shown += new System.EventHandler(this.fTableManager_Shown);
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFoodCount)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDiscount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown numericUpDownFoodCount;
        private System.Windows.Forms.Button buttonAddFood;
        private System.Windows.Forms.ComboBox comboBoxFood;
        private System.Windows.Forms.ComboBox comboBoxFoodCategory;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTableFood;
        private System.Windows.Forms.NumericUpDown numericUpDownDiscount;
        private System.Windows.Forms.Button buttonDiscount;
        private System.Windows.Forms.Button buttonCheckout;
        private System.Windows.Forms.ComboBox comboBoxSwitchTable;
        private System.Windows.Forms.Button buttonSwitchTable;
        private System.Windows.Forms.ListView listViewBill;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Label label1;
        private TextBox textBoxTotalPrice;
    }
}