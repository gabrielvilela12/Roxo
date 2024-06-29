/**********************************************************************************
 Nome da Classe: Item
    Dt. Criação: 02/02/2024
      Descrição: Esta classe é responsável pelo objeto Item.
  Dt. Alteração: --/--/---- 
     Observação:
     Criado Por: mFacine
***********************************************************************************/
namespace Fear
{
    public class Itens
    {
        ~Itens()
        {
        }

        #region Atributos
        //Atributos privados
        private int v_Cod_Itens = -1;
        private int v_Cod_Pedido = -1;
        private int v_Cod_Produto = -1;
        private int v_Qtde_Itens = 0;
        private decimal v_ValrUnit_Itens = 0;

        #endregion
        #region metodos
        public int Cod_Itens { 
            get => v_Cod_Itens;
            set => v_Cod_Itens = value;
        }
        public int Cod_Pedido { 
            get => v_Cod_Pedido;
            set => v_Cod_Pedido = value;
        }
        public int Cod_Produto { 
            get => v_Cod_Produto;
            set => v_Cod_Produto = value; 
        }
        public int Qtde_Itens {
            get => v_Qtde_Itens;
            set => v_Qtde_Itens = value; 
        }
        public decimal ValrUnit_Itens {
            get => v_ValrUnit_Itens;
            set => v_ValrUnit_Itens = value; 
        }
        #endregion

    }
}
