using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSCIMOBBackOffice
{
    public class InstituicaoParceira : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }


        int instituicaoParceiraID;
        public int InstituicaoParceiraID
        {
            get { return instituicaoParceiraID; }
            set
            {
                instituicaoParceiraID = value;
                OnPropertyChanged(new PropertyChangedEventArgs("InstituicaoParceiraID"));

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

        string pais;
        public string Pais
        {
            get { return pais; }
            set
            {
                pais = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Pais"));
            }
        }

        string cidade;
        public string Cidade
        {
            get { return cidade; }
            set
            {
                cidade = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Cidade"));
            }
        }

        string programaNome;
        public string ProgramaNome
        {
            get { return programaNome; }
            set
            {
                programaNome = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ProgramaNome"));
            }
        }

        public InstituicaoParceira()
        {
        }
    }
}
