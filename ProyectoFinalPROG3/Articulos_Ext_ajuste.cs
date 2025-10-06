using Npgsql;
using ProyectoFinalPROG3.Clases;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoFinalPROG3
{
    public partial class Articulos_Ext_ajuste : Form
    {
        inventario form2 = new inventario();
        Clases.dbconeccion gestor = new dbconeccion();
        public Articulos_Ext_ajuste()
        {
            InitializeComponent();
            // Registrar en la auditoría
            Auditoria auditoria = new Auditoria();
            auditoria.RegistrarAuditoria(0, "Abrir Articulo_Ext ajuste"); // Reemplaza "UsuarioActual" con el ID del usuario actual


        }



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


        private void chart()
        {
            NpgsqlConnection cn = Clases.dbconeccion.conectar();
            NpgsqlCommand cm = new NpgsqlCommand();
            cm.Connection = cn;
            cm.CommandType = CommandType.Text;
            cm.CommandText = "select \"ID\",\"Referencia\",\"Descripcion\",\"Numero de marca\",\"Fecha de ingreso\",\"Usuario de ingreso\",\"Usuario MOD\" from articulo where activo=true";
            NpgsqlDataReader dr = cm.ExecuteReader();

            try
            {
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos", "Error" + e.ToString());
            }
            finally
            {
                cn.Close(); cm.Dispose();
            }
        }



        private void Articulos_Ext_ajuste_Load(object sender, EventArgs e)
        {
            chart();
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            comboboxs.SelectedIndex = 0;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            inventario formbase = Owner as inventario;
            NpgsqlConnection cn = Clases.dbconeccion.conectar();



            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];



                try
                {
                    int id = Convert.ToInt32(row.Cells["ID"].Value);


                    // Consulta para obtener los datos. 
                    string query = "select \"Descripcion\",\"Numero de marca\",\"Existencia\",\"Costo\" from articulo where activo=true and \"ID\"=@id";

                    using (var command = new NpgsqlCommand(query, cn))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int rowIndex = formbase.dataGridView1.Rows.Add(); // Agregar una nueva fila y obtener el índice de esa fila
                                formbase.dataGridView1.Rows[rowIndex].Cells[1].Value = reader["Descripcion"].ToString();
                                formbase.dataGridView1.Rows[rowIndex].Cells[2].Value = reader["Numero de marca"].ToString();
                                formbase.dataGridView1.Rows[rowIndex].Cells[3].Value = reader["Costo"].ToString();
                                formbase.dataGridView1.Rows[rowIndex].Cells[5].Value = reader["Existencia"].ToString();

                                this.Hide();
                                form2.Focus();



                            }

                            this.Hide();
                            form2.Focus();

                        }
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Has seleccionado un registro vacio!");
                }
                finally
                {
                    cn.Close();
                }

            }
        }
    }
}

