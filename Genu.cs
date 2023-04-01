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
    public partial class Genu : Form
    {
        private readonly List<FamilyDto> _family;

        public Genu()
        {
            _family = new List<FamilyDto>();
            InitializeComponent();
        }

        private void genuBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.genuBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void Genu_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Family". При необходимости она может быть перемещена или удалена.
            this.familyTableAdapter.Fill(this.database1DataSet.Family);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Genu". При необходимости она может быть перемещена или удалена.
            this.genuTableAdapter.Fill(this.database1DataSet.Genu);
            FillFamilyComboBox();
        }

        private void FillFamilyComboBox()
        {
            _family.Clear();
            foreach (var family in familyTableAdapter.GetData().Select())
            {

                var familydto = new FamilyDto
                {
                    Id = (int)family["Id"],
                    Name = (string)family["Назва"],
                };
                _family.Add(familydto);
            }

            this.comboBox2.Items.AddRange(_family.ToArray());
            this.comboBox2.DisplayMember = "Name";
            this.comboBox2.SelectedIndex = 0;
        }


        private void delete_Click(object sender, EventArgs e)
        {
            database1DataSet.Tables["Genu"].Rows[genuBindingSource.Position].Delete();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            try
            {
                var family = (FamilyDto)this.comboBox2.SelectedItem;
                DataRow currentr = database1DataSet.Tables["Genu"].Rows[genuBindingSource.Position];

                currentr["Id"] = textBox2.Text;
                currentr["Назва"] = textBox4.Text;
                currentr["Родина"] = family.Id;

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
                var family = (FamilyDto)this.comboBox2.SelectedItem;
                DataRow newr = database1DataSet.Tables["Genu"].NewRow();
                newr["Id"] = textBox3.Text;
                newr["Назва"] = textBox4.Text;
                newr["Родина"] = family.Id;
                database1DataSet.Tables["Genu"].Rows.Add(newr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void familyBindingSource_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow currentr = database1DataSet.Tables["Genu"].Rows[genuBindingSource.Position];

                textBox3.Text = currentr["Id"].ToString();
                textBox4.Text = currentr["Назва"].ToString();

                var familyid = (int)currentr["Родина"];
                foreach (var family in _family)
                {
                    if (family.Id == familyid)
                    {
                        comboBox2.SelectedItem = family;
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
            
        }
    }
}
