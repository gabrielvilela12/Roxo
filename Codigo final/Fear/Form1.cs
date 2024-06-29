using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml;

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
            openFileDialog.Filter = "Arquivos CSV (*.csv)|*.csv|Arquivos JSON ou XML (*.json, *.xml)|*.json;*.xml";

            // Mostra o OpenFileDialog e verifica se o usuário clicou em OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Verifica a extensão do arquivo selecionado
                string selectedFile = openFileDialog.FileName;
                string extension = Path.GetExtension(selectedFile);

                try
                {
                    if (extension.Equals(".csv", StringComparison.InvariantCultureIgnoreCase))
                    {
                        // Leitura e exibição de CSV
                        using (var reader = new StreamReader(selectedFile))
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                        {
                            var records = csv.GetRecords<dynamic>();

                            foreach (var record in records)
                            {
                                foreach (var field in record)
                                {
                                    string line = string.Format("{0}: {1}", field.Key, field.Value);
                                    txtConteudo.AppendText(line + Environment.NewLine);

                                    // Captura o valor após ": "
                                    int separatorIndex = line.IndexOf(": ");
                                    if (separatorIndex != -1 && separatorIndex + 2 < line.Length)
                                    {
                                        string valorDepoisDoSeparador = line.Substring(separatorIndex + 2);
                                        // Use 'valorDepoisDoSeparador' conforme necessário
                                        Console.WriteLine(valorDepoisDoSeparador); // Exemplo de uso
                                    }
                                }
                                txtConteudo.AppendText(Environment.NewLine); // Linha em branco para separar os registros
                            }
                        }
                    }
                    else if (extension.Equals(".json", StringComparison.InvariantCultureIgnoreCase))
                    {
                        // Leitura e exibição de JSON
                        string jsonContent = File.ReadAllText(selectedFile);
                        var data = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(jsonContent);

                        foreach (var item in data)
                        {
                            foreach (var field in item)
                            {
                                string line = string.Format("{0}: {1}", field.Key, field.Value);
                                txtConteudo.AppendText(line + Environment.NewLine);

                                // Captura o valor após ": "
                                int separatorIndex = line.IndexOf(": ");
                                if (separatorIndex != -1 && separatorIndex + 2 < line.Length)
                                {
                                    string valorDepoisDoSeparador = line.Substring(separatorIndex + 2);
                                    // Use 'valorDepoisDoSeparador' conforme necessário
                                    Console.WriteLine(valorDepoisDoSeparador); // Exemplo de uso
                                }
                            }
                            txtConteudo.AppendText(Environment.NewLine); // Linha em branco para separar os registros
                        }
                    }
                    else if (extension.Equals(".xml", StringComparison.InvariantCultureIgnoreCase))
                    {
                        // Leitura e exibição de XML
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(selectedFile);

                        XmlNodeList nodes = xmlDoc.DocumentElement.ChildNodes;
                        foreach (XmlNode node in nodes)
                        {
                            foreach (XmlNode childNode in node.ChildNodes)
                            {
                                string line = string.Format("{0}: {1}", childNode.Name, childNode.InnerText);
                                txtConteudo.AppendText(line + Environment.NewLine);

                                // Captura o valor após ": "
                                int separatorIndex = line.IndexOf(": ");
                                if (separatorIndex != -1 && separatorIndex + 2 < line.Length)
                                {
                                    string valorDepoisDoSeparador = line.Substring(separatorIndex + 2);
                                    // Use 'valorDepoisDoSeparador' conforme necessário
                                    Console.WriteLine(valorDepoisDoSeparador); // Exemplo de uso
                                }
                            }
                            txtConteudo.AppendText(Environment.NewLine); // Linha em branco para separar os registros
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, selecione um arquivo CSV, JSON ou XML válido.", "Tipo de arquivo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao ler o arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
