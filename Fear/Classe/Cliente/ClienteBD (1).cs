/*****************************************************************************
*           Nome: ClienteBD
*      Descrição: Representa a classe que negocia com a Base de dados da 
*                 Entidade Cliente. A classe BD possui os metodos: Incluir,
*                 Alterar, Excluir, FindByCod e FindAll (Publicas)
*    Dt. Criação: 29/06/2024
*  Dt. Alteração: --/--/----
* Obs. Alteração: -------------------
******************************************************************************/

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fear
{
    class ClienteBD
    {
        // Destruidor da Classe
        ~ClienteBD()
        {
        }

        /**********************************************************************
        *  Nome: Incluir
        *  Descrição: Responsável por incluir uma nova tupla do objeto Cliente na
        *             Tabela TB_CLIENTE.
        *  Parametro: Cliente (Objeto da Classe)
        *  Retorna: Inteiro (int) - Código do cliente incluído
        ***********************************************************************/
        public int Incluir(Cliente pobj_Cliente)
        {
            string s_varSql = "";
            int i_Cod = pobj_Cliente.Cod_Cliente;

            // Conexão
            SqlConnection obj_Conn = new SqlConnection(Connection.PathConnection());

            s_varSql = " INSERT INTO TB_CLIENTE " +
                       " ( " +
                       " I_COD_CLIENTE, " +
                       " S_NM_CLIENTE, " +
                       " S_MAIL_CLIENTE, " +
                       " S_CEL_CLIENTE, " +
                       " S_CNPJ_CLIENTE " +
                       " ) " +
                       " VALUES " +
                       " ( " +
                       " @I_COD_CLIENTE, " +
                       " @S_NM_CLIENTE, " +
                       " @S_MAIL_CLIENTE, " +
                       " @S_CEL_CLIENTE, " +
                       " @S_CNPJ_CLIENTE " +
                       " ); " +
                       " SELECT CAST(scope_identity() AS int) AS 'COD' ";

            SqlCommand obj_Cmd = new SqlCommand(s_varSql, obj_Conn);
            obj_Cmd.Parameters.AddWithValue("@I_COD_CLIENTE", pobj_Cliente.Cod_Cliente);
            obj_Cmd.Parameters.AddWithValue("@S_NM_CLIENTE", pobj_Cliente.Nm_Cliente);
            obj_Cmd.Parameters.AddWithValue("@S_MAIL_CLIENTE", pobj_Cliente.Mail_Cliente);
            obj_Cmd.Parameters.AddWithValue("@S_CEL_CLIENTE", pobj_Cliente.Cel_Cliente);
            obj_Cmd.Parameters.AddWithValue("@S_CNPJ_CLIENTE", pobj_Cliente.Cnpj_Cliente);

            try
            {
                obj_Conn.Open();
                i_Cod = (int)obj_Cmd.ExecuteScalar(); // Usar CAST(scope_identity() AS int)
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