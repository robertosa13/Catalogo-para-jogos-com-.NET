/* Created by Robert Sá on 09/09/2021
  Criando um catálogo de jogos usandos boas práticas de arquitetura com .NET
  Digital Innovation One
  BOOTCAMP AVANADE  */

using ApiCatalogoJogos.Controllers.InputModel;
using ExemploApiCatalogoJogos.InputModel;
using ExemploApiCatalogoJogos.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExemploApiCatalogoJogos.Services
{
    public interface IJogoService : IDisposable
    {
        Task<List<JogoViewModel>> Obter(int pagina, int quantidade);
        Task<JogoViewModel> Obter(Guid id);
        Task<JogoViewModel> Inserir(JogoInputModel jogo);
        Task Atualizar(Guid id, JogoInputModel jogo);
        Task Atualizar(Guid id, double preco);
        Task Remover(Guid id);
    }
}
