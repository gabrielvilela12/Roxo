using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fear
{
    class ItensBD
    {
        // Método para incluir um item na tabela TB_ITEM
        public int Incluir(Itens pobj_Item)
        {
            string s_varSql = "";
            int i_Cod = pobj_Item.Cod_Itens;

            // Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " INSERT INTO TB_ITEM " +
                       " ( " +
                       " I_COD_PEDIDO, " +
                       " I_COD_PRODUTO, " +
                       " I_QTDE_ITENS, " +
                       " D_VALRUNIT_ITENS " +
                       " ) " +
                       " VALUES " +
                       " ( " +
                       " @I_COD_PEDIDO, " +
                       " @I_COD_PRODUTO, " +
                       " @I_QTDE_ITENS, " +
                       " @D_VALRUNIT_ITENS " +
                       " ); " +
                       " SELECT IDENT_CURRENT ('TB_ITEM') AS 'COD' ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@I_COD_PEDIDO", pobj_Item.Cod_Pedido);
            obj_Cmd.Parameters.AddWithValue("@I_COD_PRODUTO", pobj_Item.Cod_Produto);
            obj_Cmd.Parameters.AddWithValue("@I_QTDE_ITENS", pobj_Item.Qtde_Itens);
            obj_Cmd.Parameters.AddWithValue("@D_VALRUNIT_ITENS", pobj_Item.ValrUnit_Itens);

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



       
        }
    }