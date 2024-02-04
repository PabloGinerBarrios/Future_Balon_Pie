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
    /// Clase que representa una caja de texto con Placeholder.
    /// </summary>
    public partial class IndicadorFormulario : UserControl
    {
        public IndicadorFormulario()
        {
            // Establece el contexto de datos como la propia instancia de la clase.
            DataContext = this;
            InitializeComponent();
        }

        // Propiedad para almacenar y actualizar la pista del indicador de formulario (el Placeholder).
        private string pista;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Pista
        {
            get { return pista; }
            set
            {
                // Actualiza el valor de la propiedad y asigna la pista al elemento de texto.
                pista = value;
                tbPista.Text = pista;

                // Invoca el evento PropertyChanged para notificar cambios en la propiedad.
                OnPropertyChanged(nameof(Pista));
            }
        }

        // Propiedad para obtener o establecer el texto del usuario.
        public string UserText
        {
            get { return userText.Text; }
            set { userText.Text = value; }
        }

        // Manejador del evento de cambio de texto del usuario.
        private void userText_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Oculta o muestra la pista según si el texto del usuario está vacío o no.
            if (string.IsNullOrEmpty(userText.Text))
                tbPista.Visibility = Visibility.Visible;
            else
                tbPista.Visibility = Visibility.Hidden;
        }

        // Método para invocar el evento PropertyChanged.
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
