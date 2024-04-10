namespace Calculadora_C_;

using Calculadora_C_.DbScripAsync;

public partial class Calculadora_Comun:Form
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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





    public class input_area : System.Windows.Forms.TextBox
    {

        public input_area(double resultado)
        {
            this.Multiline = true;
            this.AutoSize = true;
            this.Location = new System.Drawing.Point(10, 20); // Posição do TextBox no formulário.
            this.Name = "inputBox"; // Nome do TextBox.
            this.Text = resultado.ToString();
            this.Width = 363; // Largura do TextBox.
            this.Height = 50; // Altura do TextBox
            this.TabIndex = 0; // Índice de 
            this.TextAlign = HorizontalAlignment.Right ;
            this.Font = new System.Drawing.Font("ArialBlack", this.Height * 0.5f, FontStyle.Regular);
           
          

            // Adiciona o evento KeyPress
            this.KeyPress += new KeyPressEventHandler(this.inputBox_KeyPress);
        }



        // Método para tratar o evento KeyPress
        // Método para tratar o evento KeyPress
        private void inputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se a tecla pressionada é um número, um controle (como backspace) ou o ponto.
            // Se não for, cancela a ação.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Se for o ponto, verifica se já existe um no texto. Se existir, cancela a ação.
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        public double PegarValor()
        {
            // Tenta converter o texto para um número inteiro
            if (double.TryParse(this.Text, out double valor))
            {
                // Retorna o valor se a conversão for bem-sucedida
                return valor;
            }
            else
            {
                // Retorna 0 se a conversão falhar
                return 0;
            }
        }
        public void DefinirValor(double valor)
        {
            this.Text = valor.ToString();
        }

    }

    public partial class buttons_area : UserControl
    {
        input_area Input_Area = new input_area(0);

        private dbScriptSybc dbScript;

        public buttons_area(dbScriptSybc dbScript)
        {

            this.dbScript = dbScript;
            // Primeira Fileira de Butões 3 =>  1,2,3
            // Segunda Fileira de Butões  3 =>  4,5,6
            // Terceira filiera de butões 3 =>  7.8,9

            // Configurações dos botões
            int larguraBotao = 87;
            int alturaBotao = 80;

            //Lagura  butão Eventos
            int larguraBotaoEvent = 80;
            int alturaBotaoEvent = 51;

            //Controle de Lagura dos Containes
            int larguraContainerEvent = 600;

            this.Size = new System.Drawing.Size(380, larguraContainerEvent); // Tamanho do TextBox.
            // Definir a posição inicial do controle na janela pai
            this.Location = new System.Drawing.Point(10, 0);

            // ================================= Grade 1 ====================================

            // ================================= Butões Numericos ==============================

            // Criar e posicionar botões individualmente
            Button btn1 = new Button();
            btn1.Text = "1";
            btn1.Width = larguraBotao;
            btn1.Height = alturaBotao;
            btn1.Font = new System.Drawing.Font("ArialBlack", 25, FontStyle.Regular);
            btn1.Click += buttonsClick;

            Button btn2 = new Button();
            btn2.Text = "2";
            btn2.Width = larguraBotao;
            btn2.Height = alturaBotao;
            btn2.Font = new System.Drawing.Font("ArialBlack", 25, FontStyle.Regular);
            btn2.Click += buttonsClick;

            Button btn3 = new Button();
            btn3.Text = "3";
            btn3.Width = larguraBotao;
            btn3.Height = alturaBotao;
            btn3.Font = new System.Drawing.Font("ArialBlack", 25, FontStyle.Regular);
            btn3.Click += buttonsClick;

            Button btn4 = new Button();
            btn4.Text = "4";
            btn4.Width = larguraBotao;
            btn4.Height = alturaBotao;
            btn4.Font = new System.Drawing.Font("ArialBlack", 25, FontStyle.Regular);
            btn4.Click += buttonsClick;

            Button btn5 = new Button();
            btn5.Text = "5";
            btn5.Width = larguraBotao;
            btn5.Height = alturaBotao;
            btn5.Font = new System.Drawing.Font("ArialBlack", 25, FontStyle.Regular);
            btn5.Click += buttonsClick;

            Button btn6 = new Button();
            btn6.Text = "6";
            btn6.Width = larguraBotao;
            btn6.Height = alturaBotao;
            btn6.Font = new System.Drawing.Font("ArialBlack", 25, FontStyle.Regular);
            btn6.Click += buttonsClick;

            Button btn7 = new Button();
            btn7.Text = "7";
            btn7.Width = larguraBotao;
            btn7.Height = alturaBotao;
            btn7.Font = new System.Drawing.Font("ArialBlack", 25, FontStyle.Regular);
            btn7.Click += buttonsClick;

            Button btn8 = new Button();
            btn8.Text = "8";
            btn8.Width = larguraBotao;
            btn8.Height = alturaBotao;
            btn8.Font = new System.Drawing.Font("ArialBlack", 25, FontStyle.Regular);
            btn8.Click += buttonsClick;

            Button btn9 = new Button();
            btn9.Text = "9";
            btn9.Width = larguraBotao;
            btn9.Height = alturaBotao;
            btn9.Font = new System.Drawing.Font("ArialBlack", 25, FontStyle.Regular);
            btn9.Click += buttonsClick;

            Button btn0 = new Button();
            btn0.Text = "0";
            btn0.Width = larguraBotao;
            btn0.Height = alturaBotao;
            btn0.Font = new System.Drawing.Font("ArialBlack", 25, FontStyle.Regular);
            btn0.Click += buttonsClick;

            Button btnPonto = new Button();
            btnPonto.Text = ",";
            btnPonto.Width = larguraBotao;
            btnPonto.Height = alturaBotao;
            btnPonto.Font = new System.Drawing.Font("ArialBlack", 25, FontStyle.Regular);
            btnPonto.Click += buttonsClick;

            btnPonto.ForeColor = Color.White; // Cor do texto
            btnPonto.BackColor = Color.FromArgb(36, 34, 34); // Cor de fundo cinza claro
            btnPonto.FlatAppearance.BorderColor = Color.Gray; // Cor da borda cinza
            btnPonto.FlatStyle = FlatStyle.Flat; // Estilo da borda
            btnPonto.FlatAppearance.BorderSize = 1; // Espessura da borda

            btnPonto.Click += buttonsClick;

            Button btnResult = new Button();
            btnResult.Text = "=";
            btnResult.Width = larguraBotao;
            btnResult.Height = alturaBotao;
            btnResult.Font = new System.Drawing.Font("ArialBlack", 25, FontStyle.Regular);

            btnResult.ForeColor = Color.White; // Cor do texto
            btnResult.BackColor = Color.FromArgb(36, 34, 34); // Cor de fundo cinza claro
            btnResult.FlatAppearance.BorderColor = Color.Gray; // Cor da borda cinza
            btnResult.FlatStyle = FlatStyle.Flat; // Estilo da borda
            btnResult.FlatAppearance.BorderSize = 1; // Espessura da borda

            btnResult.Click += buttonsClick;

            // ================================= Butões de Acões ==============================

            Button adicao = new Button();
            adicao.Text = "+";
            adicao.Width = larguraBotaoEvent;
            adicao.Height = alturaBotaoEvent;
            adicao.Font = new System.Drawing.Font("ArialBlack", 25, FontStyle.Regular);

            adicao.ForeColor = Color.White; // Cor do texto
            adicao.BackColor = Color.FromArgb(36, 34, 34); // Cor de fundo cinza claro
            adicao.FlatAppearance.BorderColor = Color.Gray; // Cor da borda cinza
            adicao.FlatStyle = FlatStyle.Flat; // Estilo da borda
            adicao.FlatAppearance.BorderSize = 1; // Espessura da borda

            adicao.Click += buttonsClick;

            Button subtracao = new Button();
            subtracao.Text = "-";
            subtracao.Width = larguraBotaoEvent;
            subtracao.Height = alturaBotaoEvent;
            subtracao.Font = new System.Drawing.Font("ArialBlack", 25, FontStyle.Regular);

            subtracao.ForeColor = Color.White; // Cor do texto
            subtracao.BackColor = Color.FromArgb(36, 34, 34); // Cor de fundo cinza claro
            subtracao.FlatAppearance.BorderColor = Color.Gray; // Cor da borda cinza
            subtracao.FlatStyle = FlatStyle.Flat; // Estilo da borda
            subtracao.FlatAppearance.BorderSize = 1; // Espessura da borda

            subtracao.Click += buttonsClick;

            Button multiplicacao = new Button();
            multiplicacao.Text = "x";
            multiplicacao.Width = larguraBotaoEvent;
            multiplicacao.Height = alturaBotaoEvent;
            multiplicacao.Font = new System.Drawing.Font("ArialBlack", 25, FontStyle.Regular);

            multiplicacao.ForeColor = Color.White; // Cor do texto
            multiplicacao.BackColor = Color.FromArgb(36, 34, 34); // Cor de fundo cinza claro
            multiplicacao.FlatAppearance.BorderColor = Color.Gray; // Cor da borda cinza
            multiplicacao.FlatStyle = FlatStyle.Flat; // Estilo da borda
            multiplicacao.FlatAppearance.BorderSize = 1; // Espessura da borda

            multiplicacao.Click += buttonsClick;

            Button divisao = new Button();
            divisao.Text = "÷";
            divisao.Width = larguraBotaoEvent;
            divisao.Height = alturaBotaoEvent;
            divisao.Font = new System.Drawing.Font("ArialBlack", 25, FontStyle.Regular);

            divisao.ForeColor = Color.White; // Cor do texto
            divisao.BackColor = Color.FromArgb(36, 34, 34); // Cor de fundo cinza claro
            divisao.FlatAppearance.BorderColor = Color.Gray; // Cor da borda cinza
            divisao.FlatStyle = FlatStyle.Flat; // Estilo da borda
            divisao.FlatAppearance.BorderSize = 1; // Espessura da borda

            divisao.Click += buttonsClick;

            Button porcentagem = new Button();
            porcentagem.Text = "%";
            porcentagem.Width = larguraBotaoEvent;
            porcentagem.Height = alturaBotaoEvent;
            porcentagem.Font = new System.Drawing.Font("ArialBlack", 25, FontStyle.Regular);

            porcentagem.ForeColor = Color.White; // Cor do texto
            porcentagem.BackColor = Color.FromArgb(36, 34, 34); // Cor de fundo cinza claro
            porcentagem.FlatAppearance.BorderColor = Color.Gray; // Cor da borda cinza
            porcentagem.FlatStyle = FlatStyle.Flat; // Estilo da borda
            porcentagem.FlatAppearance.BorderSize = 1; // Espessura da borda

            porcentagem.Click += buttonsClick;

            Button limpar = new Button();
            limpar.Text = "CE";
            limpar.Width = larguraBotaoEvent;
            limpar.Height = alturaBotaoEvent;
            limpar.Font = new System.Drawing.Font("ArialBlack", 25, FontStyle.Regular);


            limpar.ForeColor = Color.White; // Cor do texto
            limpar.BackColor = Color.FromArgb(219, 18, 18); // Cor de fundo cinza claro
            limpar.FlatAppearance.BorderColor = Color.FromArgb(219, 18, 18); // Cor da borda cinza
            limpar.FlatStyle = FlatStyle.Flat; // Estilo da borda
            limpar.FlatAppearance.BorderSize = 1; // Espessura da borda

            limpar.Click += buttonsClick;

            // Criar a grade horizontal
            FlowLayoutPanel grade01 = new FlowLayoutPanel();
            grade01.FlowDirection = FlowDirection.LeftToRight;
            // grade01.BackColor = Color.Green; // Definindo a cor de fundo
            grade01.Width = 280; // Preenche a largura disponível
            grade01.Height = larguraContainerEvent - 7;

            //==================== Grade Vertical ====================
            FlowLayoutPanel gradeVertical = new FlowLayoutPanel();
            gradeVertical.FlowDirection = FlowDirection.TopDown;
            // gradeVertical.BackColor = Color.Red;
            gradeVertical.Width = 87;
            gradeVertical.Height = larguraContainerEvent - 7;

            // =================== Criar um Layout Vertical para Guarda o Grade1 e  GradeVertical ============================


            FlowLayoutPanel GradeAll = new FlowLayoutPanel();
            GradeAll.FlowDirection = FlowDirection.LeftToRight;
            // GradeAll.BackColor = Color.LightGray; // Definindo a cor de fundo
            GradeAll.Width = 390;
            GradeAll.Height = larguraContainerEvent;

            GradeAll.Location = new System.Drawing.Point(0, 80);


            GradeAll.Controls.Add(grade01);
            GradeAll.Controls.Add(gradeVertical);



            // ================================================================================================================

            grade01.Controls.Add(btn1);
            grade01.Controls.Add(btn2);
            grade01.Controls.Add(btn3);
            grade01.Controls.Add(btn4);
            grade01.Controls.Add(btn5);
            grade01.Controls.Add(btn6);
            grade01.Controls.Add(btn7);
            grade01.Controls.Add(btn8);
            grade01.Controls.Add(btn9);
            grade01.Controls.Add(btn0);
            grade01.Controls.Add(btnPonto);
            grade01.Controls.Add(btnResult);

            // ===================== Butoes Grade Vertical ==================================

            gradeVertical.Controls.Add(limpar);
            gradeVertical.Controls.Add(porcentagem);
            gradeVertical.Controls.Add(subtracao);
            gradeVertical.Controls.Add(multiplicacao);
            gradeVertical.Controls.Add(divisao);
            gradeVertical.Controls.Add(adicao);


            // ================================= Grade 2 ====================================
            // Eventos Acionadores 
            // this.BackColor = Color.Red;

            this.Controls.Add(Input_Area);
            this.Controls.Add(GradeAll);


        }



        //     // Declare uma variável de classe para armazenar o valor em memória
        //     private double valorEmMemoria = 0;
        //     // Declare uma variável de classe para armazenar a operação selecionada
        //     private char operacaoSelecionada = ' ';

        //     private void buttonsClick(object sender, EventArgs e)
        //     {
        //         // Converte o remetente para um botão
        //         Button button = sender as Button;

        //         // Verifica se a conversão foi bem-sucedida
        //         if (button != null)
        //         {
        //             // Se o texto do botão for "CE", limpa o campo
        //             if (button.Text == "CE")
        //             {
        //                 Input_Area.DefinirValor(0);
        //             }
        //             // Tenta converter o texto do botão para um número inteiro
        //             else if (int.TryParse(button.Text, out int valor))
        //             {
        //                 // Se o valor atual é 0, substitui pelo novo número
        //                 if (Input_Area.Text == "0")
        //                 {
        //                     Input_Area.Text = valor.ToString();
        //                 }
        //                 // Senão, concatena o novo número ao valor existente
        //                 else
        //                 {
        //                     string valorAntigo = Input_Area.Text;
        //                     Input_Area.Text = valorAntigo + valor.ToString();
        //                 }
        //             }

        //             if (button.Text == ",")
        //             {
        //                 // Verifica se já existe um ponto no campo de entrada
        //                 if (!Input_Area.Text.Contains("."))
        //                 {

        //                     if (Input_Area.Text == "0")
        //                     {
        //                         return;
        //                     }
        //                     // Senão, concatena o novo número ao valor existente
        //                     else
        //                     {
        //                         string valorAntigo = Input_Area.Text;
        //                         Input_Area.Text = valorAntigo + ".";
        //                     }

        //                 }
        //             }

        //             else if (button.Text == "+")
        //             {
        //                 // Armazene o valor atual de entrada
        //                 double valorAtual = Input_Area.PegarValor();

        //                 // Realize a operação pendente (se houver)
        //                 RealizarOperacaoPendente(valorAtual);

        //                 // Armazene esse valor na memória
        //                 valorEmMemoria = valorAtual;

        //                 // Defina a operação selecionada como soma
        //                 operacaoSelecionada = '+';

        //                 // Limpe a área de entrada para permitir a entrada de um novo número
        //                 Input_Area.DefinirValor(0);
        //             }

        //             // Adicione condições para lidar com outras operações aritméticas
        //             else if (button.Text == "-")
        //             {
        //                 double valorAtual = Input_Area.PegarValor();

        //                 // Realize a operação pendente (se houver)
        //                 RealizarOperacaoPendente(valorAtual);

        //                 // Armazene esse valor na memória
        //                 valorEmMemoria = valorAtual;

        //                 // Defina a operação selecionada como subtração
        //                 operacaoSelecionada = '-';

        //                 // Limpe a área de entrada para permitir a entrada de um novo número
        //                 Input_Area.DefinirValor(0);
        //             }
        //             // Adicione uma condição para lidar com a operação de multiplicação (*)
        //             else if (button.Text == "x")
        //             {

        //                 double valorAtual = Input_Area.PegarValor();

        //                 // Realize a operação pendente (se houver)
        //                 RealizarOperacaoPendente(valorAtual);

        //                 // Armazene esse valor na memória
        //                 valorEmMemoria = valorAtual;

        //                 // Defina a operação selecionada como multiplicação
        //                 operacaoSelecionada = '*';

        //                 // Limpe a área de entrada para permitir a entrada de um novo número
        //                 Input_Area.DefinirValor(0);
        //             }

        //             // Adicione uma condição para lidar com a operação de divisão (÷)
        //             else if (button.Text == "÷")
        //             {
        //                 double valorAtual = Input_Area.PegarValor();

        //                 // Realize a operação pendente (se houver)
        //                 RealizarOperacaoPendente(valorAtual);

        //                 // Armazene esse valor na memória
        //                 valorEmMemoria = valorAtual;

        //                 // Defina a operação selecionada como divisão
        //                 operacaoSelecionada = '/';

        //                 // Limpe a área de entrada para permitir a entrada de um novo número
        //                 Input_Area.DefinirValor(0);
        //             }

        //             // Adicione uma condição para lidar com a operação de porcentagem (%)
        //             else if (button.Text == "%")
        //             {
        //                 double valorAtual = Input_Area.PegarValor();

        //                 // Realize a operação pendente (se houver)
        //                 RealizarOperacaoPendente(valorAtual);

        //                 // Armazene esse valor na memória
        //                 valorEmMemoria = valorAtual;

        //                 // Defina a operação selecionada como porcentagem
        //                 operacaoSelecionada = '%';

        //                 // Limpe a área de entrada para permitir a entrada de um novo número
        //                 Input_Area.DefinirValor(0);
        //             }

        //             // Adicione uma condição para lidar com o botão de igual (=)
        //             else if (button.Text == "=")
        //             {
        //                 // Obtenha o valor atual de entrada
        //                 double novoValor = Input_Area.PegarValor();

        //                 // Realize a operação pendente (se houver)
        //                 RealizarOperacaoPendente(novoValor);

        //                 // Limpe a memória após exibir o resultado
        //                 valorEmMemoria = 0;
        //                 operacaoSelecionada = ' ';
        //             }
        //             else
        //             {
        //                 // O texto do botão não é um número válido
        //                 Console.WriteLine("O texto do botão não é um número válido.");
        //             }
        //         }
        //         else
        //         {
        //             // O remetente não é um botão
        //             Console.WriteLine("O remetente não é um botão.");
        //         }
        //     }

        //     // Método para realizar a operação pendente (se houver)
        //     private void RealizarOperacaoPendente(double novoValor)
        //     {
        //         // Verifique se há uma operação pendente
        //         if (operacaoSelecionada != ' ')
        //         {
        //             // Realize a operação com base na operação selecionada
        //             switch (operacaoSelecionada)
        //             {
        //                 case '+':
        //                     valorEmMemoria += novoValor;
        //                     break;
        //                 case '-':
        //                     valorEmMemoria -= novoValor;
        //                     break;
        //                 case '*':
        //                     valorEmMemoria *= novoValor;
        //                     break;
        //                 case '/':
        //                     // Verifique se o novo valor é zero para evitar a divisão por zero
        //                     if (novoValor != 0)
        //                     {
        //                         valorEmMemoria /= novoValor;
        //                     }
        //                     else
        //                     {
        //                         Console.WriteLine("Erro: Divisão por zero.");
        //                         // Você pode lidar com a divisão por zero de acordo com sua lógica específica aqui
        //                         // Por exemplo, definir o valor em memória como zero ou exibir uma mensagem de erro para o usuário
        //                     }
        //                     break;
        //                 case '%':
        //                     // Calcule a porcentagem corretamente
        //                     valorEmMemoria = valorEmMemoria * novoValor / 100;
        //                     break;
        //             }

        //             // Exiba o resultado na área de entrada
        //             Input_Area.DefinirValor(valorEmMemoria);
        //         }
        //     }

        private double valorEmMemoria = 0;
        private char operacaoSelecionada = ' ';
        private bool limparTela = false;

        public event EventHandler OperacaoHistoricoRealizada;

        public void buttonsClick(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button != null)
            {
                string buttonText = button.Text;

                if (buttonText == "CE")
                {
                    LimparTela();
                    return;
                }

                if (double.TryParse(buttonText, out double valor))
                {
                    if (limparTela)
                    {
                        Input_Area.DefinirValor(valor);
                        limparTela = false;
                    }
                    else
                    {
                        string novoValor = Input_Area.PegarValor().ToString() + valor;
                        Input_Area.DefinirValor(double.Parse(novoValor));
                    }
                }
                else if (buttonText == "," && !Input_Area.PegarValor().ToString().Contains("."))
                {
                    string valorAtual = Input_Area.PegarValor().ToString();
                    Input_Area.DefinirValor(double.Parse(valorAtual + "."));
                }
                else if (buttonText == "+" || buttonText == "-" || buttonText == "x" || buttonText == "÷" || buttonText == "%")
                {
                    if (!limparTela) // Verifica se há um novo número para calcular
                    {
                        RealizarOperacaoPendente();
                    }

                    operacaoSelecionada = buttonText[0];
                    valorEmMemoria = Input_Area.PegarValor();
                    limparTela = true; // Pronto para inserir um novo número
                }
                else if (buttonText == "=")
                {
                    RealizarOperacaoPendente(); // Realiza a operação pendente
                    limparTela = true; // Pronto para inserir um novo número
                }
            }
        }

        private void LimparTela()
        {
            Input_Area.DefinirValor(0);
            valorEmMemoria = 0;
            operacaoSelecionada = ' ';
            limparTela = false;
        }

        private void RealizarOperacaoPendente()
        {
            if (operacaoSelecionada != ' ')
            {
                double novoValor = Input_Area.PegarValor();
                double resultado = 0;

                switch (operacaoSelecionada)
                {
                    case '+':
                        resultado = valorEmMemoria + novoValor;
                        dbScript.inserirHistorico($"{valorEmMemoria} + {novoValor}", resultado);
                        break;
                    case '-':
                        resultado = valorEmMemoria - novoValor;
                        dbScript.inserirHistorico($"{valorEmMemoria} - {novoValor}", resultado);
                        break;
                    case 'x':
                        resultado = valorEmMemoria * novoValor;
                        dbScript.inserirHistorico($"{valorEmMemoria} * {novoValor}", resultado);
                        break;
                    case '÷':
                        if (novoValor != 0) {
                            resultado = valorEmMemoria / novoValor;
                            dbScript.inserirHistorico($"{valorEmMemoria} + {novoValor}", resultado);
                        }
                        else
                            Console.WriteLine("Erro: Divisão por zero!");
                        break;
                    case '%':
                        resultado = valorEmMemoria * novoValor / 100;
                        dbScript.inserirHistorico($"{valorEmMemoria} * {novoValor} / 100", resultado);
                        break;
                    default:
                        break;
                }

                Input_Area.DefinirValor(resultado);
                valorEmMemoria = resultado;

                // Dispara o evento para notificar a realização da operação no histórico
                OnOperacaoHistoricoRealizada();
            }

            
        }

        public void OnOperacaoHistoricoRealizada()
        {
            // Verifica se há inscritos no evento e dispara-o
            Console.WriteLine("Pode Atualizar o Historico...");
            OperacaoHistoricoRealizada?.Invoke(this, EventArgs.Empty);
        }



    }


    // private void InitializeComponent()
    // {
    //     this.components = new System.ComponentModel.Container();
    //     this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    //     this.ClientSize = new System.Drawing.Size(400, 550);
    //     this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle; // Define a borda do formulário como única
    //     this.MaximizeBox = false; // Desativa o botão de maximizar
    //     this.Text = "Calculadora";
    //     buttons_area buttons_Area = new buttons_area();

    //     //Adiconar o TextBox ao Area de Renderização
    //     this.Controls.Add(buttons_Area);

    // }

    #endregion
}
