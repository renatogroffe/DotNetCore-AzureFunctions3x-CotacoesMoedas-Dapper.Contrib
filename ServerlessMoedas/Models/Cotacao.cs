using System;
using Dapper.Contrib.Extensions;

namespace ServerlessMoedas.Models
{
    [Table("dbo.Cotacoes")]
    public class Cotacao
    {
        [ExplicitKey]
        public string Sigla { get; set; }
        public string NomeMoeda { get; set; }
        public DateTime? UltimaCotacao   { get; set; }
        public double? Valor { get; set; }
    }
}