using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSCIMOBBackOffice
{
    public class ProgramaModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }


        int programaID;
        public int ProgramaID
        {
            get { return programaID; }
            set
            {
                programaID = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ProgramaID"));

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
        int utilizadorProfissao;
        public int UtilizadorProfissao
        {
            get { return utilizadorProfissao; }
            set
            {
                utilizadorProfissao = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UtilizadorProfissao"));
            }
        }

        DateTime prazoCandidaturaPrimeiroSemestre;
        public DateTime PrazoCandidaturaPrimeiroSemestre
        {
            get { return prazoCandidaturaPrimeiroSemestre; }
            set
            {
                prazoCandidaturaPrimeiroSemestre = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PrazoCandidaturaPrimeiroSemestre"));
            }
        }

        DateTime prazoCandidaturaSegundoSemestre;
        public DateTime PrazoCandidaturaSegundoSemestre
        {
            get { return prazoCandidaturaSegundoSemestre; }
            set
            {
                prazoCandidaturaSegundoSemestre = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PrazoCandidaturaSegundoSemestre"));
            }
        }
        public ProgramaModel()
        {
        }
    }
}
