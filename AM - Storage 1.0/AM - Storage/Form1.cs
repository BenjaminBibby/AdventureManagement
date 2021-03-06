﻿using System;
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

        #region Heroes fields + class
        public int Agi;
        public int Str;
        public int Int;
        public int HP;
        public int Prc;
        public int Sal;
        public string Klasse;

        private class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name; Value = value;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }

        }
        public Form1()
        {
            InitializeComponent();
            dbConn.Open();
            CreateTables();
            comboBox1.Items.Add(new Item("Vælg Klasse", 0));
            comboBox1.Items.Add(new Item("Rogue", 1));
            comboBox1.Items.Add(new Item("Mage", 2));
            comboBox1.Items.Add(new Item("Warrior", 3));
            comboBox1.Items.Add(new Item("Priest", 4));
            comboBox1.Items.Add(new Item("Hunter", 5));
        }

        #endregion

        #region Adventure
        public int adventureCount = 0;
        public bool firstClick = true;
        public string name = "";
        public string difficulty = "";
        public string description = "";

        private void button1_Click(object sender, EventArgs e)
        {
            //SQLiteConnection.CreateFile("AdventureManager.db");


            if (firstClick == false && adventureCount < 4)
            {

                Random random = new Random();

                int randomNumber = random.Next(0, 4);
                switch (randomNumber)
                {
                    case 0:
                        {
                            name = "'Forgotten Temple'";
                            description = "'A forgotten temple. Its home to a large tribe of goblins.'";
                            break;
                        }

                    case 1:
                        {
                            name = "'Desert Labyrinth'";
                            description = "'A labyrinth located in the desert. Its said that sandworms can be found there.'";
                            break;
                        }

                    case 2:
                        {
                            name = "'Shrine of Darkness'";
                            description = "'A shrine which is home to a cult which worships a demon.'";
                            break;
                        }

                    case 3:
                        {
                            name = "'Underwater Cavern'";
                            description = "'An underwater cavern which is inhabited by mutated Crabs.'";
                            break;
                        }
                }
                randomNumber = random.Next(0, 5);
                switch (randomNumber)
                {
                    case 0:
                        {
                            difficulty = "'Very Easy'";
                            break;
                        }

                    case 1:
                        {
                            difficulty = "'Easy'";
                            break;
                        }

                    case 2:
                        {
                            difficulty = "'Normal'";
                            break;
                        }

                    case 3:
                        {
                            difficulty = "'Hard'";
                            break;
                        }
                    case 4:
                        {
                            difficulty = "'Very Hard'";
                            break;
                        }
                }
                //SQLiteConnection dbConn = new SQLiteConnection("Data Source=AdventureManager.db;Version=3");
                //dbConn.Open();

                string sql;
                sql = string.Format("insert into Adventures(name, difficulty, info) values ({0}, {1}, {2})", name, difficulty, description);
                SQLiteCommand command = new SQLiteCommand(sql, dbConn);
                command.ExecuteNonQuery();
                adventureCount++;

                sql = "select * from Adventures Where ID=4";
                command = new SQLiteCommand(sql, dbConn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listBox1.Items.Add(reader["name"] + ",      " + reader["difficulty"] + ",      " + reader["info"]);
                }
            }

            if (adventureCount == 0 && firstClick == true)
            {
                //SQLiteConnection dbConn = new SQLiteConnection("Data Source=AdventureManager.db;Version=3");
                //dbConn.Open();
                String sql = "create table if not exists Storage(ID Integer primary key, player_id int, current_space_used int, maxsimum_space)";
                SQLiteCommand command = new SQLiteCommand(sql, dbConn);
                command.ExecuteNonQuery();

                sql = "create table if not exists Items(ID Integer primary key, weight int, quality string, is_in_storage bool, type string)";
                command = new SQLiteCommand(sql, dbConn);
                command.ExecuteNonQuery();

                sql = "create table if not exists Adventures(ID Integer primary key, name string, difficulty string, info string)";
                command = new SQLiteCommand(sql, dbConn);
                command.ExecuteNonQuery();

                sql = "insert into Adventures(name, difficulty, info) values ('Forgotten Temple   ', 'Hard        ', 'A forgotten temple. Its home to a large tribe of goblins.')";
                command = new SQLiteCommand(sql, dbConn);
                command.ExecuteNonQuery();
                adventureCount += 1;

                sql = "insert into Adventures(name, difficulty, info) values ('Desert Labyrinth     ', 'Easy        ', 'A labyrinth located in the desert. Its said that sandworms can be found there.')";
                command = new SQLiteCommand(sql, dbConn);
                command.ExecuteNonQuery();
                adventureCount += 1;

                sql = "insert into Adventures(name, difficulty, info) values ('Shrine of Darkness ', 'Very Hard', 'A shrine which is home to a cult which worships a demon')";
                command = new SQLiteCommand(sql, dbConn);
                command.ExecuteNonQuery();
                adventureCount += 1;

                //sql = "insert into Adventures(name, difficulty, info) values ('Underwater Cavern', 'Normal     ', 'An underwater cavern which is inhabited by mutated Crabs')";
                //command = new SQLiteCommand(sql, dbConn);
                //command.ExecuteNonQuery();
                //adventureCount++;

                sql = "select * from Adventures";
                command = new SQLiteCommand(sql, dbConn);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listBox1.Items.Add(reader["name"] + ",      " + reader["difficulty"] + ",      " + reader["info"]);
                }
                firstClick = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (listBox1.SelectedIndex == 0)
            //{
            //    textBox1.Text = "b";
            //}
            //if (listBox1.SelectedIndex == 1)
            //{
            //    textBox1.Text = "a";
            //}
            //if (listBox1.SelectedIndex == 2)
            //{
            //    textBox1.Text = "c";
            //}
            //if (listBox1.SelectedIndex == 3)
            //{
            //    textBox1.Text = "w";
            //}
        }
        #endregion

        #region Storage

        private void CreateTables()
        {
            String sql = "create table if not exists Trinket(ID Integer primary key, weight int, quality string, is_in_storage bool, attribute_type string, attribute_amount int)";
            SQLiteCommand command = new SQLiteCommand(sql, dbConn);
            command.ExecuteNonQuery();

            sql = "create table if not exists Heroes(ID Integer primary key, Intelligence int, strength int, agility int, hp int, Buy_price int, Spiller_ID int, Exp int, Salary int, Equipped_Items_ID int, Class string)";
            command = new SQLiteCommand(sql, dbConn);
            command.ExecuteNonQuery();

        }

        private void UpdateStorage()
        {
            //Armor list
            listBox2.Items.Clear();
            string sql = "select * from armor WHERE is_in_storage = 1";
            SQLiteCommand command = new SQLiteCommand(sql, dbConn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listBox2.Items.Add(reader["ID"] + "\t" + reader["weight"] + "\t" + reader["quality"] + "\t\t" + reader["type"] + "\t" + reader["dmg_mitigation"]);

            }

            //Weapon list
            listBox3.Items.Clear();
            sql = "select * from weapon WHERE is_in_storage = 1";
            command = new SQLiteCommand(sql, dbConn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                listBox3.Items.Add(reader["ID"] + "\t" + reader["weight"] + "\t" + reader["quality"] + "\t\t" + reader["type"] + "\t" + reader["dmg"]);
            }

            //Trinket list
            listBox1.Items.Clear();
            sql = "select * from trinket WHERE is_in_storage = 1";
            command = new SQLiteCommand(sql, dbConn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                listBox1.Items.Add(reader["ID"] + "\t" + reader["weight"] + "\t" + reader["quality"] + "\t\t" + reader["type"] + "\t" + reader["attribute_type"] + "\t" + reader["attribute_value"]);
            }

          

        }

        #endregion

        #region random empthy shit

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateStorage();
        }
        #endregion

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdateStorage();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void tabControl2_Click(object sender, EventArgs e)
        {
            UpdateStorage();
        }

        private void tabPage3_Click_1(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string sql = "insert into Trinket(weight, quality, is_in_storage, type, attribute_type, attribute_value) values (0.1, 'legendary', 1, 'ring', 'int', 10)";
            SQLiteCommand command = new SQLiteCommand(sql, dbConn);
            command.ExecuteNonQuery();

        }

        private void tabPage2_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label16.Text = "Venligst vælg en gyldig Klasse.";
                label16.Visible = true;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                // Rogue Klasse, Agility Højest, så Int, så Strength, HP standard.
                Random rnd = new Random();
                Agi = rnd.Next(50, 100);
                Int = rnd.Next(15, 65);
                Str = rnd.Next(0, 50);
                 HP = rnd.Next(10, 15);
                 Prc = rnd.Next(1500, 2500);
                 Sal = rnd.Next(200, 400);
                Klasse = "Rogue";
                label16.Text = "Klasse: " + Klasse + "\r\n Health: " + HP + "\r\n Styrke: " + Str + "\r\n Intelligens: " + Int + "\r\n Agilitet: " + Agi + "\r\n Pris: " + Prc + "\r\n Løn: " + Sal;
                label16.Visible = true;

            }
            else if (comboBox1.SelectedIndex == 2)
            {
                // Mage Klasse, Int Højest, så Agi, så Strength, HP Lav.
                Random rnd = new Random();
                 Agi = rnd.Next(15, 65);
                 Int = rnd.Next(50, 100);
                 Str = rnd.Next(0, 50);
                 HP = rnd.Next(8, 12);
                 Prc = rnd.Next(1500, 2500);
                 Sal = rnd.Next(200, 400);
                 Klasse = "Mage";
                label16.Text = "Klasse: " + Klasse + "\r\n Health: " + HP + "\r\n Styrke: " + Str + "\r\n Intelligens: " + Int + "\r\n Agilitet: " + Agi + "\r\n Pris: " + Prc + "\r\n Løn: " + Sal;
                label16.Visible = true;

            }
            else if (comboBox1.SelectedIndex == 3)
            {
                // Warrior Klasse, Strength Højest, så Agi, så Int, HP Høj.
                Random rnd = new Random();
                 Agi = rnd.Next(15, 65);
                 Int = rnd.Next(0, 50);
                 Str = rnd.Next(50, 100);
                 HP = rnd.Next(12, 17);
                 Prc = rnd.Next(1500, 2500);
                 Sal = rnd.Next(200, 400);
                 Klasse = "Warrior";
                label16.Text = "Klasse: " + Klasse + "\r\n Health: " + HP + "\r\n Styrke: " + Str + "\r\n Intelligens: " + Int + "\r\n Agilitet: " + Agi + "\r\n Pris: " + Prc + "\r\n Løn: " + Sal;
                label16.Visible = true;

            }
            else if (comboBox1.SelectedIndex == 4)
            {
                // Priest Klasse, Int Højest, så Agi, så Strength, HP Lav.
                Random rnd = new Random();
                 Agi = rnd.Next(15, 65);
                 Int = rnd.Next(50, 100);
                 Str = rnd.Next(0, 50);
                 HP = rnd.Next(8, 12);
                 Prc = rnd.Next(1500, 2500);
                 Sal = rnd.Next(200, 400);
                 Klasse = "Priest";
                label16.Text = "Klasse: " + Klasse + "\r\n Health: " + HP + "\r\n Styrke: " + Str + "\r\n Intelligens: " + Int + "\r\n Agilitet: " + Agi + "\r\n Pris: " + Prc + "\r\n Løn: " + Sal;
                label16.Visible = true;

            }
            else if (comboBox1.SelectedIndex == 5)
            {
                // Hunter Klasse, Agility Højest, så Int, så Strength, HP standard.
                Random rnd = new Random();
                 Agi = rnd.Next(50, 100);
                 Int = rnd.Next(15, 65);
                 Str = rnd.Next(0, 50);
                 HP = rnd.Next(10, 15);
                 Prc = rnd.Next(1500, 2500);
                 Sal = rnd.Next(200, 400);
                 Klasse = "Hunter";
                label16.Text += "Klasse: " + Klasse + "\r\n Health: " + HP + "\r\n Styrke: " + Str + "\r\n Intelligens: " + Int + "\r\n Agilitet: " + Agi + "\r\n Pris: " + Prc + "\r\n Løn: " + Sal;
                label16.Visible = true;

            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string sql = "insert into Heroes(Intelligence, strength, agility, hp, Buy_price, Spiller_ID, Exp, Salary, Equipped_Items_ID, Class) values (" + Int + ", " + Str + ", " + Agi + ", " + HP + ", " + Prc + ", " + 1 + ", '0', " + Sal + ", '0', '" + Klasse + "')";
            SQLiteCommand command = new SQLiteCommand(sql, dbConn);
            command.ExecuteNonQuery();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
