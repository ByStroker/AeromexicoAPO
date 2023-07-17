using AeromexicoAPO.Conexion;
using AeromexicoAPO.Models;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace AeromexicoAPO.Services
{
    public class VueloService : IVueloService
    {
        private readonly ConexionDB _conexionDB;
        public VueloService(IOptions<ConexionDB> conexionDB)
        {
            _conexionDB = conexionDB.Value;
        }

        public List<vuelo> GetVuelos(string inicio,string fin)
        {
            string query;
            SqlCommand comando;
            DataTable getVuelos = new DataTable();
            query = $"select * from vuelos where fecha_salida between'{inicio}' AND  '{fin}'";
            try
            {
                using (SqlConnection con = new SqlConnection(_conexionDB.conexionDb))
                {
                    comando = new SqlCommand(query, con);
                    comando.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    adapter.Fill(getVuelos);
                    con.Close();
                }
                List<vuelo> vuelos = new List<vuelo>();
                foreach (DataRow item in getVuelos.Rows)
                {
                    vuelo vuelo = new vuelo();
                    vuelo.id = Convert.ToInt32(item["id"]);
                    vuelo.numero_vuelo = item["numero_vuelo"].ToString();
                    vuelo.origen = item["origen"].ToString();
                    vuelo.destino = item["destino"].ToString();
                    vuelo.fecha_salida = Convert.ToDateTime(item["fecha_salida"]);
                    vuelos.Add(vuelo);
                }
                return vuelos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<vuelo> PostVuelo()
        {
            throw new NotImplementedException();
        }
    }
}
