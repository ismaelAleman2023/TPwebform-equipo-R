using dominio;
using System;

namespace negocio
{
    public class EnvioNegocio
    {
        private const double LATITUD_LOCAL = -34.6037;
        private const double LONGITUD_LOCAL = -58.3816;
        private const decimal TARIFA_BASE = 1500;
        private const decimal TARIFA_POR_KM = 12;
        private const decimal COSTO_RESPALDO = 3000;

        private double distanciaKm(double lat1, double lon1, double lat2, double lon2)
        {
            double f1 = lat1 * Math.PI / 180;
            double f2 = lat2 * Math.PI / 180;
            double a = Math.Pow(Math.Sin((f2 - f1) / 2), 2)
                     + Math.Cos(f1) * Math.Cos(f2) * Math.Pow(Math.Sin((lon2 - lon1) * Math.PI / 360), 2);
            return 2 * 6371 * Math.Asin(Math.Sqrt(a));
        }

        public decimal calcularCostoEnvio(Direccion direccion)
        {
            Coordenada destino = new UbicacionNegocio().obtenerCoordenadas(direccion.Localidad, direccion.Provincia);
            if (destino == null)
            {
                return COSTO_RESPALDO;
            }
            double km = distanciaKm(LATITUD_LOCAL, LONGITUD_LOCAL, destino.Latitud, destino.Longitud);
            return Math.Round(TARIFA_BASE + TARIFA_POR_KM * (decimal)km);
        }
    }
}
