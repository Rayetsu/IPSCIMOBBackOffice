using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSCIMOBBackOffice
{
    public class Sugestao : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }


        int sugestaoID;
        public int SugestaoID
        {
            get { return sugestaoID; }
            set
            {
                sugestaoID = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SugestaoID"));

            }
        }

        string emailUtilizador;
        public string EmailUtilizador
        {
            get { return emailUtilizador; }
            set
            {
                emailUtilizador = value;
                OnPropertyChanged(new PropertyChangedEventArgs("EmailUtilizador"));
            }
        }

        string textoSugestao;
        public string TextoSugestao
        {
            get { return textoSugestao; }
            set
            {
                textoSugestao = value;
                OnPropertyChanged(new PropertyChangedEventArgs("TextoSugestao"));
            }
        }

        public Sugestao()
        {
        }

        public Sugestao(Sugestao sugestao)
        {
            SugestaoID = sugestao.SugestaoID;
            EmailUtilizador = sugestao.EmailUtilizador;
            TextoSugestao = sugestao.TextoSugestao; 
        }
    }
}
