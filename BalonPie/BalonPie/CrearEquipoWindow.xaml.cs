using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BalonPie
{
    /// <summary>
    /// Lógica para la creción y edición de equipos
    /// </summary>
    public partial class CrearEquipoWindow : Window
    {
        // Colección de equipos
        ObservableCollection<Equipo> teams;

        // Equipo actual (puede ser nulo si no se está editando un equipo existente)
        Equipo team;

        // Constructor para la ventana de creación de equipo sin equipo existente
        internal CrearEquipoWindow(ObservableCollection<Equipo> teamsList)
        {
            // Inicializa la interfaz de usuario
            InitializeComponent();

            // Asigna la lista de equipos a la variable local
            this.teams = teamsList;
        }

        // Constructor para la ventana de creación de equipo con equipo existente (para editar)
        internal CrearEquipoWindow(ObservableCollection<Equipo> teamsList, Equipo team)
        {
            // Inicializa la interfaz de usuario
            InitializeComponent();

            // Asigna el equipo existente y la lista de equipos a las variables locales
            this.team = team;
            this.teams = teamsList;

            // Llena automáticamente los campos de la interfaz de usuario con los datos del equipo existente
            LlenarCampos();
        }

        // Método para llenar los campos de la interfaz de usuario con los datos del equipo existente
        private void LlenarCampos()
        {
            // Asigna la propiedad 'id' del objeto 'team' al texto del control 'UserText' de 'equipoId'
            equipoId.UserText = team.id.ToString();
            // Asigna la propiedad 'nombre' del objeto 'team' al texto del control 'UserText' de 'equipoNombre'
            equipoNombre.UserText = team.nombre;
            // Convierte la propiedad 'año_fundacion' del objeto 'team' a cadena y asigna al texto del control 'UserText' de 'equipoFundacion
            equipoFundacion.UserText = team.año_fundacion.ToString();
            // Asigna la propiedad 'nombre_estadio' del objeto 'team' al texto del control 'UserText' de 'equipoEstadio'
            equipoEstadio.UserText = team.nombre_estadio;
            // Asigna la imagen del equipo a la propiedad 'Source' del control 'imagenNuevoEquipo'
            imagenNuevoEquipo.Source = team.imagen;
        }

        private void SeleccionarImagen(object sender, MouseButtonEventArgs e)
        {
            // Abre el cuadro de diálogo de archivo para seleccionar imágenes
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Filtra los tipos de archivos que se pueden seleccionar (imágenes comunes)
            openFileDialog.Filter = "Archivos de Imágenes|*.png;*.jpg;*.jpeg;*.gif;*.bmp|Todos los Archivos|.*";

            // Verifica si el usuario ha seleccionado un archivo y ha hecho clic en "Aceptar"
            if (openFileDialog.ShowDialog() == true)
            {
                // Obtiene la ruta del archivo seleccionado
                string imgPath = openFileDialog.FileName;

                // Carga la imagen desde la ruta y la asigna como fuente al control 'imagenNuevoEquipo'
                imagenNuevoEquipo.Source = new BitmapImage(new Uri(imgPath));
            }
        }

        private void Cancelar(object sender, MouseButtonEventArgs e)
        {
            //Cierra la ventana actual
            Close();
        }

        private void GuardarEquipo(object sender, MouseButtonEventArgs e)
        {
            // Mensaje de error para almacenar mensajes de validación
            string msg = "";
            // Contador de errores
            int count = 0;

            // Validaciones de campos obligatorios y formatos
            if (string.IsNullOrEmpty(equipoId.UserText))
            {
                msg += "Introduce un ID.\n";
                count++;
            }
            else if (!int.TryParse(equipoId.UserText, out _))
            {
                msg += "El ID debe ser un número mayor que 0 y menor que 1 millón\n";
                count++;
            }
            else if (int.Parse(equipoId.UserText) < 0)
            {
                msg += "El ID debe ser un número positivo\n";
                count++;
            }
            if (string.IsNullOrEmpty(equipoNombre.UserText))
            {
                msg += "Introduce un nombre.\n";
                count++;
            }
            if (string.IsNullOrEmpty(equipoFundacion.UserText))
            {
                msg += "Introduce el año de fundación.\n";
                count++;
            }
            else if(!int.TryParse(equipoFundacion.UserText, out _)) {
                msg += "El año de fundación debe ser un número mayor que 0 y menor que 1 millón\n";
                count++;
            }
            else if (int.Parse(equipoFundacion.UserText) < 0)
            {
                msg += "El año de fundación debe ser un número positivo\n";
                count++;
            }
            if (string.IsNullOrEmpty(equipoEstadio.UserText))
            {
                msg += "Introduce el nombre del estadio.\n";
                count++;
            }
            if (imagenNuevoEquipo.Source == null)
            {
                msg += "Añade una imagen\n";
                count++;
            }

            // Muestra el mensaje de error si hay errores en la validación
            if (count > 0)
            {
                MessageBox.Show(msg, "No se pudo guardar");
            }
            else if (team == null)
            {
                // Si no hay errores y no se está editando un equipo existente
                bool validTeam = true;

                // Crea un nuevo equipo
                Equipo newTeam = new Equipo(
                    int.Parse(equipoId.UserText),
                    equipoNombre.UserText,
                    int.Parse(equipoFundacion.UserText),
                    equipoEstadio.UserText,
                    imagenNuevoEquipo.Source as BitmapImage);

                // Validaciones adicionales para asegurarse de que no haya equipos duplicados
                foreach (var team in teams)
                {
                    if(newTeam.nombre == team.nombre)
                    {
                        MessageBox.Show("Ya existe un equipo con ese nombre.", "No se pudo guardar.");
                        validTeam = false;
                        break;
                    }
                    if (newTeam.id == team.id)
                    {
                        MessageBox.Show("Ya existe un equipo con ese ID.", "No se pudo guardar.");
                        validTeam = false;
                        break;
                    }
                }
                // Si todo es válido, agrega el nuevo equipo y cierra la ventana
                if (validTeam)
                {
                    teams.Add(newTeam);
                    Close();
                }
            }
            else
            {
                // Si no hay errores y se está editando un equipo existente
                bool validTeam = true;

                // Validaciones adicionales para asegurarse de que no haya equipos duplicados
                foreach (Equipo teamA in teams)
                {
                    if(teamA.id != team.id && int.Parse(equipoId.UserText) == teamA.id)
                    {
                        MessageBox.Show("Ya existe un equipo con ese ID.", "Error al editar");
                        validTeam = false;
                        break;
                    }
                    if((teamA.nombre != team.nombre && equipoNombre.UserText == teamA.nombre))
                    {
                        MessageBox.Show("Ya existe un equipo con ese nombre.", "Error al editar");
                        validTeam = false;
                        break;
                    }
                }
                // Si todo es válido, actualiza los datos del equipo y cierra la ventana
                if (validTeam)
                {
                    //En cada campo, si el valor del atributo es diferente lo cambia en el objeto y llama al método OnPropertyChanged
                    if(!equipoId.UserText.Equals(team.id))
                    {
                        team.id = int.Parse(equipoId.UserText);
                        team.OnPropertyChanged(nameof(team.id));
                    }
                    if(!equipoNombre.UserText.Equals(team.nombre))
                    {
                        team.nombre = equipoNombre.UserText;
                        team.OnPropertyChanged(nameof (team.nombre));
                    }
                    if(int.Parse(equipoFundacion.UserText) != team.año_fundacion)
                    {
                        team.año_fundacion = int.Parse(equipoFundacion.UserText);
                        team.OnPropertyChanged(nameof(team.año_fundacion));
                    }
                    if(!equipoEstadio.UserText.Equals(team.nombre_estadio))
                    {
                        team.nombre_estadio = equipoEstadio.UserText;
                        team.OnPropertyChanged(nameof(team.nombre_estadio));
                    }
                    if(imagenNuevoEquipo.Source != team.imagen)
                    {
                        team.imagen = imagenNuevoEquipo.Source as BitmapImage;
                        team.OnPropertyChanged(nameof(team.imagen));
                    }
                    Close();
                }
            }
        }
    }
}

