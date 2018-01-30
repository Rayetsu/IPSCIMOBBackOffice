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
            cmd.Parameters.AddWithValue("@id", foreignStudent.Id.ToString());

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

                    c.Id = (int)dr["Id"];
                    c.Nome = (string)dr["Nome"];
                    c.Nacionalidade = (string)dr["Nacionalidade"];
                    c.Email = (string)dr["Email"];
                    c.DataDeNascimento = (DateTime)dr["DataDeNascimento"];
                    c.CandidaturaAtual = (int)dr["CandidaturaAtual"];
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
                    c.NormalizedEmail = (string)dr["NormalizedEmail"];
                    c.NormalizedUserName = (string)dr["NormalizedUserName"];
                    c.AccessFailedCount = (int)dr["AccessFailedCount"];
                    c.ConcurrencyStamp = (string)dr["ConcurrencyStamp"];
                    c.EmailConfirmed = (bool)dr["EmailConfirmed"];
                    c.LockoutEnabled = (bool)dr["LockoutEnabled"];
                    c.LockoutEnd = (DateTimeOffset)dr["LockoutEnd"];
                    c.PasswordHash = (string)dr["PasswordHash"];
                    c.PhoneNumber = (string)dr["PhoneNumber"];
                    c.PhoneNumberConfirmed = (bool)dr["PhoneNumberConfirmed"];
                    c.SecurityStamp = (string)dr["SecurityStamp"];
                    c.TwoFactorEnabled = (bool)dr["TwoFactorEnabled"];
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
    }
}
