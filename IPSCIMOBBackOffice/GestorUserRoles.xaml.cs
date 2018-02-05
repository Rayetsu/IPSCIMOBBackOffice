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
    /// Interaction logic for GestorUserRoles.xaml
    /// </summary>
    public partial class GestorUserRoles : Window
    {
        
            ObservableCollection<UserRoles> userRoles = new ObservableCollection<UserRoles>();

            List<Roles> roles = new List<Roles>();

        public GestorUserRoles()
            {
                InitializeComponent();
                userRoles = App.IPSCIMOBDB.GetUserRoles();

                roles = App.IPSCIMOBDB.GetRoles();

            listBoxUserRoles.ItemsSource = userRoles;

                listBoxUserRoles.DisplayMemberPath = "UserId"; 

                listBoxUserRoles.SelectedItem = listBoxUserRoles.Items[0];
                listBoxUserRoles.IsSynchronizedWithCurrentItem = true;

                DataGridUserRoles.ItemsSource = userRoles;

                foreach(Roles role in roles)
            {
                TextBoxRoles.Text += role.Name + " - " + role.Id + "\n";
            }
                
                
            }

            

            private void Edit_OnClick(object sender, RoutedEventArgs e)
            {
                if (listBoxUserRoles.SelectedItem == null)
                    return;

                UserRoles userRole = (UserRoles)listBoxUserRoles.SelectedItem as UserRoles;

                if (userRole == null)
                    return;

                EditUserRole eS = new EditUserRole(userRole);
                eS.Title = "Editar User Role";
                if (eS.ShowDialog() == true)
                {

                    //sugestaoAtual.EmailUtilizador = eS.Sugestao.EmailUtilizador;
                    //sugestaoAtual.TextoSugestao = eS.Sugestao.TextoSugestao;


                    App.IPSCIMOBDB.ActualizarUserRoles(eS.UserRole);
                }
            }

            

            private void cancelButton_Click(object sender, RoutedEventArgs e)
            {
                this.DialogResult = false;
            }

            private void ListBoxUserRoles_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                UserRoles userRoleAtual = listBoxUserRoles.SelectedItem as UserRoles;
                if (userRoleAtual == null)
                    return;
            }
        }
    }