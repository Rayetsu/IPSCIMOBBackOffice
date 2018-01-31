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

        public Sugestao(string emailUtilizador, string textoSugestao)
        {
            EmailUtilizador = emailUtilizador;
            TextoSugestao = textoSugestao;
        }
        public Sugestao(Sugestao sugestao)
        {
            SugestaoID = sugestao.SugestaoID;
            EmailUtilizador = sugestao.EmailUtilizador;
            TextoSugestao = sugestao.TextoSugestao; 
        }

        override
        public string ToString()
        {
            return EmailUtilizador;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Sugestao sugestao = obj as Sugestao;
            if ((object)sugestao == null)
                return false;

            return Equals(sugestao);
        }

        public bool Equals(Sugestao sugestao)
        {
            return SugestaoID == sugestao.SugestaoID &&
                   EmailUtilizador == sugestao.EmailUtilizador &&
                   TextoSugestao == sugestao.TextoSugestao;
        }

        public override int GetHashCode()
        {
            return SugestaoID;
        }

        public static bool operator == (Sugestao sugestao1, Sugestao sugestao2)
        {
            if (Object.ReferenceEquals(sugestao1, sugestao2))
                return true;

            if ((object)sugestao1 == null || (object)sugestao2 == null)
                return false;

            return sugestao1.Equals(sugestao2);
        }

        public static bool operator !=(Sugestao sugestao1, Sugestao sugestao2)
        {
            return !(sugestao1 == sugestao2);
        }
    }
}
