using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSCIMOBBackOffice
{
    [Serializable]
    public class ForeignStudents : INotifyPropertyChanged
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

        string nacionalidade;
        public string Nacionalidade
        {
            get { return nacionalidade; }
            set
            {
                nacionalidade = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Nacionalidade"));
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

        DateTime dataDeNascimento;
        public DateTime DataDeNascimento
        {
            get { return dataDeNascimento; }
            set
            {
                dataDeNascimento = value;
                OnPropertyChanged(new PropertyChangedEventArgs("DataDeNascimento"));
            }
        }

        string escolaIPSECurso;
        public string EscolaIPSECurso
        {
            get { return escolaIPSECurso; }
            set
            {
                escolaIPSECurso = value;
                OnPropertyChanged(new PropertyChangedEventArgs("EscolaIPSECurso"));
            }
        }

        string morada;
        public string Morada
        {
            get { return morada; }
            set
            {
                morada = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Morada"));
            }
        }

        int numeroDaPorta;
        public int NumeroDaPorta
        {
            get { return numeroDaPorta; }
            set
            {
                numeroDaPorta = value;
                OnPropertyChanged(new PropertyChangedEventArgs("NumeroDaPorta"));

            }
        }

        string andar;
        public string Andar
        {
            get { return andar; }
            set
            {
                andar = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Andar"));
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

        string distrito;
        public string Distrito
        {
            get { return distrito; }
            set
            {
                distrito = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Distrito"));
            }
        }

        string codigoPostal;
        public string CodigoPostal
        {
            get { return codigoPostal; }
            set
            {
                codigoPostal = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CodigoPostal"));
            }
        }

        string universidade;
        public string Universidade
        {
            get { return universidade; }
            set
            {
                universidade = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Universidade"));
            }
        }

        int telefone;
        public int Telefone
        {
            get { return telefone; }
            set
            {
                telefone = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Telefone"));

            }
        }

        bool isBolseiro;
        public bool IsBolseiro
        {
            get { return isBolseiro; }
            set
            {
                isBolseiro = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsBolseiro"));

            }
        }

        bool partilhaMobilidade;
        public bool PartilhaMobilidade
        {
            get { return partilhaMobilidade; }
            set
            {
                partilhaMobilidade = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PartilhaMobilidade"));

            }
        }

        bool isFuncionario;
        public bool IsFuncionario
        {
            get { return isFuncionario; }
            set
            {
                isFuncionario = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsFuncionario"));

            }
        }

        bool isDadosVerificados;
        public bool IsDadosVerificados
        {
            get { return isDadosVerificados; }
            set
            {
                isDadosVerificados = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsDadosVerificados"));

            }
        }

        public ForeignStudents()
        {
        }

        public ForeignStudents(ForeignStudents foreignStudent)
        {
            this.Id = foreignStudent.Id;
            this.Nome = foreignStudent.Nome;
            this.Nacionalidade = foreignStudent.Nacionalidade;
            this.Email = foreignStudent.Email;
            this.DataDeNascimento = foreignStudent.DataDeNascimento;
            this.EscolaIPSECurso = foreignStudent.EscolaIPSECurso;
            this.Morada = foreignStudent.Morada;
            this.NumeroDaPorta = foreignStudent.NumeroDaPorta;
            this.Andar = foreignStudent.Andar;
            this.Cidade = foreignStudent.Cidade;
            this.Distrito = foreignStudent.Distrito;
            this.CodigoPostal = foreignStudent.CodigoPostal;
            this.Universidade = foreignStudent.Universidade;
            this.Telefone = foreignStudent.Telefone;
            this.IsBolseiro = foreignStudent.IsBolseiro;
            this.PartilhaMobilidade = foreignStudent.PartilhaMobilidade;
            this.IsFuncionario = foreignStudent.IsFuncionario;
            this.IsDadosVerificados = foreignStudent.IsDadosVerificados;
        }

        //public override string ToString()
        //{
        //    return Nome + ", " + Nacionalidade + ", " + Email + ", " + DataDeNascimento + ", " + EscolaIPSECurso + ", " +
        //        Morada;
        //}

    }
}
