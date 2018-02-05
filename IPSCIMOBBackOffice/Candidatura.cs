using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSCIMOBBackOffice
{
    public class Candidatura : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }


        int candidaturaID;
        public int CandidaturaID
        {
            get { return candidaturaID; }
            set
            {
                candidaturaID = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CandidaturaID"));

            }
        }

        string programa;
        public string Programa
        {
            get { return programa; }
            set
            {
                programa = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Programa"));
            }
        }

        string instituicaoNome;
        public string InstituicaoNome
        {
            get { return instituicaoNome; }
            set
            {
                instituicaoNome = value;
                OnPropertyChanged(new PropertyChangedEventArgs("InstituicaoNome"));
            }
        }

        string instituicaoPais;
        public string InstituicaoPais
        {
            get { return instituicaoPais; }
            set
            {
                instituicaoPais = value;
                OnPropertyChanged(new PropertyChangedEventArgs("InstituicaoPais"));
            }
        }

        string instituicaoCidade;
        public string InstituicaoCidade
        {
            get { return instituicaoCidade; }
            set
            {
                instituicaoCidade = value;
                OnPropertyChanged(new PropertyChangedEventArgs("InstituicaoCidade"));
            }
        }

        DateTime dataInicioCandidatura;
        public DateTime DataInicioCandidatura
        {
            get { return dataInicioCandidatura; }
            set
            {
                dataInicioCandidatura = value;
                OnPropertyChanged(new PropertyChangedEventArgs("DataInicioCandidatura"));
            }
        }

        DateTime dataFimCandidatura;
        public DateTime DataFimCandidatura
        {
            get { return dataFimCandidatura; }
            set
            {
                dataFimCandidatura = value;
                OnPropertyChanged(new PropertyChangedEventArgs("DataFimCandidatura"));
            }
        }

        int semestre;
        public int Semestre
        {
            get { return semestre; }
            set
            {
                semestre = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Semestre"));
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

        int entrevistaID;
        public int EntrevistaId
        {
            get { return entrevistaID; }
            set
            {
                entrevistaID = value;
                OnPropertyChanged(new PropertyChangedEventArgs("EntrevistaID"));
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

        int numeroInterno;
        public int NumeroInterno
        {
            get { return numeroInterno; }
            set
            {
                numeroInterno = value;
                OnPropertyChanged(new PropertyChangedEventArgs("NumeroInterno"));
            }
        }

        bool isBolsa;
        public bool IsBolsa
        {
            get { return isBolsa; }
            set
            {
                isBolsa = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsBolsa"));
            }
        }

        int estadoBolsa;
        public int EstadoBolsa
        {
            get { return estadoBolsa; }
            set
            {
                estadoBolsa = value;
                OnPropertyChanged(new PropertyChangedEventArgs("EstadoBolsa"));
            }
        }


        bool isEstudo;
        public bool IsEstudo
        {
            get { return isEstudo; }
            set
            {
                isEstudo = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsEstudo"));
            }
        }

        bool isEstagio;
        public bool IsEstagio
        {
            get { return isEstagio; }
            set
            {
                isEstagio = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsEstagio"));
            }
        }

        bool isInvestigacao;
        public bool IsInvestigacao
        {
            get { return isInvestigacao; }
            set
            {
                isInvestigacao = value;
                OnPropertyChanged(new PropertyChangedEventArgs("isInvestigacao"));
            }
        }

        bool isLecionar;
        public bool IsLecionar
        {
            get { return isLecionar; }
            set
            {
                isLecionar = value;
                OnPropertyChanged(new PropertyChangedEventArgs("isLecionar"));
            }
        }

        bool isFormacao;
        public bool IsFormacao
        {
            get { return isFormacao; }
            set
            {
                isFormacao = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsFormacao"));
            }
        }

        bool isConfirmado;
        public bool IsConfirmado
        {
            get { return isConfirmado; }
            set
            {
                isConfirmado = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsConfirmado"));
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

        int estadoDocumentos;
        public int EstadoDocumentos
        {
            get { return estadoDocumentos; }
            set
            {
                estadoDocumentos = value;
                OnPropertyChanged(new PropertyChangedEventArgs("EstadoDocumentos"));
            }
        }


        public Candidatura()
        {
        }
    }
}
