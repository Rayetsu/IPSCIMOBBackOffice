using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSCIMOBBackOffice
{
    public class ApplicationUser : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        string id;
        public string Id
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

        //int candidaturaAtual;
        //public int CandidaturaAtual
        //{
        //    get { return candidaturaAtual; }
        //    set
        //    {
        //        candidaturaAtual = value;
        //        OnPropertyChanged(new PropertyChangedEventArgs("CandidaturaAtual"));
        //    }
        //}

        int numeroDoBI;
        public int NumeroDoBI
        {
            get { return numeroDoBI; }
            set
            {
                numeroDoBI = value;
                OnPropertyChanged(new PropertyChangedEventArgs("NumeroDoBI"));
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

        
        bool emailConfirmed;
        public bool EmailConfirmed
        {
            get { return emailConfirmed; }
            set
            {
                emailConfirmed = value;
                OnPropertyChanged(new PropertyChangedEventArgs("EmailConfirmed"));

            }
        }


        string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UserName"));
            }
        }

        public ApplicationUser()
        {
        }

        //public ApplicationUser(ApplicationUser utilizador)
        //{
        //    Id = utilizador.Id;
        //    Nome = utilizador.Nome;
        //    Nacionalidade = utilizador.Nacionalidade;
        //    Email = utilizador.Email;
        //    DataDeNascimento = utilizador.DataDeNascimento;
        //    //CandidaturaAtual = utilizador.CandidaturaAtual;
        //    Morada = utilizador.Morada;
        //    NumeroDaPorta = utilizador.NumeroDaPorta;
        //    Andar = utilizador.Andar;
        //    Cidade = utilizador.Cidade;
        //    Distrito = utilizador.Distrito;
        //    CodigoPostal = utilizador.CodigoPostal;
        //    NumeroDoBI = utilizador.NumeroDoBI;
        //    NumeroInterno = NumeroInterno;
        //    Telefone = utilizador.Telefone;
        //    PartilhaMobilidade = utilizador.PartilhaMobilidade;
        //    IsFuncionario = utilizador.IsFuncionario;
        //    IsDadosVerificados = utilizador.IsDadosVerificados;
        //    //AccessFailedCount = utilizador.AccessFailedCount;
        //    //ConcurrencyStamp = utilizador.ConcurrencyStamp;
        //    //EmailConfirmed = utilizador.EmailConfirmed;
        //    //LockoutEnabled = utilizador.LockoutEnabled;
        //    //LockoutEnd = utilizador.LockoutEnd;
        //    //NormalizedEmail = utilizador.NormalizedEmail;
        //    //NormalizedUserName = utilizador.NormalizedUserName;
        //    //PasswordHash = utilizador.PasswordHash;
        //    //PhoneNumber = utilizador.PhoneNumber;
        //    //PhoneNumberConfirmed = utilizador.PhoneNumberConfirmed;
        //    //SecurityStamp = utilizador.SecurityStamp;
        //    //TwoFactorEnabled = utilizador.TwoFactorEnabled;
        //    UserName = utilizador.UserName;
        //}
    }
}
