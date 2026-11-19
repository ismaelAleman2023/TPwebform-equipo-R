using dominio;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace negocio
{
    public class UbicacionNegocio
    {
        private const string BASE = "https://apis.datos.gob.ar/georef/api/v2.1";

        private static readonly HttpClient clienteHttp = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };

        private string obtenerTexto(string ruta)
        {
            return clienteHttp.GetStringAsync(BASE + ruta).GetAwaiter().GetResult();
        }

        public List<Provincia> listarProvincias()
        {
            List<Provincia> lista = new List<Provincia>();
            try
            {
                string texto = obtenerTexto("/provincias?campos=id,nombre&orden=nombre&max=30");
                JObject respuesta = JObject.Parse(texto);
                foreach (JToken p in respuesta["provincias"])
                {
                    Provincia aux = new Provincia();
                    aux.Id = (string)p["id"];
                    aux.Nombre = (string)p["nombre"];
                    lista.Add(aux);
                }
            }
            catch (Exception)
            {
                return new List<Provincia>();
            }
            return lista;
        }

        public List<Localidad> listarLocalidades(string idProvincia)
        {
            List<Localidad> lista = new List<Localidad>();
            try
            {
                string ruta = "/localidades?provincia=" + Uri.EscapeDataString(idProvincia)
                            + "&campos=id,nombre&orden=nombre&max=1000";
                string texto = obtenerTexto(ruta);
                JObject respuesta = JObject.Parse(texto);
                foreach (JToken l in respuesta["localidades"])
                {
                    Localidad aux = new Localidad();
                    aux.Id = (string)l["id"];
                    aux.Nombre = (string)l["nombre"];
                    lista.Add(aux);
                }
            }
            catch (Exception)
            {
                return new List<Localidad>();
            }
            return lista;
        }

        public bool localidadValida(string localidad, string idProvincia)
        {
            try
            {
                string ruta = "/localidades?provincia=" + Uri.EscapeDataString(idProvincia)
                            + "&nombre=" + Uri.EscapeDataString(localidad)
                            + "&exacto=true&campos=id&max=1";
                JObject respuesta = JObject.Parse(obtenerTexto(ruta));
                return (int)respuesta["cantidad"] > 0;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public Coordenada obtenerCoordenadas(string localidad, string provincia)
        {
            try
            {
                string ruta = "/localidades?nombre=" + Uri.EscapeDataString(localidad)
                            + "&provincia=" + Uri.EscapeDataString(provincia)
                            + "&campos=centroide&max=1";
                JObject respuesta = JObject.Parse(obtenerTexto(ruta));
                JToken centro = respuesta["localidades"][0]["centroide"];
                return new Coordenada { Latitud = (double)centro["lat"], Longitud = (double)centro["lon"] };
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
