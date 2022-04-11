using System;
using System.Collections.Generic;
using System.Linq;

namespace teste.classes
{
    public class Frete
    {   

        private List<Coordenadas> estados = new List<Coordenadas>();

        public Frete(){
            estados.Add(new Coordenadas(-70.55,-8.77,"AC"));
            estados.Add(new Coordenadas(-35.73,-9.71,"AL"));
            estados.Add(new Coordenadas(-61.66,-3.07,"AM"));
            estados.Add(new Coordenadas(-51.77, 1.41,"AP"));
            estados.Add(new Coordenadas(-38.51,-12.96,"BA"));
            estados.Add(new Coordenadas(-38.54,-3.71,"CE"));
            estados.Add(new Coordenadas(-47.86,-15.83,"DF"));
            estados.Add(new Coordenadas(-40.34,-19.19,"ES"));
            estados.Add(new Coordenadas(-49.31,-16.64,"GO"));
            estados.Add(new Coordenadas(-44.30,-2.55,"MA"));
            estados.Add(new Coordenadas(-55.42,-12.64,"MT"));
            estados.Add(new Coordenadas(-54.54,-20.51,"MS"));
            estados.Add(new Coordenadas(-44.38,-18.10,"MG"));
            estados.Add(new Coordenadas(-52.29,-5.53,"PA"));
            estados.Add(new Coordenadas(-35.55,-7.06,"PB"));
            estados.Add(new Coordenadas(-51.55,-24.89,"PR"));
            estados.Add(new Coordenadas(-35.07,-8.28,"PE"));
            estados.Add(new Coordenadas(-43.68,-8.28,"PI"));
            estados.Add(new Coordenadas(-43.15,-22.84,"RJ"));
            estados.Add(new Coordenadas(-36.52,-5.22,"RN"));
            estados.Add(new Coordenadas(-62.80,-11.22,"RO"));
            estados.Add(new Coordenadas(-51.22,-30.01,"RS"));
            estados.Add(new Coordenadas(-61.22, 1.89,"RR"));
            estados.Add(new Coordenadas(-49.44,-27.33,"SC"));
            estados.Add(new Coordenadas(-37.07,-10.90,"SE"));
            estados.Add(new Coordenadas(-46.64,-23.55,"SP"));
            estados.Add(new Coordenadas(-48.25,-10.25,"TO"));
        }

        public Coordenadas SelecionarPorEstado(string estado){
            return estados.Where(x => x.Estado == estado).FirstOrDefault();
        }

        public string PrazoDestino(string destino, string origem){
            return "Entrega em 5 dias";
        }

        private double CalcularDistancia(double origem_lat, double origem_lng, double destino_lat, double destino_lng)  {
    
            double x1 = origem_lat;
            double x2 = destino_lat;
            double y1 = origem_lng;
            double y2 = destino_lng;

            double c = 90 - (y2);
            double b = 90 - (y1);
            double a = x2 - x1;
            double cos_a = Math.Cos(b) * Math.Cos(c) + Math.Sin(c) * Math.Sin(b) * Math.Cos(a);
            double arc_cos = Math.Acos(cos_a);
            double distancia = (40030 * arc_cos) / 360;

            return distancia;
        }

        public double DistanciaEntreEstados(string EstadoOrigem, string EstadoDestino){
            var estadoOrigem = SelecionarPorEstado(EstadoOrigem);
            var estadoDestino = SelecionarPorEstado(EstadoDestino);

            return CalcularDistancia(estadoOrigem.Latitude, estadoOrigem.Longitude
                                    ,estadoDestino.Latitude, estadoDestino.Longitude);

        }

    }

    public struct Coordenadas{
        
        public double Longitude;
        public double Latitude;
        public string Estado;

        public Coordenadas(double longitude, double latitude, string estado){
            this.Longitude = longitude;
            this.Latitude = latitude;
            this.Estado = estado;
        }

    }

}