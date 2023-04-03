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
    public partial class Plant : Form
    {
        public Plant()
        {
            InitializeComponent();
        }

        private void plantBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.plantBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void Plant_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Plant". При необходимости она может быть перемещена или удалена.
            this.plantTableAdapter.Fill(this.database1DataSet.Plant);

        }

        private void add_Click(object sender, EventArgs e)
        {

            try
            {
                DataRow newr = database1DataSet.Tables["Plant"].NewRow();
                newr["Id"] = textBox3.Text;
                newr["Тип"] = textBox4.Text;
                newr["Вологість"] = textBox6.Text;
                database1DataSet.Tables["Put"].Rows.Add(newr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow currentr = database1DataSet.Tables["Plant"].Rows[plantBindingSource.Position];
                currentr["Id"] = textBox3.Text;
                currentr["Тип"] = textBox4.Text;
                currentr["Вологість"] = textBox6.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            database1DataSet.Tables["Plant"].Rows[plantBindingSource.Position].Delete();
        }

        private void plantBindingSource_PositionChanged(object sender, EventArgs e)
        {
            DataRow currentr = database1DataSet.Tables["Plant"].Rows[plantBindingSource.Position];
            textBox3.Text = currentr["Id"].ToString();
            textBox4.Text = currentr["Тип"].ToString();
            textBox6.Text = currentr["Вологість"].ToString();
        }

        private void find_Click(object sender, EventArgs e)
        {
            Database1DataSet.PlantRow searchRes = database1DataSet.Plant.FindById(Convert.ToInt32(textBox9.Text));
            textBox10.Visible = true;
            dataGridView1.Visible = false;
            if (searchRes != null)
            {
                textBox10.Text = searchRes.Id.ToString() + ", " + searchRes.Тип.ToString();
            }
            else
            {
                MessageBox.Show("no data!");
            }
        }

        private void select_Click(object sender, EventArgs e)
        {
            DataRow[] searchRes = database1DataSet.Tables["Plant"].Select("Тип LIKE '" + textBox11.Text + "%'");
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
                plantBindingSource.Filter = "Тип >= '" + textBox11.Text + "' AND Тип <= '" + textBox12.Text + "'";
            }
            else
            {
                plantBindingSource.Filter = "";
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
