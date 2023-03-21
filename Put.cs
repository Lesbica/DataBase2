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
    }
}
