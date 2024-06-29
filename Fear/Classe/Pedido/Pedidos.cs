
using System;

namespace Fear
{
    public class Pedidos
    {
        ~Pedidos()
        {
        }

        #region Atributos
        //Atributos privados

        private int v_Cod_Pedido = -1;
        private int v_Cod_Cliente = -1;
     private DateTime v_Dt_Data_Pedido = DateTime.MinValue;
        private Decimal v_Total_Pedido = 0;




        #endregion

        #region metodos
        public int Cod_Pedido {
            get => v_Cod_Pedido;
            set => v_Cod_Pedido = value; 
        }
        public int Cod_Cliente { 
            get => v_Cod_Cliente; 
            set => v_Cod_Cliente = value;
        }
        public DateTime Dt_Data_Pedido { 
            get => v_Dt_Data_Pedido;
            set => v_Dt_Data_Pedido = value;
        }
        public decimal Total_Pedido { 
            get => v_Total_Pedido; 
            set => v_Total_Pedido = value;
        }

        #endregion

    }
}
