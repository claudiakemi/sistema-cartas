using System;

namespace SistemaCartas
{
    internal class NaoUsaSalvarAttribute : Attribute
    {
        public NaoUsaSalvarAttribute(int x)
        {

        }

        public NaoUsaSalvarAttribute()
        {

        }

        public bool UsaSalvar { get; set; }
    }
}