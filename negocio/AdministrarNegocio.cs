using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class AdministrarNegocio
    {

        public void agregarAdministrador(Administrador admin)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("insert into personas(nombre_per,apellido_per,email_per,telefono_per,contrasenia_per,fecha_nacimiento_per,estado_per,idroll_per) values(@nombre,@apellido,@email,@telefono,@pass,@fechaNacimiento,@estado,@roll)");
                datos.setearParametros("@nombre", admin.Nombre);
                datos.setearParametros("@apellido", admin.Apellido);
                datos.setearParametros("@email", admin.Email);
                datos.setearParametros("@telefono", admin.Telefono);
                datos.setearParametros("@pass", admin.Password);
                datos.setearParametros("@fechaNacimiento", admin.FechaDeNacimiento);
                datos.setearParametros("@estado", admin.Estado);
                datos.setearParametros("@roll", admin.IdRol);
                
                datos.ejecutarAccion();
                datos.cerrarConexion();
                
                datos.consultaSql("select max(idPersona) from personas");
                datos.ejecutarLectura();
                
                if (datos.Lector.Read())
                {
                    admin.IdPersona = (int)datos.Lector[0];
                }
                datos.cerrarConexion();
                datos.consultaSql("insert into administradores(idpersona_admin,cuil_admin) values(@idPersona,@cuil)");
                datos.setearParametros("@idPersona", admin.IdPersona);
                datos.setearParametros("@cuil", admin.Cuil);
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

        public List<Administrador> listarAdministradores()
        {
            List<Administrador> lista = new List<Administrador>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("select p.idPersona, p.nombre_per, p.apellido_per, p.email_per, p.telefono_per, p.contrasenia_per, p.fecha_nacimiento_per, p.estado_per, a.cuil_admin from personas p inner join administradores a on p.idPersona = a.idpersona_admin");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Administrador aux = new Administrador();
                    aux.IdPersona = (int)datos.Lector["idPersona"];
                    aux.Nombre = (string)datos.Lector["nombre_per"];
                    aux.Apellido = (string)datos.Lector["apellido_per"];
                    aux.Email = (string)datos.Lector["email_per"];
                    aux.Telefono = (string)datos.Lector["telefono_per"];
                    aux.Password = (string)datos.Lector["contrasenia_per"];
                    aux.FechaDeNacimiento = (DateTime)datos.Lector["fecha_nacimiento_per"];
                    aux.Estado = (int)datos.Lector["estado_per"];
                    aux.Cuil = datos.Lector["cuil_admin"].ToString();
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

        public Administrador buscarAdministrador(int idPersona)
        {
            Administrador admin = new Administrador();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("select p.idPersona, p.nombre_per, p.apellido_per, p.email_per, p.telefono_per, p.contrasenia_per, p.fecha_nacimiento_per, p.estado_per, a.cuil_admin from personas p inner join administradores a on p.idPersona = a.idpersona_admin where p.idPersona = @idPersona");
                datos.setearParametros("@idPersona", idPersona);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    admin.IdPersona = (int)datos.Lector["idPersona"];
                    admin.Nombre = (string)datos.Lector["nombre_per"];
                    admin.Apellido = (string)datos.Lector["apellido_per"];
                    admin.Email = (string)datos.Lector["email_per"];
                    admin.Telefono = (string)datos.Lector["telefono_per"];
                    admin.Password = (string)datos.Lector["contrasenia_per"];
                    admin.FechaDeNacimiento = (DateTime)datos.Lector["fecha_nacimiento_per"];
                    admin.Estado = (int)datos.Lector["estado_per"];
                    admin.Cuil = datos.Lector["Cuil_admin"].ToString();
                }
                return admin;
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

        public void eliminarAdministrador(int idPersona)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("update Personas set estado_per = 0 where idpersona = @idPersona");
                datos.setearParametros("@idPersona", idPersona);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void reactivarAdministrador(int idPersona)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("update Personas set estado_per = 1 where idpersona = @idPersona");
                datos.setearParametros("@idPersona", idPersona);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }

        }


        public void modificarAdministrador(Administrador admin)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("update personas set nombre_per=@nombre, apellido_per=@apellido, email_per=@email, telefono_per=@telefono, contrasenia_per=@pass, fecha_nacimiento_per=@fechaNacimiento where idPersona=@idPersona");
                datos.setearParametros("@nombre", admin.Nombre);
                datos.setearParametros("@apellido", admin.Apellido);
                datos.setearParametros("@email", admin.Email);
                datos.setearParametros("@telefono", admin.Telefono);
                datos.setearParametros("@pass", admin.Password);
                datos.setearParametros("@fechaNacimiento", admin.FechaDeNacimiento);
                datos.setearParametros("@idPersona", admin.IdPersona);

                datos.ejecutarAccion();
                datos.cerrarConexion();

                datos.consultaSql("update administradores set cuil_admin=@cuil where idpersona_admin=@idPersona");
                datos.setearParametros("@cuil", admin.Cuil);
                datos.setearParametros("@idPersona", admin.IdPersona);
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
