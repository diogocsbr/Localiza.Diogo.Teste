using Localiza.Diogo.Modelo;
using Localiza.Diogo.Services.Interfaces;

using System;
using System.ComponentModel;

namespace Localiza.Diogo.Logic
{
    public class Numero : IFatorar
    {
        public mResposta fatorar(int numero)
        {
            mResposta m = new mResposta();
            m.Entrada = numero;

            while (numero != 0 )
            {
                if (m.Entrada % numero == 0)
                {
                    m.Divisores.Add(numero);
                    if( IsPrimo(numero))
                    {
                        m.Primos.Add(numero);
                    }
                }

                numero--;
            }

            return m;
        }

        bool IsPrimo(int numero)
        {
            bool bPrimo = true;
            int fator = numero / 2;
            int i = 0;
            for (i = 2; i <= fator; i++)
            {
                if ((numero % i) == 0)
                    bPrimo = false;
            }
            return bPrimo;
        }

    }
}
