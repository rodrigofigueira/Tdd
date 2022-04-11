using teste.classes;
using Xunit;

namespace teste
{
    public class PrazoEntrega
    {

        [Fact(Skip="aguardando outros testes")]
        public void TestePrazoEntregaLocal(){
            Assert.Equal("Entrega em 5 dias", new Frete().PrazoDestino("SP", "sp"));
        }
        
        [Fact(Skip="aguardando outros testes")]
        public void TestePrazoEntregaForaDoEstado(){
            Assert.Equal("Entrega em 15 dias", new Frete().PrazoDestino("BA", "sp"));
        }

        [Fact]
        public void RetornarEstadoSolicitado(){            
            string estadoSolicitado = "SP";
            var estadoRetornado = new Frete().SelecionarPorEstado(estadoSolicitado);
            Assert.Equal(estadoSolicitado, estadoRetornado.Estado);
        }

        [Fact]
        public void RetornaDistanciaMaiorQueZero(){
            double distancia = new Frete().DistanciaEntreEstados("SP", "BA");
            Assert.True(distancia > 0);
        }
        
    }
}