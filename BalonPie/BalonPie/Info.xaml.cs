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
    /// Lógica para la ventana principal de la aplicación.
    /// </summary>
    public partial class Info : Window
    {
        //Lista de jugadores
        ObservableCollection<Jugador> jugadoresList = new ObservableCollection<Jugador>();

        //Lista de equipos
        ObservableCollection<Equipo> equiposList = new ObservableCollection<Equipo>();
        public Info()
        {
            //Inicializa la interfaz de usuario
            InitializeComponent();

            // Crear imágenes para los equipos y jugadores
            BitmapImage imgPower = new BitmapImage(new Uri("img/ranger_rojo.png", UriKind.Relative));
            BitmapImage imgFrodo = new BitmapImage(new Uri("img/froto.jpeg", UriKind.Relative));
            BitmapImage imgCaca = new BitmapImage(new Uri("img/img_caca.jpeg", UriKind.Relative));
            BitmapImage imgPowerRangers = new BitmapImage(new Uri("img/escudo_power6.jpeg", UriKind.Relative));
            BitmapImage imgMasters = new BitmapImage(new Uri("img/escudo_masters2.jpeg", UriKind.Relative));

            // Crear equipos
            Equipo masters = new Equipo(1, "Masters del Universo", 1975, "Greyskull", imgMasters);
            Equipo powerRangers = new Equipo(2, "Power Rangers", 1975, "Casa de Zorton", imgPowerRangers);

            // Crear jugadores
            Jugador powerRangerRojo = new Jugador(1, "Power", "Ranger Rojo", "Fiera", 304, 23, "Americanito", powerRangers, imgPower);
            Jugador frodo = new Jugador(2, "Frodo", "Bolsaco", "Ricitos morenitos", 79, 9, "Comarcano", powerRangers, imgFrodo);

            // Añadir equipos y jugadores a las listas
            equiposList.Add(masters);
            equiposList.Add(powerRangers);
            jugadoresList.Add(powerRangerRojo);
            powerRangers.jugadores.Add(powerRangerRojo);
            jugadoresList.Add(frodo);
            powerRangers.jugadores.Add(frodo);

            // Configurar la fuente de datos para los controles de la interfaz (las listbox)
            listaJugadores.ItemsSource = jugadoresList;
            listaEquipos.ItemsSource = equiposList;
        }

        // Método para añadir un nuevo jugador
        public void AñadirJugador(object sender, MouseButtonEventArgs e)
        {
            // Crea una nueva ventana de creación de jugador
            CrearJugadorWindow crearJugador = new CrearJugadorWindow(jugadoresList, equiposList);

            // Establece la ventana principal como propietaria de la ventana de creación de jugador
            crearJugador.Owner = this;

            // Muestra la ventana de creación de jugador de forma modal
            crearJugador.ShowDialog();

            // Selecciona el último jugador añadido en la lista de jugadores
            listaJugadores.SelectedItem = listaJugadores.Items.Cast<Jugador>().LastOrDefault();
        }

        // Método para editar un jugador existente
        public void EditarJugador(object sender, MouseButtonEventArgs e)
        {
            // Verifica si hay un jugador seleccionado en la lista
            if (listaJugadores.SelectedItem == null)
            {
                // Muestra un mensaje de información si no hay jugador seleccionado
                MessageBox.Show("Selecciona una jugador", "Información");
            }
            else
            {
                // Obtiene el jugador seleccionado
                Jugador jugadorSeleccionado = (Jugador)listaJugadores.SelectedItem;

                // Crea una nueva ventana de creación de jugador para editar el jugador seleccionado
                CrearJugadorWindow crearJugador = new CrearJugadorWindow(jugadoresList, equiposList, jugadorSeleccionado);

                // Establece la ventana principal como propietaria de la ventana de creación de jugador
                crearJugador.Owner = this;

                // Muestra la ventana de creación de jugador de forma modal
                crearJugador.ShowDialog();

                //Refresca las listas de jugadores
                listaJugadores.Items.Refresh();
                listBoxJugadores.Items.Refresh();

                // Desselecciona el jugador actualmente seleccionado
                listaJugadores.SelectedIndex = -1;

                // Vuelve a seleccionar el jugador editado en la lista de jugadores
                listaJugadores.SelectedIndex = listaJugadores.Items.IndexOf(jugadorSeleccionado);
            }
        }

        // Método para eliminar un jugador
        private void EliminarJugador(object sendder, MouseButtonEventArgs e)
        {
            // Verifica si hay un jugador seleccionado en la lista
            if (listaJugadores.SelectedItem == null)
            {
                // Muestra un mensaje de información si no hay jugador seleccionado
                MessageBox.Show("Selecciona un jugador", "Info");
            }
            else
            {
                // Obtiene el índice actualmente seleccionado en la lista de jugadores
                int indiceActual = listaJugadores.SelectedIndex;

                // Obtiene el jugador seleccionado
                Jugador jugador = listaJugadores.SelectedItem as Jugador;

                // Remueve el jugador de la lista de jugadores
                jugadoresList.Remove(jugador);

                // Selecciona el elemento anterior en la lista después de eliminar el jugador
                listaJugadores.SelectedIndex = indiceActual - 1; 
            }
        }

        // Método para añadir un nuevo equipo
        public void AñadirEquipo(object sender, MouseButtonEventArgs e)
        {
            // Crea una nueva ventana de creación de equipo
            CrearEquipoWindow crearEquipo = new CrearEquipoWindow(equiposList);

            // Establece la ventana principal como propietaria de la ventana de creación de equipo
            crearEquipo.Owner = this;

            // Muestra la ventana de creación de equipo de forma modal
            crearEquipo.ShowDialog();

            // Selecciona el último equipo añadido en la lista de equipos
            listaEquipos.SelectedItem = listaEquipos.Items.Cast<Equipo>().LastOrDefault();
        }

        // Método para editar un equipo existente
        public void EditarEquipo(object sender, MouseButtonEventArgs e)
        {
            // Verifica si hay un equipo seleccionado en la lista
            if (listaEquipos.SelectedItem == null)
            {
                // Muestra un mensaje de información si no hay equipo seleccionado
                MessageBox.Show("Selecciona una equipo", "Información");
            }
            else
            {
                // Obtiene el equipo seleccionado
                Equipo equipoSeleccionado = (Equipo)listaEquipos.SelectedItem;

                // Crea una nueva ventana de creación de equipo para editar el equipo seleccionado
                CrearEquipoWindow crearEquipo = new CrearEquipoWindow(equiposList, equipoSeleccionado);

                // Establece la ventana principal como propietaria de la ventana de creación de equipo
                crearEquipo.Owner = this;

                // Muestra la ventana de creación de equipo de forma modal
                crearEquipo.ShowDialog();

                //Refresca el contenido de la lista.
                listaEquipos.Items.Refresh();
                listBoxJugadores.Items.Refresh();

                // Vuelve a seleccionar el equipo editado en la lista de equipos
                listaEquipos.SelectedIndex = listaEquipos.Items.IndexOf(equipoSeleccionado);
            }
        }

        // Método para eliminar un equipo
        private void EliminarEquipo(object sendder, MouseButtonEventArgs e)
        {
            // Verifica si hay un equipo seleccionado en la lista
            if (listaEquipos.SelectedItem == null)
            {
                // Muestra un mensaje de información si no hay equipo seleccionado
                MessageBox.Show("Selecciona un equipo", "Info");
            }
            else
            {
                // Obtiene el índice actualmente seleccionado en la lista de equipos
                int indiceActual = listaEquipos.SelectedIndex;

                // Obtiene el equipo seleccionado
                Equipo equipo = listaEquipos.SelectedItem as Equipo;

                // Remueve el equipo de la lista de equipos
                equiposList.Remove(equipo);

                // Selecciona el elemento anterior en la lista después de eliminar el equipo
                listaEquipos.SelectedIndex = indiceActual - 1;
            }
        }
    }
}
