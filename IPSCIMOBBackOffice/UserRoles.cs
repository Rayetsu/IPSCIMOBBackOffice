using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSCIMOBBackOffice
{
    public class UserRoles : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }


       

        string userId;
        public string UserId
        {
            get { return userId; }
            set
            {
                userId = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UserId"));
            }
        }

        string roleId;
        public string RoleId
        {
            get { return roleId; }
            set
            {
                roleId = value;
                OnPropertyChanged(new PropertyChangedEventArgs("RoleId"));
            }
        }
    }
}