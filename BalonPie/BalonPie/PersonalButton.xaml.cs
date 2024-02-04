using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BalonPie
{
    /// <summary>
    /// Clase que representa un botón personalizado en una interfaz de usuario WPF.
    /// </summary>
    public partial class PersonalButton : UserControl
    {
        public PersonalButton()
        {
            // Establece el contexto de datos como la propia instancia de la clase.
            DataContext = this;
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Propiedad para almacenar y actualizar el contenido del botón.
        private string content;

        public string TextButton
        {
            get { return content; }
            set
            {
                // Actualiza el valor de la propiedad y asigna el contenido al botón.
                content = value;
                btnPersonal.Text = content;

                // Invoca el evento PropertyChanged para notificar cambios en la propiedad.
                OnPropertyChanged(nameof(TextButton));
            }
        }

        // Propiedad para almacenar y actualizar el ancho del botón.
        private double ancho;

        public double Ancho
        {
            get { return ancho; }
            set
            {
                // Actualiza el valor de la propiedad y asigna el ancho al borde y al botón.
                ancho = value;
                borderButton.Width = ancho;
                btnPersonal.Width = ancho;

                // Invoca el evento PropertyChanged para notificar cambios en la propiedad.
                OnPropertyChanged(nameof(Ancho));
            }
        }

        // Propiedad para almacenar y actualizar el alto del botón.
        private double alto;

        public double Alto
        {
            get { return alto; }
            set
            {
                // Actualiza el valor de la propiedad y asigna el alto al borde y al botón.
                alto = value;
                borderButton.Height = alto;
                btnPersonal.Height = alto;

                // Invoca el evento PropertyChanged para notificar cambios en la propiedad.
                OnPropertyChanged(nameof(Alto));
            }
        }

        // Propiedad para almacenar y actualizar el tamaño de letra del botón.
        private double tamañoLetra;

        public double TamañoLetra
        {
            get { return tamañoLetra; }
            set
            {
                // Actualiza el valor de la propiedad y asigna el tamaño de letra al botón.
                tamañoLetra = value;
                btnPersonal.FontSize = tamañoLetra;

                // Invoca el evento PropertyChanged para notificar cambios en la propiedad.
                OnPropertyChanged(nameof(TamañoLetra));
            }
        }

        // Método para invocar el evento PropertyChanged.
        private void OnPropertyChanged(string propertyName)
        {
            // Verifica si hay suscriptores al evento antes de invocarlo.
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
