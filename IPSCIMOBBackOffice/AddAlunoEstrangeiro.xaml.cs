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
    /// Lógica interna para AddAlunoEstrangeiro.xaml
    /// </summary>
    public partial class AddAlunoEstrangeiro : Window
    {
        public ForeignStudents ForeignStudent { get; set; }
        public AddAlunoEstrangeiro()
        {
            InitializeComponent();

            ForeignStudent = new ForeignStudents();
            FormAlunoEstrangeiroAdd.DataContext = ForeignStudent;
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
