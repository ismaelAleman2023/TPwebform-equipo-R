using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class NovedadesNegocio
    {

        public void agregarNovedades(Novedades nove)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.consultaSql("insert into Novedades (TituloChicoDer1 ,TituloGrandeDer2, DescripcionDer3, BotonInfDer4, Card1Titulo, Card1Precio, card1Subtitulo,Card2Titulo, Card2Precio, Card2Subtitulo,Card3Titulo ,Card3Precio ,Card3Subtitulo ,DestacadoCard1, estadoNov) " +
                    "values (@TituloChicoDer1 ,@TituloGrandeDer2, @DescripcionDer3, @BotonInfDer4, @Card1Titulo,@Card1Precio, @card1Subtitulo,@Card2Titulo, @Card2Precio, @Card2Subtitulo,@Card3Titulo ,@Card3Precio ,@Card3Subtitulo, @DestacadoCard, @estadoNov)");

                datos.setearParametros("@TituloChicoDer1", nove.TituloChicoIzq1);
                datos.setearParametros("@TituloGrandeDer2", nove.TituloGrandeIzq2);
                datos.setearParametros("@DescripcionDer3", nove.DescripcionIzq3);
                datos.setearParametros("@BotonInfDer4", nove.BotonInfIzq4);
                datos.setearParametros("@Card1Titulo", nove.Card1Titulo);
                datos.setearParametros("@Card1Precio", nove.Card1Precio);
                datos.setearParametros("@card1Subtitulo", nove.card1Subtitulo);
                datos.setearParametros("@Card2Titulo", nove.Card2Titulo);
                datos.setearParametros("@Card2Precio", nove.Card2Precio);
                datos.setearParametros("@Card2Subtitulo", nove.Card2Subtitulo);
                datos.setearParametros("@Card3Titulo", nove.Card3Titulo);
                datos.setearParametros("@Card3Precio", nove.Card3Precio);
                datos.setearParametros("@Card3Subtitulo", nove.Card3Subtitulo);
                datos.setearParametros("@DestacadoCard", nove.DestacadoCard);
                datos.setearParametros("@estadoNov", nove.estadoNov? 1 :0);

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


        public Novedades BuscarNovedad(int idNovedad)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("select idNovedades, TituloChicoDer1 ,TituloGrandeDer2, DescripcionDer3, BotonInfDer4, Card1Titulo, Card1Precio, card1Subtitulo,Card2Titulo, Card2Precio,Card2Subtitulo,Card3Titulo ,Card3Precio ,Card3Subtitulo ,DestacadoCard1, estadoNov " +
                    "from Novedades where idNovedades = @idNovedad");

                datos.setearParametros("@idNovedad", idNovedad);
                Novedades nov = null;

                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    nov = new Novedades();
                    nov.idNovedad = (int)datos.Lector["idNovedades"];
                    nov.TituloChicoIzq1 = (string)datos.Lector["TituloChicoDer1"];
                    nov.TituloGrandeIzq2 = (string)datos.Lector["TituloGrandeDer2"];
                    nov.DescripcionIzq3 = (string)datos.Lector["DescripcionDer3"];
                    nov.BotonInfIzq4 = (string)datos.Lector["BotonInfDer4"];
                    nov.Card1Titulo = (string)datos.Lector["Card1Titulo"];
                    nov.Card1Precio = (string)datos.Lector["Card1Precio"];
                    nov.card1Subtitulo = (string)datos.Lector["card1Subtitulo"];
                    nov.Card2Titulo = (string)datos.Lector["Card2Titulo"];
                    nov.Card2Precio = (string)datos.Lector["Card2Precio"];
                    nov.Card2Subtitulo = (string)datos.Lector["Card2Subtitulo"];
                    nov.Card3Titulo = (string)datos.Lector["Card3Titulo"];
                    nov.Card3Precio = (string)datos.Lector["Card3Precio"];
                    nov.Card3Subtitulo = (string)datos.Lector["Card3Subtitulo"];
                    nov.DestacadoCard = (string)datos.Lector["DestacadoCard1"];
                    nov.estadoNov = (bool)datos.Lector["estadoNov"];

                }

                return nov;
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


        public List<Novedades> listarNovedades()
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("select idNovedades, TituloChicoDer1 ,TituloGrandeDer2, DescripcionDer3, BotonInfDer4, Card1Titulo, Card1Precio, card1Subtitulo,Card2Titulo, Card2Precio,Card2Subtitulo,Card3Titulo ,Card3Precio ,Card3Subtitulo ,DestacadoCard1, estadoNov " +
                    "from Novedades");
                List<Novedades> listNov = new List<Novedades>();

                Novedades nov;

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    nov = new Novedades();
                    nov.idNovedad = (int)datos.Lector["idNovedades"];
                    nov.TituloChicoIzq1 = (string)datos.Lector["TituloChicoDer1"];
                    nov.TituloGrandeIzq2 = (string)datos.Lector["TituloGrandeDer2"];
                    nov.DescripcionIzq3 = (string)datos.Lector["DescripcionDer3"];
                    nov.BotonInfIzq4 = (string)datos.Lector["BotonInfDer4"];
                    nov.Card1Titulo = (string)datos.Lector["Card1Titulo"];
                    nov.Card1Precio = (string)datos.Lector["Card1Precio"];
                    nov.card1Subtitulo = (string)datos.Lector["card1Subtitulo"];
                    nov.Card2Titulo = (string)datos.Lector["Card2Titulo"];
                    nov.Card2Precio = (string)datos.Lector["Card2Precio"];
                    nov.Card2Subtitulo = (string)datos.Lector["Card2Subtitulo"];
                    nov.Card3Titulo = (string)datos.Lector["Card3Titulo"];
                    nov.Card3Precio = (string)datos.Lector["Card3Precio"];
                    nov.Card3Subtitulo = (string)datos.Lector["Card3Subtitulo"];
                    nov.DestacadoCard = (string)datos.Lector["DestacadoCard1"];
                    nov.estadoNov = (bool)datos.Lector["estadoNov"];

                    listNov.Add(nov);
                }

                return listNov;
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


        public void eliminarNovedad(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("delete from Novedades where idNovedades = @idNovedades ");
                datos.ejecutarAccion();

            }
            catch (Exception)
            {
                datos.cerrarConexion();
                throw;
            }
        }


        public void bajaNovedad(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("update Novedades set(estadoNov = 0) where idNovedades = @idNov");
                datos.setearParametros("@idNov", id);
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


        public Novedades BuscarNovedadActiva()
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("select idNovedades, TituloChicoDer1 ,TituloGrandeDer2, DescripcionDer3, BotonInfDer4, Card1Titulo, Card1Precio, card1Subtitulo,Card2Titulo, Card2Precio,Card2Subtitulo,Card3Titulo ,Card3Precio ,Card3Subtitulo ,DestacadoCard1, estadoNov " +
                    "from Novedades where estadoNov = 1");

                
                Novedades nov = null;

                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    nov = new Novedades();
                    nov.idNovedad = (int)datos.Lector["idNovedades"];
                    nov.TituloChicoIzq1 = (string)datos.Lector["TituloChicoDer1"];
                    nov.TituloGrandeIzq2 = (string)datos.Lector["TituloGrandeDer2"];
                    nov.DescripcionIzq3 = (string)datos.Lector["DescripcionDer3"];
                    nov.BotonInfIzq4 = (string)datos.Lector["BotonInfDer4"];
                    nov.Card1Titulo = (string)datos.Lector["Card1Titulo"];
                    nov.Card1Precio = (string)datos.Lector["Card1Precio"];
                    nov.card1Subtitulo = (string)datos.Lector["card1Subtitulo"];
                    nov.Card2Titulo = (string)datos.Lector["Card2Titulo"];
                    nov.Card2Precio = (string)datos.Lector["Card2Precio"];
                    nov.Card2Subtitulo = (string)datos.Lector["Card2Subtitulo"];
                    nov.Card3Titulo = (string)datos.Lector["Card3Titulo"];
                    nov.Card3Precio = (string)datos.Lector["Card3Precio"];
                    nov.Card3Subtitulo = (string)datos.Lector["Card3Subtitulo"];
                    nov.DestacadoCard = (string)datos.Lector["DestacadoCard1"];
                    nov.estadoNov = (bool)datos.Lector["estadoNov"];

                }

                return nov;
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

        public void modificarNovedades(Novedades nove)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.consultaSql("update Novedades set TituloChicoDer1 = @TituloChicoDer1, TituloGrandeDer2 = @TituloGrandeDer2, DescripcionDer3 = @DescripcionDer3, " +
                    "BotonInfDer4 = @BotonInfDer4,Card1Titulo = @Card1Titulo, Card1Precio = @Card1Precio, card1Subtitulo = @card1Subtitulo, Card2Titulo = @Card2Titulo, " +
                    "Card2Precio = @Card2Precio, Card2Subtitulo = @Card2Subtitulo, Card3Titulo = @Card3Titulo, Card3Precio = @Card3Precio, Card3Subtitulo = @Card3Subtitulo, " +
                    "DestacadoCard1 = @DestacadoCard, estadoNov = @estadoNov where idNovedades = @idNovedades" );

                datos.setearParametros("@TituloChicoDer1", nove.TituloChicoIzq1);
                datos.setearParametros("@TituloGrandeDer2", nove.TituloGrandeIzq2);
                datos.setearParametros("@DescripcionDer3", nove.DescripcionIzq3); 
                datos.setearParametros("@BotonInfDer4", nove.BotonInfIzq4);
                datos.setearParametros("@Card1Titulo", nove.Card1Titulo);
                datos.setearParametros("@Card1Precio", nove.Card1Precio);
                datos.setearParametros("@card1Subtitulo", nove.card1Subtitulo);
                datos.setearParametros("@Card2Titulo", nove.Card2Titulo);
                datos.setearParametros("@Card2Precio", nove.Card2Precio);
                datos.setearParametros("@Card2Subtitulo", nove.Card2Subtitulo);
                datos.setearParametros("@Card3Titulo", nove.Card3Titulo);
                datos.setearParametros("@Card3Precio", nove.Card3Precio);
                datos.setearParametros("@Card3Subtitulo", nove.Card3Subtitulo);
                datos.setearParametros("@DestacadoCard", nove.DestacadoCard);
                datos.setearParametros("@estadoNov", nove.estadoNov ? 1 : 0);
                datos.setearParametros("@idNovedades", nove.idNovedad);

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
