/**********************************************************************************
 Nome da Classe: Categoria
    Dt. Criação: 02/02/2024
      Descrição: Esta classe é responsável pelo objeto Categoria.
  Dt. Alteração: --/--/---- 
     Observação:
     Criado Por: mFacine
***********************************************************************************/
namespace Fear
{
    public class Categoria
    {
        ~Categoria()
        {
        }

        #region Atributos
        //Atributos privados
        private int v_Cod_Categoria = -1;
        private string v_Nm_Categoria = "";

        #endregion

        #region Métodos
        //Métodos Públicos
        public int Cod_Categoria
        {
            get => v_Cod_Categoria;
            set => v_Cod_Categoria = value;
        }

        public string Nm_Categoria
        {
            get => v_Nm_Categoria;
            set => v_Nm_Categoria = value;
        }

        #endregion
    }
}
