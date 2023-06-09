﻿using DataBase.Models;
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
    public partial class Family : Form
    {
        private readonly List<RankDto> _rank;

        public Family()
        {
            _rank = new List<RankDto>();
            InitializeComponent();
        }
        
        private void familyBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.familyBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void Family_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Rank". При необходимости она может быть перемещена или удалена.
            this.rankTableAdapter.Fill(this.database1DataSet.Rank);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Family". При необходимости она может быть перемещена или удалена.
            this.familyTableAdapter.Fill(this.database1DataSet.Family);
            FillRankComboBox();
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

            this.comboBox2.Items.AddRange(_rank.ToArray());
            this.comboBox2.DisplayMember = "Name";
            this.comboBox2.SelectedIndex = 0;
        }


        private void delete_Click(object sender, EventArgs e)
        {
            database1DataSet.Tables["Family"].Rows[familyBindingSource.Position].Delete();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            try
            {
                var rank = (RankDto)this.comboBox2.SelectedItem;
                DataRow currentr = database1DataSet.Tables["Family"].Rows[familyBindingSource.Position];

                currentr["Id"] = textBox2.Text;
                currentr["Назва"] = textBox4.Text;
                currentr["Порядок"] = rank.Id;

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
                var rank = (RankDto)this.comboBox2.SelectedItem;
                DataRow newr = database1DataSet.Tables["Family"].NewRow();
                newr["Id"] = textBox3.Text;
                newr["Назва"] = textBox4.Text;
                newr["Порядок"] = rank.Id;
                database1DataSet.Tables["Family"].Rows.Add(newr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rankBindingSource_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow currentr = database1DataSet.Tables["Family"].Rows[familyBindingSource.Position];

                textBox3.Text = currentr["Id"].ToString();
                textBox4.Text = currentr["Назва"].ToString();

                var rankid = (int)currentr["Порядок"];
                foreach (var rank in _rank)
                {
                    if (rank.Id == rankid)
                    {
                        comboBox2.SelectedItem = rank;
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
            Database1DataSet.FamilyRow searchRes = database1DataSet.Family.FindById(Convert.ToInt32(textBox9.Text));
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
            DataRow[] searchRes = database1DataSet.Tables["Family"].Select("Назва LIKE '" + textBox11.Text + "%'");
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
                familyBindingSource.Filter = "Назва >= '" + textBox11.Text + "' AND Назва <= '" + textBox12.Text + "'";
            }
            else
            {
                familyBindingSource.Filter = "";
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }

        private void textBox11_TextChanged_1(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }
    }
}
