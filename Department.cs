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
    public partial class Department : Form
    {
        public Department()
        {
            InitializeComponent();
        }

        private void departmentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.departmentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Department". При необходимости она может быть перемещена или удалена.
            this.departmentTableAdapter.Fill(this.database1DataSet.Department);

        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                /*Database1DataSet.DepartmentRow newr = database1DataSet.Department.NewDepartmentRow();
                newr.Id = Convert.ToInt32(textBox3.Text);
                newr.Назва = textBox4.Text;
                database1DataSet.Department.Rows.Add(newr);*/

                DataRow newr = database1DataSet.Tables["Department"].NewRow();
                newr["Id"] = textBox3.Text;
                newr["Назва"] = textBox4.Text;
                database1DataSet.Tables["Department"].Rows.Add(newr);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void edit_Click(object sender, EventArgs e)
        {
            try
            {
                /*Database1DataSet.DepartmentRow currentr = database1DataSet.Department.FindById(Convert.ToInt32(textBox3.Text));
                currentr.Назва = textBox4.Text;*/

                //DataRow[] currentr = database1DataSet.Tables["Department"].Select("Назва = '" + textBox4.Text+"'");
                //if (currentr.Count > 0)
                //{
                //    currentr[0]["Id"] = textBox3.Text;
                //    currentr[0]["Назва"] = textBox4.Text;
                //}

                DataRow currentr = database1DataSet.Tables["Department"].Rows[departmentBindingSource.Position];
                currentr["Id"] = textBox3.Text;
                currentr["Назва"] = textBox4.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void departmentBindingSource_PositionChanged(object sender, EventArgs e)
        {
            DataRow currentr = database1DataSet.Tables["Department"].Rows[departmentBindingSource.Position];
            textBox3.Text = currentr["Id"].ToString();
            textBox4.Text = currentr["Назва"].ToString();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            database1DataSet.Tables["Department"].Rows[departmentBindingSource.Position].Delete();
        }

        private void Department_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach(DataRow currentr in database1DataSet.Tables["Department"].Rows)
            {
                if(currentr.RowState != DataRowState.Unchanged)
                {
                    e.Cancel = true;
                    MessageBox.Show("Save before closing");
                }
            }

        }
    }
}
