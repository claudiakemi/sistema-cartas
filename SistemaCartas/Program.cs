using System;

namespace SistemaCartas
{
    class Program
    {
        static void Main(string[] args)
        {
            var cartaReis = new CartaReis();
            cartaReis.Nome = "Oi";
            cartaReis.Cor = "Vermelho";
            cartaReis.Salvar();

            var cartaPaus = new CartaPaus();
            cartaPaus.Nome = "Olá";
            cartaPaus.Cor = "Preto";
            cartaPaus.Salvar();
        }
    }
}
