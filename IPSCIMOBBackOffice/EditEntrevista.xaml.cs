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
using System.Windows.Shapes;

namespace IPSCIMOBBackOffice
{
    /// <summary>
    /// Interaction logic for EditEntrevista.xaml
    /// </summary>
    public partial class EditEntrevista : Window
    {
        public Entrevista Entrevista { get; set; }
        public EditEntrevista(Entrevista entrevista = null)
        {
            InitializeComponent();

            Entrevista = entrevista ?? new Entrevista();
            FormEntrevistaEdit.DataContext = Entrevista;
        }

        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }



    }
}