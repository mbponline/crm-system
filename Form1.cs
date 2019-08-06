using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Management;
using System.Media;
using System.Xml;
using System.ComponentModel;
using System.Data.Sql;
using MySql.Data.MySqlClient;


namespace ServiceProgramm
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        int i = 10;//значение счетчика переподключения

        private bool botimer = false;//отключает формы ввода и кнопку авторизации

        string Connect = "server=localhost;user id=mysql;password=mysql;persistsecurityinfo=True;database=main";//данные от базы данных

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
            timer1.Interval = 1;
            timer1.Tick += new EventHandler(OnTimer);
            timer1.Enabled = true;

            timer2.Interval = 1000;
            timer2.Tick += new EventHandler(OnTimer2);
            timer2.Enabled = false;
        }

        private void OnTimer(object sender, EventArgs e)
        {
            try
            {
                //Задаем команду
                string CommandText = "SELECT Count(*) FROM  checkConnection WHERE connection = 1";
                MySqlConnection myConnection = new MySqlConnection(Connect);
                //выполняем команду
                MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
                //открытие подключения
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(myCommand);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1") // сверка значений
                {
                    timer1.Interval = 10000;
                    label1.ForeColor = Color.Green;
                    label1.Text = "соединение установлено";
                    label3.Enabled = false;
                    label3.Visible = false;
                    botimer = false;
                    timer2.Enabled = false;

                }
                else
                {
                    timer1.Interval = 10000;
                    label2.ForeColor = Color.Red;
                    label2.Text = "нету подключения к базе";
                    botimer = true;
                    timer2.Enabled = true;
                }
                myConnection.Close();  //Code
            }

            catch (Exception)
            {
                timer1.Interval = 10000;
                label1.ForeColor = Color.Red;
                label1.Text = "нету подключения к базе";
                botimer = true;
                timer2.Enabled = true;
            }
        }

        private void OnTimer2(object sender, EventArgs e)
        {
            
            if (i == 0)
            {

            }
            else
            {
                do
                {
                    i--;
                }
                while (i == 0);
                {
                    label3.Text = "До переподключения "+i +" секунд";
                    if(i <= 1)
                    {
                        label3.Text = "Попытка переподключения";
                        i = +10;
                    }
                }
            }


            if (botimer == true)
            {
                metroTextBox1.Enabled = false;
                metroTextBox2.Enabled = false;
                pictureBox1.Enabled = false;
                label3.Enabled = true;
                label3.Visible = true;
            }
        }


        public double loggedUser
        {
            get
            {
                return Convert.ToDouble(metroTextBox1.Text);
            }
        }




        private void MetroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void MetroTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }




        private void PictureBox1_Click(object sender, EventArgs e)
        {

            //Задаем команду
            string CommandText = "SELECT Count(*) FROM  authorization WHERE login = '" + metroTextBox1.Text + "' AND password = '" + metroTextBox2.Text + "' LIMIT 1";
            MySqlConnection myConnection = new MySqlConnection(Connect);
            //выполняем команду
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
            //открытие подключения
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(myCommand);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1") // сверка значений
            {

                Form2 frm = new Form2();
                frm.loggeduser = metroTextBox1.Text;
                frm.Show();
                this.Hide();
                timer1.Enabled = false;
                timer2.Enabled = false;
            }
            else
            {
                MessageBox.Show("Пожалуйста, проверьте правильность введенных данных!");
            }
            myConnection.Close();

        }

        private void Timer1_Tick_1(object sender, EventArgs e)
        {

        }
    }
}
