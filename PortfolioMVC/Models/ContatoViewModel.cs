﻿using System.ComponentModel.DataAnnotations;

namespace PortfolioMVC.Models
{
    public class ContatoViewModel
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Mensagem { get; set; }
    }
}
