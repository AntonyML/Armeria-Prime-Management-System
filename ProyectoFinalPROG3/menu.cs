using ProyectoFinalPROG3.Clases;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoFinalPROG3
{
    public partial class menu : Form
    {
        Clases.dbconeccion gestor = new dbconeccion();



        public menu()
        {
            InitializeComponent();
            Clases.dbconeccion.MakeMovable(this);
            // Registrar en la auditoría
            Auditoria auditoria = new Auditoria();
            auditoria.RegistrarAuditoria(0, "Abrir Articulo_con_linea"); // Reemplaza "UsuarioActual" con el ID del usuario actual

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form = new users();
            this.Hide();
            Form.Show();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form = new login();
            this.Hide();
            Form.Show();

        }

        //-----------------------------------------------------Cambiar bordes------------------------------------------------------------------------------------------
        private void menu_Paint(object sender, PaintEventArgs e)
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

        private void menu_Load(object sender, EventArgs e)
        {


        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {


            /*
            if(hide()=true) 
            {
                userstrip.Visible = true;
                MessageBox.Show(Clases.dbconeccion.nivel_usuario, "SISTEMA");
            }
            else
            {
                userstrip.Visible = false;
            }
            */
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form = new clientes();
            this.Hide();
            Form.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            gestor.CerrarForm(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            gestor.MaximizarRestaurarForm(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            gestor.MinimizarForm(this);
        }

        private void mantenimientosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            mantenimientosToolStripMenuItem.ForeColor = Color.Black;
        }



        private void userstrip_Click(object sender, EventArgs e)
        {
            Form Form1 = new users();
            Form1.Show();

        }

        private void cerrarSesiónToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form Form1 = new login();

            this.Hide();
            Form1.Show();
        }

        private void clientesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form Form1 = new clientes();
            Form1.Show();
            Form1.Focus();

        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form1 = new articulos();
            Form1.Show();
            Form1.Focus();
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form1 = new marca();
            Form1.Show();
            Form1.Focus();
        }

        private void lineaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form1 = new linea();
            Form1.Show();
            Form1.Focus();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form Form1 = new unidad();
            Form1.Show();
            Form1.Focus();
        }

        private void proveedoresToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form Form1 = new proveedor();
            Form1.Show();
            Form1.Focus();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form Form1 = new vendedor();
            Form1.Show();
            Form1.Focus();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form Form1 = new facturador();
            Form1.Show();
            Form1.Focus();
        }

        private void mantenimientosToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            mantenimientosToolStripMenuItem.ForeColor = Color.White;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            toolStripMenuItem6.ForeColor = Color.Black;
        }

        private void toolStripMenuItem6_DropDownClosed(object sender, EventArgs e)
        {
            toolStripMenuItem6.ForeColor = Color.White;
        }

        private void cONSULTASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cONSULTASToolStripMenuItem.ForeColor = Color.Black;
        }

        private void cONSULTASToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            cONSULTASToolStripMenuItem.ForeColor = Color.White;
        }

        private void cONSULTASToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            cONSULTASToolStripMenuItem.ForeColor = Color.Black;
        }

        private void toolStripMenuItem6_DropDownOpened(object sender, EventArgs e)
        {
            toolStripMenuItem6.ForeColor = Color.Black;
        }

        private void mantenimientosToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            mantenimientosToolStripMenuItem.ForeColor = Color.Black;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Form Form1 = new inventario();


            Form1.Show();
            Form1.Focus();
        }
        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form1 = new Ventas();

            Form1.Show();
            Form1.Focus();
        }

        private void entidadstrip_Click(object sender, EventArgs e)
        {
            Form Form1 = new entidad();
            Form1.Show();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void toolStripMenufact_Click(object sender, EventArgs e)
        {
          /*  Form Form1 = new facturador();
            Form1.Show();
            Form1.Focus(); */
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            Form Form1 = new Cotizacion();

            Form1.Show();
            Form1.Focus();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Form Form1 = new Recibos();

            Form1.Show();
            Form1.Focus();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            Form Form1 = new FormAuditoria();

            Form1.Show();
            Form1.Focus();
        }
    }
}
