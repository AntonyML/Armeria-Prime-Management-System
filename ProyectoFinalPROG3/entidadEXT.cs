using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalPROG3
{
    public partial class entidadEXT : Form
    {
        public entidadEXT()
        {
            InitializeComponent();
            // Registrar en la auditoría
            Auditoria auditoria = new Auditoria();
            auditoria.RegistrarAuditoria(0, "Abrir EntidadEXT"); // Reemplaza "UsuarioActual" con el ID del usuario actual

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
