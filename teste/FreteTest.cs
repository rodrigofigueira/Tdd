using teste.classes;
using Xunit;

namespace teste
{
    public class FreteTest
    {

        [Fact]
        public void TestePrazoEntregaLocal(){
            Assert.Equal("Entrega em 5 dias", new Frete().PrazoDestino("SP", "sp"));
        }
        
        [Fact]
        public void TestePrazoEntregaForaDoEstado(){
            Assert.Equal("Entrega em 15 dias", new Frete().PrazoDestino("BA", "sp"));
        }

        [Fact]
        public void TestePrazoEntregaOrigemErrada(){
            Assert.Equal("Estado origem BLAH não existe", new Frete().PrazoDestino("blah", "sp"));
        }

        [Fact]
        public void TestePrazoEntregaDestinoErrado(){
            Assert.Equal("Estado destino BLAH não existe", new Frete().PrazoDestino("sp", "blah"));
        }

        [Theory]
        [InlineData("SP", "RJ", "RS", "AC", "ce")]
        public void ValoresPassadosSaoEstadosValidos(params string[] estados){            
            foreach(string estado in estados)
                Assert.True(new Frete().EstadoExiste(estado));
        }
        
        [Theory]
        [InlineData("99", "ok", "", " ")]        
        public void ValoresPassadosComoEstadoRetornamFalse(params string[] estados){
            foreach(string estado in estados)
                Assert.False(new Frete().EstadoExiste(estado));
        }

    }
}