using System;
using System.Globalization;

namespace teste.classes
{
    public class Fatura
    {
        public string VerificaPagamento(string dataVencimento, string dataPagamento){
            
            DateTime _dataVencimento = CriarDataAPartirDoTexto(dataVencimento);
            DateTime _dataPagamento = CriarDataAPartirDoTexto(dataPagamento);

            int diferencaEntreAsDatas = DiferencaEntreAsDatasEmDias(_dataVencimento, _dataPagamento);

            return StatusDaFatura(diferencaEntreAsDatas);
        }

        public int DiferencaEntreAsDatasEmDias(DateTime dataVencimento, DateTime dataPagamento){
            return  (int)(dataVencimento - dataPagamento).TotalDays;
        }

        public DateTime CriarDataAPartirDoTexto(string dataEmTexto){
            return DateTime.ParseExact(dataEmTexto, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        public string StatusDaFatura(int qtdDeDias){
            
            if(qtdDeDias < 0) 
                return $"Pgt feito com {qtdDeDias * -1} dia(s) de atraso";
            
            return "Pgto feito em dia";
        }
        
    }
}