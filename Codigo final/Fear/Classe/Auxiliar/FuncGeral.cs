

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fear
{
    class FuncGeral
    {
        ///<summary>
        ///Vetor de byte utilizado para a criptografia (chave externa) 
        ///</summary>

        private static byte[] bIV = { 0x50, 0x80, 0xF1, 0xDD, 0xDE, 
            0x3C, 0xF2, 0x18, 0x44, 0x74, 0x19, 0x2C, 0x53, 0x49, 0xAB, 0xBC };

        /// <summary>
        /// Representação de valor em base 64 (chave interna)
        /// Valor representa a transformação para base 64 de 
        /// um conjunto de 32 caracteres (8 * 32 - 256 bits)
        /// a chave é: "Criptografia com Rijndael / AES"
        /// </summary>
        private const string s_cryptokey = "Q3JpcHRvZ3JhZmlhcyBjb20gUmluamRhZWwgLyNNRVM=";



        public string Criptografa(string s_PW)
        {
            try
            {
                //Se a string não for vazia, executa a criptografia
                if (!string.IsNullOrEmpty(s_PW))
                {
                    //Cria uma instância do vetor de bytes com as chaves
                    byte[] bKey = Convert.FromBase64String(s_cryptokey);
                    byte[] bText = new UTF8Encoding().GetBytes(s_PW);

                    //Instância da classe de criptografia Rijndael
                    Rijndael obj_Rijndael = new RijndaelManaged();

                    //Define o tamanho da chave " 256 = 8 * 32 "
                    //Chaves possíveis: 128 (16 caracteres), 192 (24 caracteres),
                    //                  256 (32 caracteres),
                    obj_Rijndael.KeySize = 256;

                    //Criar um espaço de memória para guardar a string criptografada
                    MemoryStream mStream = new MemoryStream();

                    //Instância para o Encriptografador 
                    CryptoStream cStream = new CryptoStream(
                        mStream,
                        obj_Rijndael.CreateEncryptor(bKey, bIV),
                        CryptoStreamMode.Write);

                    //Fazer a escrita da criptografia no espaço de memória
                    cStream.Write(bText, 0, bText.Length);

                    //Despejar toda a memória
                    cStream.FlushFinalBlock();

                    //Pegar o vetor de bytes da memória e gerar a string Criptografada

                    return Convert.ToBase64String(mStream.ToArray());

                }
                else
                {
                    // Se a string for vazia, deve ser retornado nulo
                    return null;
                }
            }
            catch (Exception erro)
            {
                //Se algum erro ocorrer, dispara a exceção
                throw new ApplicationException("Erro ao tentar criptografar", erro);
            }
        }

        public string Descriptografa(string s_PW)
        {
            try
            {
                //Se a string não for vazia, executa a criptografia
                if (!string.IsNullOrEmpty(s_PW))
                {
                    //Cria uma instância do vetor de bytes com as chaves
                    byte[] bKey = Convert.FromBase64String(s_cryptokey);
                    byte[] bText = Convert.FromBase64String(s_PW);

                    //Instância da classe de criptografia Rijndael
                    Rijndael obj_Rijndael = new RijndaelManaged();

                    //Define o tamanho da chave " 256 = 8 * 32 "
                    //Chaves possíveis: 128 (16 caracteres), 192 (24 caracteres),
                    //                  256 (32 caracteres),
                    obj_Rijndael.KeySize = 256;

                    //Criar um espaço de memória para guardar a string criptografada
                    MemoryStream mStream = new MemoryStream();

                    //Instância para o Encriptografador 
                    CryptoStream dcStream = new CryptoStream(
                        mStream,
                        obj_Rijndael.CreateDecryptor(bKey, bIV),
                        CryptoStreamMode.Write);

                    //Fazer a escrita da criptografia no espaço de memória
                    dcStream.Write(bText, 0, bText.Length);

                    //Despejar toda a memória
                    dcStream.FlushFinalBlock();

                    //Instância a classe de codificação para que a string venha de forma correta
                    UTF8Encoding utf8 = new UTF8Encoding();

                    //Com o vetor de bytes da memória, gera a string Descriptografada em UTF8

                    return utf8.GetString(mStream.ToArray());

                }
                else
                {
                    // Se a string for vazia, deve ser retornado nulo
                    return null;
                }
            }
            catch (Exception erro)
            {
                //Se algum erro ocorrer, dispara a exceção
                throw new ApplicationException("Erro ao tentar descriptografar", erro);
            }
        }







        public void LimpaTela(Form pobj_Form)
        {
            foreach (Control pnl in pobj_Form.Controls)
            {
                if (pnl is Panel && pnl.Name == "pnl_Detail")
                {
                    foreach (Control ctr in pnl.Controls)
                    {
                        if (ctr is TextBox)
                        {
                            ctr.Text = "";
                        }

                        if (ctr is Label && Convert.ToInt16(ctr.Tag) == 1)
                        {
                            ctr.Text = "";
                        }

                        if (ctr is ListView)
                        {
                            ((ListView)ctr).Items.Clear();
                        }

                        if (ctr is ComboBox)
                        {
                            ctr.Text = "";
                        }

                        if (ctr is MaskedTextBox)
                        {
                            ctr.Text = "";
                        }


                        if (ctr is CheckBox)
                        {
                            ((CheckBox)ctr).Checked = false;
                        }
                    }
                }
            }
        }

   
        public void HabilitaTela(Form pobj_Form, bool b_Habilita)
        {
            foreach (Control pnl in pobj_Form.Controls)
            {
                if (pnl is Panel && pnl.Name == "pnl_Detail")
                {
                    foreach (Control ctr in pnl.Controls)
                    {
                        if (ctr is TextBox && Convert.ToInt16(ctr.Tag) != 1)
                        {
                            ctr.Enabled = b_Habilita;
                        }

                        if (ctr is CheckBox)
                        {
                            ctr.Enabled = b_Habilita;
                        }

                        if (ctr is Button)
                        {
                            ctr.Enabled = b_Habilita;
                        }

                        if (ctr is ComboBox)
                        {
                            ctr.Enabled = b_Habilita;
                        }

                        if (ctr is MaskedTextBox)
                        {
                            ctr.Enabled = b_Habilita;
                        }

                        if (ctr is ListView)
                        {
                            ctr.Enabled = b_Habilita;
                        }
                    }
                }
            }
        }

     
        public void StatusBtn(Form pobj_Form, int i_Status)
        {
            foreach (Control pnl in pobj_Form.Controls)
            {
                if (pnl is Panel && pnl.Name == "pnl_Button")
                {
                    foreach (Control ctr in pnl.Controls)
                    {
                        switch (i_Status)
                        {
                            case 1:
                                {
                                    if (ctr.Name == "btn_Novo")
                                    {
                                        ctr.Enabled = true;
                                    }

                                    if (ctr.Name == "btn_Alterar")
                                    {
                                        ctr.Enabled = false;
                                    }

                                    if (ctr.Name == "btn_Excluir")
                                    {
                                        ctr.Enabled = false;
                                    }

                                    if (ctr.Name == "btn_Cancelar")
                                    {
                                        ctr.Enabled = false;
                                    }

                                    if (ctr.Name == "btn_Confirmar")
                                    {
                                        ctr.Enabled = false;
                                    }
                                    break;
                                }

                            case 2:
                                {
                                    if (ctr.Name == "btn_Novo")
                                    {
                                        ctr.Enabled = true;
                                    }

                                    if (ctr.Name == "btn_Alterar")
                                    {
                                        ctr.Enabled = true;
                                    }

                                    if (ctr.Name == "btn_Excluir")
                                    {
                                        ctr.Enabled = true;
                                    }

                                    if (ctr.Name == "btn_Cancelar")
                                    {
                                        ctr.Enabled = false;
                                    }

                                    if (ctr.Name == "btn_Confirmar")
                                    {
                                        ctr.Enabled = false;
                                    }
                                    break;
                                }

                            case 3:
                                {
                                    if (ctr.Name == "btn_Novo")
                                    {
                                        ctr.Enabled = false;
                                    }

                                    if (ctr.Name == "btn_Alterar")
                                    {
                                        ctr.Enabled = false;
                                    }

                                    if (ctr.Name == "btn_Excluir")
                                    {
                                        ctr.Enabled = false;
                                    }

                                    if (ctr.Name == "btn_Cancelar")
                                    {
                                        ctr.Enabled = true;
                                    }

                                    if (ctr.Name == "btn_Confirmar")
                                    {
                                        ctr.Enabled = true;
                                    }
                                    break;
                                }
                        }

                    }
                }
            }
        }




        public bool ValidaTipo(Type p_Tipo, string ps_Conteudo)
        {
            bool b_Valida = false;
            switch (p_Tipo.Name)
            {
                case "Int16":
                    {
                        int i_vlr_Inteiro = 0;
                        b_Valida = int.TryParse(ps_Conteudo, out i_vlr_Inteiro);
                        
                        if (i_vlr_Inteiro < 0)
                        {
                            b_Valida = false;
                        }
                        
                        break;
                    }

                case "DateTime":
                    {
                        DateTime dt_vlr_Data = DateTime.MinValue;
                        b_Valida = DateTime.TryParse(ps_Conteudo, out dt_vlr_Data);
                        break;
                    }
                case "double":
                    {
                        double d_vlr_Decimal = 0;
                        b_Valida = double.TryParse(ps_Conteudo, out d_vlr_Decimal);

                        if (d_vlr_Decimal < 0)
                        {
                            b_Valida = false;
                        }

                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return b_Valida;
        }

        public void ShowAlert(Control p_Ctrl)
        {
            MessageBox.Show("Campo não preenchido ou inválido...", "Entrada Inválida",MessageBoxButtons.OK, MessageBoxIcon.Error);
            p_Ctrl.Focus();
        }

        public bool ValidaTela (Form pobj_Form)
        {
            bool b_Valida = true;

            foreach (Control pnl in pobj_Form.Controls)
            {
                if (pnl is Panel && pnl.Name == "pnl_Detail")
                {
                    foreach (Control ctrl in pnl.Controls) 
                    {
                        if (ctrl is TextBox && ctrl.Text == "" && Convert.ToInt16(ctrl.Tag) != 1)
                        {
                            ShowAlert(ctrl);
                            b_Valida = false;
                            break;
                        }

                        if (ctrl is ComboBox && ((ComboBox)ctrl).SelectedIndex == -1)
                        {
                            ShowAlert(ctrl);
                            b_Valida = false;
                            break;
                        }

                        if (ctrl is MaskedTextBox && ctrl.Text == "")
                        {
                            ShowAlert(ctrl);
                            b_Valida = false;
                            break;
                        }
                    }
                }
            }
            return b_Valida;
        }


        public void PopulaMascara(Form pobj_Form)
        {
            foreach (Control pnl in pobj_Form.Controls)
            {
                if (pnl is Panel &&  pnl.Name == "pnl_Detail")
                {
                    foreach(Control ctrl in pnl.Controls)
                    {
                        if (ctrl is MaskedTextBox)
                        {
                            switch (Convert.ToInt16(ctrl.Tag))
                            {
                                case 11:
                                    {
                                        ((MaskedTextBox)ctrl).Mask = "00.000,00";
                                        break;
                                    }
                                case 12:
                                    {
                                        ((MaskedTextBox)ctrl).Mask = "00/00/0000";
                                        break;
                                    }
                                case 13:
                                    {
                                        ((MaskedTextBox)ctrl).Mask = "000.000.000-00";
                                        break;
                                    }
                                case 14:
                                    {
                                        ((MaskedTextBox)ctrl).Mask = "00.000-000";
                                        break;
                                    }
                                case 15:
                                    {
                                        ((MaskedTextBox)ctrl).Mask = "(00) 00000-0000";
                                        break;
                                    }
                            }
                        }
                    }
                }
            }
        }

       
        public void TamanhoMaximo(Form pobj_Form, string ps_Nm_Tabela) 
        {
            string s_NmCampo = "";

            Campo obj_Campo = new Campo();
            CampoBD obj_CampoBD = new CampoBD();

            List<Campo> Lista = new List<Campo>();

            Lista = obj_CampoBD.FindAllCampo(ps_Nm_Tabela);

            if (Lista.Count > 0)
            {
                for (int i = 0; i < Lista.Count; i++)
                {
                    obj_Campo.Nm_Campo = Lista[i].Nm_Campo;
                    obj_Campo.Tp_Campo = Lista[i].Tp_Campo;
                    obj_Campo.Tam_Campo = Lista[i].Tam_Campo;

                    foreach (Control pnl in pobj_Form.Controls)
                    {
                        if (pnl is Panel && pnl.Name == "pnl_Detail")
                        {
                            foreach(Control ctrl in pnl.Controls)
                            {
                                if (ctrl is TextBox)
                                {
                                    if (obj_Campo.Tp_Campo == "DateTime")
                                    {
                                        //DT_NASC_CLIENTE
                                        s_NmCampo = "TBOX_" + obj_Campo.Nm_Campo.Substring(3,obj_Campo.Nm_Campo.Length-3);
                                    }
                                    else
                                    {
                                        //S_NM_CLIENTE
                                        s_NmCampo = "TBOX_" + obj_Campo.Nm_Campo.Substring(2, obj_Campo.Nm_Campo.Length - 2);

                                        if (s_NmCampo == ctrl.Name.ToUpper())
                                        {
                                            if (obj_Campo.Tp_Campo == "text")
                                            {
                                                ((TextBox)ctrl).MaxLength = 300;
                                            }
                                            else
                                            {
                                                ((TextBox)ctrl).MaxLength = obj_Campo.Tam_Campo;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }



    }
}
