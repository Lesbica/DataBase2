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
    }
}
