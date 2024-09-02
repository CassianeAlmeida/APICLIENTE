using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIcliente.Models;
using APIcliente.Metodos;
using static APIcliente.Dtos.ClienteDTO;
using APIcliente.Dtos;
using System.Text;


namespace APIcliente.Controllers
{
    [Route("cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        List<Cliente> listCliente = new List<Cliente>();

        public ClienteController()//criar
        {
            var cliente1 = new Cliente()
            {
                Nome = "Cassiane Almeida de Paula",
                DataNascimento = "30/01/2007",
                Sexo = "Feminino",
                RG =  "1566374",
                CPF =  "057.431.302-80",
                Endereco = "Rua Castelo Branco, n° 1323",
                Cidade = "Ouro Preto do Oeste",
                Estado = "Rondônia",
                Telefone = "(69) 99282-8030",
                Email = "cassianealmeida@gmail.com"
            };
            var cliente2 = new Cliente()
            {
                Nome = "Cassiane Almeida de Paula",
                DataNascimento = "30/01/2007",
                Sexo = "Feminino",
                RG = "1566374",
                CPF = "804.178.252-34",
                Endereco = "Rua Castelo Branco, n° 1323",
                Cidade = "Ouro Preto do Oeste",
                Estado = "Rondônia",
                Telefone = "(69) 99282-8030",
                Email = "cassianealmeida@gmail.com"
            };
            var cliente3 = new Cliente()
            {
                Nome = "Cassfdsfsdfsfla",
                DataNascimento = "30/01/2007",
                Sexo = "Feminino",
                RG = "1566374",
                CPF = "057.431.982-41",
                Endereco = "Rua Castelo Branco, n° 1323",
                Cidade = "Ouro Preto do Oeste",
                Estado = "Rondônia",
                Telefone = "(69) 99282-8030",
                Email = "cassianealmeida@gmail.com"
            };
            if (ValidaCPF.ValidaCpf(cliente1.CPF))
            {
                listCliente.Add(cliente1);
            }
            if (ValidaCPF.ValidaCpf(cliente2.CPF))
            {
                listCliente.Add(cliente2);
            }

        }
        [HttpGet("")]//listar
        public IActionResult Get()
        {
            return Ok(listCliente);
        }

        [HttpGet("{cpf}")]//buscar com cpf
        public IActionResult GetByCpf(string cpf)
        {
            var tarefa = listCliente.Where(item => item.CPF == cpf).FirstOrDefault();
            return Ok(tarefa);
        }

        [HttpPost]//criar
        public IActionResult Post([FromBody] Cliente item)
        {
            var cliente = new Cliente();

            cliente.Nome = item.Nome;
            cliente.DataNascimento = item.DataNascimento;
            cliente.Sexo = item.Sexo;
            cliente.RG = item.RG;
            cliente.CPF = item.CPF;
            cliente.Endereco = item.Endereco;
            cliente.Cidade = item.Cidade;   
            cliente.Estado = item.Estado;
            cliente.Telefone = item.Telefone;
            cliente.Email  = item.Email;

            if (ValidaCPF.ValidaCpf(cliente.CPF))
            {
                listCliente.Add(cliente);
                SalvarClientesEmArquivo();
            }
           
            return StatusCode(StatusCodes.Status201Created, cliente);

        }

        
        [HttpPut("{cpf}")]//atualizar

        public IActionResult Put(string cpf, [FromBody] ClienteDTO item)
        {
            var cliente = listCliente.Where(item => item.CPF == cpf).FirstOrDefault();

            if (cliente == null)
            {
                return NotFound();

            }

            cliente.Nome = item.Nome;
            cliente.DataNascimento = item.DataNascimento;
            cliente.Sexo = item.Sexo;
            cliente.RG = item.RG;
            cliente.CPF = item.CPF;
            cliente.Endereco = item.Endereco;
            cliente.Cidade = item.Cidade;
            cliente.Estado = item.Estado;
            cliente.Telefone = item.Telefone;
            cliente.Email = item.Email;

            SalvarClientesEmArquivo();

            return Ok(listCliente);
            
        }

        [HttpDelete("{cpf}")]//Deletar

        public IActionResult Delete(string cpf)
        {
            var cliente = listCliente.Where(item => item.CPF == cpf).FirstOrDefault();

            if (cliente == null)
            {
                return NotFound();
            }

            listCliente.Remove(cliente);
            SalvarClientesEmArquivo();

            return Ok(cliente);
        }

        private void SalvarClientesEmArquivo()
        {
            var caminhoArquivo = "clientes.txt";
            var conteudoArquivo = new StringBuilder();

            foreach (var cliente in listCliente)
            {
                conteudoArquivo.AppendLine($"{cliente.Nome};{cliente.DataNascimento};{cliente.Sexo};{cliente.RG};{cliente.CPF};{cliente.Endereco};{cliente.Cidade};{cliente.Estado};{cliente.Telefone};{cliente.Email}");
            }

            System.IO.File.WriteAllText(caminhoArquivo, conteudoArquivo.ToString());
        }
    }
}
