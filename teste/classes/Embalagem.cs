using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teste.classes
{
    public class Embalagem
    {

        private Frete frete = new Frete();       

        public double CalculoPreco(double peso){
            if(peso <= 1) return 24.00;
            return 62.00;
        }

        public string PrazoDestino(string estadoOrigem, string estadoDestino){
            return frete.PrazoDestino(estadoOrigem, estadoDestino);
        }

    }
}