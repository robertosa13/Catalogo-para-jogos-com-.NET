/* Created by Robert Sá on 09/09/2021
  Criando um catálogo de jogos usandos boas práticas de arquitetura com .NET
  Digital Innovation One
  BOOTCAMP AVANADE 
 */



using ApiCatalogoJogos.Controllers.InputModel;
using ApiCatalogoJogos.Controllers.ViewModel;
using ApiCatalogoJogos.Entities;
using ApiCatalogoJogos.Repositories;
using ApiCatalogoJogos.Services;
using ExemploApiCatalogoJogos.Entities;
using ExemploApiCatalogoJogos.Exceptions;
using ExemploApiCatalogoJogos.InputModel;
using ExemploApiCatalogoJogos.Repositories;
using ExemploApiCatalogoJogos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploApiCatalogoJogos.Services
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository) //Recebe uma instância do repositório
        {
            _jogoRepository = jogoRepository;
        }

        public async Task<List<JogoViewModel>> Obter(int pagina, int quantidade) //recebe paginação
        {
            var jogos = await _jogoRepository.Obter(pagina, quantidade);

            return jogos.Select(jogo => new JogoViewModel
                                {
                                    Id = jogo.Id,
                                    Nome = jogo.Nome,
                                    Produtora = jogo.Produtora,
                                    Preco = jogo.Preco
                                })
                               .ToList();
        }
        //Interface sem implementação não compila

        public async Task<JogoViewModel> Obter(Guid id)
        {
            var jogo = await _jogoRepository.Obter(id);

            if (jogo == null)
                return null; //Se não encontrar referência retorna null

            return new JogoViewModel
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            }; // retorna o jogo
        }

        public async Task<JogoViewModel> Inserir(JogoInputModel jogo)
        {
            var entidadeJogo = await _jogoRepository.Obter(jogo.Nome, jogo.Produtora);

            if (entidadeJogo.Count > 0)
                throw new JogoJaCadastradoException();  //Retorna erro já cadastrado

            var jogoInsert = new Jogo //Cria uma entidade
            {
                Id = Guid.NewGuid(), //novo código do jogo
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };

            await _jogoRepository.Inserir(jogoInsert);

            return new JogoViewModel //Retorna uma viewmodel
            {
                Id = jogoInsert.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };
        }

        public async Task Atualizar(Guid id, JogoInputModel jogo)
        {
            var entidadeJogo = await _jogoRepository.Obter(id);

            if (entidadeJogo == null)
                throw new JogoNaoCadastradoException();

            entidadeJogo.Nome = jogo.Nome;
            entidadeJogo.Produtora = jogo.Produtora;
            entidadeJogo.Preco = jogo.Preco;

            await _jogoRepository.Atualizar(entidadeJogo);
        }

        public async Task Atualizar(Guid id, double preco)
        {
            var entidadeJogo = await _jogoRepository.Obter(id);

            if (entidadeJogo == null)
                throw new JogoNaoCadastradoException();

            entidadeJogo.Preco = preco;

            await _jogoRepository.Atualizar(entidadeJogo);
        }

        public async Task Remover(Guid id)
        {
            var jogo = await _jogoRepository.Obter(id);

            if (jogo == null)
                throw new JogoNaoCadastradoException();

            await _jogoRepository.Remover(id);
        }

        public void Dispose() //Garantir que não tenha conexões abertas com o banco de dados
        {
            _jogoRepository?.Dispose(); //feche as conexões de repositório quando for destruído com o banco
        }

        Task<List<JogosViewModel>> IJogoService.Obter(int pagina, int quantidade)
        {
            throw new NotImplementedException();
        }

        Task<JogosViewModel> IJogoService.Obter(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<JogosViewModel> Inserir(JogoInputModel jogo)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Guid id, JogoInputModel jogo)
        {
            throw new NotImplementedException();
        }

        Task<JogosViewModel> IJogoService.Inserir(JogoInputModel jogo)
        {
            throw new NotImplementedException();
        }

        Task IJogoService.Atualizar(Guid id, JogoInputModel jogo)
        {
            throw new NotImplementedException();
        }

        Task IJogoService.Atualizar(Guid id, double preco)
        {
            throw new NotImplementedException();
        }

        Task IJogoService.Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<JogosViewModel> Inserir(JogoInputModel jogo)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Guid id, JogoInputModel jogo)
        {
            throw new NotImplementedException();
        }

        Task<JogosViewModel> IJogoService.Inserir(JogoInputModel jogo)
        {
            throw new NotImplementedException();
        }

        Task IJogoService.Atualizar(Guid id, JogoInputModel jogo)
        {
            throw new NotImplementedException();
        }

        public Task<JogosViewModel> Inserir(JogoInputModel jogo)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Guid id, JogoInputModel jogo)
        {
            throw new NotImplementedException();
        }

        public Task<JogosViewModel> Inserir(JogoInputModel jogo)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Guid id, JogoInputModel jogo)
        {
            throw new NotImplementedException();
        }

        Task<JogosViewModel> IJogoService.Inserir(JogoInputModel jogo)
        {
            throw new NotImplementedException();
        }

        Task IJogoService.Atualizar(Guid id, JogoInputModel jogo)
        {
            throw new NotImplementedException();
        }
    }
}
