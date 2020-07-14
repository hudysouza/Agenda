using System;
using System.Collections.Generic;

namespace Agenda.Models
{
    public class Pessoa 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Nascimento { get; set; }

        public ICollection<Telefone> Telefones { get; set; }
        public Endereco Endereco { get; set; }
    }
}