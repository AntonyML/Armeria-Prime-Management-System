using Npgsql;
using ProyectoFinalPROG3.Clases;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProyectoFinalPROG3
{
    public partial class Cotizacion : Form
    {
        public Cotizacion()
        {
            InitializeComponent();
            Clases.dbconeccion.MakeMovable(this);
            // Registrar en la auditoría
            Auditoria auditoria = new Auditoria();
            auditoria.RegistrarAuditoria(0, "Abrir Cotizacion"); // Reemplaza "UsuarioActual" con el ID del usuario actual

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

        private void LimpiarDataGridView()
        {
            dataGridView1.Rows.Clear();
        }

        private void buttonCotizar_Click(object sender, EventArgs e)
        {
            NpgsqlConnection cn = Clases.dbconeccion.conectar();

            // Verificar la conexión
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[1].Value != null) // Asegurarse de que ambas celdas tienen valor
                {
                    string descripcion = row.Cells[1].Value.ToString();
                    int cantidad = Convert.ToInt32(row.Cells[0].Value);

                    // Aquí puedes obtener el precio del artículo si es necesario para la cotización
                    decimal precio;
                    using (var cmd = new NpgsqlCommand("SELECT \"Precio\" FROM articulo WHERE \"Descripcion\" = @descripcion;", cn))
                    {
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        precio = (decimal)cmd.ExecuteScalar();
                    }

                    decimal valor = cantidad * precio;

                    // Aquí podrías acumular el valor total de la cotización si es necesario
                    // Por ejemplo, almacenarlo en una variable o en un TextBox para mostrar el total
                    textvalortotal.Text = valor.ToString("N2");
                }
            }

            MessageBox.Show("Cotización calculada con éxito", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Cotizacion_Load(object sender, EventArgs e)
        {
            textFecha.Text = DateTime.Now.ToString();
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

            if (e.ColumnIndex == 3 || e.ColumnIndex == 4) // Asume que "Costo" es la columna 3 y "Valor" es la columna 4
            {
                ActualizarSumas();
            }
        }

        private void combotipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Implementa la lógica si es necesario
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
                    dataGridView1.Rows[e.RowIndex].ErrorText = "Debe ingresar solo números en este campo!";
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
            // Implementa la lógica si es necesario
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LimpiarDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
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
