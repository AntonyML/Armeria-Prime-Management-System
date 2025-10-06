using Npgsql;
using ProyectoFinalPROG3.Buscadores;
using ProyectoFinalPROG3.Clases;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoFinalPROG3
{
    public partial class Ventas : Form
    {
        dbconeccion obj = new dbconeccion();

        private int existencia = 0;

        private decimal PrecioArt = 0;
        private decimal subtotal = 0;
        private decimal totalNeto = 0;
        private decimal Monto = 0;
        private decimal ITBIS = 0;
        private ComboBox cbUnidadMedida;

        string TipoVenta = "";
        public Ventas()
        {
            // Registrar en la auditoría
            Auditoria auditoria = new Auditoria();
            auditoria.RegistrarAuditoria(0, "Abrir ventas"); // Reemplaza "UsuarioActual" con el ID del usuario actual

            InitializeComponent();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void Articulo_Click(object sender, EventArgs e)
        {
            Busca_Articulo BA = new Busca_Articulo();
            AddOwnedForm(BA);
            BA.Show();
            BA.Focus();
        }
        private void Vendedor_Click(object sender, EventArgs e)
        {
            Busca_Vendedor BV = new Busca_Vendedor();
            AddOwnedForm(BV);
            BV.Show();
            BV.Focus();
        }
        private void Facturador_Click(object sender, EventArgs e)
        {
            Busca_Facturador BF = new Busca_Facturador();
            AddOwnedForm(BF);
            BF.Show();
            BF.Focus();
        }
        private void NoCliente_Click(object sender, EventArgs e)
        {
            Busca_Cliente BC = new Busca_Cliente();
            AddOwnedForm(BC);
            BC.Show();
            BC.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";

                }
            }
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";

                }
            }
        }

        private void llenarTabla()
        {
            dbconeccion obj = new dbconeccion();
            NpgsqlConnection conexion = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=enyer.12 ; Database=armeria prime");
            try
            {
                conexion.Open();
                string consulta = "select * from ventas_d where VentaNo = " + NoVenta.Text;
                NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(consulta, conexion);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                dataGridView1.DataSource = dt;
                NpgsqlCommand ejecutar = new NpgsqlCommand(consulta, conexion);
                NpgsqlDataReader leer;
                leer = ejecutar.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos: " + ex);
            }
            conexion.Close();
        }
        private void limpiaTabla()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            txtTotalDescuento.Clear();
            textITBIS.Clear();
            txtTotal.Clear();
            txtTotalNeto.Clear();
        }
        private Boolean validator()
        {
            if (Vendedor.Text.Equals(""))
            {
                Vendedor.Focus();
                return false;
            }
            else if (Facturador.Text.Equals(""))
            {
                Facturador.Focus();
                return false;
            }
            else if (NoCliente.Text.Equals(""))
            {
                NoCliente.Focus();
                return false;
            }
            else if (NumCantidad.Value == 0)
            {
                NumCantidad.Focus();
                return false;
            }
            else if (Numdescuento.Value == 0)
            {
                Numdescuento.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (validator())
            {
                decimal descuento = Numdescuento.Value;
                decimal precio = Convert.ToDecimal(txtPrecio.Text);
                decimal cantidad = NumCantidad.Value;
                decimal imp = 0;
                //subtotal = Convert.ToDecimal(txtSubTotal.Text);

                // Calcular descuento
                descuento = precio * (descuento / 100);
                precio -= descuento;

                // Calcular monto según la unidad de medida
                string unidadSeleccionada = cbUnidadMedida.SelectedItem.ToString();
                if (unidadSeleccionada == "caja")
                {
                    // Obtener el factor de conversión de la base de datos
                    int conversionFactor = GetConversionFactor(Articulo.Text);
                    cantidad *= conversionFactor;
                }

                // Calcular monto
                Monto = precio * cantidad;

                // Calcular ITBIS
                if (ImpuestoProd.Checked == true)
                {
                    ITBIS = Monto * 0.18M;
                    imp += ITBIS;
                }

                subtotal += Monto;
                totalNeto = (subtotal + imp);

                // ITBIS = 0;
                if (radioContado.Checked == true)
                {
                    TipoVenta = "A";
                }
                else if (radioCredito.Checked == true)
                {
                    TipoVenta = "C";
                }

                decimal exitenciaArticulo = decimal.Parse(txtExistencia.Text) - cantidad;

                if (exitenciaArticulo < 0)
                {
                    MessageBox.Show("La existencia de este producto es menor que la cantidad", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    NumCantidad.Value = 0;
                    return;
                }
                else
                {
                    string update = "UPDATE articulo SET " +
                                    "existencia = " + exitenciaArticulo +
                                    " WHERE descripcion = '" + Articulo.Text + "'";
                    try
                    {
                        obj.EjecutaQuery(update);
                        MessageBox.Show("Ejecuto Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al Ejecutar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    string consulta = "INSERT INTO ventas_d VALUES (" +
                                      int.Parse(NoVenta.Text) + ",'" +
                                      TipoVenta + "','" +
                                      Articulo.Text + "'," +
                                      NumCantidad.Value + "," +
                                      decimal.Parse(txtPrecio.Text) + "," +
                                      descuento + "," +
                                      Numdescuento.Value + "," +
                                      precio + "," +
                                      ITBIS + "," +
                                      totalNeto + ")";

                    try
                    {
                        obj.EjecutaQuery(consulta);
                        MessageBox.Show("Ejecuto Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al Ejecutar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    llenarTabla();
                }

                txtExistencia.Clear();
                txtPrecio.Clear();
                Articulo.Clear();
                radioCredito.Checked = false;
                NumCantidad.Value = 0;
                Numdescuento.Value = 0;

                decimal TotalDescuento = 0;
                decimal TotalImpuesto = 0;
                decimal TotalMonto = 0;
                decimal TotalNeto = 0;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    TotalDescuento += Convert.ToDecimal(row.Cells["Column5"].Value);
                    TotalMonto += Convert.ToDecimal(row.Cells["MontoA"].Value);
                    TotalImpuesto += Convert.ToDecimal(row.Cells["Impuesto"].Value);
                }
                txtTotalDescuento.Text = Convert.ToString(TotalDescuento);
                txtTotal.Text = Convert.ToString(TotalMonto);
                txtTotalNeto.Text = Convert.ToString(TotalMonto + TotalImpuesto - TotalDescuento);
                textITBIS.Text = Convert.ToString(TotalImpuesto);
            }
        }
        private int GetConversionFactor(string descripcionArticulo)
        {
            int factor = 1; // Valor por defecto para "detalle"
            using (NpgsqlConnection cn = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=enyer.12; Database=armeria prime"))
            {
                string query = "SELECT conversion_detalle_a_caja FROM articulo WHERE descripcion = @descripcion";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@descripcion", descripcionArticulo);
                    cn.Open();
                    factor = (int)cmd.ExecuteScalar();
                }
            }
            return factor;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            limpiaTabla();
        }

        private void Quitar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                string idToDelete = dataGridView1.Rows[rowIndex].Cells["Column2"].Value.ToString();
                int cantToDelete = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["Column3"].Value);

                using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=enyer.12 ; Database=armeria prime"))
                {
                    connection.Open();

                    // Eliminar fila de la base de datos
                    string deleteQuery = "DELETE FROM ventas_d WHERE ArticuloNo = @ID and Cantidad = @Cant";
                    NpgsqlCommand deleteCommand = new NpgsqlCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@ID", idToDelete);
                    deleteCommand.Parameters.AddWithValue("@Cant", cantToDelete);
                    deleteCommand.ExecuteNonQuery();

                    connection.Close();
                }
                // Eliminar fila del DataGridView
                dataGridView1.Rows.RemoveAt(rowIndex);
            }
        }
        private void txtTotalPagado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void NoVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Evita que se ingrese el carácter no válido
            }
        }
        private void Vendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Facturador_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void NoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Grabar_Click(object sender, EventArgs e)
        {
            dbconeccion obj = new dbconeccion();
            if (string.IsNullOrWhiteSpace(NoVenta.Text))
            {
                MessageBox.Show("El No.Venta no puede estar vacío.", "Error de validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrWhiteSpace(Vendedor.Text))
            {
                MessageBox.Show("El Vendedor no puede estar vacío.", "Error de validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (string.IsNullOrWhiteSpace(Facturador.Text))
            {
                MessageBox.Show("El Facturador no puede estar vacío.", "Error de validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrWhiteSpace(NoCliente.Text))
            {
                MessageBox.Show("El NoCliente  no puede estar vacío.", "Error de validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (radioContado.Checked == true)
            {
                if (double.Parse(txtTotalPagado.Text) >= double.Parse(txtTotalNeto.Text))
                {
                    string consulta = "INSERT INTO ventas_m VALUES (" +
                                       int.Parse(NoVenta.Text) + ",'C'," +
                                       int.Parse(NoCliente.Text) + ",'" +
                                       NombreCliente.Text + "'," +
                                       int.Parse(Vendedor.Text) + "," +
                                       int.Parse(Facturador.Text) + ",GetDate()," +
                                       decimal.Parse(txtTotalPagado.Text) + "," +
                                       decimal.Parse(txtTotalDescuento.Text) + "," +
                                       decimal.Parse(textITBIS.Text) + ",''," +
                                       decimal.Parse(txtTotal.Text) + "," +
                                       decimal.Parse(txtTotalNeto.Text) + ",'P')";

                    try
                    {
                        // obj.EjecutaQuery(consulta);
                        MessageBox.Show("Ejecuto Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiaTabla();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al Ejecutar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El valor Pagado debe de ser Mayor o igual Al Total Neto", "Error de validación",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            llenarTabla();
        }
        private void NoVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dbconeccion obj = new dbconeccion();
                string consulta = "SELECT * FROM ventas_m WHERE ventano = @Venta";

                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("Server=localhost;User Id=postgres; Password=enyer.12 ; Database=armeria prime");
                    command.Parameters.AddWithValue("@Venta", NoVenta.Text);

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        if (reader["Estado"].ToString().Equals("P"))
                        {
                            MessageBox.Show("Esta Vente Ya Fue Procesada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            NoVenta.Clear();
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los datos: " + ex);
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Vendedor_TextChanged(object sender, EventArgs e)
        {

        }
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}