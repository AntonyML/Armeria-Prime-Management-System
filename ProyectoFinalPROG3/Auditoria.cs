using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoFinalPROG3
{
    public class Auditoria
    {
        private NpgsqlConnection _connection;

        public Auditoria()
        {
            _connection = Clases.dbconeccion.conectar();
        }

        public void RegistrarInicioSesion(int usuarioId)
        {
            RegistrarEvento(usuarioId, "Inicio de sesión", $"Usuario con ID {usuarioId} ha iniciado sesión.");
        }
        public void RegistrarAuditoria(int usuarioId, string mensaje)
        {
            try
            {
                using (NpgsqlConnection cn = Clases.dbconeccion.conectar())
                {
                    string query = "INSERT INTO auditoria (usuario_id, operacion, mensaje, fechahora) VALUES (@usuarioId, @operacion, @mensaje, @fechahora)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@usuarioId", usuarioId);
                        cmd.Parameters.AddWithValue("@operacion", "Apertura de formulario");
                        cmd.Parameters.AddWithValue("@mensaje", mensaje);
                        cmd.Parameters.AddWithValue("@fechahora", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores, puedes registrar el error en algún log o mostrar un mensaje
                MessageBox.Show("Error al registrar auditoría: " + ex.Message);
            }
        }

        public void RegistrarCambioTabla(int usuarioId, string tabla, string cambio)
        {
            RegistrarEvento(usuarioId, "Cambio en tabla", $"Usuario con ID {usuarioId} ha realizado un cambio en la tabla {tabla}. Detalles: {cambio}");
        }

        public void RegistrarAccionNoAutorizada(int usuarioId, string accion)
        {
            RegistrarEvento(usuarioId, "Acción no autorizada", $"Usuario con ID {usuarioId} intentó realizar una acción no autorizada: {accion}");
        }

        private void RegistrarEvento(int usuarioId, string operacion, string mensaje)
        {
            try
            {
                using (var cmd = new NpgsqlCommand("INSERT INTO auditoria (usuario_id, operacion, mensaje, fechahora) VALUES (@usuarioId, @operacion, @mensaje, @fechahora)", _connection))
                {
                    cmd.Parameters.AddWithValue("@usuarioId", usuarioId);
                    cmd.Parameters.AddWithValue("@operacion", operacion);
                    cmd.Parameters.AddWithValue("@mensaje", mensaje);
                    cmd.Parameters.AddWithValue("@fechahora", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones, posiblemente registrar en un log de errores
                Console.WriteLine($"Error al registrar auditoría: {ex.Message}");
            }
        }

        public DataTable ConsultarAuditoria()
        {
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = new NpgsqlCommand("SELECT * FROM auditoria ORDER BY fechahora DESC", _connection))
                {
                    using (var da = new NpgsqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones, posiblemente registrar en un log de errores
                Console.WriteLine($"Error al consultar auditoría: {ex.Message}");
            }
            return dt;
        }
    }
}
