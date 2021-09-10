/* Created by Robert Sá on 09/09/2021
  Criando um catálogo de jogos usandos boas práticas de arquitetura com .NET
  Digital Innovation One
  BOOTCAMP AVANADE 
 */

//A controller depende de um contrato e não de uma implementação


using ApiCatalogoJogos.Controllers.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Controllers.V1
{
    [Route("api/[controller]")] // endreço da controller
    [ApiController]
    public class JogosController : ControllerBase
    {

        // readonly pois a responsabilidade de dar uma instância é da própia .ASPNET

        private readonly IJogoService _jogoService; //instância de IJogoService

        public JogosController(IJogoService jogoService) // construtor
        {
            _jogoService = jogoService;
        }

        // MÉTODOS HTTP OU VERBOS
        //GET GERALMENTE É USADO PARA CONSULTAS
        //POST PARA CRIAR UM RECURSO
        //PUT E PATCH PARA ATUALIZAÇÕES
        // REMOVER UM RECURSO

        [HttpGet] //método GET
                  //recebe jogosviewmodel
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        // página vem da requisição na query, range de 1 até a qtdpágina com no máximo 50 páginas
        {
            var jogos = await _jogoService.Obter(pagina, quantidade);

            if (jogos.Count() == 0) // Se não tiver nada na lista vai rodar não tem conteúdo
                return NoContent();

            return Ok(jogos); // Ok retorna status 200 com a lista do conteúdo
        }


        /// <summary>
        /// Buscar um jogo pelo seu Id
        /// </summary>
        /// <param name="idJogo">Id do jogo buscado</param>
        /// <response code="200">Retorna o jogo filtrado</response>
        /// <response code="204">Caso não haja jogo com este id</response>



        //Não vem da query, vem pela rota
        [HttpGet("(idJogo:guid)")] // guid struct que gera um valor aleatório e único
                                   //recebe jogosviewmodel
        public async Task<ActionResult<JogoViewModel>> Obter([FromRoute] Guid idJogo)
        {
            var jogo = await _jogoService.Obter(idJogo);

            if (jogo == null)
                return NoContent();

            return Ok(jogo);
        }

        [HttpPost] // método post
        // retorna jogosviewmodel
        //vem do body (FromBody) ....Get and Delete não tem body mas post, patch and delete does!!
        public async Task<ActionResult<JogoViewModel>> InserirJogo([FromBody] JogoInputModel jogoInputModel)
        {
            try //Verificar se já existe cadastro do jogo
            {
                var jogo = await _jogoService.Inserir(jogoInputModel);

                return Ok(jogo); 
            }
            
            catch (JogoJaCadastradoException ex)
            {
                return UnprocessableEntity("Já existe um jogo com este nome para esta produtora"); //status 422 retornando que já existe o jogo com o nome para a produtora
            }
        }


        /// <summary>
        /// Atualizar o preço de um jogo
        /// </summary>
        /// /// <param name="idJogo">Id do jogo a ser atualizado</param>
        /// <param name="preco">Novo preço do jogo</param>
        /// <response code="200">Cao o preço seja atualizado com sucesso</response>
        /// <response code="404">Caso não exista um jogo com este Id</response>  


        [HttpPut("(idJogo:guid)")] // método put para retornar actionResult
        // put atualiza o recurso inteiro de uma vez 
        // como já se sabe qual é o jogo não tem necessidade de receber novamente o IDJogo       
        // guid para identificar o recurso através da rota
         public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, jogoInputModel);

                return Ok();
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound("Não existe este jogo");
            }
        }




        /// <summary>
        /// Atualizar o preço de um jogo
        /// </summary>
        /// /// <param name="idJogo">Id do jogo a ser atualizado</param>
        /// <param name="preco">Novo preço do jogo</param>
        /// <response code="200">Cao o preço seja atualizado com sucesso</response>
        /// <response code="404">Caso não exista um jogo com este Id</response> 


        [HttpPatch("{idJogo:guid}/preco/{preco:double}")] // método patch atualiza uma coisa específica do recurso
        // especifica para atualizar o preço double preco
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromRoute] double preco)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, preco);

                return Ok();
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound("Não existe este jogo");
            }
        }

        /// <summary>
        /// Excluir um jogo
        /// </summary>
        /// /// <param name="idJogo">Id do jogo a ser excluído</param>
        /// <response code="200">Cao o preço seja atualizado com sucesso</response>
        /// <response code="404">Caso não exista um jogo com este Id</response> 

        [HttpDelete("{idJogo:guid}")]
        public async Task<ActionResult> ApagarJogo([FromRoute] Guid idJogo)
        {
            try
            {
                await _jogoService.Remover(idJogo);

                return Ok();
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound("Não existe este jogo"); //status 404 não existe o jogo
            }
        }

    }
}
