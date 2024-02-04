using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Constructor de la ventana principal
        public MainWindow()
        {
            //Inicializa la interfaz de usuario 
            InitializeComponent();
        }

        // Método para iniciar la aplicación
        public void Iniciar(object sender, MouseButtonEventArgs e)
        {
            // Crea una nueva instancia de la ventana 'Info'
            Info infoWindow = new Info();

            // Muestra la ventana 'Info'
            infoWindow.Show();

            // Cierra la ventana principal
            this.Close();
        }

        // Método para mostrar información acerca de la aplicación
        private void Info(object sender, MouseButtonEventArgs e)
        {
            // Muestra un cuadro de diálogo con información acerca de la aplicación
            MessageBox.Show("Aplicación desarrollada por Pablo Giner Barrios.", "Acerca de");
        }
    }
}
