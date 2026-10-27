using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel.Design;

namespace negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }


        public AccesoDatos() {

            conexion = new SqlConnection("server= .\\SQLEXPRESS; database=ecommerceDB; integrated security = true");
            comando = new SqlCommand();

        }

        public void setearParametros(string nombre, object valor) {

            try
            {
                comando.Parameters.AddWithValue(nombre, valor);

            }
            catch (ArgumentException)
            {

                throw;
            }
           
        }


        public void consultaSql(string consulta ) {


            try
            {
            comando.CommandType=System.Data.CommandType.Text;
            comando.CommandText=consulta;

            }
            catch (InvalidOperationException)
            {

                throw;
            }
        
        }

        public void  ejecutarLectura() {
           comando.Connection = conexion;

            try
            {
                conexion.Open();
                lector= comando.ExecuteReader();



            }
            catch (SqlException )
            {

                throw;
            }
            catch(InvalidOperationException ) {

                throw;
            }
        
        
        }


        public void ejecutarAccion() { 
        comando.Connection=conexion;

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();

            }
            catch (SqlException)
            {

                throw;
            }
            catch (InvalidOperationException) {

                throw;
            
            }
        
        
        
        }



        public void cerrarConexion() {

            try
            {
                if (lector != null && !lector.IsClosed)
                {

                    conexion.Close();

                }
                if (conexion !=null && conexion.State == System.Data.ConnectionState.Open) { 
                
                conexion.Close();
                }

            }
            catch (SqlException)
            {

                throw ;
            }
            catch (InvalidOperationException){

                throw;
            }
           
        }



    }
}
