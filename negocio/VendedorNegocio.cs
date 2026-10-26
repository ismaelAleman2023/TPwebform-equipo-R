using dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace negocio
{
    public class VendedorNegocio
    {
        public VendedorNegocio() { }

        public void agregarVendedor(Vendedor vendedorN) {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.consultaSql("insert into personas(nombre_per,apellido_per,email_per,telefono_per,contraseña_per,fecha_nacimiento_per,estado_per,idroll_per) values(@nombre,@apellido,@email,@telefono,@pass,@fechaNacimiento,@estado,@roll)");
                datos.setearParametros("@nombre", vendedorN.Nombre);
                datos.setearParametros("@apellido", vendedorN.Apellido);
                datos.setearParametros("@email", vendedorN.Email);
                datos.setearParametros("@telefono", vendedorN.Telefono);
                datos.setearParametros("@pass", vendedorN.Password);
                datos.setearParametros("@fechaNacimiento", vendedorN.FechaDeNacimiento);
                datos.setearParametros("@estado", vendedorN.Estado);
                datos.setearParametros("@roll", vendedorN.IdRol);

                datos.ejecutarAccion();
                datos.cerrarConexion();

                datos.consultaSql("select max(idPersona) from personas");
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    vendedorN.IdPersona = (int)datos.Lector[0];
                }

                datos.cerrarConexion();

                datos.consultaSql("insert into vendedores(idpersona_v,legajo_V) values(@idPersona,@legajo)");
                datos.setearParametros("@idPersona", vendedorN.IdPersona);
                datos.setearParametros("@legajo", vendedorN.Legajo);
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


        public List<Vendedor> listarVendedores()
        {
            List<Vendedor> listVendedor = new List<Vendedor>();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.consultaSql("select p.idPersona, p.nombre_per, p.apellido_per, p.email_per, p.telefono_per, p.contraseña_per, p.fecha_nacimiento_per, p.estado_per, p.idroll_per, v.legajo_V from personas p inner join Vendedores v on p.idPersona = v.idPersona_V");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Vendedor aux = new Vendedor();
                    aux.IdPersona = (int)datos.Lector["idPersona"];
                    aux.Nombre = (string)datos.Lector["nombre_per"];
                    aux.Apellido = (string)datos.Lector["apellido_per"];
                    aux.Email = (string)datos.Lector["email_per"];
                    aux.Telefono = (string)datos.Lector["telefono_per"];
                    aux.Password = (string)datos.Lector["contraseña_per"];
                    aux.FechaDeNacimiento = (DateTime)datos.Lector["fecha_nacimiento_per"];
                    aux.Estado = (int)datos.Lector["estado_per"];
                    aux.IdRol = (int)datos.Lector["idroll_per"];
                    aux.Legajo = (string)datos.Lector["legajo_V"];
                    listVendedor.Add(aux);
                }
                return listVendedor;
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
