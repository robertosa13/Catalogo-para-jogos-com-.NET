/* Created by Robert Sá on 09/09/2021
  Criando um catálogo de jogos usandos boas práticas de arquitetura com .NET
  Digital Innovation One
  BOOTCAMP AVANADE 
 */



using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



using System.Linq;

using System.Threading.Tasks;

namespace ApiCatalogoJogos.Controllers.InputModel
{
    public class JogoInputModel
    {
        // o Id é gerado para o usuário 
        // data notation

        //se estiver fora das regras estabelecidas não vair na controller, vai voltar o ErrorMessage

        [Required]
        [System.ComponentModel.DataAnnotations.StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do jogo deve conter entre 3 e 100 caracteres")]
        public string Nome { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome da produtora deve conter entre 3 e 100 caracteres")]
        public string Produtora { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "O preço deve ser de no mínimo 1 real e no máximo 1000 reais")]
        public double Preco { get; set; }
    }
}
