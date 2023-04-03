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
using static DataBase.Database1DataSet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DataBase
{
    public partial class Kind : Form
    {
        private readonly List<GenuDto> _genus;

        public Kind()
        {
            _genus = new List<GenuDto>();
            InitializeComponent();
        }

        private void kindBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.kindBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void Kind_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Genu". При необходимости она может быть перемещена или удалена.
            this.genuTableAdapter.Fill(this.database1DataSet.Genu);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Kind". При необходимости она может быть перемещена или удалена.
            this.kindTableAdapter.Fill(this.database1DataSet.Kind);
            FillGenuComboBox();
        }

        private void FillGenuComboBox()
        {
            _genus.Clear();
            foreach (var genu in genuTableAdapter.GetData().Select())
            {

                var genudto = new GenuDto
                {
                    Id = (int)genu["Id"],
                    Name = (string)genu["Назва"],
                };
                _genus.Add(genudto);
            }

            this.comboBox2.Items.AddRange(_genus.ToArray());
            this.comboBox2.DisplayMember = "Name";
            this.comboBox2.SelectedIndex = 0;
        }


        private void delete_Click(object sender, EventArgs e)
        {
            database1DataSet.Tables["Kind"].Rows[kindBindingSource.Position].Delete();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            try
            {
                var genu = (GenuDto)this.comboBox2.SelectedItem;
                DataRow currentr = database1DataSet.Tables["Kind"].Rows[kindBindingSource.Position];

                currentr["Id"] = textBox3.Text;
                currentr["Назва"] = textBox4.Text;
                currentr["Рід"] = genu.Id;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void kindBindingSource_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow currentr = database1DataSet.Tables["Kind"].Rows[kindBindingSource.Position];

                textBox3.Text = currentr["Id"].ToString();
                textBox4.Text = currentr["Назва"].ToString();

                var genuid = (int)currentr["Рід"];
                foreach (var genu in _genus)
                {
                    if (genu.Id == genuid)
                    {
                        comboBox2.SelectedItem = genu;
                        break;
                    }
                }
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
                var genu = (GenuDto)this.comboBox2.SelectedItem;
                DataRow newr = database1DataSet.Tables["Kind"].NewRow();
                newr["Id"] = textBox3.Text;
                newr["Назва"] = textBox4.Text;
                newr["Рід"] = genu.Id;
                database1DataSet.Tables["Kind"].Rows.Add(newr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void find_Click(object sender, EventArgs e)
        {
            Database1DataSet.KindRow searchRes = database1DataSet.Kind.FindById(Convert.ToInt32(textBox9.Text));
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
            DataRow[] searchRes = database1DataSet.Tables["Kind"].Select("Назва LIKE '" + textBox11.Text + "%'");
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
                kindBindingSource.Filter = "Назва >= '" + textBox11.Text + "' AND Назва <= '" + textBox12.Text + "'";
            }
            else
            {
                kindBindingSource.Filter = "";
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
