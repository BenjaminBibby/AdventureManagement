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

        public Form1()
        {
            InitializeComponent();
            dbConn.Open();
            CreateTables();
        }


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

<<<<<<< HEAD
        private void Form1_Load(object sender, EventArgs e)
=======
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
>>>>>>> e89ee58eb494ad51a096a403ecf329e189c14bfa
        {

        }

<<<<<<< HEAD
=======
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
>>>>>>> e89ee58eb494ad51a096a403ecf329e189c14bfa
    }
}
