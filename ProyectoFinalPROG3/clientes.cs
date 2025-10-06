using Npgsql;
using ProyectoFinalPROG3.Clases;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoFinalPROG3
{
    public partial class clientes : Form
    {
        string text2 = "cliente";
        Form Form = new menu();
        string ruta = "";
        private System.Windows.Forms.ToolTip toolTip;


        //-----------------------------------------------------Cambiar bordes------------------------------------------------------------------------------------------
        private void clientes_Paint(object sender, PaintEventArgs e)
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
        //-----------------------------------------------------Cambiar bordes------------------------------------------------------------------------------------------


        

        Clases.dbconeccion gestor = new dbconeccion();

        public clientes()
        {
            // Registrar en la auditoría
            Auditoria auditoria = new Auditoria();
            auditoria.RegistrarAuditoria(0, "Abrir Clientes"); // Reemplaza "UsuarioActual" con el ID del usuario actual

            InitializeComponent();

            Clases.dbconeccion.MakeMovable(this);
            this.toolTip1.SetToolTip(this.button9, "Agregar");
            this.toolTip1.SetToolTip(this.button1, "limpiar imagen");
            this.toolTip1.SetToolTip(this.button3, "Guardar");
            this.toolTip1.SetToolTip(this.button2, "Limpiar");
            this.toolTip1.SetToolTip(this.button4, "Eliminar");
            this.toolTip1.SetToolTip(this.button5, "Salir");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.dbconeccion.Validar(e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            gestor.MinimizarForm(this);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            gestor.CerrarForm(this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {



            ruta = Clases.dbconeccion.CargarImagenNueva(pictureBox1);

            laberconfirmar();

        }




        private void clientes_Load(object sender, EventArgs e)
        {

            textFecha.Text = DateTime.Now.ToShortDateString();
            txtstatus.SelectedIndex = 0;

        }




        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.dbconeccion.Validar(e);
        }

        private void textBox11_DoubleClick(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtstatus_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Deseas salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                Form.Focus();
            }
        }



        //Funcion para actualizar el registro en caso de existir
        private void actualizar()
        {
            if (string.IsNullOrEmpty(txtnombre.Text) || string.IsNullOrEmpty(txtnumero.Text) || string.IsNullOrEmpty(txtcedula.Text) || string.IsNullOrEmpty(txtciudad.Text) || string.IsNullOrEmpty(txtdireccion.Text) || string.IsNullOrEmpty(txttelefono.Text) || string.IsNullOrEmpty(txttipo.Text) || string.IsNullOrEmpty(txtstatus.Text))
            {

                cambiarcolor1();
                MessageBox.Show("Los campos en amarillo NO pueden estar vacios!");



            }
            else
            {
                DialogResult result = MessageBox.Show("¿Se ha encontrado un cliente, deseas actualizarlo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    NpgsqlConnection cn = Clases.dbconeccion.conectar();
                    NpgsqlCommand cmd = new NpgsqlCommand("update cliente set \"Nombre\" ='" + txtnombre.Text + "',\"ID\" = '" + txtnumero.Text + "',\"Razon social\" ='" + txtrazon.Text + "',\"Cedula o RNC\" ='" + txtcedula.Text + "',\"Tipo de cliente\" ='" + txttipo.Text + "',\"Direccion\" ='" + txtdireccion.Text + "',\"Ciudad\" ='" + txtciudad.Text + "',\"Telefono\" ='" + txttelefono.Text + "',\"Email\" ='" + txtemail.Text + "',\"Limite de credito\" ='" + txtlimite.Text + "',\"Observacion\" ='" + txtobservacion.Text + "',\"Status\" ='" + txtstatus.Text + "',\"rutaimagen\" ='" + ruta.ToString() + "'where activo=true and \"ID\"='" + txtnumero.Text + "'", cn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cliente actualizado con exito", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cambiarcolor2();
                        cn.Close();
                        cmd.Dispose();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al actualizar cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cambiarcolor2();
                    }
                    finally { cn.Close(); cmd.Dispose(); }
                }

            }
        }










        //Funcion para borrar el registro en caso de existir
        private void borrar()
        {

            NpgsqlConnection cn = Clases.dbconeccion.conectar();
            if (string.IsNullOrEmpty(txtnombre.Text) || string.IsNullOrEmpty(txtnumero.Text) || string.IsNullOrEmpty(txtcedula.Text) || string.IsNullOrEmpty(txtciudad.Text) || string.IsNullOrEmpty(txtdireccion.Text) || string.IsNullOrEmpty(txttelefono.Text) || string.IsNullOrEmpty(txttipo.Text) || string.IsNullOrEmpty(txtstatus.Text))
            {

                cambiarcolor1();
                MessageBox.Show("Los campos en amarillo NO pueden estar vacios!");



            }
            else
            {
                DialogResult result = MessageBox.Show("¿Deseas eliminar este cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    NpgsqlCommand cmd = new NpgsqlCommand("update cliente set \"activo\" = false where activo= true and \"ID\"='" + txtnumero.Text + "'", cn);
                    try
                    {
                        if (Clases.dbconeccion.confirmar(txtnumero.Text, text2))
                        {

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Cliente eliminado con exito", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cambiarcolor2();
                            limpiar();
                        }
                        else
                        {
                            MessageBox.Show("Cliente no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cambiarcolor2();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Cliente no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cambiarcolor2();
                    }
                    finally { cn.Close(); cmd.Dispose(); }

                }
            }
        }









        //Funcion para crear el registro en caso de NO existir
        private void crear()
        {

            if (string.IsNullOrEmpty(txtnombre.Text) || string.IsNullOrEmpty(txtnumero.Text) || string.IsNullOrEmpty(txtcedula.Text) || string.IsNullOrEmpty(txtciudad.Text) || string.IsNullOrEmpty(txtdireccion.Text) || string.IsNullOrEmpty(txttelefono.Text) || string.IsNullOrEmpty(txttipo.Text) || string.IsNullOrEmpty(txtstatus.Text))
            {

                cambiarcolor1();
                MessageBox.Show("Los campos en amarillo NO pueden estar vacios!");



            }
            else
            {

                DialogResult result = MessageBox.Show("¿No se ha encontrado ningun cliente, desesas crearlo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    textFecha.Text = DateTime.Now.ToShortDateString();
                    NpgsqlConnection cn = Clases.dbconeccion.conectar();
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into cliente (\"Nombre\",\"ID\",\"Fecha de ingreso\",\"Razon social\",\"Cedula o RNC\",\"Tipo de cliente\",\"Direccion\",\"Ciudad\",\"Telefono\",\"Email\",\"Limite de credito\",\"Observacion\",\"Status\",\"rutaimagen\",\"activo\") VALUES ('" + txtnombre.Text + "','" + txtnumero.Text + "','" + textFecha.Text + "','" + txtrazon.Text + "','" + txtcedula.Text + "','" + txttipo.Text + "','" + txtdireccion.Text + "','" + txtciudad.Text + "','" + txttelefono.Text + "','" + txtemail.Text + "','" + txtlimite.Text + "','" + txtobservacion.Text + "','" + txtstatus.Text + "','" + ruta.ToString() + "','" + "true" + "')", cn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cliente creado con exito", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cambiarcolor2();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al crear cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cambiarcolor2();
                    }
                    finally { cn.Close(); cmd.Dispose(); }
                }
            }
        }
















        public void cambiarcolor1()
        {
            label12.ForeColor = Color.Yellow;
            label2.ForeColor = Color.Yellow;
            label4.ForeColor = Color.Yellow;
            label13.ForeColor = Color.Yellow;
            label5.ForeColor = Color.Yellow;
            label6.ForeColor = Color.Yellow;
            label7.ForeColor = Color.Yellow;
            labelstatus.ForeColor = Color.Yellow;

        }

        public void cambiarcolor2()
        {
            label12.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label13.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label6.ForeColor = Color.White;
            label7.ForeColor = Color.White;
            labelstatus.ForeColor = Color.White;
        }



        private void button3_Click(object sender, EventArgs e)
        {
            string text = txtnumero.Text;


            if (string.IsNullOrEmpty(txtnombre.Text) || string.IsNullOrEmpty(txtnumero.Text) || string.IsNullOrEmpty(txtcedula.Text) || string.IsNullOrEmpty(txtciudad.Text) || string.IsNullOrEmpty(txtdireccion.Text) || string.IsNullOrEmpty(txttelefono.Text) || string.IsNullOrEmpty(txttipo.Text) || string.IsNullOrEmpty(txtstatus.Text))
            {

                cambiarcolor1();
                MessageBox.Show("Los campos en amarillo NO pueden estar vacios!");



            }
            else
            {
                if (Clases.dbconeccion.confirmar(text, text2))
                {
                    if (labelstatus.ForeColor == Color.Yellow)
                    {
                        cambiarcolor2();
                    }
                    actualizar();

                }
                else
                {
                    crear();

                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void limpiar()
        {
            textFecha.Text = DateTime.Now.ToShortDateString();
            txtcedula.Text = null;
            txtciudad.Text = null;
            txtdireccion.Text = null;
            txtemail.Text = null;
            txtlimite.Text = null;
            txtnombre.Text = null;
            txtnumero.Text = null;
            txtobservacion.Text = null;
            txtrazon.Text = null;
            txtstatus.SelectedIndex = 0;
            txttelefono.Text = null;
            txttipo.Text = null;
            pictureBox1.Image = null;
            ruta = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
        }



        private void txtcedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.dbconeccion.Validar(e);
        }

        private void txttelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.dbconeccion.Validar(e);
        }

        private void txtlimite_Leave(object sender, EventArgs e)
        {


        }

        private void button7_Click(object sender, EventArgs e)
        {
            clientesEXT form2 = new clientesEXT();
            AddOwnedForm(form2);
            form2.Show();
            form2.Focus();
            laberconfirmar();
        }

        private void txtlimite_Click(object sender, EventArgs e)
        {

        }



        private void txtlimite_Validating(object sender, CancelEventArgs e)
        {
            Clases.dbconeccion.validarmoneda(txtlimite);
        }

        private void txtlimite_Validated(object sender, EventArgs e)
        {
            Clases.dbconeccion.validarmoneda(txtlimite);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            borrar();
        }

        private void textFecha_TextChanged(object sender, EventArgs e)
        {

        }


        public void laberconfirmar()
        {
            if (pictureBox1.ImageLocation != null)
            {
                // Si hay una imagen cargada en el PictureBox
                label14.SendToBack(); // Ocultar el label
            }
            else
            {
                // Si no hay una imagen cargada en el PictureBox
                label14.BringToFront();  // Mostrar el label
            }
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = null;
            laberconfirmar();


        }

        private void clientes_Validating(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox1_Validated(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Validating(object sender, CancelEventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            clientesEXT form2 = new clientesEXT();
            AddOwnedForm(form2);
            form2.Show();
            form2.Focus();
            laberconfirmar();
        }
    }
}
