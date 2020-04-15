using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCartas
{
    /// <summary>
    /// Classe abstrata com propriedades e métodos das cartas
    /// </summary>
    abstract class ACarta : ICarta
    {
        public string Nome { get; set; }
        public string Cor { get; set; }
        public abstract LocalSalvar LocalSalvar { get; }
        /*
        public void Gravar() { }
        public void Buscar() { }
        public void Excluir() { }
        public void Atualizar() { }
        */

        internal void Salvar()
        {
            new CartaDsl().Salvar(this);
        }
    }
}

    