using DataBase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    public partial class Category : Form
    {
        private readonly List<DepartmentDto> _department;

        public Category()
        {
            _department = new List<DepartmentDto>();
            InitializeComponent();
        }
        public bool updated = false;
        private void categoryBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.categoryBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);
            updated = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Department". При необходимости она может быть перемещена или удалена.
            this.departmentTableAdapter.Fill(this.database1DataSet.Department);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Category". При необходимости она может быть перемещена или удалена.
            this.categoryTableAdapter.Fill(this.database1DataSet.Category);
            FillDepartmentComboBox();
        }

        private void FillDepartmentComboBox()
        {
            _department.Clear();
            foreach (var department in departmentTableAdapter.GetData().Select())
            {

                var departmentdto = new DepartmentDto
                {
                    Id = (int)department["Id"],
                    Name = (string)department["Назва"],
                };
                _department.Add(departmentdto);
            }

            this.comboBox2.Items.AddRange(_department.ToArray());
            this.comboBox2.DisplayMember = "Name";
            this.comboBox2.SelectedIndex = 0;
        }


        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            updated = false;
        }

        private void categoryDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            updated = false;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            database1DataSet.Tables["Category"].Rows[categoryBindingSource.Position].Delete();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            try
            {
                var department = (DepartmentDto)this.comboBox2.SelectedItem;
                DataRow currentr = database1DataSet.Tables["Category"].Rows[categoryBindingSource.Position];

                currentr["Id"] = textBox3.Text;
                currentr["Назва"] = textBox4.Text;
                currentr["Відділ"] = department.Id;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                var department = (DepartmentDto)this.comboBox2.SelectedItem;
                DataRow newr = database1DataSet.Tables["Category"].NewRow();
                newr["Id"] = textBox3.Text;
                newr["Назва"] = textBox4.Text;
                newr["Відділ"] = department.Id;
                database1DataSet.Tables["Category"].Rows.Add(newr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void departmentBindingSource_PositionChanged(object sender, EventArgs e)
        {

        }

        private void categoryBindingSource_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow currentr = database1DataSet.Tables["Category"].Rows[categoryBindingSource.Position];

                textBox3.Text = currentr["Id"].ToString();
                textBox4.Text = currentr["Назва"].ToString();

                var departmentid = (int)currentr["Відділ"];
                foreach (var department in _department)
                {
                    if (department.Id == departmentid)
                    {
                        comboBox2.SelectedItem = department;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void find_Click(object sender, EventArgs e)
        {
            Database1DataSet.CategoryRow searchRes = database1DataSet.Category.FindById(Convert.ToInt32(textBox9.Text));
            textBox10.Visible = true;
            dataGridView1.Visible = false;
            if (searchRes != null)
            {
                textBox10.Text = searchRes.Id.ToString() + ", " + searchRes.Назва.ToString();
            }
            else
            {
                MessageBox.Show("no data!");
            }
        }

        private void select_Click(object sender, EventArgs e)
        {
            DataRow[] searchRes = database1DataSet.Tables["Category"].Select("Назва LIKE '" + textBox11.Text + "%'");
            dataGridView1.Visible = true;
            textBox10.Visible = false;
            dataGridView1.Rows.Clear();
            if (searchRes == null)
            {
                MessageBox.Show("no data!");
            }
            else
            {
                foreach (DataRow dr in searchRes)
                {
                    dataGridView1.Rows.Add(dr.ItemArray);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                categoryBindingSource.Filter = "Назва >= '" + textBox11.Text + "' AND Назва <= '" + textBox12.Text + "'";
            }
            else
            {
                categoryBindingSource.Filter = "";
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }
    }
}
