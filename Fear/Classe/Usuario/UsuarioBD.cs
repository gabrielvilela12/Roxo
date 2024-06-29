
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
    class UsuarioBD
    {
        //Destruidor da Classe
        ~UsuarioBD()
        {
        }

        /**********************************************************************
        *  Nome: Incluir
        *  Descrição: Responsável por incluir a TUPLA do Objeto Usuario na
        *             Tabela TB_USUARIO
        *  Parametro: Usuario (Objeto da Classe)
        *  Retorna: Código da TUPLA incluída.
        *  Dt. Criação:
        *  DT. Alteração:
        *  Obs. Alteração: -------------------
        *  Criada por: mFacine
        *  Observação: Este método utiliza a classe auxiliar de conexão.
        ***********************************************************************/
        public int Incluir(Usuario pobj_Usuario)
        {
            string s_varSql = "";
            int i_Cod = pobj_Usuario.Cod_Usuario;

            //Conexão

            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " INSERT INTO TB_USUARIO " +
                       " ( " +
                       " S_NM_USUARIO, " +
                       " S_UNM_USUARIO, " +
                       " S_PW_USUARIO " +
                       " ) " +
                       " VALUES " +
                       " ( " +
                       " @S_NM_USUARIO, " +
                       " @S_UNM_USUARIO, " +
                       " @S_PW_USUARIO " +
                       " ); " +
                       " SELECT IDENT_CURRENT ('TB_USUARIO') AS 'COD' ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@S_NM_USUARIO", pobj_Usuario.Nm_Usuario);
            obj_Cmd.Parameters.AddWithValue("@S_UNM_USUARIO", pobj_Usuario.UNm_Usuario);
            obj_Cmd.Parameters.AddWithValue("@S_PW_USUARIO", pobj_Usuario.PW_Usuario);

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

       
        public bool Alterar(Usuario pobj_Usuario)
        {
            string s_varSql = "";
            bool b_valida = false;

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " UPDATE TB_USUARIO SET " +
                       " S_NM_USUARIO = @S_NM_USUARIO, " +
                       " S_UNM_USUARIO = @S_UNM_USUARIO, " +
                       " S_PW_USUARIO = @S_PW_USUARIO " +
                       " WHERE I_COD_USUARIO = @I_COD_USUARIO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            
            obj_Cmd.Parameters.AddWithValue("@I_COD_USUARIO", pobj_Usuario.Cod_Usuario);
            obj_Cmd.Parameters.AddWithValue("@S_NM_USUARIO", pobj_Usuario.Nm_Usuario);
            obj_Cmd.Parameters.AddWithValue("@S_UNM_USUARIO", pobj_Usuario.UNm_Usuario);
            obj_Cmd.Parameters.AddWithValue("@S_PW_USUARIO", pobj_Usuario.PW_Usuario);

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


   
        public bool Excluir(Usuario pobj_Usuario)
        {
            string s_varSql = "";
            bool b_valida = false;

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " DELETE FROM TB_USUARIO " +
                       " WHERE I_COD_USUARIO = @I_COD_USUARIO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@I_COD_USUARIO", pobj_Usuario.Cod_Usuario);

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

     
        public Usuario FindByCod(Usuario pobj_Usuario)
        {
            string s_varSql = "";

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " SELECT * FROM TB_USUARIO " +
                       " WHERE I_COD_USUARIO = @I_COD_USUARIO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@I_COD_USUARIO", pobj_Usuario.Cod_Usuario);

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();
                    pobj_Usuario.Nm_Usuario = obj_Dtr["S_NM_USUARIO"].ToString();
                    pobj_Usuario.UNm_Usuario = obj_Dtr["S_UNM_USUARIO"].ToString();
                    pobj_Usuario.PW_Usuario = obj_Dtr["S_PW_USUARIO"].ToString();
                }
                else
                {
                    pobj_Usuario = new Usuario();
                }

                obj_Conn.Close();
                obj_Dtr.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return pobj_Usuario;
        }

      
        public Usuario FindByUNm(Usuario pobj_Usuario)
        {
            string s_varSql = "";

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " SELECT * FROM TB_USUARIO " +
                       " WHERE S_UNM_USUARIO = @S_UNM_USUARIO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@S_UNM_USUARIO", pobj_Usuario.UNm_Usuario);

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();
                    pobj_Usuario.Cod_Usuario = Convert.ToInt16(obj_Dtr["I_COD_USUARIO"].ToString());
                    pobj_Usuario.Nm_Usuario = obj_Dtr["S_NM_USUARIO"].ToString();
                    pobj_Usuario.UNm_Usuario = obj_Dtr["S_UNM_USUARIO"].ToString();
                    pobj_Usuario.PW_Usuario = obj_Dtr["S_PW_USUARIO"].ToString();
                }
                else
                {
                    pobj_Usuario = new Usuario();
                }

                obj_Conn.Close();
                obj_Dtr.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return pobj_Usuario;
        }

      
        public List<Usuario> FindAll()
        {
            string s_varSql = "";

            //Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " SELECT * FROM TB_USUARIO ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);

            List<Usuario> Lista = new List<Usuario>();

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {

                    while (obj_Dtr.Read())
                    {
                        Usuario obj_Usuario = new Usuario();
                        obj_Usuario.Cod_Usuario = Convert.ToInt16(obj_Dtr["I_COD_USUARIO"].ToString());
                        obj_Usuario.Nm_Usuario = obj_Dtr["S_NM_USUARIO"].ToString();
                        obj_Usuario.UNm_Usuario = obj_Dtr["S_UNM_USUARIO"].ToString();
                        obj_Usuario.PW_Usuario = obj_Dtr["S_PW_USUARIO"].ToString();

                        Lista.Add(obj_Usuario);
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
