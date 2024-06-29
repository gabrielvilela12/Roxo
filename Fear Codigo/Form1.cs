using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Fear
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtConteudo.Clear();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos JSON|*.json";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    // Lê o conteúdo do arquivo JSON
                    string jsonContent = File.ReadAllText(filePath);

              

                    // Deserialize JSON para uma lista de dicionários
                    var data = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(jsonContent);

                    // Exibe os valores no TextBox1
                    foreach (var item in data)
                    {
                        txtConteudo.AppendText("Código do produto: ");        
                        foreach (var value in item.Values)
                        {
                            txtConteudo.AppendText(value.ToString() + Environment.NewLine);
                            txtConteudo.AppendText("Produto:\n ");

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao ler o arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string FormatJson(string json)
        {
            try
            {
                // Parse do JSON para formatar com indentação
                var parsedJson = JsonDocument.Parse(json);
                return JsonSerializer.Serialize(parsedJson.RootElement, new JsonSerializerOptions { WriteIndented = true });
            }
            catch (JsonException)
            {
                return json; // Retorna o JSON original se não puder ser formatado
            }
        }
    }
}
