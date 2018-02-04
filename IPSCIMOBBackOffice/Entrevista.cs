using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSCIMOBBackOffice
{
    public class Entrevista : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }


        int entrevistaId;
        public int EntrevistaId
        {
            get { return entrevistaId; }
            set
            {
                entrevistaId = value;
                OnPropertyChanged(new PropertyChangedEventArgs("EntrevistaId"));

            }
        }

        int numeroAluno;
        public int NumeroAluno
        {
            get { return numeroAluno; }
            set
            {
                numeroAluno = value;
                OnPropertyChanged(new PropertyChangedEventArgs("NumeroAluno"));
            }
        }

        string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Email"));
            }
        }

        bool entrevistaAtual;
        public bool EntrevistaAtual
        {
            get { return entrevistaAtual; }
            set
            {
                entrevistaAtual = value;
                OnPropertyChanged(new PropertyChangedEventArgs("EntrevistaAtual"));
            }
        }

        DateTime dataDeEntrevista;
        public DateTime DataDeEntrevista
        {
            get { return dataDeEntrevista; }
            set
            {
                dataDeEntrevista = value;
                OnPropertyChanged(new PropertyChangedEventArgs("DataDeEntrevista"));
            }
        }

        int estado;
        public int Estado
        {
            get { return estado; }
            set
            {
                estado = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Estado"));
            }
        }

        string nomePrograma;
        public string NomePrograma
        {
            get { return nomePrograma; }
            set
            {
                nomePrograma = value;
                OnPropertyChanged(new PropertyChangedEventArgs("NomePrograma"));
            }
        }


        public Entrevista()
        {
        }
    }
}
