using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCartas
{
    class CartaPaus : ACarta
    {
        [NaoUsaSalvar]
        public override LocalSalvar LocalSalvar => LocalSalvar.Disco;
    }
}
