/**********************************************************************************
 Nome da Classe: Usuario
    Dt. Criação: 02/02/2024
      Descrição: Esta classe é responsável pelo objeto Usuario.
  Dt. Alteração: --/--/---- 
     Observação:
     Criado Por: mFacine
***********************************************************************************/
namespace Fear
{
    public class Usuario
    {
        ~Usuario()
        {
        }

        #region Atributos
        //Atributos privados
        private int v_Cod_Usuario = -1;
        private string v_Nm_Usuario = "";
        private string v_UNm_Usuario = "";
        private string v_PW_Usuario = "";
        #endregion

        #region Métodos
        //Métodos Públicos
        public int    Cod_Usuario 
        { 
            get => v_Cod_Usuario; 
            set => v_Cod_Usuario = value; 
        }

        public string Nm_Usuario 
        { 
            get => v_Nm_Usuario; 
            set => v_Nm_Usuario = value; 
        }

        public string UNm_Usuario 
        { 
            get => v_UNm_Usuario; 
            set => v_UNm_Usuario = value; 
        }

        public string PW_Usuario 
        { 
            get => v_PW_Usuario; 
            set => v_PW_Usuario = value; 
        }
        #endregion
    }
}
