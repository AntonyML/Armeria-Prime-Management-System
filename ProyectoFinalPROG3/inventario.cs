using Npgsql;
using ProyectoFinalPROG3.Clases;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProyectoFinalPROG3
{


    public partial class inventario : Form
    {

        public int suma_resta = 0;
        public inventario()
        {
            InitializeComponent();
            Clases.dbconeccion.MakeMovable(this);
            // Registrar en la auditoría
            Auditoria auditoria = new Auditoria();
            auditoria.RegistrarAuditoria(0, "Abrir inventario"); // Reemplaza "UsuarioActual" con el ID del usuario actual

        }
        Clases.dbconeccion gestor = new dbconeccion();
        //-----------------------------------------------------Cambiar bordes------------------------------------------------------------------------------------------
        private void articulosEXT_Paint(object sender, PaintEventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }



        private void LimpiarDataGridView()
        {
            dataGridView1.Rows.Clear();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            // Determinar la operación basada en el ComboBox
            bool esEntrada = combotipo.SelectedItem.ToString() == "Entrada";

            // Iterar sobre cada fila del DataGridView
            /*try
            {*/
            NpgsqlConnection cn = Clases.dbconeccion.conectar();

            DialogResult result = MessageBox.Show("¿Desea guardar el movimiento de inventario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {





                    if (row.Cells[0].Value != null && row.Cells[5].Value != null) // Asegurarse de que ambas celdas tienen valor
                    {


                        string descripcion = row.Cells[1].Value.ToString();
                        int cantidad = Convert.ToInt32(row.Cells[0].Value);

                        decimal valorMaximo;

                        if (decimal.TryParse(row.Cells[5].Value.ToString(), out valorMaximo))
                        {
                            if (combotipo.Text == "Salida" && cantidad > valorMaximo)
                            {
                                MessageBox.Show($"La cantidad en la fila {row.Index + 1} excede el valor máximo.");

                            }
                            else { ActualizarInventario(descripcion, cantidad, esEntrada); }
                        }
                        else
                        {
                            MessageBox.Show($"El valor en la fila {row.Index + 1} no es un número decimal válido.");

                        }






                    }
                }

            }
            /*}catch (Exception) { MessageBox.Show("Error al guardar movimiento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }*/

        }








        private void ActualizarInventario(string descripcion, int cantidad, bool esEntrada)
        {
            // Conexión y consulta


            NpgsqlConnection cn = Clases.dbconeccion.conectar();

            // Obtener la existencia actual
            /*try
            {*/


            string query = "SELECT \"Existencia\" FROM articulo WHERE \"Descripcion\" = @descripcion";
            NpgsqlCommand cmd = new NpgsqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);

            int existenciaActual = Convert.ToInt32(cmd.ExecuteScalar());

            // Calcular la nueva existencia
            int nuevaExistencia = esEntrada ? existenciaActual + cantidad : existenciaActual - cantidad;

            // Actualizar la existencia en la base de datos
            query = "UPDATE articulo SET \"Existencia\" = @nuevaExistencia WHERE \"Descripcion\" = @descripcion";
            cmd = new NpgsqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@nuevaExistencia", nuevaExistencia);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);

            cmd.ExecuteNonQuery();





            // Actualizar ajuste_base
            string txt = textID.Text;
            string txt2 = "ajuste_base";

            if (Clases.dbconeccion.confirmar(txt, txt2))
            {
                using (cmd = new NpgsqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "UPDATE ajuste_base SET \"Fecha de ingreso\" = @fecha, \"Tipo inventario\" = @tipo, \"Costo\" = @costo, \"Valor\" = @valor WHERE \"ID\" = @id;";
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Parse(textFecha.Text));
                    cmd.Parameters.AddWithValue("@tipo", combotipo.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@costo", decimal.Parse(texttotalcosto.Text));
                    cmd.Parameters.AddWithValue("@valor", decimal.Parse(textvalortotal.Text));
                    cmd.Parameters.AddWithValue("@id", int.Parse(textID.Text));
                    cmd.ExecuteNonQuery();
                }


            }
            else
            {
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO ajuste_base (\"Fecha de ingreso\", \"Tipo inventario\", \"Costo\", \"Valor\") VALUES (@fecha, @tipo, @costo, @valor);";
                cmd.Parameters.AddWithValue("@fecha", DateTime.Parse(textFecha.Text));
                cmd.Parameters.AddWithValue("@tipo", combotipo.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@costo", decimal.Parse(texttotalcosto.Text));
                cmd.Parameters.AddWithValue("@valor", decimal.Parse(textvalortotal.Text));
                cmd.Parameters.AddWithValue("@id", int.Parse(textID.Text));
                cmd.ExecuteNonQuery();

            }


            // Insertar en ajuste_detalle
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[1].Value != null) // Columna Descripcion
                {
                    long articuloID;
                    using (cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.CommandText = "SELECT \"ID\" FROM articulo WHERE \"Descripcion\" = @descripcion;";
                        cmd.Parameters.AddWithValue("@descripcion", row.Cells[1].Value.ToString());
                        articuloID = (long)cmd.ExecuteScalar();
                    }

                    using (cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.CommandText = "INSERT INTO ajuste_detalle(\"ID articulo\", \"Cantidad\", \"Costo\", \"Valor\") VALUES(@idAtributo, @col0, @col3, @col4);";
                        cmd.Parameters.AddWithValue("@idAtributo", articuloID);

                        decimal cantidad2 = Convert.ToDecimal(row.Cells[0].Value);
                        cmd.Parameters.AddWithValue("@col0", cantidad2);

                        decimal costo = Convert.ToDecimal(row.Cells[3].Value);
                        cmd.Parameters.AddWithValue("@col3", costo);


                        decimal valor = Convert.ToDecimal(row.Cells[4].Value);
                        cmd.Parameters.AddWithValue("@col4", valor);

                        cmd.ExecuteNonQuery();
                    }
                }
            }





            MessageBox.Show("Movimiento exitoso, articulos actualizados", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarDataGridView();
            using (cmd = new NpgsqlCommand("INSERT INTO ajuste_base DEFAULT VALUES RETURNING \"ID\";", cn))
            {
                textID.Text = cmd.ExecuteScalar().ToString();
            }
            /*}
            catch (Exception) { MessageBox.Show("Error al guardar movimineto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { cn.Close();  }*/


        }

        private void inventario_Load(object sender, EventArgs e)
        {
            textFecha.Text = DateTime.Now.ToString();
            combotipo.SelectedIndex = 0;

            // Obtener la conexión
            NpgsqlConnection cn = Clases.dbconeccion.conectar();

            try
            {
                // Asegurarse de que la conexión esté abierta
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                // Ejecutar el comando
                using (var cmd = new NpgsqlCommand("INSERT INTO ajuste_base DEFAULT VALUES RETURNING \"ID\";", cn))
                {
                    textID.Text = cmd.ExecuteScalar().ToString();
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Error al acceder a la base de datos: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión si está abierta
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
        }





        private void textarticulo_DoubleClick(object sender, EventArgs e)
        {


        }



        private decimal SumarValoresDeColumna(int columnIndex)
        {
            decimal suma = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[columnIndex].Value != null)
                {
                    suma += Convert.ToDecimal(row.Cells[columnIndex].Value);
                }
            }
            return suma;
        }


        public void ActualizarSumas()
        {
            decimal totalCosto = SumarValoresDeColumna(3); // Asume que "Costo" es la columna 3
            decimal totalValor = SumarValoresDeColumna(4); // Asume que "Valor" es la columna 4

            texttotalcosto.Text = totalCosto.ToString("N2"); // Formatea el número a dos decimales
            textvalortotal.Text = totalValor.ToString("N2");
        }


        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == 0 || e.ColumnIndex == 3))
            {
                // Obtiene las celdas usando los índices
                DataGridViewCell cellCantidad = dataGridView1.Rows[e.RowIndex].Cells[0];
                DataGridViewCell cellCosto = dataGridView1.Rows[e.RowIndex].Cells[3];
                DataGridViewCell cellValor = dataGridView1.Rows[e.RowIndex].Cells[4];

                // Verifica si ambas celdas tienen valores
                if (cellCantidad.Value != null && cellCosto.Value != null)
                {
                    decimal cantidad;
                    decimal costo;
                    if (decimal.TryParse(cellCantidad.Value.ToString(), out cantidad) && decimal.TryParse(cellCosto.Value.ToString(), out costo))
                    {
                        // Establece el valor en la celda "Valor" (2)
                        cellValor.Value = cantidad * costo;
                    }
                }
            }

            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                // Obtiene las celdas
                DataGridViewCell cellCantidad = dataGridView1.Rows[e.RowIndex].Cells[0];
                DataGridViewCell cellValorMaximo = dataGridView1.Rows[e.RowIndex].Cells[5];  // Columna "existencia" que actúa como máximo

                if (cellCantidad.Value != null && cellValorMaximo.Value != null)
                {
                    decimal cantidad;
                    decimal valorMaximo;
                    if (decimal.TryParse(cellCantidad.Value.ToString(), out cantidad) && decimal.TryParse(cellValorMaximo.Value.ToString(), out valorMaximo))
                    {
                        if (combotipo.Text == "Salida")
                        {
                            if (cantidad > valorMaximo)
                            {
                                MessageBox.Show("La cantidad no debe exceder la existencia");
                                cellCantidad.Value = 0;
                            }
                        }
                    }
                }
            }







            if (e.ColumnIndex == 3 || e.ColumnIndex == 4) // Asume que "Costo" es la columna 3 y "Valor" es la columna 4
            {
                ActualizarSumas();
            }
        }

        private void combotipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private bool EsNumeroValido(string input)
        {
            if (Regex.IsMatch(input, @"[^\d]"))
            {
                return false; // Validación fallida
            }

            return true; // Validación exitosa

        }



        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                if (!EsNumeroValido(e.FormattedValue.ToString()))
                {
                    e.Cancel = true; // Cancela el cambio si no es válido
                    dataGridView1.Rows[e.RowIndex].ErrorText = "Debe ingresar solo numeros en este campo!";
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText = null; // Limpiar el error
                }
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if (grid.CurrentCell.ColumnIndex == 0)
            {
                // Usa tu función de validación
                Clases.dbconeccion.Validar(e);

            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LimpiarDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Articulos_Ext_ajuste form2 = new Articulos_Ext_ajuste();
            AddOwnedForm(form2);
            form2.Show();
            form2.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            gestor.MinimizarForm(this);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            gestor.CerrarForm(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Deseas salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();

            }
        }
    }
}
