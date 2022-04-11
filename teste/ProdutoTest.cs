using System.Collections.Generic;
using Xunit;

namespace teste
{
    public class ProdutoTest
    {

        [Fact]
        public void TestCalculaFreteLivroLocalmente(){
            List<Produto> cestaLivro = new List<Produto>();
            cestaLivro.Add(new Produto(0, "Guia do exame SCJP", 1));
            Assert.Equal("24 Entrega em 5 dias", new Produto().Checkout(cestaLivro, "SP", "SP"));
        }

        [Fact]
        public void TestCalculaFreteLocalDiferente(){
            List<Produto> cestaLivro = new List<Produto>();
            cestaLivro.Add(new Produto(0, "Guia do exame SCJP", 1));
            cestaLivro.Add(new Produto(1, "Dominando Hibernate", 2));
            Assert.Equal("62 Entrega em 15 dias", new Produto().Checkout(cestaLivro, "BA", "SP"));
        }

        [Fact]
        public void TestCalculaFreteMenosUmKg(){
            List<Produto> cestaLivro = new List<Produto>();
            cestaLivro.Add(new Produto(0, "Guia do exame SCJP", 0.500));
            Assert.Equal("24 Entrega em 5 dias", new Produto().Checkout(cestaLivro, "SP", "SP"));
        }

        [Fact]
        public void TestCalculaFreteMaisUmKg(){
            List<Produto> cestaLivro = new List<Produto>();
            cestaLivro.Add(new Produto(0, "Guia do exame SCJP", 1));
            cestaLivro.Add(new Produto(1, "Dominando Hibernate", 2));
            cestaLivro.Add(new Produto(3, "TomCat Administrador", 1));
            cestaLivro.Add(new Produto(4, "Core JSF 2.0", 1));
            cestaLivro.Add(new Produto(5, "Certificação LPI", 1));
            Assert.Equal(" Entrega em 5 dias", new Produto().Checkout(cestaLivro, "RJ", "rj"));
        }

    }
}