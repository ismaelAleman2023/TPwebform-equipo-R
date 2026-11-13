using dominio;
using System;
using System.Collections.Generic;

namespace negocio
{
    public class RolNegocio
    {
        public List<Rol> ListarRol(int estado =2)
        {
            List<Rol> lista = new List<Rol>();
            AccesoDatos datos = new AccesoDatos();
            try
            {

                string consulta = "select idRoll, descripcion_rol, estado_rol from roles";


                if (estado == 0 || estado == 1)
                {
                    consulta += " where estado_rol = @estado";
                    datos.setearParametros("@estado", estado);
                }
                
                datos.consultaSql(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Rol aux = new Rol();
                    aux.IdRol = (int)datos.Lector["idRoll"];
                    aux.Descripcion = (string)datos.Lector["descripcion_rol"];
                    aux.Estado = (int)datos.Lector["estado_rol"];
                    lista.Add(aux);
                }
                return lista;
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

        public void AgregarRol(Rol nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("insert into roles(descripcion_rol, estado_rol) values (@descripcion, @estado)");
                datos.setearParametros("@descripcion", nuevo.Descripcion);
                datos.setearParametros("@estado", nuevo.Estado);
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

        public bool ExisteDescripcion(string descrip)
        {
            foreach (Rol r in ListarRol())
            {
                if (r.Descripcion.Equals(descrip, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ExisteOtraDescripcion(string descrip, int id)
        {
            foreach (Rol r in ListarRol())
            {
                if (r.IdRol != id && r.Descripcion.Equals(descrip, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public void BajaRol(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("update roles set estado_rol = 0 where idRoll = @id");
                datos.setearParametros("@id", id);
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

        public void AltaRol(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("update roles set estado_rol = 1 where idRoll = @id");
                datos.setearParametros("@id", id);
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

        public Rol buscarRol(int id)
        {
            Rol rol = new Rol();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("select idRoll, descripcion_rol, estado_rol from roles where idRoll = @id");
                datos.setearParametros("@id", id);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    rol.IdRol = (int)datos.Lector["idRoll"];
                    rol.Descripcion = (string)datos.Lector["descripcion_rol"];
                    rol.Estado = (int)datos.Lector["estado_rol"];
                }
                return rol;
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

        public void modificarRol(Rol rol)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("update roles set descripcion_rol = @descripcion where idRoll = @id");
                datos.setearParametros("@descripcion", rol.Descripcion);
                datos.setearParametros("@id", rol.IdRol);
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
    }
}
