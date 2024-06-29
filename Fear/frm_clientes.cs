using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fear
{
    public partial class frm_clientes : Form
    {
        FuncGeral obj_FuncGeral = new FuncGeral();
        public Usuario obj_Usuario_Atual = new Usuario();


        public frm_clientes()
        {
            InitializeComponent();
            PopulaLista();
            obj_FuncGeral.TamanhoMaximo(this, "TB_USUARIO");
            obj_FuncGeral.StatusBtn(this, 1);
            obj_FuncGeral.HabilitaTela(this, false);
        }

        /**********************************************************************************
                  Nome : PopulaLista
            Dt. Criação: 29/02/2024
              Descrição: Preencher o ListBox com os dados que estão na Tabela (TB_USUARIO).
          Dt. Alteração: --/--/---- 
             Observação: --
             Criado Por: mFacine
        ***********************************************************************************/
        private void PopulaLista()
        {
            //Instância da classe BD
            UsuarioBD obj_UsuarioBD = new UsuarioBD();

            //Instância da Lista de Objetos
            List<Usuario> Lista = new List<Usuario>();

            //Limpeza do ListBox
            ltbox_Usuarios.Items.Clear();

            //Lista recebe os usuários
            Lista = obj_UsuarioBD.FindAll();

            if (Lista != null)
            {
                for (int i = 0; i < Lista.Count; i++)
                {
                    ltbox_Usuarios.Items.Add(Lista[i].Cod_Usuario.ToString() + "-" +
                                             Lista[i].Nm_Usuario.ToString());
                }
            }

        }

        /**********************************************************************************
                  Nome : PopulaTela
            Dt. Criação: 29/02/2024
              Descrição: Preencher a Tela com os dados do Objeto Atual.
          Dt. Alteração: --/--/---- 
             Observação: --
             Criado Por: mFacine
        ***********************************************************************************/
        private void PopulaTela(Usuario pobj_Usuario)
        {
            if (pobj_Usuario.Cod_Usuario != -1)
            {
                tbox_Cod_Usuario.Text = pobj_Usuario.Cod_Usuario.ToString();
                tbox_Nm_Usuario.Text = pobj_Usuario.Nm_Usuario.ToString();
                tbox_UNm_Usuario.Text = pobj_Usuario.UNm_Usuario.ToString();
                tbox_PW_Usuario.Text = obj_FuncGeral.Descriptografa(pobj_Usuario.PW_Usuario.ToString());
            }
        }

        /**********************************************************************************
                  Nome : PopulaObjeto
            Dt. Criação: 29/02/2024
              Descrição: Preencher o Objeto Atual com os dados da Tela.
          Dt. Alteração: --/--/---- 
             Observação: --
             Criado Por: mFacine
        ***********************************************************************************/
        private Usuario PopulaObjeto()
        {
            Usuario obj_Usuario = new Usuario();

            if (tbox_Cod_Usuario.Text != "")
            {
                obj_Usuario.Cod_Usuario = Convert.ToInt16(tbox_Cod_Usuario.Text);
            }
            obj_Usuario.Nm_Usuario = tbox_Nm_Usuario.Text;
            obj_Usuario.UNm_Usuario = tbox_UNm_Usuario.Text;
            obj_Usuario.PW_Usuario = obj_FuncGeral.Criptografa(tbox_PW_Usuario.Text);
            return obj_Usuario;
        }


        private void btn_Novo_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.HabilitaTela(this, true);
            obj_FuncGeral.LimpaTela(this);
            obj_FuncGeral.StatusBtn(this, 3);
            tbox_Nm_Usuario.Focus();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.HabilitaTela(this, false);

            if (obj_Usuario_Atual.Cod_Usuario != -1)
            {
                PopulaTela(obj_Usuario_Atual);
                obj_FuncGeral.StatusBtn(this, 2);
            }
            else
            {
                obj_FuncGeral.StatusBtn(this, 1);
                obj_FuncGeral.LimpaTela(this);
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            UsuarioBD obj_UsuarioBD = new UsuarioBD();
            DialogResult v_Resp = MessageBox.Show("Confirma a exclusão do Usuário " + obj_Usuario_Atual.Nm_Usuario + "?", "Excluir Usuário", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (v_Resp == DialogResult.Yes)
            {
                if (obj_UsuarioBD.Excluir(obj_Usuario_Atual))
                {
                    MessageBox.Show("Exclusão do Usuário " + obj_Usuario_Atual.Nm_Usuario + " realizada com sucesso", "Excluir Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                obj_FuncGeral.LimpaTela(this);
                obj_FuncGeral.HabilitaTela(this, false);
                obj_FuncGeral.StatusBtn(this, 1);
                PopulaLista();

            }
        }

        private void ltbox_Usuarios_Click(object sender, EventArgs e)
        {
            if (ltbox_Usuarios.SelectedIndex != -1)
            {
                UsuarioBD obj_UsuarioBD = new UsuarioBD();
                string s_Linha = ltbox_Usuarios.Items[ltbox_Usuarios.SelectedIndex].ToString();

                int i_pos = 0;
                for (int i = 0; i < s_Linha.Length; i++)
                {
                    if (s_Linha.Substring(i, 1) == "-")
                    {
                        i_pos = i;
                        break;
                    }
                }

                obj_Usuario_Atual.Cod_Usuario = Convert.ToInt16(s_Linha.Substring(0, i_pos));

                obj_Usuario_Atual = obj_UsuarioBD.FindByCod(obj_Usuario_Atual);
                PopulaTela(obj_Usuario_Atual);
                obj_FuncGeral.StatusBtn(this, 2);



            }
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.HabilitaTela(this, true);
            obj_FuncGeral.StatusBtn(this, 3);
            tbox_Nm_Usuario.Focus();
        }

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            UsuarioBD obj_UsuarioBD = new UsuarioBD();

            obj_Usuario_Atual = PopulaObjeto();

            if (obj_Usuario_Atual.Cod_Usuario != -1)
            {
                if (obj_UsuarioBD.Alterar(obj_Usuario_Atual))
                {
                    MessageBox.Show("Usuário " + obj_Usuario_Atual.Nm_Usuario + " foi atualizado com sucesso.", "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                obj_Usuario_Atual.Cod_Usuario = obj_UsuarioBD.Incluir(obj_Usuario_Atual);
                PopulaTela(obj_Usuario_Atual);
                MessageBox.Show("Usuário " + obj_Usuario_Atual.Nm_Usuario +
                    " foi incluido com sucesso.", "Inclusão",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            PopulaLista();
            obj_FuncGeral.HabilitaTela(this, false);
            obj_FuncGeral.StatusBtn(this, 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbox_PW_Usuario.PasswordChar != default)
            {
                tbox_PW_Usuario.PasswordChar = default;
            }
            else
            {
                tbox_PW_Usuario.PasswordChar = '*';
            }
        }
    }
}