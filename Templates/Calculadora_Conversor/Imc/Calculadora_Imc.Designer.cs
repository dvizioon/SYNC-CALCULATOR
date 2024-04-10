// Program.cs
using System;
using System.Runtime.InteropServices;
namespace Calculadora_C_;
using Calculadora_C_.Pdf_Genarate;
using Calculadora_C_.DvisonIa;
using Newtonsoft.Json;
using System.Diagnostics;


partial class Calculadora_IMC : Form
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>

    // Criar um Class para Renderizar inputs dos Components


    public class calc_imc : UserControl
    {

        Process myProcess = new Process();

        TextBox InputPeso = new TextBox();
        TextBox InputAltura = new TextBox();
        Label LabelPeso = new Label();
        Label labelAltura = new Label();
        Button Calcular = new Button();
        Panel Container_img = new Panel();
        Panel Container_Resultado = new Panel();
        PictureBox img_person = new PictureBox();
        Label Resultado = new Label();
        Button btnImprimi = new Button();
        Button btnOrgan = new Button();
        TextBox InputResultado = new TextBox();

        private Image imgIconMenu = Image.FromFile("./Personagens/Baixo_Peso_ideal.png");
      
        public calc_imc()
        {

            Panel Container_All = new Panel();
            Container_All.Size = new Size(390, 445);
            Container_All.Location = new Point(5, 0);
            // Container_All.BackColor = Color.FromArgb(0, 0, 0);

            FlowLayoutPanel ContainerLabels = new FlowLayoutPanel();
            ContainerLabels.FlowDirection = FlowDirection.LeftToRight;
            ContainerLabels.Location = new Point(10, 10);
            ContainerLabels.Size = new Size(370, 50);
            // ContainerLabels.BackColor = Color.FromArgb(63, 53, 2);


            FlowLayoutPanel ContainerInputs = new FlowLayoutPanel();
            ContainerInputs.FlowDirection = FlowDirection.LeftToRight;
            ContainerInputs.Location = new Point(10, 70);
            ContainerInputs.Size = new Size(370, 50);
            // ContainerInputs.BackColor = Color.FromArgb(63, 53, 2);

            LabelPeso.Size = new Size(179, 44);
            LabelPeso.Text = "Peso";
            LabelPeso.Font = new Font("ArialBlack", 25, FontStyle.Regular);
            LabelPeso.TextAlign = ContentAlignment.MiddleCenter;

            labelAltura.Size = new Size(179, 44);
            labelAltura.Text = "Altura";
            labelAltura.Font = new Font("ArialBlack", 25, FontStyle.Regular);
            labelAltura.TextAlign = ContentAlignment.MiddleCenter;

            InputAltura.Size = new Size(179, 44);
            InputAltura.Multiline = true;
            InputAltura.Font = new Font("ArialBlack", 25, FontStyle.Regular);
            InputAltura.TextAlign = HorizontalAlignment.Center;
            InputAltura.PlaceholderText = "0.00";
            InputAltura.KeyPress += InputPeso_KeyPress;

            InputPeso.Size = new Size(179, 44);
            InputPeso.Multiline = true;
            InputPeso.Font = new Font("ArialBlack", 25, FontStyle.Regular);
            InputPeso.TextAlign = HorizontalAlignment.Center;
            InputPeso.PlaceholderText = "00";
            InputPeso.KeyPress += InputPeso_KeyPress;

            InputResultado.PlaceholderText = "Resultado da Busca...🔎";

            ContainerInputs.Controls.Add(InputAltura);
            ContainerLabels.Controls.Add(labelAltura);
            ContainerLabels.Controls.Add(LabelPeso);
            ContainerInputs.Controls.Add(InputPeso);

            Calcular.Location = new Point(10, 140);
            Calcular.Size = new Size(370, 50);
            Calcular.Font = new Font("ArialBlack", 15, FontStyle.Regular);
            Calcular.Text = "Calcular";
            Calcular.Click += CalcularImc;

            Label Resultado_Label = new Label();
            Resultado_Label.Location = new Point(10, 200);
            Resultado_Label.Size = new Size(370, 50);
            Resultado_Label.Text = "Resultado";
            Resultado_Label.Font = new Font("ArialBlack", 25, FontStyle.Regular);
            Resultado_Label.TextAlign = ContentAlignment.MiddleCenter;

            FlowLayoutPanel Container_Resultado_Img = new FlowLayoutPanel();
            Container_Resultado_Img.FlowDirection = FlowDirection.LeftToRight;
            Container_Resultado_Img.Location = new Point(10, 200);
            Container_Resultado_Img.Size = new Size(370, 230);
            // Container_Resultado_Img.BackColor = Color.FromArgb(63, 53, 2);



            Container_img.Location = new Point(0, 200);
            Container_img.Size = new Size(179, 230);
            // Container_img.BackColor = Color.FromArgb(63, 3, 2);

            Container_Resultado.Location = new Point(0, 200);
            Container_Resultado.Size = new Size(179, 230);
            // Container_Resultado.BackColor = Color.FromArgb(63, 3, 2);

            Container_Resultado_Img.Controls.Add(Container_img);
            Container_Resultado_Img.Controls.Add(Container_Resultado);

            Resultado.Location = new Point(0, 50);
            Resultado.Size = new Size(179, 40);
            Resultado.Text = "0.00 IC";
            Resultado.Font = new Font("ArialBlack", 25, FontStyle.Regular);
            Resultado.TextAlign = ContentAlignment.MiddleCenter;

            img_person.Location = new Point(0, 95);
            img_person.Size = new Size(179, 140);
            // img_person.ImageLocation = ;
            img_person.SizeMode = PictureBoxSizeMode.CenterImage; // Centraliza a imagem
            img_person.Anchor = AnchorStyles.Top;
            // img_person.BackColor = Color.Red;


            Image imgIconMenuImpresora = Image.FromFile("./Icons/impressora.png");
            Image impressoraIconRedimensionada = imgIconMenuImpresora.GetThumbnailImage(20, 20, null, IntPtr.Zero);

            btnOrgan.Location = new Point(0, 50);
            btnOrgan.Size = new Size(100, 35);
            btnOrgan.Font = new Font("ArialBlack", 10, FontStyle.Regular);
            btnOrgan.Text = "Seu IMC";
            btnOrgan.Click += abrirSiteToolStripMenuItem_Click;

            btnImprimi.Location = new Point(0, 50);
            btnImprimi.Size = new Size(60, 35);
            btnImprimi.Font = new Font("ArialBlack", 10, FontStyle.Regular);
            btnImprimi.Image = impressoraIconRedimensionada;
            btnImprimi.ImageAlign = ContentAlignment.MiddleCenter;
            btnImprimi.Click += imprimirResultadoReceita;

            FlowLayoutPanel ContainerButtons = new FlowLayoutPanel();
            ContainerButtons.FlowDirection = FlowDirection.LeftToRight;
            ContainerButtons.Location = new Point(0, 50);
            ContainerButtons.Size = new Size(179, 40);


            ContainerButtons.Controls.Add(btnOrgan);
            ContainerButtons.Controls.Add(btnImprimi);

            InputResultado.Location = new Point(0, 95);
            InputResultado.Multiline = true;
            InputResultado.ScrollBars = ScrollBars.Vertical;
            InputResultado.Size = new Size(179, 140);
            // InputResultado.BackColor = Color.Red;
 

            Image imgIconRedimensionada = imgIconMenu.GetThumbnailImage(70, 130, null, IntPtr.Zero);
            img_person.Image = imgIconRedimensionada;

            Container_img.Controls.Add(Resultado);
            Container_img.Controls.Add(img_person);

            Container_Resultado.Controls.Add(ContainerButtons);
            Container_Resultado.Controls.Add(InputResultado);

            this.Size = new Size(400, 450);
            this.Controls.Add(Container_All);
            Container_All.Controls.Add(ContainerLabels);
            Container_All.Controls.Add(ContainerInputs);
            Container_All.Controls.Add(Calcular);
            Container_All.Controls.Add(Resultado_Label);
            Container_All.Controls.Add(Container_Resultado_Img);

        }

        public void imgLoad(string caminho){
            if (img_person.Image != null)
            {
                img_person.Image.Dispose();
            }

            // Carregue a nova imagem
            imgIconMenu = Image.FromFile(caminho);
            Image imgIconRedimensionada = imgIconMenu.GetThumbnailImage(70, 130, null, IntPtr.Zero);

            // Atribua a nova imagem
            img_person.Image = imgIconRedimensionada;

            // Atualize a interface do usuário
            img_person.Refresh();
        }


        private void InputPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifique se a tecla pressionada é um número, um ponto decimal ou um controle de backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Verifique se é um ponto decimal e se já existe na caixa de texto
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void imprimirResultadoReceita(object sender, EventArgs e)
        {
            string conteudo = InputResultado.Text;

            try
            {
                // Configurar o SaveFileDialog
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Arquivos PDF|*.pdf";
                saveFileDialog.Title = "Salvar PDF";
                saveFileDialog.FileName = "Receita_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf";

                // Definir o diretório inicial para o diretório de Documentos do usuário
                string documentosPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog.InitialDirectory = documentosPath;

                // Mostrar o diálogo para permitir que o usuário escolha o local de salvamento
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obter o caminho completo do arquivo escolhido pelo usuário
                    string caminhoPdf = saveFileDialog.FileName;

                    // Extrair apenas o nome do arquivo (sem o caminho completo) para uso no construtor
                    string nomeArquivoPdf = Path.GetFileName(caminhoPdf);

                    // Criar o arquivo PDF com o conteúdo, nome do arquivo e caminho escolhido pelo usuário
                    PDF pdf = new PDF(nomeArquivoPdf, conteudo, caminhoPdf);

                    MessageBox.Show($"Arquivo Salvo em: {caminhoPdf}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar PDF: {ex.Message}");
                MessageBox.Show("Erro ao salvar PDF. Verifique se o arquivo não está em uso ou se possui permissões suficientes.");
            }
        }




        private async void CalcularImc(object sender, EventArgs e)
        {
            // Converter a altura e o peso para string e remover o ponto decimal se presente
            string alturaStr = InputAltura.Text.Replace(".", "");
            string pesoStr = InputPeso.Text.Replace(".", "");

            if (float.TryParse(alturaStr, out float valorAltura) && float.TryParse(pesoStr, out float valorPeso))
            {
                // Exibir indicador de carregamento
                InputResultado.Text = "Carregando...";

                // Calcular o IMC
                float imc = valorPeso / (valorAltura * valorAltura);

                // Multiply by 10000 to shift the decimal point to the right by 4 places
                float number_imc = imc * 10000;

                // Round the number to two decimal places
                number_imc = (float)Math.Round(number_imc, 2);

                // Classificar o peso de acordo com a tabela fornecida
                string classificacao;
                if (number_imc < 18.5)
                {
                    classificacao = "Abaixo do peso";
                    imgLoad("./Personagens/Magreza_Extrema.png");

                    Resultado.ForeColor = Color.White;
                    Resultado.BackColor = Color.GreenYellow;
                }
                else if (number_imc < 24.9)
                {
                    classificacao = "Peso normal";
                    imgLoad("./Personagens/Peso_Ideial.png");

                    Resultado.ForeColor = Color.White;
                    Resultado.BackColor = Color.Green;
                }
                else if (imc < 29.9)
                {
                    classificacao = "Sobrepeso";
                    imgLoad("./Personagens/Sobre_Peso.png");

                    Resultado.ForeColor = Color.White;
                    Resultado.BackColor = Color.Orange;
                }
                else if (number_imc < 39.9)
                {
                    classificacao = "Obesidade";
                    imgLoad("./Personagens/Sobre_Peso.png");
                    Resultado.ForeColor = Color.White;
                    Resultado.BackColor = Color.Red;
                }
                else
                {
                    classificacao = "Obesidade grave";
                    imgLoad("./Personagens/Sobre_Peso.png");
                    Resultado.ForeColor = Color.White;
                    Resultado.BackColor = Color.Red;
                }

                Console.WriteLine($"IMC REAL => {imc} IMC CONVERTIDO =>{number_imc}");

                // Convert the float to a string
                string number_imc_string = number_imc.ToString();

                Resultado.Text = number_imc_string;

                // Enviar altura e peso para o método de envio de pergunta
                OpenIa openIa = new OpenIa();
                string altura = alturaStr;
                string peso = pesoStr;

                string resposta = await openIa.EnviarAlturaEPeso(altura, peso);

            
                // Converter a resposta JSON em objeto e obter o texto da resposta
                dynamic jsonResponse = JsonConvert.DeserializeObject(resposta);
                string respostaText = jsonResponse.response;

                // Atualizar o campo de texto com a resposta formatada
                InputResultado.Text = respostaText;
            }
            else
            {
                Console.WriteLine("Não foi possível converter os valores para float");
            }
        }

        private void abrirSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = "http://www.gestaoescolar.diaadia.pr.gov.br/modules/conteudo/conteudo.php?conteudo=195";
                myProcess.Start();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        



    }


    #endregion
}
