
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fear
{
    class CategoriaBD
    {
        //Destruidor da Classe
        ~CategoriaBD()
        {
        }


        public int Incluir(Categoria pobj_Categoria)
        {
            string s_varSql = "";
            int i_Cod = pobj_Categoria.Cod_Categoria;

            //Conexão

            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " INSERT INTO TB_CATEGORIA " +
                       " ( " +
                       " S_NM_CATEGORIA " +
                       " ) " +
                       " VALUES " +
                       " ( " +
                       " @S_NM_CATEGORIA " +
                       " ); " +
                       " SELECT IDENT_CURRENT ('TB_CATEGORIA') AS 'COD' ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@S_NM_CATEGORIA", pobj_Categoria.Nm_Categoria);

            try
            {
                obj_Conn.Open();
                i_Cod = Convert.ToInt16(obj_Cmd.ExecuteScalar());
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

       