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
        private IEnumerable<Sugestao> listaSugestoes;
        private bool mayClose;
        public EditSugestao(IEnumerable<Sugestao> sugestoes, Sugestao sugestao = null)
        {
            InitializeComponent();


            listaSugestoes = sugestoes;
            Sugestao = sugestao ?? new Sugestao();

            this.DataContext = Sugestao;

            //Sugestao = sugestao == null ? new Sugestao() : sugestao;
            //FormSugestaoEdit.DataContext = Sugestao;
        }

        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        //private bool AtualizarEmpresa()
        //{
            
        //    if (listaSugestoes.Any(sugestao => sugestao.EmailUtilizador == Sugestao.EmailUtilizador && sugestao.SugestaoID != Sugestao.SugestaoID))
        //    {
        //        MessageBox.Show("Sigla Inválida. Já existente para outra empresa.", "Sigla Inválida", MessageBoxButton.OK, MessageBoxImage.Error);
        //        return false;
        //    }
            
        //    return true;
        //}

    }
}