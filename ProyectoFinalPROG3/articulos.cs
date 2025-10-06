using Npgsql;
using ProyectoFinalPROG3.Clases;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoFinalPROG3
{
    public partial class articulos : Form
    {
        string ruta = "";
        string text2 = "articulo";
        Form Form = new menu();
        public int s = 0;
        private System.Windows.Forms.ToolTip toolTip;
        Clases.dbconeccion gestor = new dbconeccion();

        public articulos()
        {
            // Registrar en la auditoría
            Auditoria auditoria = new Auditoria();
            auditoria.RegistrarAuditoria(0, "Abrir Articulos"); // Reemplaza "UsuarioActual" con el ID del usuario actual

            InitializeComponent();
            Clases.dbconeccion.MakeMovable(this);
            this.toolTip1.SetToolTip(this.button9, "Agregar");
            this.toolTip1.SetToolTip(this.button1, "limpiar imagen");
            this.toolTip1.SetToolTip(this.button3, "Guardar");
            this.toolTip1.SetToolTip(this.button2, "Limpiar");
            this.toolTip1.SetToolTip(this.button4, "Eliminar");
            this.toolTip1.SetToolTip(this.button5, "Salir");
        }

        //-----------------------------------------------------Cambiar bordes------------------------------------------------------------------------------------------
        private void articulos_Paint(object sender, PaintEventArgs e)
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
        //------------------------------------------------------------------------------------------------------------------------------------------------------------





        //Funcion para actualizar el registro en caso de existir
        private void actualizar()
        {

            if (string.IsNullOrEmpty(txtdescripcion.Text) || string.IsNullOrEmpty(txtlinea.Text) || string.IsNullOrEmpty(txtnumero.Text) || string.IsNullOrEmpty(txtmarca.Text) || string.IsNullOrEmpty(txtproveedor.Text) || string.IsNullOrEmpty(txtcosto.Text) || string.IsNullOrEmpty(txtprecio.Text) || string.IsNullOrEmpty(txtunidad.Text) || string.IsNullOrEmpty(txtexistencia.Text))
            {

                cambiarcolor1();
                MessageBox.Show("Los campos en amarillo NO pueden estar vacios!");

            }

            else
            {
                DialogResult result = MessageBox.Show("¿Se ha encontrado un articulo, deseas actualizarlo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    textusermod.Text = Clases.dbconeccion.Name_usuario;

                    NpgsqlConnection cn = Clases.dbconeccion.conectar();
                    NpgsqlCommand cmd = new NpgsqlCommand("update articulo set \"Referencia\" ='" + txtreferencia.Text + "',\"ID\" = '" + txtnumero.Text + "',\"Descripcion\" ='" + txtdescripcion.Text + "',\"Numero de marca\" ='" + txtmarca.Text + "',\"Numero de proveedor\" ='" + txtproveedor.Text + "',\"Numero de linea\" ='" + txtlinea.Text + "',\"Precio\" ='" + txtprecio.Text + "',\"Existencia\" ='" + txtexistencia.Text + "',\"Costo\" ='" + txtcosto.Text + "',\"Numero de unidad\" ='" + txtunidad.Text + "',\"Observaciones\" ='" + txtobservacion.Text + "',\"Usuario de ingreso\" ='" + textuser.Text + "',\"Usuario MOD\" ='" + textusermod.Text + "',\"ITBIS\" ='" + txtitbis.Text + "',\"rutaimagen\" ='" + ruta.ToString() + "'where activo=true and \"ID\"='" + txtnumero.Text + "'", cn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Articulo actualizado con exito", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cambiarcolor2();
                        cn.Close();
                        cmd.Dispose();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al actualizar articulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (string.IsNullOrEmpty(txtdescripcion.Text) || string.IsNullOrEmpty(txtlinea.Text) || string.IsNullOrEmpty(txtnumero.Text) || string.IsNullOrEmpty(txtmarca.Text) || string.IsNullOrEmpty(txtproveedor.Text) || string.IsNullOrEmpty(txtcosto.Text) || string.IsNullOrEmpty(txtprecio.Text) || string.IsNullOrEmpty(txtunidad.Text) || string.IsNullOrEmpty(txtexistencia.Text))
            {

                cambiarcolor1();
                MessageBox.Show("Los campos en amarillo NO pueden estar vacios!");



            }
            else
            {
                DialogResult result = MessageBox.Show("¿Deseas eliminar este articulo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (Clases.dbconeccion.confirmar(txtnumero.Text, text2))
                        {
                            NpgsqlCommand cmd = new NpgsqlCommand("update articulo set \"activo\" = false where activo= true and \"ID\"='" + txtnumero.Text + "'", cn);


                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Articulo eliminado con exito", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cambiarcolor2();
                            limpiar();
                        }


                        else
                        {
                            MessageBox.Show("Articulo no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cambiarcolor2();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Articulo no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cambiarcolor2();
                    }
                    finally { cn.Close(); }


                }
            }
        }








        //Funcion para crear el registro en caso de NO existir
        private void crear()
        {
            if (string.IsNullOrEmpty(txtdescripcion.Text) || string.IsNullOrEmpty(txtlinea.Text) || string.IsNullOrEmpty(txtnumero.Text) || string.IsNullOrEmpty(txtmarca.Text) || string.IsNullOrEmpty(txtproveedor.Text) || string.IsNullOrEmpty(txtcosto.Text) || string.IsNullOrEmpty(txtprecio.Text) || string.IsNullOrEmpty(txtunidad.Text) || string.IsNullOrEmpty(txtexistencia.Text))
            {

                cambiarcolor1();
                MessageBox.Show("Los campos en amarillo NO pueden estar vacios!");



            }
            else
            {
                DialogResult result = MessageBox.Show("¿No se ha encontrado ningun Articulo, deseas crearlo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                NpgsqlConnection cn = Clases.dbconeccion.conectar();

                try
                {
                    if (result == DialogResult.Yes)
                    {

                        textFecha.Text = DateTime.Now.ToShortDateString();
                        NpgsqlCommand cmd = new NpgsqlCommand("insert into articulo (\"ID\",\"Referencia\",\"Descripcion\",\"Numero de marca\",\"Numero de proveedor\",\"Numero de linea\",\"Precio\",\"Existencia\",\"Fecha de ingreso\",\"rutaimagen\",\"Costo\",\"Numero de unidad\",\"ITBIS\",\"Observaciones\",\"Usuario de ingreso\",\"activo\") VALUES ('" + txtnumero.Text + "','" + txtreferencia.Text + "','" + txtdescripcion.Text + "','" + txtmarca.Text + "','" + txtproveedor.Text + "','" + txtlinea.Text + "','" + txtprecio.Text + "','" + txtexistencia.Text + "','" + textFecha.Text + "','" + ruta.ToString() + "','" + txtcosto.Text + "','" + txtunidad.Text + "','" + txtitbis.Text + "','" + txtobservacion.Text + "','" + textuser.Text + "','" + "true" + "')", cn);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Articulo creado con exito", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cambiarcolor2();





                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al crear Articulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cambiarcolor2();
                }
                finally
                {
                    cn.Close();
                }
            }
        }






        private void button6_Click(object sender, EventArgs e)
        {
            gestor.MinimizarForm(this);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            gestor.CerrarForm(this);
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


        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = null;
            laberconfirmar();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ruta = Clases.dbconeccion.CargarImagenNueva(pictureBox1);

            laberconfirmar();
        }

        private void articulos_Load(object sender, EventArgs e)
        {
            textFecha.Text = DateTime.Now.ToShortDateString();
            txtitbis.SelectedIndex = 0;
            if (textuser.Text == "")
            {
                textuser.Text = Clases.dbconeccion.Name_usuario;
            }
            s = 0;

        }




        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textFecha_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtobservacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtlimite_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttelefono_TextChanged(object sender, EventArgs e)
        {
            Clases.dbconeccion.validarmoneda(txtprecio);
        }

        private void txtlimite_Validating(object sender, CancelEventArgs e)
        {
            Clases.dbconeccion.validarmoneda(txtprecio);
        }

        private void txttelefono_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtnumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.dbconeccion.Validar(e);

            Clases.dbconeccion.ValidarLetra(e);

        }

        private void limpiar()
        {
            textFecha.Text = DateTime.Now.ToShortDateString();
            txtreferencia.Text = null;
            txtproveedor.Text = null;
            txtdescripcion.Text = null;
            txtmarca.Text = null;
            txtlinea.Text = null;
            txtunidad.Text = null;
            txtcosto.Text = null;
            txtprecio.Text = null;
            txtexistencia.Text = null;
            txtobservacion.Text = null;
            textuser.Text = null;
            textusermod.Text = null;
            pictureBox1.Image = null;
            ruta = "";
        }


        public void cambiarcolor1()
        {
            label12.ForeColor = Color.Yellow;
            label4.ForeColor = Color.Yellow;
            label13.ForeColor = Color.Yellow;
            label7.ForeColor = Color.Yellow;
            label6.ForeColor = Color.Yellow;
            label1.ForeColor = Color.Yellow;
            label9.ForeColor = Color.Yellow;
            label8.ForeColor = Color.Yellow;
            label5.ForeColor = Color.Yellow;


        }

        public void cambiarcolor2()
        {
            label12.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label13.ForeColor = Color.White;
            label7.ForeColor = Color.White;
            label6.ForeColor = Color.White;
            label1.ForeColor = Color.White;
            label9.ForeColor = Color.White;
            label8.ForeColor = Color.White;
            label5.ForeColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string text = txtnumero.Text;

            textusermod.Text = Clases.dbconeccion.Name_usuario;

            if (string.IsNullOrEmpty(txtdescripcion.Text) || string.IsNullOrEmpty(txtnumero.Text) || string.IsNullOrEmpty(txtmarca.Text) || string.IsNullOrEmpty(txtproveedor.Text) || string.IsNullOrEmpty(txtcosto.Text) || string.IsNullOrEmpty(txtprecio.Text) || string.IsNullOrEmpty(txtunidad.Text) || string.IsNullOrEmpty(txtexistencia.Text))
            {

                cambiarcolor1();
                MessageBox.Show("Los campos en amarillo NO pueden estar vacios!");

            }
            else
            {
                if (Clases.dbconeccion.confirmar(text, text2))
                {
                    if (label12.ForeColor == Color.Yellow)
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

        private void button7_Click(object sender, EventArgs e)
        {
            articulosEXT form2 = new articulosEXT();
            AddOwnedForm(form2);
            s = 1;
            form2.Show();
            form2.Focus();
            laberconfirmar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            borrar();
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

        private void txtcosto_Validating(object sender, CancelEventArgs e)
        {
            Clases.dbconeccion.validarmoneda(txtcosto);
        }

        private void txtcosto_TextChanged(object sender, EventArgs e)
        {
            Clases.dbconeccion.validarmoneda(txtcosto);
        }

        private void txtproveedor_DoubleClick(object sender, EventArgs e)
        {
            articulo_con_proveedor form2 = new articulo_con_proveedor();
            AddOwnedForm(form2);
            form2.Show();
            form2.Focus();
        }

        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.dbconeccion.Validar(e);

        }

        private void txtmarca_DoubleClick(object sender, EventArgs e)
        {
            Articulo_con_marca form2 = new Articulo_con_marca();
            AddOwnedForm(form2);
            form2.Show();
            form2.Focus();
        }

        private void txtmarca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Articulo_con_marca form2 = new Articulo_con_marca();
                AddOwnedForm(form2);
                form2.Show();
                form2.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtproveedor_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                articulo_con_proveedor form2 = new articulo_con_proveedor();
                AddOwnedForm(form2);
                form2.Show();
                form2.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtlinea_DoubleClick(object sender, EventArgs e)
        {
            Articulo_con_linea form2 = new Articulo_con_linea();
            AddOwnedForm(form2);
            form2.Show();
            form2.Focus();
        }

        private void txtlinea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Articulo_con_linea form2 = new Articulo_con_linea();
                AddOwnedForm(form2);
                form2.Show();
                form2.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtunidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                articulo_con_unidad form2 = new articulo_con_unidad();
                AddOwnedForm(form2);
                form2.Show();
                form2.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtunidad_DoubleClick(object sender, EventArgs e)
        {
            articulo_con_unidad form2 = new articulo_con_unidad();
            AddOwnedForm(form2);
            form2.Show();
            form2.Focus();
        }
    }
}
