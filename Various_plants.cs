﻿using DataBase.Database1DataSetTableAdapters;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace DataBase
{
    public partial class Various_plants : Form
    {

        private readonly List<GenuDto> _genus;
        private readonly List<KindDto> _kind;
        private readonly List<DepartmentDto> _department;
        private readonly List<CategoryDto> _category;
        private readonly List<RankDto> _rank;
        private readonly List<PutDto> _put;
        private readonly List<FamilyDto> _family;
        private readonly List<PlantDto> _plant;
        Role role;
        public Various_plants(Role role)
        {
            _genus= new List<GenuDto>();
            _kind= new List<KindDto>();
            _department = new List<DepartmentDto>();
            _category = new List<CategoryDto>();
            _rank = new List<RankDto>();
            _put = new List<PutDto>();
            _family = new List<FamilyDto>();
            _plant = new List<PlantDto>();
            this.role = role;
            InitializeComponent();
        }
        public bool updated = false;

        private void various_plantsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.various_plantsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);
            updated = true;
            this.various_plantsTableAdapter.Fill(this.database1DataSet.Various_plants);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet1.Plant". При необходимости она может быть перемещена или удалена.
            this.plantTableAdapter.Fill(this.database1DataSet1.Plant);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet1.Family". При необходимости она может быть перемещена или удалена.
            this.familyTableAdapter.Fill(this.database1DataSet1.Family);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet1.Put". При необходимости она может быть перемещена или удалена.
            this.putTableAdapter.Fill(this.database1DataSet1.Put);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet1.Rank". При необходимости она может быть перемещена или удалена.
            this.rankTableAdapter.Fill(this.database1DataSet1.Rank);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet1.Category". При необходимости она может быть перемещена или удалена.
            this.categoryTableAdapter.Fill(this.database1DataSet1.Category);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet1.Kind". При необходимости она может быть перемещена или удалена.
            this.kindTableAdapter.Fill(this.database1DataSet1.Kind);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Department". При необходимости она может быть перемещена или удалена.
            this.departmentTableAdapter.Fill(this.database1DataSet.Department);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Genu". При необходимости она может быть перемещена или удалена.
            this.genuTableAdapter.Fill(this.database1DataSet.Genu);
            //TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Various_plants".При необходимости она может быть перемещена или удалена.
            this.various_plantsTableAdapter.Fill(this.database1DataSet.Various_plants);


            /*GenuEditComboBox.Items.Clear();
            for(int i = 0; i < database1DataSet.Genu.Rows.Count; i++)
            {
                GenuEditComboBox.Items.Add(database1DataSet.Genu.Rows[i][1]);
            }

            DataRow dr_gen = database1DataSet.Genu.Rows[0];
            DataRow[] dr_kind = database1DataSet.Kind.Select("id=" + dr_gen[1].ToString());
            GenuEditComboBox.SelectedIndex = GenuEditComboBox.FindString(dr_kind[0][1].ToString());*/
            if (role.user == "user")
            {
                this.various_plantsDataGridView.Enabled = false;
                this.edit.Enabled = false;
                this.bindingNavigatorAddNewItem.Enabled = false;
                this.bindingNavigatorDeleteItem.Enabled = false;
                this.various_plantsBindingNavigatorSaveItem.Enabled = false;
                this.button3.Enabled = false;
                this.delete.Enabled = false;

                this.textBox1.Enabled = false;
                this.textBox3.Enabled = false;
                this.textBox4.Enabled = false;
                this.textBox8.Enabled = false;
                this.textBox7.Enabled = false;
                this.textBox6.Enabled = false;
                this.textBox6.Enabled = false;
                this.textBox5.Enabled = false;
            }
            else if (role.admin == "admin")
            {
                this.various_plantsDataGridView.Enabled = true;
                this.edit.Enabled = true;
                this.bindingNavigatorAddNewItem.Enabled = true;
                this.bindingNavigatorDeleteItem.Enabled = true;
                this.various_plantsBindingNavigatorSaveItem.Enabled = true;
                this.button3.Enabled = true;
                this.delete.Enabled = true;
                this.textBox1.Enabled = true;
                this.textBox3.Enabled = true;
                this.textBox4.Enabled = true;
                this.textBox8.Enabled = true;
                this.textBox7.Enabled = true;
                this.textBox6.Enabled = true;
                this.textBox6.Enabled = true;
                this.textBox5.Enabled = true;
            }
            
            FillGenuComboBox();
            FillKindComboBox();
            FillDepartmentComboBox();
            FillCategoryComboBox();
            FillRankComboBox();
            FillPutComboBox();
            FillFamilyComboBox();
            FillPlantComboBox();
        }

        private void FillPlantComboBox()
        {
            _plant.Clear();
            foreach (var plant in plantTableAdapter.GetData().Select())
            {

                var plantdto = new PlantDto
                {
                    Id = (int)plant["Id"],
                    Name = (string)plant["Тип"],
                };
                _plant.Add(plantdto);
            }

            this.PlantComboBox.Items.AddRange(_plant.ToArray());
            this.PlantComboBox.DisplayMember = "Name";
            this.PlantComboBox.SelectedIndex = 0;
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

            this.FamilyComboBox.Items.AddRange(_family.ToArray());
            this.FamilyComboBox.DisplayMember = "Name";
            this.FamilyComboBox.SelectedIndex = 0;
        }

        private void FillPutComboBox()
        {
            _put.Clear();
            foreach (var put in putTableAdapter.GetData().Select())
            {

                var putdto = new PutDto
                {
                    Id = (int)put["Id"],
                    Name = (string)put["Назва"],
                };
                _put.Add(putdto);
            }

            this.PutComboBox.Items.AddRange(_put.ToArray());
            this.PutComboBox.DisplayMember = "Name";
            this.PutComboBox.SelectedIndex = 0;
        }

        private void FillRankComboBox()
        {
            _rank.Clear();
            foreach (var rank in rankTableAdapter.GetData().Select())
            {

                var rankdto = new RankDto
                {
                    Id = (int)rank["Id"],
                    Name = (string)rank["Назва"],
                };
                _rank.Add(rankdto);
            }

            this.RankComboBox.Items.AddRange(_rank.ToArray());
            this.RankComboBox.DisplayMember = "Name";
            this.RankComboBox.SelectedIndex = 0;
        }

        private void FillCategoryComboBox()
        {
            _category.Clear();
            foreach (var category in categoryTableAdapter.GetData().Select())
            {

                var categorydto = new CategoryDto
                {
                    Id = (int)category["Id"],
                    Name = (string)category["Назва"],
                };
                _category.Add(categorydto);
            }

            this.CategoryComboBox.Items.AddRange(_category.ToArray());
            this.CategoryComboBox.DisplayMember = "Name";
            this.CategoryComboBox.SelectedIndex = 0;
        }

        private void FillDepartmentComboBox()
        {
            _department.Clear();
            foreach (var department in departmentTableAdapter.GetData().Select())
            {

                var departmentdto = new DepartmentDto
                {
                    Id = (int)department["Id"],
                    Name = (string)department["Назва"],
                };
                _department.Add(departmentdto);
            }

            this.DepartmentComboBox.Items.AddRange(_department.ToArray());
            this.DepartmentComboBox.DisplayMember = "Name";
            this.DepartmentComboBox.SelectedIndex = 0;
        }

        private void FillKindComboBox()
        {
            _kind.Clear();
            foreach (var kind in kindTableAdapter.GetData().Select())
            {

                var kinddto = new KindDto
                {
                    Id = (int)kind["Id"],
                    Name = (string)kind["Назва"],
                };
                _kind.Add(kinddto);
            }

            this.KindComboBox.Items.AddRange(_kind.ToArray());
            this.KindComboBox.DisplayMember = "Name";
            this.KindComboBox.SelectedIndex = 0;
        }

        private void FillGenuComboBox()
        {
            GenuEditComboBox.Items.Clear();
            foreach (var genu in genuTableAdapter.GetData().Select())
            {

                var genudto = new GenuDto
                {
                    Id = (int)genu["Id"],
                    Name = (string)genu["Назва"],
                };
                _genus.Add(genudto);
            }

            this.GenuEditComboBox.Items.AddRange(_genus.ToArray());
            this.GenuEditComboBox.DisplayMember = "Name";
            this.GenuEditComboBox.SelectedIndex = 0;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            updated = false;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            updated = false;
        }

        private void Various_plants_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (DataRow currentr in database1DataSet.Tables["Various_plants"].Rows)
            {
                if (currentr.RowState != DataRowState.Unchanged)
                {
                    e.Cancel = true;
                    MessageBox.Show("Save before closing");
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            database1DataSet.Tables["Various_plants"].Rows[various_plantsBindingSource.Position].Delete();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            try
            {

                var genu = (GenuDto)this.GenuEditComboBox.SelectedItem;
                var kind = (KindDto)this.KindComboBox.SelectedItem;
                var department = (DepartmentDto)this.DepartmentComboBox.SelectedItem;
                var category = (CategoryDto)this.CategoryComboBox.SelectedItem;
                var rank = (RankDto)this.RankComboBox.SelectedItem;
                var put = (PutDto)this.PutComboBox.SelectedItem;
                var family = (FamilyDto)this.FamilyComboBox.SelectedItem;
                var plant = (PlantDto)this.PlantComboBox.SelectedItem;
                DataRow currentr = database1DataSet.Tables["Various_plants"].Rows[various_plantsBindingSource.Position];

                currentr["Id"] = textBox8.Text;
                currentr["Рід"] = genu.Id;
                currentr["Вид"] = kind.Id;
                currentr["Відділ"] = department.Id; ;
                currentr["Клас"] = category.Id;
                currentr["Порядок"] = rank.Id;
                currentr["Клада"] = put.Id;
                currentr["Родина"] = family.Id;
                currentr["Ареал виду"] = textBox7.Text;
                currentr["Природоохоронний статус"] = textBox6.Text;
                currentr["Бі /Триномінальна назва"] = textBox5.Text;
                currentr["Земля"] = plant.Id;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented!");
        }

        private void various_plantsBindingSource_PositionChanged(object sender, EventArgs e)
        {
            try
            {

                DataRow currentr = database1DataSet.Tables["Various_plants"].Rows[various_plantsBindingSource.Position];

                if (int.TryParse(currentr["Рід"].ToString(), out var genuid))
                {
                    foreach (var genu in _genus)
                    {
                        if (genu.Id == genuid)
                        {
                            GenuEditComboBox.SelectedItem = genu;
                            break;
                        }
                    }
                }
                else
                {
                    GenuEditComboBox.SelectedItem = null;
                }

                if (int.TryParse(currentr["Вид"].ToString(), out var kindid))
                {
                    foreach (var kind in _kind)
                    {
                        if (kind.Id == kindid)
                        {
                            KindComboBox.SelectedItem = kind;
                            break;
                        }
                    }
                }
                else
                {
                    KindComboBox.SelectedItem = null;
                }

                if (int.TryParse(currentr["Відділ"].ToString(), out var departmentid))
                {
                    foreach (var department in _department)
                    {
                        if (department.Id == departmentid)
                        {
                            DepartmentComboBox.SelectedItem = department;
                            break;
                        }
                    }
                }
                else
                {
                    DepartmentComboBox.SelectedItem = null;
                }

                if (int.TryParse(currentr["Клас"].ToString(), out var сategorytid))
                {
                    foreach (var сategory in _category)
                    {
                        if (сategory.Id == сategorytid)
                        {
                            CategoryComboBox.SelectedItem = сategory;
                            break;
                        }
                    }
                }
                else
                {
                    CategoryComboBox.SelectedItem = null;
                }

                if (int.TryParse(currentr["Порядок"].ToString(), out var rankid))
                {
                    foreach (var rank in _rank)
                    {
                        if (rank.Id == rankid)
                        {
                            RankComboBox.SelectedItem = rank;
                            break;
                        }
                    }
                }
                else
                {
                    RankComboBox.SelectedItem = null;
                }

                if (int.TryParse(currentr["Клада"].ToString(), out var putid))
                {
                    foreach (var put in _put)
                    {
                        if (put.Id == putid)
                        {
                            PutComboBox.SelectedItem = put;
                            break;
                        }
                    }
                }
                else
                {
                    PutComboBox.SelectedItem = null;
                }

                if (int.TryParse(currentr["Родина"].ToString(), out var familyid))
                {
                    foreach (var family in _family)
                    {
                        if (family.Id == familyid)
                        {
                            FamilyComboBox.SelectedItem = family;
                            break;
                        }
                    }
                }
                else
                {
                    FamilyComboBox.SelectedItem = null;
                }

                if (int.TryParse(currentr["Земля"].ToString(), out var plantid))
                {
                    foreach (var plant in _plant)
                    {
                        if (plant.Id == plantid)
                        {
                            PlantComboBox.SelectedItem = plant;
                            break;
                        }
                    }
                }
                else
                {
                    PlantComboBox.SelectedItem = null;
                }

                textBox8.Text = currentr["Id"].ToString();
                textBox7.Text = currentr["Ареал виду"].ToString();
                textBox6.Text = currentr["Природоохоронний статус"].ToString();
                textBox5.Text = currentr["Бі /Триномінальна назва"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void putBindingSource_CurrentChanged(object sender, EventArgs e)
        {
                    }

        private void various_plantsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void find_Click(object sender, EventArgs e)
        {
            Database1DataSet.Various_plantsRow searchRes = database1DataSet.Various_plants.FindById(Convert.ToInt32(textBox9.Text));
            textBox10.Visible = true;
            dataGridView1.Visible = false;
            if (searchRes != null)
            {
                textBox10.Text = searchRes.Рід.ToString()+", "+ searchRes._Бі__Триномінальна_назва.ToString();            }
            else
            {
                MessageBox.Show("no data!");
            }

        }

        private void select_Click(object sender, EventArgs e)
        {
            DataRow[] searchRes = database1DataSet.Tables["Various_plants"].Select("[Бі /Триномінальна назва] LIKE '" + textBox11.Text + "%'");
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
            if(checkBox1.Checked)
            {
                various_plantsBindingSource.Filter = "[Бі /Триномінальна назва] >= '" + textBox11.Text + "' AND [Бі /Триномінальна назва] <= '" + textBox12.Text + "'";
            }
            else
            {
                various_plantsBindingSource.Filter = "";
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            DataRow dr_vp = database1DataSet.Various_plants.Rows[various_plantsBindingSource.Position];
            form2.dataGridView1.DataSource = database1DataSet.Genu;
            int r;

            for(r=0; r< form2.dataGridView1.Rows.Count; r++)
            {
                if (form2.dataGridView1.Rows[r].Cells[0].Value.ToString()== dr_vp["Рід"].ToString())
                {
                    break;
                }
            }

            form2.dataGridView1.CurrentCell = form2.dataGridView1[0,r];
            if (form2.ShowDialog() == DialogResult.OK)
            {
                int code_genu = Convert.ToInt32(form2.dataGridView1.CurrentRow.Cells[0].Value);
                textBox13.Text = form2.dataGridView1.CurrentRow.Cells[0].Value.ToString()+"(Name = "+ form2.dataGridView1.CurrentRow.Cells[1].Value.ToString()+")";
                dr_vp["Рід"] = code_genu;
            }
        }
    }
}
