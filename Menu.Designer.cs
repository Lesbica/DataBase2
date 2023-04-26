namespace DataBase
{
    partial class Menu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.Various_plants = new System.Windows.Forms.Button();
            this.Category = new System.Windows.Forms.Button();
            this.database1DataSet = new DataBase.Database1DataSet();
            this.viewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.viewTableAdapter = new DataBase.Database1DataSetTableAdapters.ViewTableAdapter();
            this.tableAdapterManager = new DataBase.Database1DataSetTableAdapters.TableAdapterManager();
            this.viewBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.viewBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.viewDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.department = new System.Windows.Forms.Button();
            this.genu = new System.Windows.Forms.Button();
            this.kind = new System.Windows.Forms.Button();
            this.catalogue = new System.Windows.Forms.Button();
            this.area = new System.Windows.Forms.Button();
            this.plant = new System.Windows.Forms.Button();
            this.put = new System.Windows.Forms.Button();
            this.family = new System.Windows.Forms.Button();
            this.rank = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewBindingNavigator)).BeginInit();
            this.viewBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Various_plants
            // 
            this.Various_plants.Location = new System.Drawing.Point(12, 449);
            this.Various_plants.Name = "Various_plants";
            this.Various_plants.Size = new System.Drawing.Size(137, 33);
            this.Various_plants.TabIndex = 0;
            this.Various_plants.Text = "Various plants";
            this.Various_plants.UseVisualStyleBackColor = true;
            this.Various_plants.Click += new System.EventHandler(this.Various_plants_Click);
            // 
            // Category
            // 
            this.Category.Location = new System.Drawing.Point(12, 137);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(137, 33);
            this.Category.TabIndex = 1;
            this.Category.Text = "Category";
            this.Category.UseVisualStyleBackColor = true;
            this.Category.Click += new System.EventHandler(this.Category_Click);
            // 
            // database1DataSet
            // 
            this.database1DataSet.DataSetName = "Database1DataSet";
            this.database1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // viewBindingSource
            // 
            this.viewBindingSource.DataMember = "View";
            this.viewBindingSource.DataSource = this.database1DataSet;
            // 
            // viewTableAdapter
            // 
            this.viewTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AreaTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CatalogueTableAdapter = null;
            this.tableAdapterManager.CategoryTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.DepartmentTableAdapter = null;
            this.tableAdapterManager.FamilyTableAdapter = null;
            this.tableAdapterManager.GenuTableAdapter = null;
            this.tableAdapterManager.KindTableAdapter = null;
            this.tableAdapterManager.PlantTableAdapter = null;
            this.tableAdapterManager.PutTableAdapter = null;
            this.tableAdapterManager.RankTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = DataBase.Database1DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.Various_plantsTableAdapter = null;
            // 
            // viewBindingNavigator
            // 
            this.viewBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.viewBindingNavigator.BindingSource = this.viewBindingSource;
            this.viewBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.viewBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.viewBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.viewBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.viewBindingNavigatorSaveItem});
            this.viewBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.viewBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.viewBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.viewBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.viewBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.viewBindingNavigator.Name = "viewBindingNavigator";
            this.viewBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.viewBindingNavigator.Size = new System.Drawing.Size(1503, 27);
            this.viewBindingNavigator.TabIndex = 2;
            this.viewBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem.Text = "Добавить";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(55, 24);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorDeleteItem.Text = "Удалить";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Переместить в начало";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Переместить назад";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Положение";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Текущее положение";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // viewBindingNavigatorSaveItem
            // 
            this.viewBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.viewBindingNavigatorSaveItem.Enabled = false;
            this.viewBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("viewBindingNavigatorSaveItem.Image")));
            this.viewBindingNavigatorSaveItem.Name = "viewBindingNavigatorSaveItem";
            this.viewBindingNavigatorSaveItem.Size = new System.Drawing.Size(29, 24);
            this.viewBindingNavigatorSaveItem.Text = "Сохранить данные";
            // 
            // viewDataGridView
            // 
            this.viewDataGridView.AutoGenerateColumns = false;
            this.viewDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.viewDataGridView.DataSource = this.viewBindingSource;
            this.viewDataGridView.Location = new System.Drawing.Point(185, 59);
            this.viewDataGridView.Name = "viewDataGridView";
            this.viewDataGridView.RowHeadersWidth = 51;
            this.viewDataGridView.RowTemplate.Height = 24;
            this.viewDataGridView.Size = new System.Drawing.Size(1029, 384);
            this.viewDataGridView.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Бі /Триномінальна назва";
            this.dataGridViewTextBoxColumn5.HeaderText = "Бі /Триномінальна назва";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Розміри";
            this.dataGridViewTextBoxColumn6.HeaderText = "Розміри";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 125;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Назва ділянки";
            this.dataGridViewTextBoxColumn7.HeaderText = "Назва ділянки";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 125;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Посадка";
            this.dataGridViewTextBoxColumn8.HeaderText = "Посадка";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 125;
            // 
            // department
            // 
            this.department.Location = new System.Drawing.Point(12, 176);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(137, 33);
            this.department.TabIndex = 4;
            this.department.Text = "Department";
            this.department.UseVisualStyleBackColor = true;
            this.department.Click += new System.EventHandler(this.department_Click);
            // 
            // genu
            // 
            this.genu.Location = new System.Drawing.Point(12, 254);
            this.genu.Name = "genu";
            this.genu.Size = new System.Drawing.Size(137, 33);
            this.genu.TabIndex = 5;
            this.genu.Text = "Genu";
            this.genu.UseVisualStyleBackColor = true;
            this.genu.Click += new System.EventHandler(this.genu_Click);
            // 
            // kind
            // 
            this.kind.Location = new System.Drawing.Point(12, 293);
            this.kind.Name = "kind";
            this.kind.Size = new System.Drawing.Size(137, 33);
            this.kind.TabIndex = 6;
            this.kind.Text = "Kind";
            this.kind.UseVisualStyleBackColor = true;
            this.kind.Click += new System.EventHandler(this.kind_Click);
            // 
            // catalogue
            // 
            this.catalogue.Location = new System.Drawing.Point(12, 98);
            this.catalogue.Name = "catalogue";
            this.catalogue.Size = new System.Drawing.Size(137, 33);
            this.catalogue.TabIndex = 6;
            this.catalogue.Text = "Catalogue";
            this.catalogue.UseVisualStyleBackColor = true;
            this.catalogue.Click += new System.EventHandler(this.catalogue_Click);
            // 
            // area
            // 
            this.area.Location = new System.Drawing.Point(12, 59);
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(137, 33);
            this.area.TabIndex = 7;
            this.area.Text = "Area";
            this.area.UseVisualStyleBackColor = true;
            this.area.Click += new System.EventHandler(this.area_Click);
            // 
            // plant
            // 
            this.plant.Location = new System.Drawing.Point(12, 332);
            this.plant.Name = "plant";
            this.plant.Size = new System.Drawing.Size(137, 33);
            this.plant.TabIndex = 8;
            this.plant.Text = "Plant";
            this.plant.UseVisualStyleBackColor = true;
            this.plant.Click += new System.EventHandler(this.plant_Click);
            // 
            // put
            // 
            this.put.Location = new System.Drawing.Point(12, 371);
            this.put.Name = "put";
            this.put.Size = new System.Drawing.Size(137, 33);
            this.put.TabIndex = 9;
            this.put.Text = "Put";
            this.put.UseVisualStyleBackColor = true;
            this.put.Click += new System.EventHandler(this.put_Click);
            // 
            // family
            // 
            this.family.Location = new System.Drawing.Point(12, 215);
            this.family.Name = "family";
            this.family.Size = new System.Drawing.Size(137, 33);
            this.family.TabIndex = 10;
            this.family.Text = "Family";
            this.family.UseVisualStyleBackColor = true;
            this.family.Click += new System.EventHandler(this.family_Click);
            // 
            // rank
            // 
            this.rank.Location = new System.Drawing.Point(12, 410);
            this.rank.Name = "rank";
            this.rank.Size = new System.Drawing.Size(137, 33);
            this.rank.TabIndex = 12;
            this.rank.Text = "Rank";
            this.rank.UseVisualStyleBackColor = true;
            this.rank.Click += new System.EventHandler(this.rank_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1503, 540);
            this.Controls.Add(this.rank);
            this.Controls.Add(this.family);
            this.Controls.Add(this.put);
            this.Controls.Add(this.plant);
            this.Controls.Add(this.area);
            this.Controls.Add(this.catalogue);
            this.Controls.Add(this.kind);
            this.Controls.Add(this.genu);
            this.Controls.Add(this.department);
            this.Controls.Add(this.viewDataGridView);
            this.Controls.Add(this.viewBindingNavigator);
            this.Controls.Add(this.Category);
            this.Controls.Add(this.Various_plants);
            this.Name = "Menu";
            this.Text = " Menu";
            this.Deactivate += new System.EventHandler(this.Menu_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menu_FormClosing);
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewBindingNavigator)).EndInit();
            this.viewBindingNavigator.ResumeLayout(false);
            this.viewBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Various_plants;
        private System.Windows.Forms.Button Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Database1DataSet database1DataSet;
        private System.Windows.Forms.BindingSource viewBindingSource;
        private Database1DataSetTableAdapters.ViewTableAdapter viewTableAdapter;
        private Database1DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator viewBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Button department;
        private System.Windows.Forms.Button genu;
        private System.Windows.Forms.Button kind;
        private System.Windows.Forms.Button catalogue;
        private System.Windows.Forms.Button area;
        private System.Windows.Forms.Button plant;
        private System.Windows.Forms.Button put;
        private System.Windows.Forms.Button family;
        private System.Windows.Forms.Button rank;
        public System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        public System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        public System.Windows.Forms.ToolStripButton viewBindingNavigatorSaveItem;
        public System.Windows.Forms.DataGridView viewDataGridView;
    }
}

