using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace ProjetoFinal
{
    class ConectaBanco
    {
        MySqlConnection conexao = new MySqlConnection("server=localhost; user id=root; password=;database=padaria_linguagens");
        public string msg;
        public bool insereUser(string user, string senha)
        {
            string senhaHash = hash.makeHash(senha);
            MySqlCommand cmd = new MySqlCommand("insere_user", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("nome", user);
            cmd.Parameters.AddWithValue("senha", senhaHash);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException erro)
            {
                msg = "Erro Mysql " + erro.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }


        }
        public bool consultaUsuario(string user, string pass)
        {
            string senhaHash = hash.makeHash(pass);
            MySqlCommand cmd = new MySqlCommand("consultaSenha", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("usuario", user);
            cmd.Parameters.AddWithValue("senha", senhaHash);
            try
            {
                conexao.Open();//abrindo a conexão;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();// tabela virtual
                da.Fill(ds); //passando os valores consultados para o DataSet 
                if (ds.Tables[0].Rows.Count > 0) // verifica se houve retorno
                    return true;
                else
                    return false;

            }
            catch (MySqlException er)
            {
                msg = "Erro" + er.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }

        public DataTable lista()
        {
            MySqlCommand cmd = new MySqlCommand("listaClientes", conexao);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dados = new DataTable();
                da.Fill(dados);
                return dados;
            }
            catch(MySqlException erro)
            {
                msg = "Erro MySQL: " + erro.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }

        }
        public bool insereCliente(Cliente c)
        {
            MySqlCommand cmd = new MySqlCommand("insereCliente", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("cpf", c.Cpf);
            cmd.Parameters.AddWithValue("nome", c.Nome);
            cmd.Parameters.AddWithValue("endereco", c.End);
            cmd.Parameters.AddWithValue("telefone", c.Tel);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException erro)
            {
                msg = "Erro Mysql " + erro.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }


        }

        public bool deletaCliente(string cpf)
        {
            MySqlCommand cmd = new MySqlCommand("deletaCliente", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("cpfRem", cpf);
           
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException erro)
            {
                msg = "Erro Mysql " + erro.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }


        }
        public bool updateCliente(Cliente c, string id)
        {
            MySqlCommand cmd = new MySqlCommand("updateCliente", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.AddWithValue("nome", c.Nome);
            cmd.Parameters.AddWithValue("endereco", c.End);
            cmd.Parameters.AddWithValue("telefone", c.Tel);
            cmd.Parameters.AddWithValue("id", id);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException erro)
            {
                msg = "Erro Mysql " + erro.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }


        }

    }
}
