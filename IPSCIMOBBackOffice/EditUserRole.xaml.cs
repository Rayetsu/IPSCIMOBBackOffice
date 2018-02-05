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
    /// Interaction logic for EditUserRole.xaml
    /// </summary>
    public partial class EditUserRole : Window
    {
        public UserRoles UserRole { get; set; }
        public EditUserRole(UserRoles userRole = null)
        {
            InitializeComponent();

            UserRole = userRole == null ? new UserRoles() : userRole;

           
            FormUserRolesEdit.DataContext = UserRole;
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