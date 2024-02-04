using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    /// Lógica para la creación y edición de jugadores
    /// </summary>
    public partial class CrearJugadorWindow : Window
    {
        // Colección de jugadores
        ObservableCollection<Jugador> players;

        // Colección de equipos
        ObservableCollection<Equipo> teams;

        // Jugador actual (puede ser nulo si no se está editando un jugador existente)
        Jugador player;

        // Constructor para la ventana de creación de jugador sin jugador existente
        internal CrearJugadorWindow(ObservableCollection<Jugador> jugadoresList, ObservableCollection<Equipo> equiposList)
        {
            // Inicializa la interfaz de usuario
            InitializeComponent();

            // Asigna la lista de jugadores y equipos a las variables locales
            this.players = jugadoresList;
            // Establece la fuente de datos de 'equipoOpciones' como la lista de equipos
            equipoOpciones.ItemsSource = equiposList;
        }

        // Constructor para la ventana de creación de jugador con jugador existente (para editar)
        internal CrearJugadorWindow(ObservableCollection<Jugador> jugadoresList, ObservableCollection<Equipo> equiposList, Jugador jugador)
        {
            // Inicializa la interfaz de usuario
            InitializeComponent();

            // Asigna el jugador existente, la lista de jugadores y la lista de equipos a las variables locales
            this.player = jugador;
            this.players = jugadoresList;
            this.teams = equiposList;

            // Establece la fuente de datos de 'equipoOpciones' como la lista de equipos
            equipoOpciones.ItemsSource = equiposList;

            // Llena automáticamente los campos de la interfaz de usuario con los datos del jugador existente
            LlenarCampos();
        }

        //Función para aignar los atributos de un objeto Jugador a los campos correspondientes de la vista.
        private void LlenarCampos() 
        {
            // Asigna la propiedad 'id' del objeto 'player' al texto del control 'UserText' de 'playerId'
            playerId.UserText = player.id.ToString();
            // Asigna la propiedad 'nombre' del objeto 'player' al texto del control 'UserText' de 'playerNombre'
            playerNombre.UserText = player.nombre;
            // Asigna la propiedad 'apellidos' del objeto 'player' al texto del control 'UserText' de 'playerApellidos'
            playerApellidos.UserText = player.apellidos;
            // Asigna la propiedad 'apodo' del objeto 'player' al texto del control 'UserText' de 'playerApodo'
            playerApodo.UserText = player.apodo;
            // Convierte la propiedad 'edad' del objeto 'player' a cadena y asigna al texto del control 'UserText' de 'playerEdad'
            playerEdad.UserText = player.edad.ToString();
            // Convierte la propiedad 'dorsal' del objeto 'player' a cadena y asigna al texto del control 'UserText' de 'playerDorsal'
            playerDorsal.UserText = player.dorsal.ToString();
            // Asigna la propiedad 'nacionalidad' del objeto 'player' al texto del control 'UserText' de 'playerNacionalidad'
            playerNacionalidad.UserText = player.nacionalidad;
            // Encuentra el índice del equipo actual del jugador en la lista de equipos y selecciona ese índice en 'equipoOpciones'
            equipoOpciones.SelectedIndex = teams.ToList().FindIndex(equipo => equipo == player.equipo);
            // Asigna la imagen del jugador a la propiedad 'Source' del control 'imagenNuevoJugador'
            imagenNuevoJugador.Source = player.imagen;
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
                string rutaImagen = openFileDialog.FileName;

                // Carga la imagen desde la ruta y la asigna como fuente al control 'imagenNuevoJugador'
                imagenNuevoJugador.Source = new BitmapImage(new Uri(rutaImagen));
            }
        }
        private void Cancelar(object sender, MouseButtonEventArgs e)
        {
            //Cierra la ventana actual
            Close();
        }
        
        private void GuardarJugador(object sender, MouseButtonEventArgs e)
        {
            // Mensaje de error para almacenar mensajes de validación
            string msg = "";
            // Contador de errores
            int count = 0;

            // Validaciones de campos obligatorios y formatos
            if (string.IsNullOrEmpty(playerId.UserText))
            {
                msg += "Introduce un ID\n";
                count++;
            }
            else if (!int.TryParse(playerId.UserText, out _))
            {
                msg += "El ID debe ser un número mayor que 0 y menor que 1 millón\n";
                count++;
            }
            else if (int.Parse(playerId.UserText) < 0)
            {
                msg += "El ID debe ser un número positivo\n";
                count++;
            }
            if (string.IsNullOrEmpty(playerNombre.UserText))
            {
                msg += "Introduce un nombre\n";
                count++;
            }
            if(string.IsNullOrEmpty(playerApellidos.UserText))
            {
                msg += "Introduce los apellidos\n";
                count++;
            }
            if(string.IsNullOrEmpty(playerApodo.UserText))
            {
                msg += "Introduce un apodo\n";
                count++;
            }
            if(string.IsNullOrEmpty(playerEdad.UserText))
            {
                msg += "Introduce la edad\n";
                count++;
            }
            else if(!int.TryParse(playerEdad.UserText, out _))
            {
                msg += "La edad debe ser un número mayor que 0 y menor que 1 millón\n";
                count++;
            }
            else if (int.Parse(playerEdad.UserText) < 0)
            {
                msg += "La edad debe ser positiva\n";
                count++;
            }
            if (string.IsNullOrEmpty(playerDorsal.UserText))
            {
                msg += "Introduce el dorsal\n";
                count++;
            }
            else if(!int.TryParse(playerDorsal.UserText, out _))
            {
                msg += "El dorsal debe ser un número mayor que 0 y menor que 99\n";
                count++;
            }
            else if (int.Parse(playerDorsal.UserText) < 0 || int.Parse(playerDorsal.UserText) > 99)
            {
                msg += "El dorsal debe ser un número positivo menor que 100\n";
                count++;
            }
            if (string.IsNullOrEmpty(playerNacionalidad.UserText))
            {
                msg += "Introduce la nacionalidad\n";
                count++;
            }
            if(equipoOpciones.SelectedItem == null)
            {
                msg += "Introduce el equipo\n";
                count++;
            }
            if(imagenNuevoJugador.Source == null)
            {
                msg += "Añade una imagen\n";
                count++;
            }
            // Muestra el mensaje de error si hay errores en la validación
            if (count > 0)
            {
                MessageBox.Show(msg, "No se pudo guardar");
            }
            else if(player == null)
            {
                // Si no hay errores y no se está editando un jugador existente
                Equipo team = equipoOpciones.SelectedItem as Equipo;
                bool validPlayer = true;

                // Crea un nuevo jugador
                Jugador newPlayer = new Jugador(
                            int.Parse(playerId.UserText),
                            playerNombre.UserText,
                            playerApellidos.UserText,
                            playerApodo.UserText,
                            int.Parse(playerEdad.UserText),
                            int.Parse(playerDorsal.UserText),
                            playerNacionalidad.UserText,
                            team,
                            imagenNuevoJugador.Source as BitmapImage);

                // Validaciones adicionales para asegurarse de que no haya jugadores duplicados
                foreach (Jugador player in players)
                {
                    if(newPlayer.dorsal == player.dorsal && newPlayer.equipo == player.equipo)
                    {
                        MessageBox.Show("Ya existe un jugador con ese dorsal en ese equipo.", "No se pudo guardar.");
                        validPlayer = false;
                        break;
                    }
                    if(newPlayer.id == player.id)
                    {
                        MessageBox.Show("Ya existe un jugador con ese ID.", "No se pudo guardar.");
                        validPlayer = false;
                        break;
                    }
                }

                // Si todo es válido, agrega el nuevo jugador y cierra la ventana
                if (validPlayer)
                {
                    players.Add(newPlayer);
                    team.jugadores.Add(newPlayer);
                    Close();
                }
            } 
            else
            {
                // Si no hay errores y se está editando un jugador existente
                bool validPlayer = true;
                Equipo team = equipoOpciones.SelectedItem as Equipo;

                // Validaciones adicionales para asegurarse de que no haya jugadores duplicados
                foreach (Jugador playerA in players)
                {
                    if(playerA.id != player.id && int.Parse(playerId.UserText) == playerA.id)
                    {
                        MessageBox.Show("Ya existe un jugador con el mismo ID.", "Error al editar el jugador.");
                        validPlayer = false;
                    }
                }

                // Si todo es válido, actualiza los datos del jugador y cierra la ventana
                if (validPlayer)
                {
                    //En cada campo comprueeba si ha cambiado y, si lo ha hecho, cambia el valor del atributo y llama al OnPropertyChanged
                    if(!playerNombre.UserText.Equals(player.nombre)) {
                        player.nombre = playerNombre.UserText;
                        player.OnPropertyChanged(nameof(player.nombre));
                    }
                    if(!playerApellidos.UserText.Equals(player.apellidos))
                    {
                        player.apellidos = playerApellidos.UserText;
                        player.OnPropertyChanged(nameof (player.apellidos));
                    }
                    if(!playerApodo.Equals(player.apodo))
                    {
                        player.apodo = playerApodo.UserText;
                        player.OnPropertyChanged(nameof(player.apodo));
                    }
                    if(int.Parse(playerEdad.UserText) != player.edad)
                    {
                        player.edad = int.Parse(playerEdad.UserText);
                        player.OnPropertyChanged(nameof(player.edad));
                    }
                    if(int.Parse(playerDorsal.UserText) != player.dorsal)
                    {
                        player.dorsal = int.Parse(playerDorsal.UserText);
                        player.OnPropertyChanged(nameof(player.dorsal));
                    }
                    if(!playerNacionalidad.UserText.Equals(player.nacionalidad))
                    {
                        player.nacionalidad = playerNacionalidad.UserText;
                        player.OnPropertyChanged(nameof(player.nacionalidad));
                    }
                    if(player.equipo != team)
                    {
                        player.equipo.jugadores.Remove(player);
                        team.jugadores.Add(player);
                        player.OnPropertyChanged(nameof(player.equipo));
                    }
                    player.equipo = team;
                    if(imagenNuevoJugador.Source != player.imagen)
                    {
                        player.imagen = imagenNuevoJugador.Source as BitmapImage;
                        player.OnPropertyChanged(nameof(player.imagen));
                    }
                    Close();
                } 
            } 
        }
    }
}
