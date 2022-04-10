using System;
using teste.classes;
using Xunit;

namespace teste
{
    public class PagamentoFatura
    {
        [Fact]
        public void VerificaPagamentoAtrasado(){

            Assert.Equal("Pgt feito com 6 dia(s) de atraso",
            new Fatura().VerificaPagamento("24/11/2010", "30/11/2010"));
            
            Assert.Equal("Pgt feito com 30 dia(s) de atraso",
            new Fatura().VerificaPagamento("10/04/2011", "10/05/2011"));

        }

        [Fact]
        public void VerificaPagamentoEmDia(){

            Assert.Equal("Pgto feito em dia",
            new Fatura().VerificaPagamento("24/11/2010", "24/11/2010"));
            
            Assert.Equal("Pgto feito em dia",
            new Fatura().VerificaPagamento("10/04/2011", "01/04/2011"));

        }


        [Fact]
        public void CompararDataParametroComDataConvertida(){

            DateTime dataParaComparar = new DateTime(2000,11,25);
            DateTime dataConvertidaPeloMetodo = new Fatura().CriarDataAPartirDoTexto("25/11/2000");
            Assert.Equal(dataParaComparar, dataConvertidaPeloMetodo);

        }

        [Fact]
        public void SemDiferencaEntreData(){
            Fatura fatura = new Fatura();
            DateTime dataVencimentoFake = new DateTime(2000,11,25);
            DateTime dataConvertidaPeloMetodo = fatura.CriarDataAPartirDoTexto("25/11/2000");
            Assert.Equal(0, fatura.DiferencaEntreAsDatasEmDias(dataVencimentoFake, dataConvertidaPeloMetodo));
        }

        [Fact]
        public void DiferencaDeUmDiaNegativo(){
            Fatura fatura = new Fatura();
            DateTime dataVencimentoFake = new DateTime(2000,11,24);
            DateTime dataConvertidaPeloMetodo = fatura.CriarDataAPartirDoTexto("25/11/2000");
            Assert.Equal(-1, fatura.DiferencaEntreAsDatasEmDias(dataVencimentoFake, dataConvertidaPeloMetodo));
        }


        [Fact]
        public void DiferencaDeCincoDiasNegativos(){
            Fatura fatura = new Fatura();
            DateTime dataVencimentoFake = new DateTime(2000,11,25);
            DateTime dataConvertidaPeloMetodo = fatura.CriarDataAPartirDoTexto("30/11/2000");
            Assert.Equal(-5, fatura.DiferencaEntreAsDatasEmDias(dataVencimentoFake, dataConvertidaPeloMetodo));
        }


        [Fact]
        public void MensagemParaPagamentoFeitoComAtrasoDeCincoDias(){
            string mensagem = "Pgt feito com 5 dia(s) de atraso";
            Assert.Equal(mensagem, new Fatura().StatusDaFatura(-5));
        }

        [Fact]
        public void MensagemParaPagamentoFeitoEmDia(){
            string mensagem = "Pgto feito em dia";
            Assert.Equal(mensagem, new Fatura().StatusDaFatura(0));
        }


        [Fact]
        public void MensagemParaPagamentoAdiantado(){
            string mensagem = "Pgto feito em dia";
            Assert.Equal(mensagem, new Fatura().StatusDaFatura(999));
        }

    }
}