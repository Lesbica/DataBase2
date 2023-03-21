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
    }
}
