using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustoViagemMaui.Models
{
    public class Pedagio
    {
        string _local;
        double _valorpedagio;

        [AutoIncrement, PrimaryKey]
        public int NumeroPedagio { get; set; }

        public double ValorPedagio
        {
            get
            {
                return _valorpedagio;
            }

            set
            {
                if(!double.TryParse(value.ToString(), out _valorpedagio))
                    _valorpedagio = 0.0;

                if (_valorpedagio < 0)
                    throw new Exception("Valor inválido");

                _valorpedagio = value;
            }
        }
        public string Local
        {
            get => _local;

            set
            {
                if (value == null)
                    throw new Exception("Local inválido");

                _local = value;
            }
        }

        public double Rendimento { get; internal set; }
    }
}
