using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DataBase.Login;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DataBase
{
    public partial class Menu : Form
    {
        Role role;
        public Menu(Role role)
        {
            InitializeComponent();  
            this.role = role;
        }

        private void Various_plants_Click(object sender, EventArgs e)
        {
            Various_plants v= new Various_plants(role);
            v.ShowDialog();
            if(v.updated)
                this.viewTableAdapter.Fill(this.database1DataSet.View);

        }

        private void Category_Click(object sender, EventArgs e)
        {
            Category cat = new Category();
            cat.ShowDialog();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.View". При необходимости она может быть перемещена или удалена.
            this.viewTableAdapter.Fill(this.database1DataSet.View);
            if (role.user == "user")
            {
                this.viewBindingNavigatorSaveItem.Enabled = false;
                this.viewDataGridView.Enabled = false;
                this.bindingNavigatorAddNewItem.Enabled = false;
                this.bindingNavigatorDeleteItem.Enabled = false;
            }else if(role.admin == "admin")
            {
                this.viewBindingNavigatorSaveItem.Enabled = true;
                this.viewDataGridView.Enabled = true;
                this.bindingNavigatorAddNewItem.Enabled = true;
                this.bindingNavigatorDeleteItem.Enabled = true;
            }

        }

        private void department_Click(object sender, EventArgs e)
        {
            Department dep = new Department();
            dep.ShowDialog();
        }

        private void catalogue_Click(object sender, EventArgs e)
        {
            Catalogue catalogue = new Catalogue();
            catalogue.ShowDialog();
            if(catalogue.updated)
                this.viewTableAdapter.Fill(this.database1DataSet.View);
        }

        private void family_Click(object sender, EventArgs e)
        {
            Family family = new Family();
            family.ShowDialog();
        }

        private void genu_Click(object sender, EventArgs e)
        {
            Genu genu = new Genu();
            genu.ShowDialog();
        }

        private void kind_Click(object sender, EventArgs e)
        {
            Kind kind = new Kind();
            kind.ShowDialog();
        }

        private void plant_Click(object sender, EventArgs e)
        {
            Plant plant = new Plant();
            plant.ShowDialog();
        }

        private void put_Click(object sender, EventArgs e)
        {
            Put put = new Put();
            put.ShowDialog();
        }

        private void rank_Click(object sender, EventArgs e)
        {
            Rank rank = new Rank();
            rank.ShowDialog();
        }

        private void area_Click(object sender, EventArgs e)
        {
            Area area = new Area();
            area.ShowDialog();
            if(area.updated)
                this.viewTableAdapter.Fill(this.database1DataSet.View);
        }

        private void Menu_Deactivate(object sender, EventArgs e)
        {

        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти из программы?", "Выход", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Закрываем программу
                Application.Exit();
            }
            else
            {
                // Отменяем закрытие формы
                e.Cancel = true;
            }
        }
    }
}
