using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BalonPie
{
    internal class Equipo: INotifyPropertyChanged
    {
        // Propiedades para representar las características de un equipo
        public int id {  get; set; }
        public string nombre {  get; set; }
        public int año_fundacion { get; set; }
        public string nombre_estadio { get; set; }
        public BitmapImage imagen { get; set; }
        public List<Jugador> jugadores { get; set; }

        // Constructor para inicializar un objeto Equipo
        public Equipo(int id, string nombre, int año_fundacion, string nombre_estadio, BitmapImage imagen)
        {
            this.id = id;
            this.nombre = nombre;
            this.año_fundacion = año_fundacion;
            this.nombre_estadio = nombre_estadio;
            this.imagen = imagen;
            this.jugadores = new List<Jugador>();
        }

        //Método para notificar el cambio de propiedades.
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
