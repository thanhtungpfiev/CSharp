using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameWorkUI
{
    public partial class Form1 : Form
    {
        TestEntityEntities db = new TestEntityEntities();
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        #region methods

        void BindData()
        {
            textBoxID.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "LopName"));
            textBoxName.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Name"));
        }

        void LoadData()
        {
            var list = (from s in db.SinhViens
                        join l in db.Lops on s.IDLop equals l.ID
                        select new { s.ID, s.Name, LopName = l.Name }).ToList();
            dataGridView1.DataSource = list;
            // Clear existing bindings
            textBoxID.DataBindings.Clear();
            textBoxName.DataBindings.Clear();

            // Re-bind the text boxes
            BindData();
        }

        void AddSinhVien()
        {
            string lopName = textBoxID.Text; 

            int idLop = 0;

            var lop = db.Lops.FirstOrDefault(l => l.Name == lopName);
            if (lop != null)
            {
                idLop = lop.ID;
            }

            db.SinhViens.Add(new SinhVien()
            {
                Name = textBoxName.Text,
                IDLop = idLop
            });
            db.SaveChanges();
        }

        void DeleteSinhVien()
        {
            string lopName = textBoxID.Text;

            int idLop = 0;

            var lop = db.Lops.FirstOrDefault(l => l.Name == lopName);
            if (lop != null)
            {
                idLop = lop.ID;
            }

            var sv = db.SinhViens.FirstOrDefault(s => s.IDLop == idLop && s.Name == textBoxName.Text);
            if (sv != null)
            {
                db.SinhViens.Remove(sv);
                db.SaveChanges();
            }
        }

        void EditSinhVien()
        {
            string lopName = textBoxID.Text;

            int idLop = 0;

            var lop = db.Lops.FirstOrDefault(l => l.Name == lopName);
            if (lop != null)
            {
                idLop = lop.ID;
            }

            var sv = db.SinhViens.FirstOrDefault(s => s.IDLop == idLop && s.Name == textBoxName.Text);
            if (sv != null)
            {
                sv.Name = textBoxName.Text;
                db.SaveChanges();
            }
        }


        #endregion

        #region events

        private void buttonShow_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddSinhVien();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteSinhVien();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // Get the selected cell from the dataGridView
            if (dataGridView1.SelectedCells.Count > 0)
            {
                DataGridViewCell selectedCell = dataGridView1.SelectedCells[0];

                // Get the ID and Name values from the selected cell
                int id = Convert.ToInt32(dataGridView1.Rows[selectedCell.RowIndex].Cells["ID"].Value);
                string name = dataGridView1.Rows[selectedCell.RowIndex].Cells["Name"].Value.ToString();

                // Find the SinhVien object with the matching ID
                var sv = db.SinhViens.FirstOrDefault(s => s.ID == id);

                if (sv != null)
                {
                    // Update the Name property of the SinhVien object
                    sv.Name = textBoxName.Text;

                    string lopName = textBoxID.Text;

                    int idLop = 0;

                    var lop = db.Lops.FirstOrDefault(l => l.Name == lopName);
                    if (lop != null)
                    {
                        idLop = lop.ID;
                    }
                    sv.IDLop = idLop;

                    // Save the changes to the database
                    db.SaveChanges();
                }
            }
        }
        #endregion
    }
}
