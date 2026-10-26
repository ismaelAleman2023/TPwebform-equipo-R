using dominio;
using System;
using System.Collections.Generic;

namespace negocio
{
    public class DireccionNegocio
    {
        public List<Direccion> listarDirecciones()
        {
            List<Direccion> lista = new List<Direccion>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("select idDireccion, idcliente_dir, calle, numero, codigoPostal, localidad, provincia, observacion_dir from direccionesEnvio");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Direccion aux = new Direccion();
                    aux.IdDireccion = (int)datos.Lector["idDireccion"];
                    aux.IdCliente = (int)datos.Lector["idcliente_dir"];
                    aux.Calle = (string)datos.Lector["calle"];
                    aux.Numero = (string)datos.Lector["numero"];
                    aux.CodigoPostal = (string)datos.Lector["codigoPostal"];
                    aux.Localidad = (string)datos.Lector["localidad"];
                    aux.Provincia = (string)datos.Lector["provincia"];
                    if (!(datos.Lector["observacion_dir"] is DBNull))
                        aux.Observacion = (string)datos.Lector["observacion_dir"];
                    lista.Add(aux);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return lista;
        }
    }


}
