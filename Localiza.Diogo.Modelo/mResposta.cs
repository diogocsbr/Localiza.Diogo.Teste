using System;
using System.Collections.Generic;

namespace Localiza.Diogo.Modelo
{
    public class mResposta
    {
        public int Entrada { get; set; }
        public List<int> Divisores { get; set; } = new List<int>();
        public List<int> Primos { get; set; } = new List<int>();
    }
}
