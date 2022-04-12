using teste.classes;
using Xunit;

namespace teste
{
    public class EmbalagemTest
    {

        [Fact]
        public void TesteCalcularFreteAcimaUmKg(){
            Assert.Equal(62, new Embalagem().CalculoPreco(3));
        }

        [Fact]
        public void TesteCalcularFreteAteUmKg(){
            Assert.Equal(24, new Embalagem().CalculoPreco(1));
        }

        [Fact]
        public void TestePrazoEntregaLocal(){
            Assert.Equal("Entrega em 5 dias", new Embalagem().PrazoDestino("SP","sp"));
        }

        [Fact]
        public void TestePrazoForaEstado(){
            Assert.Equal("Entrega em 15 dias", new Embalagem().PrazoDestino("BA","sp"));
        }

    }
}