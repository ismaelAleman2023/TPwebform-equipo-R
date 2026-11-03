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

        public void agregarDireccion(Direccion dir)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("insert into direccionesEnvio(idcliente_dir, calle, numero, codigoPostal, localidad, provincia, observacion_dir) values(@idCliente, @calle, @numero, @codigoPostal, @localidad, @provincia, @observacion)");
                datos.setearParametros("@idCliente", dir.IdCliente);
                datos.setearParametros("@calle", dir.Calle);
                datos.setearParametros("@numero", dir.Numero);
                datos.setearParametros("@codigoPostal", dir.CodigoPostal);
                datos.setearParametros("@localidad", dir.Localidad);
                datos.setearParametros("@provincia", dir.Provincia);
                datos.setearParametros("@observacion", dir.Observacion);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void ModificarDireccion(int idCliente, Direccion dir)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("update direccionesEnvio set calle = @calle, numero = @numero, codigoPostal = @codigoPostal, localidad = @localidad, provincia = @provincia, observacion_dir = @observacion where idDireccion = @idDireccion and idcliente_dir = @idCliente");
                datos.setearParametros("@calle", dir.Calle);
                datos.setearParametros("@numero", dir.Numero);
                datos.setearParametros("@codigoPostal", dir.CodigoPostal);
                datos.setearParametros("@localidad", dir.Localidad);
                datos.setearParametros("@provincia", dir.Provincia);
                datos.setearParametros("@observacion", dir.Observacion);
                datos.setearParametros("@idDireccion", dir.IdDireccion);
                datos.setearParametros("@idCliente", idCliente);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Direccion buscarDireccion(int id)
        {
            Direccion dir = new Direccion();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("select idDireccion, idcliente_dir, calle, numero, codigoPostal, localidad, provincia, observacion_dir from direccionesEnvio where idDireccion = @id");
                datos.setearParametros("@id", id);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    dir.IdDireccion = (int)datos.Lector["idDireccion"];
                    dir.IdCliente = (int)datos.Lector["idcliente_dir"];
                    dir.Calle = (string)datos.Lector["calle"];
                    dir.Numero = (string)datos.Lector["numero"];
                    dir.CodigoPostal = (string)datos.Lector["codigoPostal"];
                    dir.Localidad = (string)datos.Lector["localidad"];
                    dir.Provincia = (string)datos.Lector["provincia"];
                    if (!(datos.Lector["observacion_dir"] is DBNull))
                        dir.Observacion = (string)datos.Lector["observacion_dir"];
                }
                return dir;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }


}
