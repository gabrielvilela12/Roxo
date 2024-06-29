/**********************************************************************************
 Nome da Classe: Cliente
    Dt. Criação: 29/06/2024
      Descrição: Esta classe é responsável pelo objeto Cliente.
  Dt. Alteração: --/--/---- 
     Observação:
***********************************************************************************/
namespace Fear
{
    public class Cliente
    {
        ~Cliente()
        {
        }

        #region Atributos
        // Atributos privados
        private int v_Cod_Cliente = -1;
        private string v_Nm_Cliente = "";
        private string v_Mail_Cliente = "";
        private string v_Cel_Cliente = "";
        private string v_Cnpj_Cliente = "";

        #endregion

        #region Métodos

        public int Cod_Cliente
        {
            get => v_Cod_Cliente;
            set => v_Cod_Cliente = value;
        }

        public string Nm_Cliente
        {
            get => v_Nm_Cliente;
            set => v_Nm_Cliente = value;
        }

        public string Mail_Cliente
        {
            get => v_Mail_Cliente;
            set => v_Mail_Cliente = value;
        }

        public string Cel_Cliente
        {
            get => v_Cel_Cliente;
            set => v_Cel_Cliente = value;
        }

        public string Cnpj_Cliente
        {
            get => v_Cnpj_Cliente;
            set => v_Cnpj_Cliente = value;
        }

        #endregion


    }
}
