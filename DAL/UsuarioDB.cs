using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class UsuarioDB
    {
        public static Response ExceptionGet(Exception e)
        {
            if (ConnectionString.Connection.State == System.Data.ConnectionState.Open)
            {
                ConnectionString.Connection.Close();
            }

            return new Response
            {
                Executed = false,
                ErrorMessage = e.Message,
                Exception = e
            };
        }

        public static Response Insert(Usuario user)
        {
            string insert = $"INSERT into dbo.Usuario(NomeDeusuario,Senha) values ('{user.NomeDeUsuario}','{user.Senha}')";
            SqlCommand cmd = new SqlCommand(insert, ConnectionString.Connection);
            try
            {
                ConnectionString.Connection.Open();
                cmd.ExecuteNonQuery();
                ConnectionString.Connection.Close();
                return new Response
                {
                    Executed = true
                };
            }
            catch (Exception e)
            {
                return ExceptionGet(e);
            }
        }

        public static Response Select(string userName,out Usuario user)
        {
            user = new Usuario();
            string select = $"SELECT * from dbo.Usuario WHERE NomeDeusuario = '{userName}'";
            SqlCommand cmd = new SqlCommand(select, ConnectionString.Connection);
            try
            {
                ConnectionString.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    user.IdUsuario = Convert.ToInt32(dr[0]);
                    user.NomeDeUsuario = dr[1].ToString();
                    user.Senha = dr[2].ToString();
                }
                dr.Close();
                ConnectionString.Connection.Close();
                return new Response
                {
                    Executed = true
                };
            }
            catch (Exception e)
            {
                return ExceptionGet(e);
            }
        }
    }
}
