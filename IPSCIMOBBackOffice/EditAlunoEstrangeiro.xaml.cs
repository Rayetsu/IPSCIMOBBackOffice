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
    /// Lógica interna para EditAlunoEstrangeiro.xaml
    /// </summary>
    public partial class EditAlunoEstrangeiro : Window
    {
        public ForeignStudents ForeignStudent { get; set; }
        public EditAlunoEstrangeiro(ForeignStudents foreignStudent = null)
        {
            InitializeComponent();

            ForeignStudent = foreignStudent==null ? new ForeignStudents() : foreignStudent;

            //if (foreignStudent != null)
            //{
            //    ForeignStudent.Nome = foreignStudent.Nome;
            //    ForeignStudent.Nacionalidade = foreignStudent.Nacionalidade;
            //    ForeignStudent.Email = foreignStudent.Email;
            //    ForeignStudent.DataDeNascimento = foreignStudent.DataDeNascimento;
            //    ForeignStudent.EscolaIPSECurso = foreignStudent.EscolaIPSECurso;
            //    ForeignStudent.Morada = foreignStudent.Morada;
            //    ForeignStudent.NumeroDaPorta = foreignStudent.NumeroDaPorta;
            //    ForeignStudent.Andar = foreignStudent.Andar;
            //    ForeignStudent.Cidade = foreignStudent.Cidade;
            //    ForeignStudent.Distrito = foreignStudent.Distrito;
            //    ForeignStudent.CodigoPostal = foreignStudent.CodigoPostal;
            //    ForeignStudent.Universidade = foreignStudent.Universidade;
            //    ForeignStudent.Telefone = foreignStudent.Telefone;
            //    ForeignStudent.IsBolseiro = foreignStudent.IsBolseiro;
            //    ForeignStudent.PartilhaMobilidade = foreignStudent.PartilhaMobilidade;
            //    ForeignStudent.IsFuncionario = foreignStudent.IsFuncionario;
            //    ForeignStudent.IsDadosVerificados = foreignStudent.IsDadosVerificados;
            //}

            FormAlunoEstrangeiroEdit.DataContext = ForeignStudent;
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