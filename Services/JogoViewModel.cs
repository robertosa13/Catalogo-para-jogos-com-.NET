/* Created by Robert Sá on 09/09/2021
  Criando um catálogo de jogos usandos boas práticas de arquitetura com .NET
  Digital Innovation One
  BOOTCAMP AVANADE 
 */




using System;

namespace ExemploApiCatalogoJogos.Services
{
    public class JogoViewModel
    {
        public Guid Id { get; internal set; }
        public string Nome { get; internal set; }
        public string Produtora { get; internal set; }
        public double Preco { get; internal set; }
    }
}