using Npgsql;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProyectoFinalPROG3.Clases
{


    internal class dbconeccion
    {

        //________________Funciones de gestion de formularios_________
        public void CerrarForm(Form form)
        {
            form.Close();
        }



        public void MaximizarRestaurarForm(Form form)
        {
            if (form.WindowState == FormWindowState.Maximized)
            {
                form.WindowState = FormWindowState.Normal;
            }
            else
            {
                form.WindowState = FormWindowState.Maximized;
            }
        }


        public void MinimizarForm(Form form)
        {
            form.WindowState = FormWindowState.Minimized;
        }
        //___________________________________________________________




        //___________________________Gestor de bordes________________________________

        //___________________________________________________________













        //_________________________________________________Gestor de imagenes______________________________________________________




        public static string CargarImagenNueva(PictureBox pictureBox1)
        {
            string ruta = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp"; // Filtrar solo archivos de imagen

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = openFileDialog.FileName;  // Cargar la imagen en el PictureBox
                    ruta = openFileDialog.FileName;  // Guardar la ruta de la imagen
                    return ruta;

                }
            }
            return ruta;
        }

        public void CargarImagenExistente(PictureBox pictureBox1, string rutaImagenGuardada)
        {



            pictureBox1.ImageLocation = rutaImagenGuardada;  // Cargar la imagen en el PictureBox


        }


        //_______________________________________________________________________________________________________________________________________
















        //_______________Coneccion Postgre____________

        public static NpgsqlConnection conectar()
        {

            NpgsqlConnection conec = new NpgsqlConnection();
            NpgsqlConnection cn = new NpgsqlConnection("Server=localhost;User Id=postgres; Password=@Tonyml2024 ; Database=ArmeriaPime");


            try
            {
                if (conec.State == ConnectionState.Closed)
                {
                    conec = cn;
                    conec.Open();
                }


            }

            catch (NpgsqlException e)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos, error: " + e.ToString());
            }
            return conec;
        }




        //______________________________________________





















        //______________________________________________Verificar campos__________________________________________________


        public static bool ValidarNumeros(System.Windows.Forms.TextBox textBox)
        {

            if (Regex.IsMatch(textBox.Text, @"[^\d]"))
            {
                return false; // Validación fallida
            }

            return true; // Validación exitosa
        }







        public static bool ValidarLetras(System.Windows.Forms.TextBox textBox)
        {

            if (Regex.IsMatch(textBox.Text, @"^[a-zA-Z\s]+$"))
            {
                return true; // Validación exitosa
            }
            else
            {

                return false; // Validación fallida
            }


        }



        public static bool VerificarAmbas(System.Windows.Forms.TextBox textBox)
        {

            bool hasLetter = Regex.IsMatch(textBox.Text, @"[a-zA-Z]"); // Verifica si tiene al menos una letra
            bool hasNumber = Regex.IsMatch(textBox.Text, @"\d");       // Verifica si tiene al menos un número

            return hasLetter && hasNumber;  // Ambas condiciones deben ser verdaderas
        }




        public static void validarmoneda(System.Windows.Forms.TextBox txtbox)
        {


            // Intenta convertir el texto en un número decimal
            if (decimal.TryParse(txtbox.Text, out decimal parsedValue))
            {
                // Si es exitoso, aplica el formato de moneda y actualiza el texto del TextBox
                txtbox.Text = parsedValue.ToString("C");
            }
        }





        //___________________Validar si es solo numeros o letras____________________

        public static void Validar(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancela el evento
            }
        }


        public static void ValidarLetra(KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancela el evento
            }
        }

        //____________________________________________________________________________




























        //____________________Busqueda de campos____________________

        public static DataTable busqueda(string n, string y, string z, int x = 0)
        {

            NpgsqlConnection cn = Clases.dbconeccion.conectar();
            string consulta = "";
            var dt = new DataTable();
            try
            {

                // Si el valor es un número
                if (Regex.IsMatch(y, @"^\d+$") && x == 0)
                {
                    if (z == "usuario")
                    {
                        consulta = $"SELECT usuario,\"usuario_id\",clave,nivel_de_acceso FROM " + z + " WHERE \"" + n + "\" = CAST(@valor AS int8) and activo=true";
                    }

                    if (z == "cliente")
                    {
                        consulta = $"SELECT \"Nombre\",\"cliente_id\",\"Fecha de ingreso\",\"Cedula o RNC\",\"Tipo de cliente\",\"Telefono\",\"Status\" FROM " + z + " WHERE \"" + n + "\" = CAST(@valor AS int8) and activo=true";
                    }

                    if (z == "articulo")
                    {
                        consulta = $"SELECT \"articulo_id\",\"Referencia\",\"Descripcion\",\"Numero de marca\",\"Precio\",\"Existencia\",\"Fecha de ingreso\",\"Costo\",\"Usuario de ingreso\",\"Usuario MOD\" FROM " + z + " WHERE \"" + n + "\" = CAST(@valor AS int8) and activo=true";
                    }
                    
                    if (z == "marca")
                    {
                        consulta = $"SELECT \"marca_id\",\"Descripcion\" FROM " + z + " WHERE \"" + n + "\" = CAST(@valor AS int8) and activo=true";
                    }

                    if (z == "categoria")
                    {
                        consulta = $"SELECT \"categoria_id\",\"Descripcion\" FROM " + z + " WHERE \"" + n + "\" = CAST(@valor AS int8) and activo=true";
                    }

                    if (z == "unidad")
                    {
                        consulta = $"SELECT \"unidad_id\",\"Descripcion\",\"Cantidad\" FROM " + z + " WHERE \"" + n + "\" = CAST(@valor AS int8) and activo=true";
                    }

                    if (z == "proveedor")
                    {
                        consulta = $"SELECT \"proveedor_id\",\"Descripcion\",\"Cedula o RNC\",\"Direccion\",\"Ciudad\",\"Contacto\",\"Telefono\",\"Estado\" FROM " + z + " WHERE \"" + n + "\" = CAST(@valor AS int8) and activo=true";
                    }

                    if (z == "vendedor")
                    {
                        consulta = $"SELECT \"vendedor_id\",\"Nombre completo\" FROM " + z + " WHERE \"" + n + "\" = CAST(@valor AS int8) and activo=true";
                    }

                    if (z == "facturador")
                    {
                        consulta = $"SELECT \"facturador_id\",\"Nombre completo\",\"Fecha de ingreso\",\"Estado\" FROM " + z + " WHERE \"" + n + "\" = CAST(@valor AS int8) and activo=true";
                    }

                    if (z == "proveedorEXT")
                    {
                        consulta = $"SELECT \"ID\",\"Descripcion\",\"Cedula o RNC\",\"Ciudad\",\"Contacto\",\"Estado\" FROM proveedor" + " WHERE \"" + n + "\" = CAST(@valor AS int8) and activo=true";
                    }


                }
                // Si el valor es una letra o contiene letras
                else if (x == 1 || Regex.IsMatch(y, @"[a-zA-Z]"))
                {
                    if (z == "usuario")
                    {
                        consulta = $"SELECT usuario,\"usuario_id\",clave,nivel_de_acceso FROM " + z + " WHERE \"" + n + "\" ILIKE @valor and activo=true";
                        y = "%" + y + "%";  // Ajustar el valor para la búsqueda con LIKE
                    }

                    if (z == "cliente")
                    {
                        consulta = $"SELECT \"Nombre\",\"cliente_id\",\"Fecha de ingreso\",\"Cedula o RNC\",\"Tipo de cliente\",\"Telefono\",\"Status\" FROM " + z + " WHERE \"" + n + "\" ILIKE @valor and activo=true";
                        y = "%" + y + "%";
                    }

                    if (z == "articulo")
                    {
                        consulta = $"SELECT \"articulo_id\",\"Referencia\",\"Descripcion\",\"Numero de marca\",\"Precio\",\"Existencia\",\"Fecha de ingreso\",\"Costo\",\"Usuario de ingreso\",\"Usuario MOD\" FROM " + z + " WHERE \"" + n + "\" ILIKE @valor and activo=true";
                        y = "%" + y + "%";
                    }

                    if (z == "marca")
                    {
                        consulta = $"SELECT \"marca_id\",\"Descripcion\" FROM " + z + " WHERE \"" + n + "\" ILIKE @valor and activo=true";
                        y = "%" + y + "%";  // Ajustar el valor para la búsqueda con LIKE
                    }

                    if (z == "categoria")
                    {
                        consulta = $"SELECT \"categoria_id\",\"Descripcion\" FROM " + z + " WHERE \"" + n + "\" ILIKE @valor and activo=true";
                        y = "%" + y + "%";  // Ajustar el valor para la búsqueda con LIKE
                    }

                    if (z == "unidad")
                    {
                        consulta = $"SELECT \"unidad_id\",\"Descripcion\",\"Cantidad\" FROM " + z + " WHERE \"" + n + "\" ILIKE @valor and activo=true";
                        y = "%" + y + "%";  // Ajustar el valor para la búsqueda con LIKE
                    }

                    if (z == "proveedor")
                    {
                        consulta = $"SELECT \"proveedor_id\",\"Descripcion\",\"Cedula o RNC\",\"Direccion\",\"Ciudad\",\"Contacto\",\"Telefono\",\"Estado\" FROM " + z + " WHERE \"" + n + "\" ILIKE @valor and activo=true";
                        y = "%" + y + "%";  // Ajustar el valor para la búsqueda con LIKE
                    }

                    if (z == "vendedor")
                    {
                        consulta = $"SELECT \"vendedor_id\",\"Nombre completo\" FROM " + z + " WHERE \"" + n + "\" ILIKE @valor and activo=true";
                        y = "%" + y + "%";  // Ajustar el valor para la búsqueda con LIKE
                    }

                    if (z == "facturador")
                    {
                        consulta = $"SELECT \"facturador_id\",\"Nombre completo\",\"Fecha de ingreso\",\"Estado\" FROM " + z + " WHERE \"" + n + "\" ILIKE @valor and activo=true";
                        y = "%" + y + "%";  // Ajustar el valor para la búsqueda con LIKE
                    }

                    if (z == "proveedorEXT")
                    {
                        consulta = $"SELECT \"proveedor_id\",\"Descripcion\",\"Cedula o RNC\",\"Ciudad\",\"Contacto\",\"Estado\" FROM proveedor" + " WHERE \"" + n + "\" ILIKE @valor and activo=true";
                        y = "%" + y + "%";  // Ajustar el valor para la búsqueda con LIKE
                    }


                }

                else
                {
                    MessageBox.Show("Valor no válido o no permitido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                if (consulta != "")
                {
                    using (var cmd = new NpgsqlCommand(consulta, cn))
                    {
                        cmd.Parameters.AddWithValue("@valor", y);
                        dt = new DataTable();
                        using (var reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                            return dt;
                        }
                    }

                }


            }



            catch (NpgsqlException e)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos, error: " + e.ToString());
            }
            finally { cn.Close(); }

            return dt;

        }






        public static DataTable busqueda(string z, DateTime startdate, DateTime enddate)
        {
            NpgsqlConnection cn = Clases.dbconeccion.conectar();
            string consulta = "";

            string fechaDesdeStr = startdate.ToString("dd/MM/yyyy");
            string fechaHastaStr = enddate.ToString("dd/MM/yyyy");

            var dataTable = new DataTable();

            try
            {
                if (z == "cliente")
                {
                    consulta = $"SELECT \"Nombre\",\"ID\",\"Fecha de ingreso\",\"Cedula o RNC\",\"Tipo de cliente\",\"Telefono\",\"Status\" FROM " + z + " WHERE activo=true and \"Fecha de ingreso\" >= TO_DATE(@startDate, 'DD/MM/YYYY') AND \"Fecha de ingreso\" <= TO_DATE(@endDate, 'DD/MM/YYYY')";
                }
                if (z == "articulo")
                {
                    consulta = $"select \"ID\",\"Referencia\",\"Descripcion\",\"Numero de marca\",\"Fecha de ingreso\",\"Usuario de ingreso\",\"Usuario MOD\" FROM " + z + " WHERE activo=true and \"Fecha de ingreso\" >= TO_DATE(@startDate, 'DD/MM/YYYY') AND \"Fecha de ingreso\" <= TO_DATE(@endDate, 'DD/MM/YYYY')";
                }

                if (z == "facturador")
                {
                    consulta = $"select \"ID\",\"Nombre completo\",\"Fecha de ingreso\",\"Estado\" FROM " + z + " WHERE activo=true and \"Fecha de ingreso\" >= TO_DATE(@startDate, 'DD/MM/YYYY') AND \"Fecha de ingreso\" <= TO_DATE(@endDate, 'DD/MM/YYYY')";
                }
                using (var cmd = new NpgsqlCommand(consulta, cn))
                {
                    cmd.Parameters.AddWithValue("@startDate", fechaDesdeStr);
                    cmd.Parameters.AddWithValue("@endDate", fechaHastaStr);

                    using (var reader = cmd.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }

                    return dataTable;
                }

            }



            catch (NpgsqlException e)
            {
                MessageBox.Show("No se ha podido acceder a la base de datos, error: " + e.ToString());
            }
            finally { cn.Close(); }

            return dataTable;
        }







        //________________________________________________________________










        //__________________________________Manipulacion de Mouse__________________________________________

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        public static void MakeMovable(Form form)
        {
            form.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(form.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            };
        }

        //___________________________________________________________________________________________________



















        //____________________Confirmar si existe o no el ID en la tabla especifica______________
        public static bool confirmar(string txt, string txt2)
        {

            NpgsqlConnection cn = Clases.dbconeccion.conectar();


            var ID = int.Parse(txt);
            string text2 = txt2;

            if (text2 != "ajuste_base")
            {
                try
                {
                    using (var cmd = new NpgsqlCommand("SELECT EXISTS(SELECT 1 FROM " + text2 + " WHERE \"ID\" = @valor and activo = true )", cn))
                    {

                        cmd.Parameters.AddWithValue("valor", ID);

                        bool existe = (bool)cmd.ExecuteScalar();

                        if (existe)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }


                }
                catch (NpgsqlException e)
                {
                    MessageBox.Show("No se ha podido acceder a la base de datos, error: " + e.ToString());
                    return false;
                }
                finally { cn.Close(); }

            }
            else
            {
                try
                {
                    using (var cmd = new NpgsqlCommand("SELECT EXISTS(SELECT 1 FROM " + text2 + " WHERE \"ID\" = @valor)", cn))
                    {

                        cmd.Parameters.AddWithValue("valor", ID);

                        bool existe = (bool)cmd.ExecuteScalar();

                        if (existe)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }


                }
                catch (NpgsqlException e)
                {
                    MessageBox.Show("No se ha podido acceder a la base de datos, error: " + e.ToString());
                    return false;
                }
                finally { cn.Close(); }

            }

        }


        //_____________________________________________________________________________________________________





















        //____________________Confirmar si existe o no el Nombre en la tabla especifica______________
        public static bool ExisteNombreUsuario(string nombreUsuario)
        {
            bool existe = false;

            using (NpgsqlConnection connection = Clases.dbconeccion.conectar())
            {


                string query = "SELECT COUNT(*) FROM usuarios WHERE usuario = @nombreUsuario and activo = true";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    // Evita inyecciones SQL
                    command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

                    long count = (long)command.ExecuteScalar();

                    if (count > 0)
                    {
                        existe = true;
                    }
                }
                connection.Close();

            }

            return existe;
        }

        //________________________________________________________________________________

        public void EjecutaQuery(string query)
        {
            using (NpgsqlConnection conexion = conectar())
            {
                try
                {
                    using (var cmd = new NpgsqlCommand(query, conexion))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (NpgsqlException e)
                {
                    MessageBox.Show("No se ha podido ejecutar la consulta, error: " + e.ToString());
                }
                finally
                {
                    if (conexion.State == ConnectionState.Open)
                    {
                        conexion.Close();
                    }
                }
            }
        }














































        //________________Guardar informacion de usuario actual__________________________

        public static string Name_usuario { get; set; }
        public static string id_usuario { get; set; }
        public static string nivel_usuario { get; set; }

        //_______________________________________________________________________________________


    }
}
