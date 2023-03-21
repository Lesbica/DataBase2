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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Various_plants_Click(object sender, EventArgs e)
        {
            Various_plants v= new Various_plants();
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
    }
}
