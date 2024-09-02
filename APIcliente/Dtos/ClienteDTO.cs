using System.ComponentModel.DataAnnotations;
using APIcliente.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace APIcliente.Dtos
{
    public class ClienteDTO
    {
       
            [Required]
            public string Nome { get; set; }

            [Required]
            public string DataNascimento { get; set; }

            [Required]
            public string Sexo { get; set; }

            [Required]
            public string RG { get; set; }

            [Required]
            public string CPF { get; set; }

            [Required]
            public string Endereco { get; set; }

            [Required]
            public string Cidade { get; set; }

            [Required]
            public string Estado { get; set; }

            [Required]
            public string Telefone { get; set; }

            [Required]
            public string Email { get; set; }


        
    }
}
