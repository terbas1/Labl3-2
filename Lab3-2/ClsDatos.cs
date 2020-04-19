using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Lab3_2.Models;

namespace Lab3_2
{
    public class ClsDatos
    {
        public SqlConnection LeerCadena()
        {
            SqlConnection connection =
                new SqlConnection("Data Source= sql5047.site4now.net;" +
                 "Initial Catalog=DB_A5A764_terbas1; User ID=DB_A5A764_terbas1_admin; Password=daniel261516;");
            return connection;
        }

        public List<Pedido> ListarPedidoFecha()
        {

            SqlConnection connection = LeerCadena();
            connection.Open();

            List<Pedido> pedidos = new List<Pedido>();
            Pedido pedido;
            SqlDataReader reader;

            try
            {
                SqlCommand cmd = new SqlCommand("USP_ListarPedidosAnio");
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    pedido = new Pedido();
                    pedido.Anio = (string)(reader[0]);
                    pedidos.Add(pedido);
                }

            }
            catch (Exception ex)
            {

                System.Console.Write(ex.Message);
            }

            connection.Close();
            return pedidos;

        }

        public List<Pedido> ListarPedidoFecha(string x)
        {

            SqlConnection connection = LeerCadena();
            connection.Open();

            List<Pedido> pedidos = new List<Pedido>();
            Pedido pedido;
            SqlDataReader reader;

            try
            {
                SqlCommand cmd = new SqlCommand("USP_ListarPedidosMes");
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Anio", x);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    pedido = new Pedido();
                    pedido.Mes = (string)(reader[0]);
                    pedidos.Add(pedido);
                }

            }
            catch (Exception ex)
            {

                System.Console.Write(ex.Message);
            }

            connection.Close();
            return pedidos;

        }

        public List<Empleado> ListarEmpleados(string mm, string yyyy)
        {
            SqlConnection connection = LeerCadena();
            connection.Open();
            List<Empleado> empleados = new List<Empleado>();
            Empleado empleado;
            SqlDataReader reader;

            try
            {
                SqlCommand cmd = new SqlCommand("USP_ListarEmpleados");
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Mes", mm);
                cmd.Parameters.AddWithValue("@Anio", yyyy);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    empleado = new Empleado();
                    empleado.IdEmpleado = (int)(reader[0]);
                    empleado.Apellidos = (string)(reader[1]);
                    empleado.Nombre = (string)(reader[2]);
                    empleado.Cargo = (string)(reader[3]);

                    empleados.Add(empleado);

                }

            }
            catch (Exception ex)
            {
                System.Console.Write(ex.Message);
            }

            connection.Close();
            return empleados;

        }
    }
}
