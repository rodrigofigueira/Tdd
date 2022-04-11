using System.Linq;
using System;

namespace teste.classes
{
    public class Frete
    {       

        private string[] EstadosBrasileiros = { "AC","AL","AP","AM","BA","CE","DF","ES","GO"
                                               ,"MA","MT","MS","MG","PA","PB","PR","PE","PI"
                                               ,"RJ","RN","RS","RO","RR","SC","SP","SE","TO"};

        public string PrazoDestino(string estadoOrigem, string estadoDestino){

            string _estadoOrigem = estadoOrigem.ToUpper();
            string _estadoDestino = estadoDestino.ToUpper();

            if(EstadoExiste(_estadoOrigem) == false) return $"Estado origem {_estadoOrigem} não existe";
            if(EstadoExiste(_estadoDestino) == false) return $"Estado destino {_estadoDestino} não existe";

            if(_estadoOrigem == _estadoDestino) return "Entrega em 5 dias";

            return "Entrega em 15 dias";

        }

        public bool EstadoExiste(string estado){

            if(String.IsNullOrEmpty(estado)) return false;

            string _estado = estado.ToUpper();
            var retorno = EstadosBrasileiros.FirstOrDefault(e => e.Contains(_estado));

            if(retorno == null) 
                return false;
            
            return true;
        }


    }

}