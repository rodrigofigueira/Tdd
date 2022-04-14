using Xunit;
using teste.classes;

namespace teste
{
    public class EmailTest
    {
        [Fact]
        public void VerificaSeExisteEspacosEmBranco(){
            Assert.Equal("Não pode ter espaços em branco"
                        , new Email("emai l").Validar());
        }

        [Theory]
        [InlineData("&", "=", "_", "'", "-", "+", ",", "<", ">")]
        public void VerificaSeExisteCaracterInvalido(params string[] valores){

            foreach(string valor in valores) 
            Assert.Equal("Email com caracteres inválidos"
                        , new Email(valor).Validar());

        }

        [Fact]
        public void UltimoCaracterInvalido(){
            Assert.Equal("Email com caracteres inválidos", new Email("1234567890@email.").Validar());
        }

        [Fact]
        public void VerificaSeExisteCaracteresEspeciaisNecessarios(){
            Assert.Equal("Email não tem os caracteres especiais necessários"
                        , new Email("abcdef").Validar());
        }

        [Fact]
        public void VerificaSeEmailMaiorQueVinteCaracteres(){
            Assert.Equal("Email não pode ter mais de 20 caracteres", new Email("123456789123456789123456789@gmail.com").Validar());
        }

        [Fact]
        public void VerificaSeEmailMenorQueCincoCaracteres(){
            Assert.Equal("Email deve ser maior que 5 caracteres", new Email("a@d.u").Validar());
        }

    }
}