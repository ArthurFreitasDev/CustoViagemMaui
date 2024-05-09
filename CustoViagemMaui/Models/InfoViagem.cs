using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustoViagemMaui.Models
{
    public class InfoViagem
    {
        public string Origem { get; set; }
        public string Destino { get; set; }
        public double Distancia { get; set; }
        public double Rendimento { get; set; }
        public double PrecoGas { get; set; }
    }
}
