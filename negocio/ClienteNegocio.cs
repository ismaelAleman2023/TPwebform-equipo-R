using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using dominio;
namespace negocio
{
	public class ClienteNegocio
	{

        public void AgregarCliente(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.consultaSql("insert into personas(nombre_per,apellido_per,email_per,telefono_per,contrasenia_per,fecha_nacimiento_per,estado_per,idroll_per) values(@nombre,@apellido,@email,@telefono,@pass,@fechaNacimiento,@estado,@roll)");
                datos.setearParametros("@nombre", cliente.Nombre);
                datos.setearParametros("@apellido", cliente.Apellido);
                datos.setearParametros("@email", cliente.Email);
                datos.setearParametros("@telefono", cliente.Telefono);
                datos.setearParametros("@pass", cliente.Password);
                datos.setearParametros("@fechaNacimiento", cliente.FechaDeNacimiento);
                datos.setearParametros("@estado", cliente.Estado);
                datos.setearParametros("@roll", cliente.IdRol);

                datos.ejecutarAccion();
                datos.cerrarConexion();

                datos.consultaSql("select max(idPersona) from personas");
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    cliente.IdPersona = (int)datos.Lector[0];
                }

                datos.cerrarConexion();

                datos.consultaSql("insert into clientes(idpersona_cli,correoOk) values(@idPersona,@correoOk)");
                datos.setearParametros("@idPersona", cliente.IdPersona);
                datos.setearParametros("@correoOk", cliente.CorreoOk);
                datos.ejecutarAccion();

                if (cliente.direccion.Count!=0 && cliente.direccion!=null)
                {
                    DireccionNegocio dirN = new DireccionNegocio();

                    foreach (Direccion dire in cliente.direccion)
                    {
                        dirN.agregarDireccion(dire);
                    }
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

        }



        public List<Cliente> listarClientes(int estado )
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                DireccionNegocio dirN = new DireccionNegocio();
                List<Direccion> listaDire = dirN.listarDirecciones();
              
                string consulta = "select c.imgPerfil,p.idPersona, p.nombre_per, p.apellido_per, p.email_per, p.telefono_per, p.contrasenia_per, p.fecha_nacimiento_per, p.estado_per, p.idroll_per, c.correoOk from personas p inner join clientes c on p.idPersona = c.idPersona_cli";

                if (estado == 0 || estado == 1)
                {
                    consulta += " where p.estado_per = @estado";
                    datos.setearParametros("estado", estado);
                }



                datos.consultaSql(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.IdPersona = (int)datos.Lector["idPersona"];
                    aux.Nombre = (string)datos.Lector["nombre_per"];
                    aux.Apellido = (string)datos.Lector["apellido_per"];
                    aux.Email = (string)datos.Lector["email_per"];
                    aux.Telefono = (string)datos.Lector["telefono_per"];
                    aux.Password = (string)datos.Lector["contrasenia_per"];
                    aux.FechaDeNacimiento = (DateTime)datos.Lector["fecha_nacimiento_per"];
                    aux.Estado = (int)datos.Lector["estado_per"];
                    aux.IdRol = (int)datos.Lector["idroll_per"];
                    if (!(datos.Lector["imgPerfil"] is DBNull))
                    {

                    aux.FotoPerfil = (string)datos.Lector["imgPerfil"];

                    }
                    aux.CorreoOk = (bool)datos.Lector["correoOk"];

                    foreach (Direccion dire in listaDire)
                    {
                        if(dire.IdCliente== aux.IdPersona)
                        {
                            aux.direccion.Add(dire);
                        }
                    }
                                                   
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



        public void eliminarCliente(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("update personas set estado_Per = 0 where idPersona = @id");
                datos.setearParametros("id", id);
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

        public void ReactivarCliente(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("update personas set estado_Per = 1 where idPersona = @id");
                datos.setearParametros("id", id);
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





        public void modificarCliente(Cliente cli, int id) 
        {
            AccesoDatos datos =new AccesoDatos();

            try
            {
                datos.consultaSql("update personas set  nombre_per = @nombre, apellido_per = @apellido, email_per = @correo, telefono_per = @telefono, contrasenia_per = @pass, fecha_nacimiento_per = @fecha where idPersona = @id");
                datos.setearParametros("@nombre", cli.Nombre);
                datos.setearParametros("@apellido", cli.Apellido);
                datos.setearParametros("@correo", cli.Email);
                datos.setearParametros("@telefono", cli.Telefono);
                datos.setearParametros("@pass", cli.Password);
                datos.setearParametros("@fecha", cli.FechaDeNacimiento);
                datos.setearParametros("@id", id);
                

                datos.ejecutarAccion();

                datos.cerrarConexion();


                if( cli.Apellido != null && cli.direccion.Count>0 )
                {
                    foreach (Direccion item in cli.direccion)
                    {
                        Direccion dir = new Direccion();
                        //dir.ModificarDireccion( cli.IdPersona,item);

                    }

                }

            }
            catch (Exception)
            {

                throw;
            }

        }




        public Cliente buscarCliente(int id)
        {
            Cliente aux = new Cliente();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                DireccionNegocio dirN = new DireccionNegocio();
                List<Direccion> listaDire = dirN.listarDirecciones();
                datos.consultaSql("select p.idPersona, p.nombre_per, p.apellido_per, p.email_per, p.telefono_per, p.contrasenia_per, p.fecha_nacimiento_per, p.estado_per, p.idroll_per,c.imgPerfil,c.correoOk from personas p inner join clientes c on p.idPersona = c.idPersona_cli where p.idPersona = @id");
                datos.setearParametros("@id", id);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    aux.IdPersona = (int)datos.Lector["idPersona"];
                    aux.Nombre = (string)datos.Lector["nombre_per"];
                    aux.Apellido = (string)datos.Lector["apellido_per"];
                    aux.Email = (string)datos.Lector["email_per"];
                    aux.Telefono = (string)datos.Lector["telefono_per"];
                    aux.Password = (string)datos.Lector["contrasenia_per"];
                    aux.FechaDeNacimiento = (DateTime)datos.Lector["fecha_nacimiento_per"];
                    aux.Estado = (int)datos.Lector["estado_per"];
                    aux.IdRol = (int)datos.Lector["idroll_per"];
                    aux.CorreoOk = (bool)datos.Lector["correoOk"];

                    if (!(datos.Lector["imgPerfil"] is DBNull))
                    {
                    aux.FotoPerfil = (string)datos.Lector["imgPerfil"];
                    }

                   
                    foreach (Direccion dire in listaDire)
                    {
                        if (dire.IdCliente == aux.IdPersona)
                        {
                            aux.direccion.Add(dire);
                        }
                    }
                }
                return aux;
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


        public bool validarInicio(string correo, string pass, ref int idPersona, ref int rol)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("select idPersona,idroll_per from Personas where email_per = @correo and contrasenia_per = @pass");
                datos.setearParametros("@correo", correo);
                datos.setearParametros("@pass", pass);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    idPersona = (int)datos.Lector["idPersona"];
                    rol = (int)datos.Lector["idroll_per"];
                    return true;
                }

                return false;

            }
            catch (Exception)
            {

                throw;
            }
            finally {
                datos.cerrarConexion();
            }

        }

        public void modificarFtPerfil(Cliente cli) {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("update Clientes set imgPerfil=@imgPerfil where idPersona_cli=@idpersona ");
                datos.setearParametros("@imgPerfil", cli.FotoPerfil);
                datos.setearParametros("idpersona",cli.IdPersona);
                datos.ejecutarAccion();


            }
            catch (Exception)
            {

                throw;
            }
            finally {

                datos.cerrarConexion();
            }
        
        
        }









    }
}
