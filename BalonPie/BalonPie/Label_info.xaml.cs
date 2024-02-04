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
    /// Lógica de interacción para Label_info.xaml
    /// </summary>
    public partial class Label_info : UserControl
    {
        // Constructor de la clase Label_info
        public Label_info()
        {
            // Establece el contexto de datos como la propia instancia de la clase
            DataContext = this;
            // Inicializa los componentes visuales definidos en XAML
            InitializeComponent();
        }

        // Evento PropertyChanged para notificar cambios en las propiedades
        public event PropertyChangedEventHandler PropertyChanged;

        // Propiedad para el texto de la etiqueta
        private string labelText;

        public string LabelText
        {
            get { return labelText; }
            set
            {
                // Actualiza el valor de la propiedad y el contenido del TextBlock lbText
                labelText = value;
                lbText.Text = labelText;

                // Notifica a los suscriptores que la propiedad ha cambiado
                OnPropertyChanged(nameof(LabelText));
            }
        }

        // Propiedad de dependencia para el dataText
        public static readonly DependencyProperty DataTextProperty =
        DependencyProperty.Register("DataText", typeof(string), typeof(Label_info));

        // Propiedad para el dataText (utilizando DependencyProperty)
        public string DataText
        {
            get { return (string)GetValue(DataTextProperty); }
            set{ SetValue(DataTextProperty, value); }
        }

        // Método para invocar el evento PropertyChanged.
        private void OnPropertyChanged(string propertyName)
        {
            // Invoca el evento PropertyChanged para notificar cambios en las propiedades
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
