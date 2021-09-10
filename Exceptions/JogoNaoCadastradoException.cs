/* Created by Robert Sá on 09/09/2021
  Criando um catálogo de jogos usandos boas práticas de arquitetura com .NET
  Digital Innovation One
  BOOTCAMP AVANADE 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploApiCatalogoJogos.Exceptions
{
    public class JogoNaoCadastradoException : Exception
    {
        public JogoNaoCadastradoException()
            : base("Este jogo não está cadastrado")
        { }
    }
}

