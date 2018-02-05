using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSCIMOBBackOffice
{
    public class Ajuda : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }


        int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Id"));

            }
        }

        string nome;
        public string Nome
        {
            get { return nome; }
            set
            {
                nome = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Nome"));
            }
        }

        string descricao;
        public string Descricao
        {
            get { return descricao; }
            set
            {
                descricao = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Descricao"));
            }
        }

        public Ajuda()
        {
        }

    }
}
