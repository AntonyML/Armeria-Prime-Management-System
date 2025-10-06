using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalPROG3
{
    public partial class RecuperarContraseñaForm : Form
    {
        public RecuperarContraseñaForm()
        {
            InitializeComponent();
            // Registrar en la auditoría
            Auditoria auditoria = new Auditoria();
            auditoria.RegistrarAuditoria(0, "Abrir Recuperar contraseña"); // Reemplaza "UsuarioActual" con el ID del usuario actual

        }
    }
}
