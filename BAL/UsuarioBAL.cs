using DAL;
using System;

namespace BAL
{
    public static class UsuarioBAL
    {
        public static Response Insert(Usuario user)
        {
            if (Checker.StringChecker(user.NomeDeUsuario,50))
            {
                if (!string.IsNullOrEmpty(user.Senha) &&
                    user.Senha.Length < 51)
                {
                    return UsuarioDB.Insert(user);
                }
                else
                {
                    return new Response
                    {
                        Executed = false,
                        ErrorMessage = "Senha num padrao incorreto"
                    };
                }
            }
            else
            {
                return new Response
                {
                    Executed = false,
                    ErrorMessage = "Usuario num padrao incorreto"
                };
            }
        }

        public static Response Select(string userName,out Usuario user)
        {
            user = new Usuario();
            if (!string.IsNullOrEmpty(userName) && 
                userName.Length < 51)
            {
                return UsuarioDB.Select(userName,out user);
            }
            else
            {
                return new Response
                {
                    Executed = false,
                    ErrorMessage = "UserName invalido"
                };
            }
        }
    }
}
