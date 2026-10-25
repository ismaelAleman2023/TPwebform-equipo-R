using System;
using System.Collections.Generic;
using System.Linq;
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
                datos.consultaSql("insert into personas(nombre_per,apellido_per,email_per,telefono_per,contraseña_per,fecha_nacimiento_per,estado_per,idroll_per) values(@nombre,@apellido,@email,@telefono,@pass,@fechaNacimiento,@estado,@roll)");
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



        public List<Cliente> listarClientes()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.consultaSql("select p.id,p.nombre_per,p.apellido_per,p.email_per,p.telefono_per,p.contraseña_per,p.fecha_nacimiento_per,p.estado_per,p.idroll_per,c.correoOk from personas p inner join clientes c on p.id=c.id_persona");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.IdPersona = (int)datos.Lector["id"];
                    aux.Nombre = (string)datos.Lector["nombre_per"];
                    aux.Apellido = (string)datos.Lector["apellido_per"];
                    aux.Email = (string)datos.Lector["email_per"];
                    aux.Telefono = (string)datos.Lector["telefono_per"];
                    aux.Password = (string)datos.Lector["contraseña_per"];
                    aux.FechaDeNacimiento = (DateTime)datos.Lector["fecha_nacimiento_per"];
                    aux.Estado = (int)datos.Lector["estado_per"];
                    aux.IdRol = (int)datos.Lector["idroll_per"];
                    aux.CorreoOk = (bool)datos.Lector["correoOk"];
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




    }
}
