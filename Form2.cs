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
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        public Form2()
        {
            InitializeComponent();
        }



        private void Form2_Load(object sender, EventArgs e)
        {
                
        }

        public string loggeduser
        {
            get { return metroLabel1.Text; }
            set { metroLabel1.Text = "Вы вошли как : " + value; }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

    }
}
