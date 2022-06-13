using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podutos.Domain.Entities
{
    public class Cartao
    {
        public string? Numero { get; set; }
        public string? Titular { get; set; }
        public string? Data_Expiracao { get; set; }
        public string? Bandeira { get; set; }
        public string? CVV { get; set; }

    }
}
