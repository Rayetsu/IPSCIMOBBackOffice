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
    /// Interaction logic for EditSugestao.xaml
    /// </summary>
    public partial class EditSugestao : Window
    {
        public Sugestao Sugestao { get; set; }
        public EditSugestao(Sugestao sugestao = null)
        {
            InitializeComponent();

            Sugestao = sugestao == null ? new Sugestao() : sugestao;

            //if (sugestao != null)
            //{
            //    Sugestao.EmailUtilizador = sugestao.EmailUtilizador;
            //    Sugestao.TextoSugestao = sugestao.TextoSugestao; 
            //}

            FormSugestaoEdit.DataContext = Sugestao;
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