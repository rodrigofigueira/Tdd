using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teste.classes
{
    public class Produto
    {
        private Frete frete;
        public int Indice { get; set; }
        public string? Nome { get; set; }
        public double Peso { get; set; }

        public Produto(){
            frete = new Frete();
        }

        public Produto(int indice, string nome, double peso){
            frete = new Frete();
            this.Indice = indice;
            this.Nome = nome;
            this.Peso = peso;
        }

        public string Checkout(List<Produto> cestaLivros, string estadoOrigem, string estadoDestino){

            double pesoTotal = SomarPesoDosProdutos(cestaLivros);
            double preco = CalcularPreco(cestaLivros, estadoOrigem, estadoDestino);            

            return $"{FormatarPreco(preco)} {frete.PrazoDestino(estadoOrigem, estadoDestino)}";

        }

        private string FormatarPreco(double preco){
            return preco <= 0 ? "" : preco.ToString();
        }

        private double CalcularPreco(List<Produto> cestaLivros, string estadoOrigem, string estadoDestino){
            
            if(estadoOrigem.ToUpper() == "RJ" && estadoDestino.ToUpper() == "RJ") return 0;
            
            double pesoTotal = SomarPesoDosProdutos(cestaLivros);

            if(estadoOrigem == estadoDestino && pesoTotal <= 1) return 24;

            return 62;

        }

        private double SomarPesoDosProdutos(List<Produto> produtos){            
            return produtos.Sum(p => p.Peso);
        }
    }
}