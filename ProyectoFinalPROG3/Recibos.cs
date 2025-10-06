using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using static System.Net.Mime.MediaTypeNames;

namespace ProyectoFinalPROG3
{
    public partial class Recibos : Form
    {
        public Recibos()
        {
            InitializeComponent();
            Clases.dbconeccion.MakeMovable(this);
            // Registrar en la auditoría
            Auditoria auditoria = new Auditoria();
            auditoria.RegistrarAuditoria(0, "Abrir Articulo_con_linea"); // Reemplaza "UsuarioActual" con el ID del usuario actual

        }

        private void Recibos_Load(object sender, EventArgs e)
        {
            // Código para inicializar el formulario
            CargarRecibos();
        }

        private void CargarRecibos()
        {
            try
            {
                using (NpgsqlConnection cn = Clases.dbconeccion.conectar())
                {
                    string query = "SELECT * FROM recibos"; // Asume que hay una tabla llamada 'recibos'
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, cn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los recibos: " + ex.Message);
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            // Código para agregar un nuevo recibo
            try
            {
                using (NpgsqlConnection cn = Clases.dbconeccion.conectar())
                {
                    string query = "INSERT INTO recibos (fecha, cliente, monto) VALUES (@fecha, @cliente, @monto)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@fecha", DateTime.Parse(textFecha.Text));
                        cmd.Parameters.AddWithValue("@cliente", textCliente.Text);
                        cmd.Parameters.AddWithValue("@monto", decimal.Parse(textMonto.Text));
                        cmd.ExecuteNonQuery();
                    }
                }
                CargarRecibos(); // Recargar los recibos después de agregar uno nuevo
                MessageBox.Show("Recibo agregado exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el recibo: " + ex.Message);
            }
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            // Código para actualizar un recibo seleccionado
            try
            {
                using (NpgsqlConnection cn = Clases.dbconeccion.conectar())
                {
                    string query = "UPDATE recibos SET fecha = @fecha, cliente = @cliente, monto = @monto WHERE id = @id";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@id", int.Parse(textID.Text));
                        cmd.Parameters.AddWithValue("@fecha", DateTime.Parse(textFecha.Text));
                        cmd.Parameters.AddWithValue("@cliente", textCliente.Text);
                        cmd.Parameters.AddWithValue("@monto", decimal.Parse(textMonto.Text));
                        cmd.ExecuteNonQuery();
                    }
                }
                CargarRecibos(); // Recargar los recibos después de actualizar uno
                MessageBox.Show("Recibo actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el recibo: " + ex.Message);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            // Código para eliminar un recibo seleccionado
            try
            {
                using (NpgsqlConnection cn = Clases.dbconeccion.conectar())
                {
                    string query = "DELETE FROM recibos WHERE id = @id";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@id", int.Parse(textID.Text));
                        cmd.ExecuteNonQuery();
                    }
                }
                CargarRecibos(); // Recargar los recibos después de eliminar uno
                MessageBox.Show("Recibo eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el recibo: " + ex.Message);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                textID.Text = row.Cells["id"].Value.ToString();
                textFecha.Text = row.Cells["fecha"].Value.ToString();
                textCliente.Text = row.Cells["cliente"].Value.ToString();
                textMonto.Text = row.Cells["monto"].Value.ToString();
            }
        }
    }
}
