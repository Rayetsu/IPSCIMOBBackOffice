using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica interna para GestorAlunosEstrangeiros.xaml
    /// </summary>
    public partial class GestorAlunosEstrangeiros : Window
    {
        ObservableCollection<ForeignStudents> alunos = new ObservableCollection<ForeignStudents>();

        public GestorAlunosEstrangeiros()
        {
            InitializeComponent();
            alunos = App.IPSCIMOBDB.GetAlunosEstrangeiros();

            listBoxAlunosEstrangeiros.ItemsSource = alunos;

            //foreach(ForeignStudents a in alunos)
            //{
            //    a.
            //}
           
            listBoxAlunosEstrangeiros.DisplayMemberPath = "Nome";
            //listBoxAvioes.DisplayMemberPath = "Preco";

            listBoxAlunosEstrangeiros.SelectedItem = listBoxAlunosEstrangeiros.Items[0];
            listBoxAlunosEstrangeiros.IsSynchronizedWithCurrentItem = true;

            DataGridAlunosEstrangeiros.ItemsSource = alunos;
        }

        

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            AddAlunoEstrangeiro aE = new AddAlunoEstrangeiro();
            if (aE.ShowDialog() == true)
            {
                int id = App.IPSCIMOBDB.InserirAlunoEstrangeiro(aE.ForeignStudent);

                if (id > 0)
                {
                    aE.ForeignStudent.Id = id;
                    alunos.Add(aE.ForeignStudent);
                }
                listBoxAlunosEstrangeiros.Items.MoveCurrentToLast();
            }
            //aA.ShowDialog();
            //aviaoAtual = aA.Aviao;
            //avioes.Add(aviaoAtual);
            //listBoxAvioes.Items.Add(aviaoAtual);
        }

        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            if (listBoxAlunosEstrangeiros.SelectedItem == null)
                return;

            ForeignStudents alunoAtual = (ForeignStudents)listBoxAlunosEstrangeiros.SelectedItem as ForeignStudents;

            if (alunoAtual == null)
                return;

            EditAlunoEstrangeiro eA = new EditAlunoEstrangeiro(new ForeignStudents(alunoAtual));
            eA.Title = "Editar Dados do Aluno Estrangeiro";
            if (eA.ShowDialog() == true && eA.ForeignStudent != alunoAtual)
            {
                
                alunoAtual.Nome = eA.ForeignStudent.Nome;
                alunoAtual.Nacionalidade = eA.ForeignStudent.Nacionalidade;
                alunoAtual.Email = eA.ForeignStudent.Email;
                alunoAtual.DataDeNascimento = eA.ForeignStudent.DataDeNascimento;
                alunoAtual.EscolaIPSECurso = eA.ForeignStudent.EscolaIPSECurso;
                alunoAtual.Morada = eA.ForeignStudent.Morada;
                alunoAtual.NumeroDaPorta = eA.ForeignStudent.NumeroDaPorta;
                alunoAtual.Andar = eA.ForeignStudent.Andar;
                alunoAtual.Cidade = eA.ForeignStudent.Cidade;
                alunoAtual.Distrito = eA.ForeignStudent.Distrito;
                alunoAtual.CodigoPostal = eA.ForeignStudent.CodigoPostal;
                alunoAtual.Universidade = eA.ForeignStudent.Universidade;
                alunoAtual.Telefone = eA.ForeignStudent.Telefone;
                alunoAtual.IsBolseiro = eA.ForeignStudent.IsBolseiro;
                alunoAtual.PartilhaMobilidade = eA.ForeignStudent.PartilhaMobilidade;
                alunoAtual.IsFuncionario = eA.ForeignStudent.IsFuncionario;
                alunoAtual.IsDadosVerificados = eA.ForeignStudent.IsDadosVerificados;

                App.IPSCIMOBDB.ActualizarAlunosEstrangeiros(eA.ForeignStudent);
            }
        }

        private void Remove_OnClick(object sender, RoutedEventArgs e)
        {
            if (listBoxAlunosEstrangeiros.SelectedItem == null)
                return;

            ForeignStudents alunoAtual = (ForeignStudents)listBoxAlunosEstrangeiros.SelectedItem;

            if (MessageBox.Show("Deseseja mesmo apagar este registo (Y/N)?", "Apagar registo?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.IPSCIMOBDB.RemoverAlunoEstrangeiro(alunoAtual.Id);
                alunos.Remove(alunoAtual);

                listBoxAlunosEstrangeiros.Items.MoveCurrentToFirst();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ListBoxAlunosEstrangeiros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ForeignStudents alunoAtual = listBoxAlunosEstrangeiros.SelectedItem as ForeignStudents;
            if (alunoAtual == null)
                return;
        }
    }
}
