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
    /// Clase que representa un rótulo de neón en una interfaz de usuario WPF.
    /// </summary>
    public partial class Rotulo_neon : UserControl
    {
        public Rotulo_neon()
        {
            // Establece el contexto de datos como la propia instancia de la clase.
            DataContext = this;
            InitializeComponent();
        }

        // Propiedad para almacenar y actualizar el texto del rótulo.
        private string text;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Text
        {
            get { return text; }
            set 
            {
                // Actualiza el valor de la propiedad y asigna el texto a los elementos de la interfaz.
                text = value;
                rotulo_1.Text = text;
                rotulo_2.Text = text;

                // Invoca el evento PropertyChanged para notificar cambios en la propiedad.
                OnPropertyChanged(nameof(Text));
            }
        }

        // Propiedad para almacenar y actualizar el tamaño de fuente del rótulo.
        private double fontsize;

        public double Fontsize
        {
            get { return fontsize; }
            set
            {
                // Actualiza el valor de la propiedad y asigna el tamaño de fuente a los elementos de la interfaz.
                fontsize = value;
                rotulo_1.FontSize = fontsize;
                rotulo_2.FontSize = fontsize;

                // Invoca el evento PropertyChanged para notificar cambios en la propiedad.
                OnPropertyChanged(nameof(FontSize));
            }
        }

        // Propiedad para almacenar y actualizar la visibilidad del rótulo.
        private Visibility visibility;

        public Visibility Visibility
        {
            get { return visibility; }
            set
            {
                // Actualiza el valor de la propiedad y asigna la visibilidad a los elementos de la interfaz.
                visibility = value;
                rotulo_1.Visibility = visibility;
                rotulo_2.Visibility = visibility;

                // Invoca el evento PropertyChanged para notificar cambios en la propiedad.
                OnPropertyChanged(nameof(Visibility));
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
