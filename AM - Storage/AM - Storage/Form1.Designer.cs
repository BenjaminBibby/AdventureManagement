namespace AM___Storage
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AddSword = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.AddArmor = new System.Windows.Forms.Button();
            this.MoveArmor = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.weaponBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.adventureManagerDataSet = new AM___Storage.AdventureManagerDataSet();
            this.armorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.armorTableAdapter = new AM___Storage.AdventureManagerDataSetTableAdapters.ArmorTableAdapter();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.weaponTableAdapter = new AM___Storage.AdventureManagerDataSetTableAdapters.WeaponTableAdapter();
            this.Storage = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.listBox4 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.weaponBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adventureManagerDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.armorBindingSource)).BeginInit();
            this.Storage.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddSword
            // 
            this.AddSword.Location = new System.Drawing.Point(5, 11);
            this.AddSword.Name = "AddSword";
            this.AddSword.Size = new System.Drawing.Size(156, 23);
            this.AddSword.TabIndex = 0;
            this.AddSword.Text = "Add Common Sword";
            this.AddSword.UseVisualStyleBackColor = true;
            this.AddSword.Click += new System.EventHandler(this.AddSword_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AddArmor
            // 
            this.AddArmor.Location = new System.Drawing.Point(6, 40);
            this.AddArmor.Name = "AddArmor";
            this.AddArmor.Size = new System.Drawing.Size(156, 23);
            this.AddArmor.TabIndex = 1;
            this.AddArmor.Text = "Add Rare Armor";
            this.AddArmor.UseVisualStyleBackColor = true;
            this.AddArmor.Click += new System.EventHandler(this.AddArmor_Click);
            // 
            // MoveArmor
            // 
            this.MoveArmor.Location = new System.Drawing.Point(6, 69);
            this.MoveArmor.Name = "MoveArmor";
            this.MoveArmor.Size = new System.Drawing.Size(155, 23);
            this.MoveArmor.TabIndex = 2;
            this.MoveArmor.Text = "Move armor to hero";
            this.MoveArmor.UseVisualStyleBackColor = true;
            this.MoveArmor.Click += new System.EventHandler(this.MoveArmor_Click);
            // 
            // listBox1
            // 
            this.listBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.weaponBindingSource, "type", true));
            this.listBox1.DataSource = this.weaponBindingSource;
            this.listBox1.DisplayMember = "type";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(184, 6);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(184, 292);
            this.listBox1.TabIndex = 0;
            this.listBox1.ValueMember = "type";
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // weaponBindingSource
            // 
            this.weaponBindingSource.DataMember = "Weapon";
            this.weaponBindingSource.DataSource = this.adventureManagerDataSet;
            // 
            // adventureManagerDataSet
            // 
            this.adventureManagerDataSet.DataSetName = "AdventureManagerDataSet";
            this.adventureManagerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // armorBindingSource
            // 
            this.armorBindingSource.DataMember = "Armor";
            this.armorBindingSource.DataSource = this.adventureManagerDataSet;
            // 
            // armorTableAdapter
            // 
            this.armorTableAdapter.ClearBeforeFill = true;
            // 
            // listBox2
            // 
            this.listBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.weaponBindingSource, "ID", true));
            this.listBox2.DataSource = this.weaponBindingSource;
            this.listBox2.DisplayMember = "ID";
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(164, 6);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(47, 292);
            this.listBox2.TabIndex = 8;
            this.listBox2.ValueMember = "ID";
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(374, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Armor";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(374, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Weapon";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // weaponTableAdapter
            // 
            this.weaponTableAdapter.ClearBeforeFill = true;
            // 
            // Storage
            // 
            this.Storage.Controls.Add(this.tabPage1);
            this.Storage.Controls.Add(this.tabPage2);
            this.Storage.Location = new System.Drawing.Point(12, 12);
            this.Storage.Name = "Storage";
            this.Storage.SelectedIndex = 0;
            this.Storage.Size = new System.Drawing.Size(1089, 378);
            this.Storage.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Controls.Add(this.MoveArmor);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.AddArmor);
            this.tabPage1.Controls.Add(this.listBox2);
            this.tabPage1.Controls.Add(this.AddSword);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1081, 349);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Weapons";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBox3);
            this.tabPage2.Controls.Add(this.listBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1081, 349);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Armor";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // listBox3
            // 
            this.listBox3.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.armorBindingSource, "type", true));
            this.listBox3.DataSource = this.armorBindingSource;
            this.listBox3.DisplayMember = "type";
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 16;
            this.listBox3.Location = new System.Drawing.Point(133, 21);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(184, 292);
            this.listBox3.TabIndex = 10;
            this.listBox3.ValueMember = "type";
            // 
            // listBox4
            // 
            this.listBox4.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.armorBindingSource, "ID", true));
            this.listBox4.DataSource = this.armorBindingSource;
            this.listBox4.DisplayMember = "ID";
            this.listBox4.FormattingEnabled = true;
            this.listBox4.ItemHeight = 16;
            this.listBox4.Location = new System.Drawing.Point(113, 21);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(47, 292);
            this.listBox4.TabIndex = 11;
            this.listBox4.ValueMember = "ID";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 490);
            this.Controls.Add(this.Storage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.weaponBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adventureManagerDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.armorBindingSource)).EndInit();
            this.Storage.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddSword;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button AddArmor;
        private System.Windows.Forms.Button MoveArmor;
        private System.Windows.Forms.ListBox listBox1;
        private AdventureManagerDataSet adventureManagerDataSet;
        private System.Windows.Forms.BindingSource armorBindingSource;
        private AdventureManagerDataSetTableAdapters.ArmorTableAdapter armorTableAdapter;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingSource weaponBindingSource;
        private AdventureManagerDataSetTableAdapters.WeaponTableAdapter weaponTableAdapter;
        private System.Windows.Forms.TabControl Storage;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.ListBox listBox4;
    }
}

