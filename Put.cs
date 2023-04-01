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
    public partial class Put : Form
    {
        public Put()
        {
            InitializeComponent();
        }

        private void putBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.putBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void Put_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Put". При необходимости она может быть перемещена или удалена.
            this.putTableAdapter.Fill(this.database1DataSet.Put);

        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow newr = database1DataSet.Tables["Put"].NewRow();
                newr["Id"] = textBox3.Text;
                newr["Назва"] = textBox4.Text;
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
                DataRow currentr = database1DataSet.Tables["Put"].Rows[putBindingSource.Position];
                currentr["Id"] = textBox3.Text;
                currentr["Назва"] = textBox4.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            database1DataSet.Tables["Put"].Rows[putBindingSource.Position].Delete();
        }

        private void putBindingSource_PositionChanged(object sender, EventArgs e)
        {
            DataRow currentr = database1DataSet.Tables["Put"].Rows[putBindingSource.Position];
            textBox3.Text = currentr["Id"].ToString();
            textBox4.Text = currentr["Назва"].ToString();
        }

        private void find_Click(object sender, EventArgs e)
        {
            Database1DataSet.PutRow searchRes = database1DataSet.Put.FindById(Convert.ToInt32(textBox9.Text));
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
            DataRow[] searchRes = database1DataSet.Tables["Put"].Select("Назва LIKE '" + textBox11.Text + "%'");
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
                putBindingSource.Filter = "Назва >= '" + textBox11.Text + "' AND Назва <= '" + textBox12.Text + "'";
            }
            else
            {
                putBindingSource.Filter = "";
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
