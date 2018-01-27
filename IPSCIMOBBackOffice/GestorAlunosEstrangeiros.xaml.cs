﻿using System;
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
        }

        //public string Display
        //{
        //    get
        //    {
        //        return String.Format("{0} - {1}",alunos. , Name);
        //    }
        //}

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

        //private void Edit_OnClick(object sender, RoutedEventArgs e)
        //{
        //    if (listBoxAvioes.SelectedItem == null)
        //        return;

        //    Aviao aviaoActual = (Aviao)listBoxAvioes.SelectedItem;

        //    EditAviao eA = new EditAviao(new Aviao(aviaoActual));
        //    if (eA.ShowDialog() == true && eA.Aviao != aviaoActual)
        //    {
        //        App.BDJetJourneys.ActualizarAviao(eA.Aviao);
        //        aviaoActual.Descricao = eA.Aviao.Descricao;
        //        aviaoActual.Preco = eA.Aviao.Preco;
        //    }
        //}

        //private void Remove_OnClick(object sender, RoutedEventArgs e)
        //{
        //    if (listBoxAvioes.SelectedItem == null)
        //        return;

        //    Aviao aviaoActual = (Aviao)listBoxAvioes.SelectedItem;

        //    if (MessageBox.Show("Deseseja mesmo apagar a tarefa (Y/N)?", "Apagar tarefa?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        //    {
        //        App.BDJetJourneys.RemoverAviao(aviaoActual.AviaoID);
        //        avioes.Remove(aviaoActual);

        //        listBoxAvioes.Items.MoveCurrentToFirst();
        //    }
        //}

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
