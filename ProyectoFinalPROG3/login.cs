using Npgsql;
using ProyectoFinalPROG3.Clases;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoFinalPROG3
{
    public partial class login : Form
    {
        Clases.dbconeccion gestor = new dbconeccion();
       



        public login()
        {
            InitializeComponent();
            Clases.dbconeccion.MakeMovable(this);
            InitializePlaceholders();
            // Registrar en la auditoría
            Auditoria auditoria = new Auditoria();
            auditoria.RegistrarAuditoria(0, "Abrir Login"); // Reemplaza "UsuarioActual" con el ID del usuario actual


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }






        private void InitializePlaceholders()
        {
            // Establecer el marcador de posición para el nombre de usuario
            txtusuario.Text = "Usuario";
            txtusuario.ForeColor = System.Drawing.Color.Gray;

            // Establecer el marcador de posición para la contraseña
            txt_pass.Text = "Contraseña";
            txt_pass.ForeColor = System.Drawing.Color.Gray;
            txt_pass.UseSystemPasswordChar = false;

            // Asignar eventos
            txtusuario.Enter += RemovePlaceholderText;
            txtusuario.Leave += SetPlaceholderText;

            txt_pass.Enter += RemovePlaceholderText;
            txt_pass.Leave += SetPlaceholderText;
        }

        private void RemovePlaceholderText(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.ForeColor == System.Drawing.Color.Gray)
            {
                textBox.Text = string.Empty;
                textBox.ForeColor = System.Drawing.Color.Black;

                if (textBox.Name == "txt_pass")
                {
                    textBox.UseSystemPasswordChar = true;
                }
            }
        }

        private void SetPlaceholderText(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox.Name == "txtusuario")
                {
                    textBox.Text = "Usuario";
                }
                else if (textBox.Name == "txt_pass")
                {
                    textBox.Text = "Contraseña";
                    textBox.UseSystemPasswordChar = false; // Mostrar el texto "Contraseña" sin puntitos
                }

                textBox.ForeColor = System.Drawing.Color.Gray;
            }
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            this.botonpass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonpass.FlatAppearance.BorderSize = 0;


        }


        private void Login()
        {
            NpgsqlConnection cn = Clases.dbconeccion.conectar();
            string query = "SELECT * FROM usuario WHERE usuario=@usuario AND clave=@clave AND activo=true";
            NpgsqlCommand cm = new NpgsqlCommand(query, cn);
            cm.Parameters.AddWithValue("@usuario", txtusuario.Text);
            cm.Parameters.AddWithValue("@clave", txt_pass.Text);

            NpgsqlDataReader dr = cm.ExecuteReader();

            try
            {
                if (dr.Read())
                {
                    Form Form2 = new menu();
                    this.Hide();
                    Form2.Show();

                    Clases.dbconeccion objetoconeccion = new Clases.dbconeccion();
                    Clases.dbconeccion.Name_usuario = dr["usuario"].ToString();
                    Clases.dbconeccion.id_usuario = dr["usuario_id"].ToString();
                    Clases.dbconeccion.nivel_usuario = dr["nivel_de_acceso"].ToString();

                    RegistrarAuditoria("Inicio de sesión", "usuario", Clases.dbconeccion.Name_usuario);
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RegistrarAuditoria("Intento fallido de inicio de sesión", "usuario", txtusuario.Text);
                }
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos, error: " + e.ToString());
            }
            finally
            {
                cn.Close();
                cm.Dispose();
            }
        }
        public void ActualizarCliente(int id, string nuevoNombre)
        {
            using (NpgsqlConnection cn = Clases.dbconeccion.conectar())
            {
                string query = "UPDATE cliente SET nombre=@nuevoNombre WHERE id=@id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@nuevoNombre", nuevoNombre);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    // Registrar auditoría
                    string descripcion = $"Cliente ID: {id}, Nuevo Nombre: {nuevoNombre}";
                    RegistrarAuditoria("Actualización", "cliente", Clases.dbconeccion.Name_usuario, descripcion);
                }
            }
        }
        public void IntentarAccionNoPermitida(string accion, string usuario)
        {
            string descripcion = $"El usuario {usuario} intentó realizar la acción: {accion}";
            RegistrarAuditoria("Acción no permitida", "N/A", usuario, descripcion);
        }
        private void RegistrarAuditoria(string accion, string tabla, string usuario, string descripcion = "")
        {
            using (NpgsqlConnection cn = Clases.dbconeccion.conectar())
            {
                string query = "INSERT INTO auditoria (usuario, accion, tabla, fecha, descripcion) VALUES (@usuario, @accion, @tabla, @fecha, @descripcion)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@accion", accion);
                    cmd.Parameters.AddWithValue("@tabla", tabla);
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            gestor.MinimizarForm(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            gestor.CerrarForm(this);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Login();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //-----------------------------------------------------Cambiar bordes------------------------------------------------------------------------------------------
        private void login_Paint(object sender, PaintEventArgs e)
        {
            using (Pen borderPen = new Pen(Color.Black, 5))
            {
                // Lateral izquierdo
                e.Graphics.DrawLine(borderPen, 0, 0, 0, this.Height);
                // Lateral derecho
                e.Graphics.DrawLine(borderPen, this.Width - 1, 0, this.Width - 1, this.Height);
                // Inferior
                e.Graphics.DrawLine(borderPen, 0, this.Height - 1, this.Width, this.Height - 1);
            }
        }

        private void txtusuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_pass.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txt_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
                e.SuppressKeyPress = true;
            }
        }

        private void txt_pass_Enter(object sender, EventArgs e)
        {

        }

        private void txt_pass_TextChanged(object sender, EventArgs e)
        {

        }

    

        private void botonpass_Click_1(object sender, EventArgs e)
        {




            this.ActiveControl = null;
            if (txt_pass.ForeColor != System.Drawing.Color.Gray)
            {

            
                // Alterna el valor de UseSystemPasswordChar para mostrar u ocultar la contraseña
                txt_pass.UseSystemPasswordChar = !txt_pass.UseSystemPasswordChar;

            // Cambia la imagen del botón según el estado de la contraseña
            if (txt_pass.UseSystemPasswordChar)
            {
                botonpass.BackgroundImage = Properties.Resources.eye_closed;
            }
            else
            {
                botonpass.BackgroundImage = Properties.Resources.eye_open;
            }
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            if (txt_pass.ForeColor != System.Drawing.Color.Gray)
            {


                // Alterna el valor de UseSystemPasswordChar para mostrar u ocultar la contraseña
                txt_pass.UseSystemPasswordChar = !txt_pass.UseSystemPasswordChar;

                // Cambia la imagen del botón según el estado de la contraseña
                if (txt_pass.UseSystemPasswordChar)
                {
                    botonpass.BackgroundImage = Properties.Resources.eye_closed;
                }
                else
                {
                    botonpass.BackgroundImage = Properties.Resources.eye_open;
                }
            }
        }
        //-----------------------------------------------------Cambiar bordes------------------------------------------------------------------------------------------
    }
}
