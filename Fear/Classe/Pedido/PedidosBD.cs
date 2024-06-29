using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fear
{
    class PedidosBD
    {
        // Método de inclusão de um pedido na tabela TB_Pedido
        public int Incluir(Pedidos pobj_Pedido)
        {
            string s_varSql = "";
            int i_Cod = pobj_Pedido.Cod_Pedido;

            // Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " INSERT INTO TB_Pedido " +
                       " ( " +
                       " I_COD_CLIENTE, " +
                       " DT_DATA_PEDIDO, " +
                       " D_TOTAL_PEDIDO " +
                       " ) " +
                       " VALUES " +
                       " ( " +
                       " @I_COD_CLIENTE, " +
                       " @DT_DATA_PEDIDO, " +
                       " @D_TOTAL_PEDIDO " +
                       " ); " +
                       " SELECT IDENT_CURRENT ('TB_Pedido') AS 'COD' ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@I_COD_CLIENTE", pobj_Pedido.Cod_Cliente);
            obj_Cmd.Parameters.AddWithValue("@DT_DATA_PEDIDO", pobj_Pedido.Dt_Data_Pedido);
            obj_Cmd.Parameters.AddWithValue("@D_TOTAL_PEDIDO", pobj_Pedido.Total_Pedido);

            try
            {
                obj_Conn.Open();
                i_Cod = Convert.ToInt32(obj_Cmd.ExecuteScalar());
                obj_Conn.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return i_Cod;
        }

        // Método de alteração de um pedido na tabela TB_Pedido
        public bool Alterar(Pedidos pobj_Pedido)
        {
            string s_varSql = "";
            bool b_valida = false;

            // Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " UPDATE TB_Pedido SET " +
                       " I_COD_CLIENTE = @I_COD_CLIENTE, " +
                       " DT_DATA_PEDIDO = @DT_DATA_PEDIDO, " +
                       " D_TOTAL_PEDIDO = @D_TOTAL_PEDIDO " +
                       " WHERE I_COD_Pedido = @I_COD_Pedido ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);

            obj_Cmd.Parameters.AddWithValue("@I_COD_Pedido", pobj_Pedido.Cod_Pedido);
            obj_Cmd.Parameters.AddWithValue("@I_COD_CLIENTE", pobj_Pedido.Cod_Cliente);
            obj_Cmd.Parameters.AddWithValue("@DT_DATA_PEDIDO", pobj_Pedido.Dt_Data_Pedido);
            obj_Cmd.Parameters.AddWithValue("@D_TOTAL_PEDIDO", pobj_Pedido.Total_Pedido);

            try
            {
                obj_Conn.Open();
                obj_Cmd.ExecuteNonQuery();
                obj_Conn.Close();
                b_valida = true;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return b_valida;
        }

        // Método de exclusão de um pedido na tabela TB_Pedido
        public bool Excluir(Pedidos pobj_Pedido)
        {
            string s_varSql = "";
            bool b_valida = false;

            // Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " DELETE FROM TB_Pedido " +
                       " WHERE I_COD_Pedido = @I_COD_Pedido ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@I_COD_Pedido", pobj_Pedido.Cod_Pedido);

            try
            {
                obj_Conn.Open();
                obj_Cmd.ExecuteNonQuery();
                obj_Conn.Close();
                b_valida = true;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return b_valida;
        }

        // Método para encontrar um pedido por código na tabela TB_Pedido
        public Pedidos FindByCod(Pedidos pobj_Pedido)
        {
            string s_varSql = "";

            // Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " SELECT * FROM TB_Pedido " +
                       " WHERE I_COD_Pedido = @I_COD_Pedido ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@I_COD_Pedido", pobj_Pedido.Cod_Pedido);

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();
                    pobj_Pedido.Cod_Cliente = Convert.ToInt32(obj_Dtr["I_COD_CLIENTE"]);
                    pobj_Pedido.Dt_Data_Pedido = Convert.ToDateTime(obj_Dtr["DT_DATA_PEDIDO"]);
                    pobj_Pedido.Total_Pedido = Convert.ToDecimal(obj_Dtr["D_TOTAL_PEDIDO"]);
                }
                else
                {
                    pobj_Pedido = new Pedidos();
                }

                obj_Conn.Close();
                obj_Dtr.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return pobj_Pedido;
        }

        // Método para encontrar todos os pedidos na tabela TB_Pedido
        public List<Pedidos> FindAll()
        {
            string s_varSql = "";

            // Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " SELECT * FROM TB_Pedido ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);

            List<Pedidos> Lista = new List<Pedidos>();

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    while (obj_Dtr.Read())
                    {
                        Pedidos obj_Pedido = new Pedidos();
                        obj_Pedido.Cod_Pedido = Convert.ToInt32(obj_Dtr["I_COD_Pedido"]);
                        obj_Pedido.Cod_Cliente = Convert.ToInt32(obj_Dtr["I_COD_CLIENTE"]);
                        obj_Pedido.Dt_Data_Pedido = Convert.ToDateTime(obj_Dtr["DT_DATA_PEDIDO"]);
                        obj_Pedido.Total_Pedido = Convert.ToDecimal(obj_Dtr["D_TOTAL_PEDIDO"]);

                        Lista.Add(obj_Pedido);
                    }
                }

                obj_Conn.Close();
                obj_Dtr.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Lista;
        }
    }
}