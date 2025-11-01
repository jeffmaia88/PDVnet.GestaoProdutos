﻿using System.ComponentModel.DataAnnotations;


namespace PDVnet.GestaoProdutos.Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }      
        public int Quantidade { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}

