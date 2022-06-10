using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podutos.Domain.Entities
{
    public class Cartao
    {
        public int Numero { get; set; }
        public string? Titular { get; set; }
        public DateTime Data_Expiracao { get; set; }
        public string? Bandeira { get; set; }
        public int CVV { get; set; }
    }
}
