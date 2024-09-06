using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PessoasWeb.Core.Entities
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }    = string.Empty;
        public int Idade { get; set; }
        public DateTime DataNascimento { get; set; }
    }

}
