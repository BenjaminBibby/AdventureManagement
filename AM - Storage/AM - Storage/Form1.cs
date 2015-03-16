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
        public Form1()
        {
            InitializeComponent();
        }
        public int adventureCount = 0;
        public bool firstClick = true;
        public string name = "";
        public string difficulty = "";
        public string description = "";

        private void button1_Click(object sender, EventArgs e)
        {
            //SQLiteConnection.CreateFile("AdventureManager.db");
            

            if(firstClick == false && adventureCount < 4)
            {

                Random random = new Random();

                int randomNumber = random.Next(0, 4);
                switch(randomNumber)
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
                SQLiteConnection dbConn = new SQLiteConnection("Data Source=AdventureManager.db;Version=3");
                dbConn.Open();

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
                SQLiteConnection dbConn = new SQLiteConnection("Data Source=AdventureManager.db;Version=3");
                dbConn.Open();
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
            if(listBox1.SelectedIndex == 0)
            {
                textBox1.Text = "b";
            }
            if (listBox1.SelectedIndex == 1)
            {
                textBox1.Text = "a";
            }
            if (listBox1.SelectedIndex == 2)
            {
                textBox1.Text = "c";
            }
            if (listBox1.SelectedIndex == 3)
            {
                textBox1.Text = "w";
            }
        }

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

    }
}
