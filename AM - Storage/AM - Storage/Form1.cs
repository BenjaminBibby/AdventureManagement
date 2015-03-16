using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AM___Storage
{
    public partial class Form1 : Form
    {
        SQLiteConnection dbConn = new SQLiteConnection("Data Source=AdventureManager.db;Version=3");

        bool viewArmor;
        bool viewWeapon;

        public Form1()
        {
            InitializeComponent();

            //this.armorTableAdapter.Fill(this.adventureManagerDataSet.Armor);

            dbConn.Open();
            String sql = "create table if not exists Storage(ID Integer primary key, player_id int, current_space_used int, maxsimum_space)";
            SQLiteCommand command = new SQLiteCommand(sql, dbConn);
            command.ExecuteNonQuery();

            sql = "create table if not exists Armor(ID Integer primary key, weight int, quality string, is_in_storage bool, type string, dmg_mitigation int)";
            command = new SQLiteCommand(sql, dbConn);
            command.ExecuteNonQuery();

            sql = "create table if not exists Weapon(ID Integer primary key, weight int, quality string, is_in_storage bool, type string, dmg int)";
            command = new SQLiteCommand(sql, dbConn);
            command.ExecuteNonQuery();

            sql = "create table if not exists Trinket(ID Integer primary key, weight int, quality string, is_in_storage bool, type string, Attribute_type string, Attribute_value int)";
            command = new SQLiteCommand(sql, dbConn);
            command.ExecuteNonQuery();

            sql = "create table if not exists Equip(Player_ID Integer, Item_ID int)";
            command = new SQLiteCommand(sql, dbConn);
            command.ExecuteNonQuery();

        }
        private void AddSword_Click(object sender, EventArgs e)
        {
            String sql = "insert into Weapon(weight, quality, is_in_storage, type, dmg) values (5, 'common', 1, 'sword', 10)";
            SQLiteCommand command = new SQLiteCommand(sql, dbConn);
            command.ExecuteNonQuery();
            this.armorTableAdapter.Fill(this.adventureManagerDataSet.Armor);
        }

        private void AddArmor_Click(object sender, EventArgs e)
        {
            String sql = "insert into Armor(weight, quality, is_in_storage, type, dmg_mitigation) values (5, 'rare', 0, 'test3', 30)";
            SQLiteCommand command = new SQLiteCommand(sql, dbConn);
            command.ExecuteNonQuery();
            this.armorTableAdapter.Fill(this.adventureManagerDataSet.Armor);
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void MoveArmor_Click(object sender, EventArgs e)
        {
            String sql = "update Armor SET is_in_storage = 0 WHERE ID = 1";
            SQLiteCommand command = new SQLiteCommand(sql, dbConn);
            command.ExecuteNonQuery();

        }
        //Shows the name
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           //listBox1 = sender as ListBox;
           //if (listBox1 != null)
           //{
           //   // test = listBox1.SelectedItem.ToString();
           //}
           
        }

        //Shows the index number
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'adventureManagerDataSet.Weapon' table. You can move, or remove it, as needed.
            this.weaponTableAdapter.Fill(this.adventureManagerDataSet.Weapon);
            // TODO: This line of code loads data into the 'adventureManagerDataSet.Armor' table. You can move, or remove it, as needed.
            this.armorTableAdapter.Fill(this.adventureManagerDataSet.Armor);

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (viewArmor == true)
                {
                    this.armorTableAdapter.FillBy(this.adventureManagerDataSet.Armor);
                }
                else if (viewWeapon == true)
                {
                    this.weaponTableAdapter.Fill(this.adventureManagerDataSet.Weapon);
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        //show armor
        private void button1_Click(object sender, EventArgs e)
        {
            AllFalse();
            viewArmor = true;
        }

        //show weapon
        private void button2_Click(object sender, EventArgs e)
        {
            AllFalse();
            viewWeapon = true;
        }

        private void AllFalse()
        {
            viewWeapon = false;
            viewArmor = false;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void fillByToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.weaponTableAdapter.FillBy(this.adventureManagerDataSet.Weapon);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        
       

      
        


    }
}
