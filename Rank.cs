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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace DataBase
{
    public partial class Rank : Form
    {
        private readonly List<CategoryDto> _category;

        public Rank()
        {
            _category = new List<CategoryDto>();
            InitializeComponent();
        }

        private void rankBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.rankBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void Rank_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Category". При необходимости она может быть перемещена или удалена.
            this.categoryTableAdapter.Fill(this.database1DataSet.Category);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Rank". При необходимости она может быть перемещена или удалена.
            this.rankTableAdapter.Fill(this.database1DataSet.Rank);
            FillCategoryComboBox();
        }

        private void FillCategoryComboBox()
        {
            _category.Clear();
            foreach (var category in categoryTableAdapter.GetData().Select())
            {

                var categorydto = new CategoryDto
                {
                    Id = (int)category["Id"],
                    Name = (string)category["Назва"],
                };
                _category.Add(categorydto);
            }

            this.comboBox2.Items.AddRange(_category.ToArray());
            this.comboBox2.DisplayMember = "Name";
            this.comboBox2.SelectedIndex = 0;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            database1DataSet.Tables["Rank"].Rows[rankBindingSource.Position].Delete();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            try
            {
                var category = (CategoryDto)this.comboBox2.SelectedItem;
                DataRow currentr = database1DataSet.Tables["Rank"].Rows[rankBindingSource.Position];

                currentr["Id"] = textBox3.Text;
                currentr["Назва"] = textBox4.Text;
                currentr["Клас"] = category.Id;

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
                var category = (CategoryDto)this.comboBox2.SelectedItem;
                DataRow newr = database1DataSet.Tables["Rank"].NewRow();
                newr["Id"] = textBox3.Text;
                newr["Назва"] = textBox4.Text;
                newr["Клас"] = category.Id;
                database1DataSet.Tables["Rank"].Rows.Add(newr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rankBindingSource_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow currentr = database1DataSet.Tables["Rank"].Rows[rankBindingSource.Position];

                textBox3.Text = currentr["Id"].ToString();
                textBox4.Text = currentr["Назва"].ToString();

                var categoryid = (int)currentr["Клас"];
                foreach (var category in _category)
                {
                    if (category.Id == categoryid)
                    {
                        comboBox2.SelectedItem = category;
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
            Database1DataSet.RankRow searchRes = database1DataSet.Rank.FindById(Convert.ToInt32(textBox9.Text));
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
            DataRow[] searchRes = database1DataSet.Tables["Rank"].Select("Назва LIKE '" + textBox11.Text + "%'");
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
                rankBindingSource.Filter = "Назва >= '" + textBox11.Text + "' AND Назва <= '" + textBox12.Text + "'";
            }
            else
            {
                rankBindingSource.Filter = "";
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
