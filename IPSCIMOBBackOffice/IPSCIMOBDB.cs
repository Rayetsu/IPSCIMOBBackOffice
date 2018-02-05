using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IPSCIMOBBackOffice
{
    public class IPSCIMOBDB
    {
        private string connectionString = "Data Source=SQL6003.site4now.net;Initial Catalog=DB_A30AB8_ipscimob;User Id=DB_A30AB8_ipscimob_admin;Password=ips12345";

        public ObservableCollection<ForeignStudents> GetAlunosEstrangeiros()
        {
            ObservableCollection<ForeignStudents> alunos = new ObservableCollection<ForeignStudents>();

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "SELECT * FROM ForeignStudents";

            cmd.CommandText = sql;

            try
            {
                con.Open();

                SqlDataReader dr;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ForeignStudents c = new ForeignStudents();

                    c.Id = (int)dr["Id"];
                    c.Nome = (string)dr["Nome"];
                    c.Nacionalidade = (string)dr["Nacionalidade"];
                    c.Email = (string)dr["Email"];
                    c.DataDeNascimento = (DateTime)dr["DataDeNascimento"];
                    c.EscolaIPSECurso = (string)dr["EscolaIPSECurso"];
                    c.Morada = (string)dr["Morada"];
                    c.NumeroDaPorta = (int)dr["NumeroDaPorta"];
                    c.Andar = (string)dr["Andar"];
                    c.Cidade = (string)dr["Cidade"];
                    c.Distrito = (string)dr["Distrito"];
                    c.CodigoPostal = (string)dr["CodigoPostal"];
                    c.Universidade = (string)dr["Universidade"];
                    c.Telefone = (int)dr["Telefone"];
                    c.IsBolseiro = (bool)dr["IsBolseiro"];
                    c.PartilhaMobilidade = (bool)dr["PartilhaMobilidade"];
                    c.IsFuncionario = (bool)dr["IsFuncionario"];
                    c.IsDadosVerificados = (bool)dr["IsDadosVerificados"];

                    alunos.Add(c);
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            return alunos;
        }

        public int InserirAlunoEstrangeiro(ForeignStudents foreignStudent)
        {
            int newId = -1;

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sqlInsert = "INSERT INTO [ForeignStudents] ([Nome], [Nacionalidade], [Email], [DataDeNascimento], [EscolaIPSECurso], [Morada], [NumeroDaPorta], [Andar], [Cidade], [Distrito], [CodigoPostal], [Universidade], [Telefone], [IsBolseiro], [PartilhaMobilidade], [IsFuncionario], [IsDadosVerificados]) VALUES ('" + foreignStudent.Nome + "', '" + foreignStudent.Nacionalidade + "', '" + foreignStudent.Email + "', '" + foreignStudent.DataDeNascimento.ToString() + "', '" + foreignStudent.EscolaIPSECurso + "', '" + foreignStudent.Morada + "', '" + foreignStudent.NumeroDaPorta.ToString() + "', '" + foreignStudent.Andar + "', '" + foreignStudent.Cidade + "', '" + foreignStudent.Distrito + "', '" + foreignStudent.CodigoPostal + "', '" + foreignStudent.Universidade + "', '" + foreignStudent.Telefone.ToString() + "', '" + foreignStudent.IsBolseiro.ToString() + "', '" + foreignStudent.PartilhaMobilidade.ToString() + "', '" + foreignStudent.IsFuncionario.ToString() + "', '" + foreignStudent.IsDadosVerificados.ToString() + "')";
            cmd.CommandText = sqlInsert;

            string sqlSelect = "SELECT Id, Nome, Nacionalidade, Email, DataDeNascimento, EscolaIPSECurso, Morada, NumeroDaPorta, Andar, Cidade, Distrito, CodigoPostal, Universidade, Telefone, IsBolseiro, PartilhaMobilidade, IsFuncionario, IsDadosVerificados FROM ForeignStudents WHERE (Id = SCOPE_IDENTITY())";

            int regs = 0;

            try
            {
                con.Open();

                regs = cmd.ExecuteNonQuery();

                SqlDataReader dr;
                cmd.CommandText = sqlSelect;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                    newId = (int)dr["Id"];
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show(regs + " registo adicionado (" + newId + ")");

            return newId;
        }

        public void RemoverAlunoEstrangeiro(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "DELETE FROM [ForeignStudents] WHERE ([Id] = " + id.ToString() + ")";
            cmd.CommandText = sql;

            int regs = 0;

            try
            {
                con.Open();

                regs = cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show(regs + " registo apagado");
        }

        public void ActualizarAlunosEstrangeiros(ForeignStudents foreignStudent)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "UPDATE [ForeignStudents] SET [Nome] = @nome, " +
                "[Nacionalidade] = @nacionalidade, [Email] = @email," +
                " [DataDeNascimento] = @dataDeNascimento," +
                " [EscolaIPSECurso] = @escolaIPSECurso, [Morada] = @morada," +
                " [NumeroDaPorta] = @numeroDaPorta, [Andar] = @andar," +
                " [Cidade] = @cidade, [Distrito] = @distrito, " +
                "[CodigoPostal] = @codigoPostal, [Universidade] = @universidade," +
                " [Telefone] = @telefone, [IsBolseiro] = @isBolseiro," +
                " [PartilhaMobilidade] = @partilhaMobilidade, " +
                "[IsFuncionario] = @isFuncionario, [IsDadosVerificados] = @isDadosVerificados WHERE ([Id] = @id)";

            //string sql = "UPDATE [ForeignStudents] SET [Nome] = '" +
            //    foreignStudent.Nome + "', [Nacionalidade] = '" +
            //    foreignStudent.Nacionalidade + "', [Email] = '" +
            //    foreignStudent.Email + "', [DataDeNascimento] = '" +
            //    foreignStudent.DataDeNascimento.ToString() + "', [EscolaIPSECurso] = '" +
            //    foreignStudent.EscolaIPSECurso + "', [Morada] = '" +
            //    foreignStudent.Morada + "', [NumeroDaPorta] = " +
            //    foreignStudent.NumeroDaPorta.ToString() + ", [Andar] = '" +
            //    foreignStudent.Andar + "', [Cidade] = '" +
            //    foreignStudent.Cidade + "', [Distrito] = '" +
            //    foreignStudent.Distrito + "', [CodigoPostal] = '" +
            //    foreignStudent.CodigoPostal + "', [Universidade] = '" +
            //    foreignStudent.Universidade + "', [Telefone] = " +
            //    foreignStudent.Telefone.ToString() + ", [IsBolseiro] = '" +
            //    foreignStudent.IsBolseiro.ToString() + "', [PartilhaMobilidade] = '" +
            //    foreignStudent.PartilhaMobilidade.ToString() + "', [IsFuncionario] = '" +
            //    foreignStudent.IsFuncionario.ToString() + "', [IsDadosVerificados] = '" +
            //    foreignStudent.IsDadosVerificados.ToString() +
            //    "' WHERE ([Id] = " +
            //    foreignStudent.Id.ToString() + ")";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@nome", foreignStudent.Nome);
            cmd.Parameters.AddWithValue("@nacionalidade", foreignStudent.Nacionalidade);
            cmd.Parameters.AddWithValue("@email", foreignStudent.Email);
            cmd.Parameters.AddWithValue("@dataDeNascimento", foreignStudent.DataDeNascimento.ToString());
            cmd.Parameters.AddWithValue("@escolaIPSECurso", foreignStudent.EscolaIPSECurso);
            cmd.Parameters.AddWithValue("@morada", foreignStudent.Morada);
            cmd.Parameters.AddWithValue("@numeroDaPorta", foreignStudent.NumeroDaPorta.ToString());
            cmd.Parameters.AddWithValue("@andar", foreignStudent.Andar);
            cmd.Parameters.AddWithValue("@cidade", foreignStudent.Cidade);
            cmd.Parameters.AddWithValue("@distrito", foreignStudent.Distrito);
            cmd.Parameters.AddWithValue("@codigoPostal", foreignStudent.CodigoPostal);
            cmd.Parameters.AddWithValue("@universidade", foreignStudent.Universidade);
            cmd.Parameters.AddWithValue("@telefone", foreignStudent.Telefone.ToString());
            cmd.Parameters.AddWithValue("@isBolseiro", foreignStudent.IsBolseiro.ToString());
            cmd.Parameters.AddWithValue("@partilhaMobilidade", foreignStudent.PartilhaMobilidade.ToString());
            cmd.Parameters.AddWithValue("@isFuncionario", foreignStudent.IsFuncionario.ToString());
            cmd.Parameters.AddWithValue("@isDadosVerificados", foreignStudent.IsDadosVerificados.ToString());
            cmd.Parameters.AddWithValue("@id", foreignStudent.Id);

            int regs = 0;

            try
            {
                con.Open();

                regs = cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show(regs + " registo actualizado");
        }

        public ObservableCollection<ApplicationUser> GetUsers()
        {
            ObservableCollection<ApplicationUser> users = new ObservableCollection<ApplicationUser>();

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "SELECT * FROM AspNetUsers";

            cmd.CommandText = sql;

            try
            {
                con.Open();

                SqlDataReader dr;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ApplicationUser c = new ApplicationUser();

                    c.Id = (string)dr["Id"];
                    c.Nome = (string)dr["Nome"];
                    c.Nacionalidade = (string)dr["Nacionalidade"];
                    c.Email = (string)dr["Email"];
                    c.DataDeNascimento = (DateTime)dr["DataDeNascimento"];
                    //c.CandidaturaAtual = (int)dr["CandidaturaAtual"];
                    c.Morada = (string)dr["Morada"];
                    c.NumeroDaPorta = (int)dr["NumeroDaPorta"];
                    c.Andar = (string)dr["Andar"];
                    c.Cidade = (string)dr["Cidade"];
                    c.Distrito = (string)dr["Distrito"];
                    c.CodigoPostal = (string)dr["CodigoPostal"];
                    c.NumeroDoBI = (int)dr["NumeroDoBI"];
                    c.Telefone = (int)dr["Telefone"];
                    c.NumeroInterno = (int)dr["NumeroInterno"];
                    c.PartilhaMobilidade = (bool)dr["PartilhaMobilidade"];
                    c.IsFuncionario = (bool)dr["IsFuncionario"];
                    c.IsDadosVerificados = (bool)dr["IsDadosVerificados"];
                    c.EmailConfirmed = (bool)dr["EmailConfirmed"];        
                    c.UserName = (string)dr["UserName"];

                    users.Add(c);
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            return users;
        }

        public void RemoverUtilizador(int numeroInterno)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "DELETE FROM [AspNetUsers] WHERE ([NumeroInterno] = " + numeroInterno + ")";
            cmd.CommandText = sql;

            int regs = 0;

            try
            {
                con.Open();

                regs = cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show(regs + " registo apagado");
        }

        public void ActualizarUtilizador(ApplicationUser user)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "UPDATE [AspNetUsers] SET [Nome] = @nome, " +
                "[NumeroInterno] = @numeroInterno, [Email] = @email," +
                "[Nacionalidade] = @nacionalidade," +
                " [DataDeNascimento] = @dataDeNascimento," +
                " [NumeroDoBI] = @numeroDoBI, [Morada] = @morada," +
                " [NumeroDaPorta] = @numeroDaPorta, [Andar] = @andar," +
                " [Cidade] = @cidade, [Distrito] = @distrito, " +
                "[CodigoPostal] = @codigoPostal," +
                " [Telefone] = @telefone," +
                " [PartilhaMobilidade] = @partilhaMobilidade, " +
                "[IsFuncionario] = @isFuncionario, [IsDadosVerificados] = @isDadosVerificados WHERE ([Id] = @id)";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@nome", user.Nome);
            cmd.Parameters.AddWithValue("@nacionalidade", user.Nacionalidade);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@dataDeNascimento", user.DataDeNascimento.ToString());
            cmd.Parameters.AddWithValue("@numeroDoBI", user.NumeroDoBI);
            cmd.Parameters.AddWithValue("@numeroInterno", user.NumeroInterno);
            cmd.Parameters.AddWithValue("@morada", user.Morada);
            cmd.Parameters.AddWithValue("@numeroDaPorta", user.NumeroDaPorta.ToString());
            cmd.Parameters.AddWithValue("@andar", user.Andar);
            cmd.Parameters.AddWithValue("@cidade", user.Cidade);
            cmd.Parameters.AddWithValue("@distrito", user.Distrito);
            cmd.Parameters.AddWithValue("@codigoPostal", user.CodigoPostal);
            cmd.Parameters.AddWithValue("@telefone", user.Telefone.ToString());
            cmd.Parameters.AddWithValue("@partilhaMobilidade", user.PartilhaMobilidade.ToString());
            cmd.Parameters.AddWithValue("@isFuncionario", user.IsFuncionario.ToString());
            cmd.Parameters.AddWithValue("@isDadosVerificados", user.IsDadosVerificados.ToString());
            cmd.Parameters.AddWithValue("@id", user.Id);

            int regs = 0;

            try
            {
                con.Open();

                regs = cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show(regs + " registo actualizado");
        }

        public ObservableCollection<Sugestao> GetSugestoes()
        {
            ObservableCollection<Sugestao> sugestoes = new ObservableCollection<Sugestao>();

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "SELECT * FROM Sugestao";

            cmd.CommandText = sql;

            try
            {
                con.Open();

                SqlDataReader dr;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Sugestao c = new Sugestao();

                    c.SugestaoID = (int)dr["SugestaoID"];
                    c.EmailUtilizador = (string)dr["EmailUtilizador"];
                    c.TextoSugestao = (string)dr["TextoSugestao"];

                    sugestoes.Add(c);
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            return sugestoes;
        }


        public int InserirSugestao(Sugestao sugestao)
        {
            int newId = -1;

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sqlInsert = "INSERT INTO [Sugestao] ([EmailUtilizador], [TextoSugestao]) VALUES ('" + sugestao.EmailUtilizador + "', '" + sugestao.TextoSugestao + "')";
            cmd.CommandText = sqlInsert;

            string sqlSelect = "SELECT SugestaoID, EmailUtilizador, TextoSugestao FROM Sugestao WHERE (SugestaoID = SCOPE_IDENTITY())";

            int regs = 0;

            try
            {
                con.Open();

                regs = cmd.ExecuteNonQuery();

                SqlDataReader dr;
                cmd.CommandText = sqlSelect;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                    newId = (int)dr["SugestaoID"];
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show(regs + " registo adicionado (" + newId + ")");

            return newId;
        }

        public void RemoverSugestao(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "DELETE FROM [Sugestao] WHERE ([SugestaoID] = " + id.ToString() + ")";
            cmd.CommandText = sql;

            int regs = 0;

            try
            {
                con.Open();

                regs = cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show(regs + " registo apagado");
        }

        public void ActualizarSugestao(Sugestao sugestao)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "UPDATE [Sugestao] SET [EmailUtilizador] = @emailUtilizador, " +
                "[TextoSugestao] = @textoSugestao WHERE ([SugestaoID] = @id)";


            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@emailUtilizador", sugestao.EmailUtilizador);
            cmd.Parameters.AddWithValue("@textoSugestao", sugestao.TextoSugestao);
            cmd.Parameters.AddWithValue("@id", sugestao.SugestaoID.ToString());

            int regs = 0;

            try
            {
                con.Open();

                regs = cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show(regs + " registo actualizado");
        }

        public ObservableCollection<InformacaoGeral> GetInformacoes()
        {
            ObservableCollection<InformacaoGeral> info = new ObservableCollection<InformacaoGeral>();

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "SELECT * FROM InformacaoGeral";

            cmd.CommandText = sql;

            try
            {
                con.Open();

                SqlDataReader dr;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    InformacaoGeral c = new InformacaoGeral();

                    c.InformacaoGeralID = (int)dr["InformacaoGeralID"];
                    c.Titulo = (string)dr["Titulo"];
                    c.Descricao = (string)dr["Descricao"];
                    c.ProgramaAtual = (bool)dr["ProgramaAtual"];

                    info.Add(c);
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            return info;
        }


        public int InserirInformacao(InformacaoGeral info)
        {
            int newId = -1;

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sqlInsert = "INSERT INTO [InformacaoGeral] ([Titulo], [Descricao], [ProgramaAtual]) VALUES ('" + info.Titulo + "', '" + info.Descricao + "', '" + info.ProgramaAtual +  "')";
            cmd.CommandText = sqlInsert;

            string sqlSelect = "SELECT InformacaoGeralID, Titulo, Descricao FROM InformacaoGeral WHERE (InformacaoGeralID = SCOPE_IDENTITY())";

            int regs = 0;

            try
            {
                con.Open();

                regs = cmd.ExecuteNonQuery();

                SqlDataReader dr;
                cmd.CommandText = sqlSelect;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                    newId = (int)dr["InformacaoGeralID"];
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show(regs + " registo adicionado (" + newId + ")");

            return newId;
        }

        public void RemoverInformacao(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "DELETE FROM [InformacaoGeral] WHERE ([InformacaoGeralID] = " + id.ToString() + ")";
            cmd.CommandText = sql;

            int regs = 0;

            try
            {
                con.Open();

                regs = cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show(regs + " registo apagado");
        }

        public void ActualizarInformacao(InformacaoGeral info)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "UPDATE [InformacaoGeral] SET [Titulo] = @titulo, " +
                "[Descricao] = @descricao WHERE ([InformacaoGeralID] = @id)";


            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@titulo", info.Titulo);
            cmd.Parameters.AddWithValue("@descricao", info.Descricao);
            cmd.Parameters.AddWithValue("@id", info.InformacaoGeralID);

            int regs = 0;

            try
            {
                con.Open();

                regs = cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show(regs + " registo actualizado");
        }


        public ObservableCollection<InstituicaoParceira> GetInstituicoes()
        {
            ObservableCollection<InstituicaoParceira> instituicao = new ObservableCollection<InstituicaoParceira>();

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "SELECT * FROM InstituicaoParceiraModel";

            cmd.CommandText = sql;

            try
            {
                con.Open();

                SqlDataReader dr;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    InstituicaoParceira c = new InstituicaoParceira();

                    c.InstituicaoParceiraID = (int)dr["InformacaoGeralID"];
                    c.Nome = (string)dr["Nome"];
                    c.Pais = (string)dr["Pais"];
                    c.Cidade = (string)dr["Cidade"];
                    c.ProgramaNome = (string)dr["ProgramaNome"];

                    instituicao.Add(c);
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            return instituicao;
        }


        public int InserirInstituicao(InstituicaoParceira instituicao)
        {
            int newId = -1;

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sqlInsert = "INSERT INTO [InstituicaoParceiraModel] ([Nome], [Pais], [Cidade], [ProgramaNome]) VALUES ('" + instituicao.Nome + "', '" + instituicao.Pais + "', '" + instituicao.Cidade + "', '" + instituicao.ProgramaNome + "')";
            cmd.CommandText = sqlInsert;

            string sqlSelect = "SELECT InstituicaoParceiraID, Nome, Pais, Cidade, ProgramaNome FROM InstituicaoParceiraModel WHERE (InstituicaoParceiraID = SCOPE_IDENTITY())";

            int regs = 0;

            try
            {
                con.Open();

                regs = cmd.ExecuteNonQuery();

                SqlDataReader dr;
                cmd.CommandText = sqlSelect;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                    newId = (int)dr["InstituicaoParceiraID"];
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show(regs + " registo adicionado (" + newId + ")");

            return newId;
        }

        public void RemoverInstituicao(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "DELETE FROM [InstituicaoParceiraModel] WHERE ([InstituicaoParceiraID] = " + id.ToString() + ")";
            cmd.CommandText = sql;

            int regs = 0;

            try
            {
                con.Open();

                regs = cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show(regs + " registo apagado");
        }

        public void ActualizarInstituicao(InstituicaoParceira instituicao)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "UPDATE [InstituicaoParceiraModel] SET [Nome] = @nome, " +
                "[Pais] = @pais, " +
                "[Cidade] = @cidade, " +
                "[ProgramaNome] = @programaNome  WHERE ([InstituicaoParceiraID] = @id)";


            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@nome", instituicao.Nome);
            cmd.Parameters.AddWithValue("@pais", instituicao.Pais);
            cmd.Parameters.AddWithValue("@programaNome", instituicao.ProgramaNome);
            cmd.Parameters.AddWithValue("@id", instituicao.InstituicaoParceiraID);

            int regs = 0;

            try
            {
                con.Open();

                regs = cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show(regs + " registo actualizado");
        }

        public ObservableCollection<Entrevista> GetEntrevistas()
        {
            ObservableCollection<Entrevista> info = new ObservableCollection<Entrevista>();

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "SELECT * FROM Entrevista";

            cmd.CommandText = sql;

            try
            {
                con.Open();

                SqlDataReader dr;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Entrevista c = new Entrevista();

                    c.EntrevistaId = (int)dr["EntrevistaId"];
                    c.NumeroAluno = (int)dr["NumeroAluno"];
                    c.Email = (string)dr["Email"];
                    c.EntrevistaAtual = (bool)dr["EntrevistaAtual"];
                    c.DataDeEntrevista = (DateTime)dr["DataDeEntrevista"];
                    c.Estado = (int)dr["Estado"];
                    c.NomePrograma = (string)dr["NomePrograma"];

                    info.Add(c);
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            return info;
        }


        public int InserirEntrevista(Entrevista entrevista)
        {
            int newId = -1;

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sqlInsert = "INSERT INTO [Entrevista] ([NumeroAluno], [Email], [EntrevistaAtual], [DataDeEntrevista], [Estado], [NomePrograma]) VALUES ('" + entrevista.NumeroAluno + "', '" + entrevista.Email + "', '" + entrevista.EntrevistaAtual + "', '" + entrevista.DataDeEntrevista + "', '" + entrevista.Estado + "', '" + entrevista.NomePrograma + "')";
            cmd.CommandText = sqlInsert;

            string sqlSelect = "SELECT EntrevistaId, NumeroAluno, Email, EntrevistaAtual, DataDeEntrevista, Estado, NomePrograma FROM Entrevista WHERE (EntrevistaId = SCOPE_IDENTITY())";

            int regs = 0;

            try
            {
                con.Open();

                regs = cmd.ExecuteNonQuery();

                SqlDataReader dr;
                cmd.CommandText = sqlSelect;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                    newId = (int)dr["EntrevistaId"];
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show(regs + " registo adicionado (" + newId + ")");

            return newId;
        }

        public void RemoverEntrevista(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "DELETE FROM [Entrevista] WHERE ([EntrevistaId] = " + id.ToString() + ")";
            cmd.CommandText = sql;

            int regs = 0;

            try
            {
                con.Open();

                regs = cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show(regs + " registo apagado");
        }

        public void ActualizarEntrevista(Entrevista entrevista)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "UPDATE [Entrevista] SET [NumeroAluno] = @numeroAluno, " +
                "[Email] = @email, " +
                "[EntrevistaAtual] = @entrevistaAtual, " +
                "[DataDeEntrevista] = @dataDeEntrevista, " +
                "[Estado] = @estado, " +
                "[NomePrograma] = @nomePrograma WHERE ([EntrevistaId] = @id)";


            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@numeroAluno", entrevista.NumeroAluno);
            cmd.Parameters.AddWithValue("@email", entrevista.Email);
            cmd.Parameters.AddWithValue("@entrevistaAtual", entrevista.EntrevistaAtual);
            cmd.Parameters.AddWithValue("@dataDeEntrevista", entrevista.DataDeEntrevista);
            cmd.Parameters.AddWithValue("@estado", entrevista.Estado);
            cmd.Parameters.AddWithValue("@nomePrograma", entrevista.NomePrograma);
            cmd.Parameters.AddWithValue("@id", entrevista.EntrevistaId);

            int regs = 0;

            try
            {
                con.Open();

                regs = cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show(regs + " registo actualizado");
        }

        public ObservableCollection<Candidatura> GetCandidatura()
        {
            ObservableCollection<Candidatura> info = new ObservableCollection<Candidatura>();

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "SELECT * FROM CandidaturaModel";

            cmd.CommandText = sql;

            try
            {
                con.Open();

                SqlDataReader dr;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Candidatura c = new Candidatura();

                    c.CandidaturaID = (int)dr["CandidaturaID"];
                    c.Programa = (string)dr["Programa"];
                    c.InstituicaoNome = (string)dr["InstituicaoNome"];
                    c.InstituicaoPais = (string)dr["InstituicaoPais"];
                    c.InstituicaoCidade = (string)dr["InstituicaoCidade"];
                    c.DataInicioCandidatura = (DateTime)dr["DataInicioCandidatura"];
                    c.DataFimCandidatura = (DateTime)dr["DataFimCandidatura"];
                    c.Semestre = (int)dr["Semestre"];
                    c.Email = (string)dr["Email"]; 
                    c.EntrevistaId = (int)dr["EntrevistaID"]; 
                    c.Nome = (string)dr["Nome"];
                    c.NumeroInterno = (int)dr["NumeroInterno"];
                    c.IsBolsa = (bool)dr["IsBolsa"];
                    c.EstadoBolsa = (int)dr["EstadoBolsa"];
                    c.IsEstudo = (bool)dr["IsEstudo"];
                    c.IsEstagio = (bool)dr["IsEstagio"];
                    c.IsInvestigacao = (bool)dr["IsInvestigacao"];
                    c.IsLecionar = (bool)dr["IsLecionar"];
                    c.IsFormacao = (bool)dr["IsFormacao"];
                    c.IsConfirmado = (bool)dr["IsConfirmado"];
                    c.Estado = (int)dr["Estado"];
                    c.EstadoDocumentos = (int)dr["EstadoDocumentos"];

                    info.Add(c);
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            return info;
        }


        //public int InserirCandidatura(Entrevista entrevista)
        //{
        //    int newId = -1;

        //    SqlConnection con = new SqlConnection(connectionString);
        //    SqlCommand cmd = new SqlCommand();

        //    cmd.Connection = con;

        //    string sqlInsert = "INSERT INTO [Entrevista] ([NumeroAluno], [Email], [EntrevistaAtual], [DataDeEntrevista], [Estado], [NomePrograma]) VALUES ('" + entrevista.NumeroAluno + "', '" + entrevista.Email + "', '" + entrevista.EntrevistaAtual + "', '" + entrevista.DataDeEntrevista + "', '" + entrevista.Estado + "', '" + entrevista.NomePrograma + "')";
        //    cmd.CommandText = sqlInsert;

        //    string sqlSelect = "SELECT EntrevistaId, NumeroAluno, Email, EntrevistaAtual, DataDeEntrevista, Estado, NomePrograma FROM Entrevista WHERE (EntrevistaId = SCOPE_IDENTITY())";

        //    int regs = 0;

        //    try
        //    {
        //        con.Open();

        //        regs = cmd.ExecuteNonQuery();

        //        SqlDataReader dr;
        //        cmd.CommandText = sqlSelect;
        //        dr = cmd.ExecuteReader();

        //        if (dr.Read())
        //            newId = (int)dr["EntrevistaId"];
        //    }
        //    catch (Exception exc)
        //    {
        //        MessageBox.Show(exc.Message);
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }

        //    MessageBox.Show(regs + " registo adicionado (" + newId + ")");

        //    return newId;
        //}

        public void RemoverCandidatura(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "DELETE FROM [Candidatura] WHERE ([CandidaturaID] = " + id.ToString() + ")";
            cmd.CommandText = sql;

            int regs = 0;

            try
            {
                con.Open();

                regs = cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show(regs + " registo apagado");
        }

        public void ActualizarCandidatura(Candidatura candidatura)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "UPDATE [Candidatura] SET [Programa] = @programa, " +
                "[InstituicaoNome] = @instituicaoNome, " +
                "[InstituicaoPais] = @instituicaoPais, " +
                "[InstituicaoCidade] = @instituicaoCidade, " +
                "[DataInicioCandidatura] = @datainicioCandidatura, " +
                "[DataFimCandidatura] = @dataFimCandidatura, " +
                "[Semestre] = @semestre, " +
                "[Email] = @email, " +
                "[EntrevistaID] = @entrevistaID, " +
                "[Nome] = @nome, " +
                "[NumeroInterno] = @numeroInterno, " +
                "[IsBolsa] = @isBolsa, " +
                "[EstadoBolsa] = @estadoBolsa, " +
                "[IsEstado] = @isEstado, " +
                "[IsEstagio] = @isEstagio, " +
                "[IsInvestigacao] = @isInvestigacao, " +
                "[IsLecionar] = @isLecionar, " +
                "[IsFormacao] = @isFormacao, " +
                "[IsConfirmado] = @isConfirmado, " +
                "[Estado] = @estado, " +
                "[EstadoDocumentos] = @estadoDocumentos WHERE ([CandidaturaID] = @id)";


            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@programa", candidatura.Programa);
            cmd.Parameters.AddWithValue("@instituicaoNome", candidatura.InstituicaoNome);
            cmd.Parameters.AddWithValue("@instituicaoPais", candidatura.InstituicaoCidade);
            cmd.Parameters.AddWithValue("@instituicaoCidade", candidatura.InstituicaoCidade);
            cmd.Parameters.AddWithValue("@dataInicioCandidatura", candidatura.DataInicioCandidatura);
            cmd.Parameters.AddWithValue("@dataFimCandidatura", candidatura.DataFimCandidatura);
            cmd.Parameters.AddWithValue("@semestre", candidatura.Semestre);
            cmd.Parameters.AddWithValue("@email", candidatura.InstituicaoNome);
            cmd.Parameters.AddWithValue("@entrevistaID", candidatura.InstituicaoCidade);
            cmd.Parameters.AddWithValue("@nome", candidatura.Nome);
            cmd.Parameters.AddWithValue("@numeroInterno", candidatura.NumeroInterno);
            cmd.Parameters.AddWithValue("@isBolsa", candidatura.IsBolsa);
            cmd.Parameters.AddWithValue("@estadoBolsa", candidatura.EstadoBolsa);
            cmd.Parameters.AddWithValue("@isEstudo", candidatura.IsEstudo);
            cmd.Parameters.AddWithValue("@isEstagio", candidatura.IsEstagio);
            cmd.Parameters.AddWithValue("@isInvestigacao", candidatura.IsInvestigacao);
            cmd.Parameters.AddWithValue("@isLecionar", candidatura.IsLecionar);
            cmd.Parameters.AddWithValue("@isFormacao", candidatura.IsFormacao);
            cmd.Parameters.AddWithValue("@isConfirmado", candidatura.IsConfirmado);
            cmd.Parameters.AddWithValue("@estado", candidatura.Estado);
            cmd.Parameters.AddWithValue("@estadoDocumentos", candidatura.EstadoDocumentos);
            cmd.Parameters.AddWithValue("@id", candidatura.EntrevistaId);

            int regs = 0;

            try
            {
                con.Open();

                regs = cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show(regs + " registo actualizado");
        }

        public ObservableCollection<UserRoles> GetUserRoles()
        {
            ObservableCollection<UserRoles> info = new ObservableCollection<UserRoles>();

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "SELECT * FROM AspNetUserRoles";

            cmd.CommandText = sql;

            try
            {
                con.Open();

                SqlDataReader dr;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    UserRoles c = new UserRoles();

                   
                    c.UserId = (string)dr["UserId"];
                    c.RoleId = (string)dr["RoleId"];
                    

                    info.Add(c);
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            return info;
        }

        public void ActualizarUserRoles(UserRoles userRoles)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "UPDATE [AspNetUserRoles] SET [RoleId] = @roleId WHERE ([UserId] = @id)";


            cmd.CommandText = sql;

            
            cmd.Parameters.AddWithValue("@roleId", userRoles.RoleId);
            cmd.Parameters.AddWithValue("@id", userRoles.UserId);

            int regs = 0;

            try
            {
                con.Open();

                regs = cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show(regs + " registo actualizado");
        }

        public List<Roles> GetRoles()
        {
            List<Roles> info = new List<Roles>();

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "SELECT * FROM AspNetRoles";

            cmd.CommandText = sql;

            try
            {
                con.Open();

                SqlDataReader dr;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Roles c = new Roles();


                    c.Id = (string)dr["Id"];
                    c.Name = (string)dr["Name"];


                    info.Add(c);
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            return info;
        }

        public ObservableCollection<Ajuda> GetAjuda()
        {
            ObservableCollection<Ajuda> info = new ObservableCollection<Ajuda>();

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "SELECT * FROM Ajuda";

            cmd.CommandText = sql;

            try
            {
                con.Open();

                SqlDataReader dr;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Ajuda c = new Ajuda();


                    c.Id = (int)dr["Id"];
                    c.Nome = (string)dr["Nome"];
                    c.Descricao = (string)dr["Descricao"];


                    info.Add(c);
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            return info;
        }

        public void ActualizarAjuda(Ajuda ajuda)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "UPDATE [Ajuda] SET [Nome] = @nome, [Descricao] = @descricao WHERE ([UserId] = @id)";


            cmd.CommandText = sql;


            cmd.Parameters.AddWithValue("@nome", ajuda.Nome);
            cmd.Parameters.AddWithValue("@descricao", ajuda.Descricao);
            cmd.Parameters.AddWithValue("@id", ajuda.Id);

            int regs = 0;

            try
            {
                con.Open();

                regs = cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show(regs + " registo actualizado");
        }
    }
}

    

