using DataBase.Database1DataSetTableAdapters;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DataBase
{
    public partial class Catalogue : Form
    {
        private readonly List<AreaDto> _area;
        private readonly List<VariantDtocs> _variant;

        public Catalogue()
        {
            _area = new List<AreaDto>();
            _variant = new List<VariantDtocs>();
            InitializeComponent();
        }
        public bool updated = false;
        private void catalogueBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.catalogueBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);
            updated = true;
        }

        private void Catalogue_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Area". При необходимости она может быть перемещена или удалена.
            this.areaTableAdapter.Fill(this.database1DataSet.Area);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Various_plants". При необходимости она может быть перемещена или удалена.
            this.various_plantsTableAdapter.Fill(this.database1DataSet.Various_plants);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Catalogue". При необходимости она может быть перемещена или удалена.
            this.catalogueTableAdapter.Fill(this.database1DataSet.Catalogue);
            FillAreaComboBox();
            FillVariantComboBox();
        }

        private void FillAreaComboBox()
        {
            _area.Clear();
            foreach (var area in areaTableAdapter.GetData().Select())
            {

                var areadto = new AreaDto
                {
                    Id = (int)area["Id"],
                    Name = (string)area["Назва ділянки"],
                };
                _area.Add(areadto);
            }

            this.comboBox4.Items.AddRange(_area.ToArray());
            this.comboBox4.DisplayMember = "Name";
            this.comboBox4.SelectedIndex = 0;
        }

        private void FillVariantComboBox()
        {
            _variant.Clear();
            foreach (var variant in various_plantsTableAdapter.GetData().Select())
            {

                var variantdto = new VariantDtocs
                {
                    Id = (int)variant["Id"],
                    Name = (string)variant["Бі /Триномінальна назва"],
                };
                _variant.Add(variantdto);
            }

            this.comboBox4.Items.AddRange(_variant.ToArray());
            this.comboBox4.DisplayMember = "Name";
            this.comboBox4.SelectedIndex = 0;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            updated = false;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            updated = false;
        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                var area = (AreaDto)this.comboBox4.SelectedItem;
                var variant = (VariantDtocs)this.comboBox2.SelectedItem;
                DataRow newr = database1DataSet.Tables["Catalogue"].NewRow();
                newr["Id"] = textBox6.Text;
                newr["Різновид"] = variant.Id;
                newr["Розміри"] = textBox4.Text;
                newr["Посадка"] = textBox3.Text;
                newr["Ділянка"] = area.Id;
                database1DataSet.Tables["Catalogue"].Rows.Add(newr);
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

                var area = (AreaDto)this.comboBox4.SelectedItem;
                var variant = (VariantDtocs)this.comboBox2.SelectedItem;
                
                DataRow currentr = database1DataSet.Tables["Catalogue"].Rows[catalogueBindingSource.Position];

                currentr["Id"] = textBox6.Text;
                currentr["Різновид"] = variant.Id;
                currentr["Розміри"] = textBox4.Text;
                currentr["Посадка"] = textBox3.Text;
                currentr["Ділянка"] = area.Id;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            database1DataSet.Tables["Catalogue"].Rows[catalogueBindingSource.Position].Delete();
        }

        private void catalogueBindingSource_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow currentr = database1DataSet.Tables["Catalogue"].Rows[catalogueBindingSource.Position];

                textBox3.Text = currentr["Посадка"].ToString();
                textBox4.Text = currentr["Розміри"].ToString();
                textBox6.Text = currentr["Id"].ToString();

                var areaid = (int)currentr["Ділянка"];
                foreach (var area in _area)
                {
                    if (area.Id == areaid)
                    {
                        comboBox4.SelectedItem = area;
                        break;
                    }
                }

                var variantid = (int)currentr["Різновид"];
                foreach (var variant in _variant)
                {
                    if (variant.Id == variantid)
                    {
                        comboBox2.SelectedItem = variant;
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
            Database1DataSet.CatalogueRow searchRes = database1DataSet.Catalogue.FindById(Convert.ToInt32(textBox9.Text));
            textBox10.Visible = true;
            dataGridView1.Visible = false;
            if (searchRes != null)
            {
                textBox10.Text = searchRes.Id.ToString() + ", " + searchRes.Розміри.ToString();
            }
            else
            {
                MessageBox.Show("no data!");
            }
        }

        private void select_Click(object sender, EventArgs e)
        {
            DataRow[] searchRes = database1DataSet.Tables["Catalogue"].Select("Розміри LIKE '" + textBox11.Text + "%'");
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
                catalogueBindingSource.Filter = "Розміри >= '" + textBox11.Text + "' AND Розміри <= '" + textBox12.Text + "'";
            }
            else
            {
                catalogueBindingSource.Filter = "";
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
