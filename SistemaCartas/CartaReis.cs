using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCartas
{
    class CartaReis : ACarta
    {
        [NaoUsaSalvar]
        public override LocalSalvar LocalSalvar => LocalSalvar.DB;

        public string Descricao { get; set; }

        [NaoUsaSalvar]
        public string Descricao2 { get; set; }
        [NaoUsaSalvar]
        public string Descricao3 { get; set; }
        [NaoUsaSalvar]
        public string Descricao4 { get; set; }
    }
}
