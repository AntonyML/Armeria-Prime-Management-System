using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace ProyectoFinalPROG3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void login()
        {
            
            NpgsqlConnection cn = new NpgsqlConnection("Server=localhost; Port=5432; User Id=postgres; Password=0208809 ; Database=armeria prime");
            NpgsqlCommand cm = new NpgsqlCommand("select usuario,clave from usuarios where usuario='" + txtusuario.Text+"' and clave='"+txt_pass.Text+"'", cn);
            cn.Open();
            NpgsqlDataReader dr =cm.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Acceso autorizado", "SISTEMA");
                


            }
            else
                {
                MessageBox.Show("Acceso NO autorizado", "SISTEMA");
            }
            cn.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* Clases.dbconeccion objetoconeccion=new Clases.dbconeccion();
              objetoconeccion.conectar();
            */

            login();
            Form form1 = new Form1();
            Form form2 = new Form2();
            form1.Hide();
            form2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
