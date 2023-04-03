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
    public partial class Area : Form
    {
        public Area()
        {
            InitializeComponent();
        }
        public bool updated = false;
        private void areaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.areaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);
            updated = true;
        }

        private void Area_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Area". При необходимости она может быть перемещена или удалена.
            this.areaTableAdapter.Fill(this.database1DataSet.Area);

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            updated = true;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            updated = true;
        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow newr = database1DataSet.Tables["Area"].NewRow();
                newr["Id"] = textBox3.Text;
                newr["Назва ділянки"] = textBox4.Text;
                newr["Відповідальний"] = textBox8.Text;
                newr["Площа"] = textBox7.Text;
                database1DataSet.Tables["Area"].Rows.Add(newr);
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
                DataRow currentr = database1DataSet.Tables["Area"].Rows[areaBindingSource.Position];
                currentr["Id"] = textBox3.Text;
                currentr["Назва ділянки"] = textBox4.Text;
                currentr["Відповідальний"] = textBox8.Text;
                currentr["Площа"] = textBox7.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            database1DataSet.Tables["Area"].Rows[areaBindingSource.Position].Delete();
        }

        private void areaBindingSource_PositionChanged(object sender, EventArgs e)
        {
            DataRow currentr = database1DataSet.Tables["Area"].Rows[areaBindingSource.Position];
            textBox3.Text = currentr["Id"].ToString();
            textBox4.Text = currentr["Назва ділянки"].ToString();
            textBox8.Text = currentr["Відповідальний"].ToString();
            textBox7.Text = currentr["Площа"].ToString();
        }

        private void find_Click(object sender, EventArgs e)
        {
            Database1DataSet.AreaRow searchRes = database1DataSet.Area.FindById(Convert.ToInt32(textBox9.Text));
            textBox10.Visible = true;
            dataGridView1.Visible = false;
            if (searchRes != null)
            {
                textBox10.Text = searchRes.Id.ToString() + ", " + searchRes.Відповідальний.ToString();
            }
            else
            {
                MessageBox.Show("no data!");
            }
        }

        private void select_Click(object sender, EventArgs e)
        {
            DataRow[] searchRes = database1DataSet.Tables["Area"].Select("Площа LIKE '" + textBox11.Text + "%'");
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
                areaBindingSource.Filter = "Площа >= '" + textBox11.Text + "' AND Площа <= '" + textBox12.Text + "'";
            }
            else
            {
                areaBindingSource.Filter = "";
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
