using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSCIMOBBackOffice
{
    public class InformacaoGeral : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }


        int informacaoGeralID;
        public int InformacaoGeralID
        {
            get { return informacaoGeralID; }
            set
            {
                informacaoGeralID = value;
                OnPropertyChanged(new PropertyChangedEventArgs("InformacaoGeralID"));

            }
        }

        string titulo;
        public string Titulo
        {
            get { return titulo; }
            set
            {
                titulo = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Titulo"));
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

        bool programaAtual;
        public bool ProgramaAtual
        {
            get { return programaAtual; }
            set
            {
                programaAtual = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ProgramaAtual"));
            }
        }

        public InformacaoGeral()
        {
        }
    }
}