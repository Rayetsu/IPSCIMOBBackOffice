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

namespace IPSCIMOBBackOffice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GestorAlunosEstrangeiros_OnClick(object sender, RoutedEventArgs e)
        {
            GestorAlunosEstrangeiros gAE = new GestorAlunosEstrangeiros();
            gAE.Title = "Gestor de Alunos Estrangeiros";
            gAE.ShowDialog();
        }

        private void GestorUtilizadores_OnClick(object sender, RoutedEventArgs e)
        {
            GestorUtilizadores gU = new GestorUtilizadores();
            gU.Title = "Gestor de Utilizadores";
            gU.ShowDialog();
        }

        private void GestorSugestoes_OnClick(object sender, RoutedEventArgs e)
        {
            GestorSugestoes gU = new GestorSugestoes();
            gU.Title = "Gestor de Sugestões";
            gU.ShowDialog();
        }

        private void GestorInfo_OnClick(object sender, RoutedEventArgs e)
        {
            GestorInformacoes gI = new GestorInformacoes();
            gI.Title = "Gestor de Informacoes Gerais";
            gI.ShowDialog();
        }

        private void GestorIntituicao_OnClick(object sender, RoutedEventArgs e)
        {
            GestorInstituicoes gI = new GestorInstituicoes();
            gI.Title = "Gestor de Instituições Parceiras";
            gI.ShowDialog();
        }


        private void GestorEntrevistas_OnClick(object sender, RoutedEventArgs e)
        {
            GestorEntrevistas gE = new GestorEntrevistas();
            gE.Title = "Gestor de Entrevistas";
            gE.ShowDialog();
        }

        private void GestorCandidaturas_OnClick(object sender, RoutedEventArgs e)
        {
            GestorCandidaturas gE = new GestorCandidaturas();
            gE.Title = "Gestor de Candidaturas";
            gE.ShowDialog();
        }

        private void GestorUserRoles_OnClick(object sender, RoutedEventArgs e)
        {
            GestorUserRoles gE = new GestorUserRoles();
            gE.Title = "Gestor de User Roles";
            gE.ShowDialog();
        }

        private void GestorAjudas_OnClick(object sender, RoutedEventArgs e)
        {
            GestorAjudas gE = new GestorAjudas();
            gE.Title = "Gestor de Ajudas";
            gE.ShowDialog();
        }

        private void GestorProgramas_OnClick(object sender, RoutedEventArgs e)
        {
            GestorProgramas gE = new GestorProgramas();
            gE.Title = "Gestor de Programas de Mobilidade";
            gE.ShowDialog();
        }


        private void Ficheiro_Sair_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
