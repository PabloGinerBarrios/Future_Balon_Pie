using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BalonPie
{
    internal class Jugador: INotifyPropertyChanged
    {
        // Propiedades del Jugador
        public int id {  get; set; }
        public string nombre {  get; set; }
        public string apellidos { get; set; }

        public string nombreCompleto
        {
            get { return $"{nombre} {apellidos.Split(' ')[0]}"; }
        }
        public string apodo { get; set; }
        public int edad {  get; set; }
        public int dorsal {  get; set; }
        public string nacionalidad { get; set; }
        public Equipo equipo { get; set; }
        public BitmapImage imagen { get; set; }

        // Constructor de la clase Jugador
        public Jugador(int id, string nombre, string apellidos, string apodo, int edad, int dorsal, string nacionalidad, Equipo equipo, BitmapImage imagen)
        {
            // Inicialización de las propiedades con los valores proporcionados
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.apodo = apodo;
            this.edad = edad;
            this.dorsal = dorsal;
            this.nacionalidad = nacionalidad;
            this.equipo = equipo;
            this.imagen = imagen;
        }

        //Métodos para notificar el cambio de propiedades
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
