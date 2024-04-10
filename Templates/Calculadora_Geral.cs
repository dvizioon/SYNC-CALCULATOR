using Calculadora_C_;
using Calculadora_C;
using System.IO; // Adicione este using para trabalhar com arquivos
using System.Threading; // Adicione este using para trabalhar com threads
using System.Diagnostics;
using System.ComponentModel;

using Calculadora_C_.Server;
using Calculadora_C_.DbScripAsync;
using Calculadora_C_.Configuracoes;

namespace Calculadora_C
{
    public partial class Calculadora_Geral : Form
    {
        private IContainer components = null; // Adicione esta linha


        // Calculadora_Peso calculadora_peso;
        // Calculadora_Comun calculadora_comun;

        dbScriptSybc dbScript = new dbScriptSybc("criar");
        public Calculadora_Geral()
        {


            InitializeComponent();


        }

        public event Action<int> atualizarHistoricoAgora;


        public class MenuLateral : Panel
        {
            private Button btnFechar;
            TextBox inputValue = new TextBox();

            Panel menuEscolhaCalculadora = new Panel();

            Panel menuEscolha_Conversor = new Panel();

            Image iconMais = Image.FromFile("./Icons/mais.png");

           

            // Evento que é acionado quando o valor do input muda
            public event Action<int> OnInputValueChanged;


            public MenuLateral()
            {
                // Configurações básicas do painel do menu lateral
                this.BackColor = Color.FromArgb(52, 73, 94); // Cor de fundo
                this.Dock = DockStyle.Left;
                this.Width = 200;


                inputValue.Visible = false;
                Image IconMaisSize = iconMais.GetThumbnailImage(20, 20, null, IntPtr.Zero);


                // Remasterizando Menu

                Label label_Calculadora_menu = new Label();
                label_Calculadora_menu.Text = "Menu";
                label_Calculadora_menu.Font = new System.Drawing.Font("ArialBlack", 25, FontStyle.Regular);
                label_Calculadora_menu.TextAlign = ContentAlignment.MiddleCenter;
                label_Calculadora_menu.Width = 200;
                label_Calculadora_menu.Height = 50;
                // label_Calculadora_menu.BackColor = Color.Red;
                label_Calculadora_menu.ForeColor = Color.White;

                // Botão para fechar o menu
                btnFechar = new Button();
                btnFechar.Text = "X";
                btnFechar.ForeColor = Color.White;
                btnFechar.Location = new System.Drawing.Point(0, 50);
                btnFechar.BackColor = Color.FromArgb(192, 57, 43);
                btnFechar.FlatStyle = FlatStyle.Flat;
                btnFechar.Font = new System.Drawing.Font("ArialBlack", 16, FontStyle.Regular);
                btnFechar.FlatAppearance.BorderSize = 0;
                btnFechar.Width = 200;
                btnFechar.Height = 50;
                btnFechar.Click += BtnFechar_Click; // Evento de clique para fechar o menu


                Label label_Calculadora = new Label();
                label_Calculadora.Text = "Calculadora";
                label_Calculadora.ForeColor = Color.White;
                label_Calculadora.Font = new System.Drawing.Font("ArialBlack", 15, FontStyle.Regular);
                label_Calculadora.TextAlign = ContentAlignment.MiddleLeft;
                label_Calculadora.Width = 120;
                label_Calculadora.Height = 50;
                label_Calculadora.Anchor = AnchorStyles.Top;
                label_Calculadora.Click += OpenPainelCalculadora;

                PictureBox picture_img_Calculadora = new PictureBox();
                picture_img_Calculadora.Size = new Size(30, 50);
                picture_img_Calculadora.SizeMode = PictureBoxSizeMode.CenterImage; // Centraliza a imagem
                picture_img_Calculadora.Image = IconMaisSize; // Adicionar o ícone ao botão
                picture_img_Calculadora.Anchor = AnchorStyles.Top;
                picture_img_Calculadora.Click += OpenPainelCalculadora;

                FlowLayoutPanel painelCalculadora_img = new FlowLayoutPanel();
                painelCalculadora_img.FlowDirection = FlowDirection.LeftToRight;
                painelCalculadora_img.Size = new Size(200, 50);
                painelCalculadora_img.Click += OpenPainelCalculadora;
                painelCalculadora_img.Controls.Add(picture_img_Calculadora);
                painelCalculadora_img.Controls.Add(label_Calculadora);

                Label label_Calculadora_separator = new Label();
                label_Calculadora_separator.Text = "";
                label_Calculadora_separator.Location = new Point(10, 0); // Posição da linha
                label_Calculadora_separator.BackColor = Color.White;
                label_Calculadora_separator.Width = 194;
                label_Calculadora_separator.Height = 2;


                menuEscolhaCalculadora.Width = 194;
                menuEscolhaCalculadora.Height = 100;
                // menuEscolhaCalculadora.BackColor = Color.Red;
                menuEscolhaCalculadora.AutoScroll = true;

                // Adiconar os Butões ao Painel MenuEscolhaCalculadora

                // Carregar a imagem do ícone
                Image iconComun = Image.FromFile("./Icons/iconCalc.png");
                Image iconComunSize = iconComun.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                // Botão da Opção 1
                Button btnComun = new Button();
                btnComun.Text = "Comun";
                btnComun.ForeColor = Color.White;
                btnComun.BackColor = Color.FromArgb(44, 62, 80); // Cor de fundo do botão
                btnComun.FlatStyle = FlatStyle.Flat;
                btnComun.FlatAppearance.BorderSize = 0; // Remove a borda do botão
                btnComun.Dock = DockStyle.Top;
                btnComun.Font = new System.Drawing.Font("ArialBlack", 15, FontStyle.Regular);
                btnComun.Height = 50;
                btnComun.Width = 194;
                btnComun.TextAlign = ContentAlignment.MiddleLeft;
                btnComun.Image = iconComunSize; // Adicionar o ícone ao botão
                btnComun.TextImageRelation = TextImageRelation.ImageBeforeText; // Colocar o ícone antes do texto
                btnComun.Click += buttonComun; // Evento de clique para a Opção 1


                //itens Calculadora Add in Calculadoras Container
                menuEscolhaCalculadora.Controls.Add(btnComun);


                Label label_Conversor = new Label();
                label_Conversor.Text = "Conversor";
                label_Conversor.ForeColor = Color.White;
                label_Conversor.Font = new System.Drawing.Font("ArialBlack", 15, FontStyle.Regular);
                label_Conversor.TextAlign = ContentAlignment.MiddleLeft;
                label_Conversor.Width = 120;
                label_Conversor.Height = 50;
                label_Conversor.Anchor = AnchorStyles.Top;
                label_Conversor.Click += OpenPainelConversor;

                PictureBox picture_imgConversor = new PictureBox();
                picture_imgConversor.Size = new Size(30, 50);
                picture_imgConversor.SizeMode = PictureBoxSizeMode.CenterImage; // Centraliza a imagem
                picture_imgConversor.Image = IconMaisSize; // Adicionar o ícone ao botão
                picture_imgConversor.Anchor = AnchorStyles.Top;
                picture_imgConversor.Click += OpenPainelConversor;

                FlowLayoutPanel painel_Converso_label_img = new FlowLayoutPanel();
                painel_Converso_label_img.FlowDirection = FlowDirection.LeftToRight;
                painel_Converso_label_img.Size = new Size(200, 50);
                painel_Converso_label_img.Controls.Add(picture_imgConversor);
                painel_Converso_label_img.Controls.Add(label_Conversor);
                painel_Converso_label_img.Click += OpenPainelConversor;

                painel_Converso_label_img.Controls.Add(picture_imgConversor);
                painel_Converso_label_img.Controls.Add(label_Conversor);

                Label label_Conversor_separator = new Label();
                label_Conversor_separator.Text = "";
                label_Conversor_separator.Location = new Point(10, 0); // Posição da linha
                label_Conversor_separator.BackColor = Color.White;
                label_Conversor_separator.Width = 194;
                label_Conversor_separator.Height = 2;


                menuEscolha_Conversor.Width = 194;
                menuEscolha_Conversor.Height = 100;
                // menuEscolha_Conversor.BackColor = Color.Red;
                menuEscolha_Conversor.AutoScroll = true;

                // Carregar a imagem do ícone
                Image iconCiencias = Image.FromFile("./Icons/iconCiencias.png");
                Image iconCienciaSize = iconCiencias.GetThumbnailImage(20, 20, null, IntPtr.Zero);

                // Botão da Opção 1
                Button btnIMC = new Button();
                btnIMC.Text = "IMC";
                btnIMC.ForeColor = Color.White;
                btnIMC.BackColor = Color.FromArgb(44, 62, 80); // Cor de fundo do botão
                btnIMC.FlatStyle = FlatStyle.Flat;
                btnIMC.FlatAppearance.BorderSize = 0; // Remove a borda do botão
                btnIMC.Dock = DockStyle.Top;
                btnIMC.Font = new System.Drawing.Font("ArialBlack", 15, FontStyle.Regular);
                btnIMC.Height = 50;
                btnIMC.Image = iconCienciaSize; // Adicionar o ícone ao botão
                btnIMC.TextImageRelation = TextImageRelation.ImageBeforeText; // Colocar o ícone antes do texto
                btnIMC.TextAlign = ContentAlignment.MiddleCenter;
                btnIMC.Click += buttonIMC; // Evento de clique para a Opção 1

                //itens Calculadora Add in Medidas Container
                menuEscolha_Conversor.Controls.Add(btnIMC);

                Image iconConfig = Image.FromFile("./Icons/configuracao.png");
                Image iconConfigSize = iconConfig.GetThumbnailImage(20, 20, null, IntPtr.Zero);

                Button btnConfiguracao = new Button();
                btnConfiguracao.Text = "Configurações";
                btnConfiguracao.Location = new System.Drawing.Point(0, 450);
                btnConfiguracao.ForeColor = Color.White;
                btnConfiguracao.BackColor = Color.FromArgb(35, 39, 43); // Cor de fundo do botão
                btnConfiguracao.FlatStyle = FlatStyle.Flat;
                btnConfiguracao.FlatAppearance.BorderSize = 0; // Remove a borda do botão
                btnConfiguracao.Font = new System.Drawing.Font("ArialBlack", 15, FontStyle.Regular);
                btnConfiguracao.Width = 200;
                btnConfiguracao.Height = 50;
                btnConfiguracao.Image = iconConfigSize; // Adicionar o ícone ao botão
                btnConfiguracao.TextImageRelation = TextImageRelation.ImageBeforeText; // Colocar o ícone antes do texto
                btnConfiguracao.TextAlign = ContentAlignment.MiddleCenter;
                btnConfiguracao.Click += buttonConfiguracao; // Evento de clique para a Opção 1


                FlowLayoutPanel painel = new FlowLayoutPanel();
                painel.FlowDirection = FlowDirection.TopDown;
                // painel.BackColor = Color.White;
                painel.Location = new System.Drawing.Point(0, 120);
                painel.Width = 200;
                painel.Height = 400;

                // Adiconar Calculadora
                painel.Controls.Add(painelCalculadora_img);
                painel.Controls.Add(label_Calculadora_separator);
                painel.Controls.Add(menuEscolhaCalculadora);

                // Adiconar Medidas
                painel.Controls.Add(painel_Converso_label_img);
                painel.Controls.Add(label_Conversor_separator);
                painel.Controls.Add(menuEscolha_Conversor);

                // Adiciona os controles ao painel do menu
                this.Controls.Add(label_Calculadora_menu);
                this.Controls.Add(btnFechar);
                this.Controls.Add(btnConfiguracao);
                this.Controls.Add(inputValue);
                this.Controls.Add(painel);


                // this.Controls.Add(btnBinario);  // posição 1
                // this.Controls.Add(btnComun); // posicão 0

            }

            // Evento de clique para fechar o menu

            private void OpenPainelCalculadora(object sender, EventArgs e)
            {


                if (menuEscolhaCalculadora.Height == 100)
                {
                    menuEscolhaCalculadora.Height = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        iconMais.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }

                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        iconMais.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }
                    menuEscolhaCalculadora.Height = 100;

                }

            }
            private void OpenPainelConversor(object sender, EventArgs e)
            {


                if (menuEscolha_Conversor.Height == 100)
                {
                    menuEscolha_Conversor.Height = 0;
                }
                else
                {
                    menuEscolha_Conversor.Height = 100;
                }

            }
            private void BtnFechar_Click(object sender, EventArgs e)
            {
                this.Width = 0; // Fecha o menu lateral
            }

            public void openMenu(int largura)
            {
                this.Width = largura;

            }


            public double PegarValorMenu()
            {
                // Tenta converter o texto para um número inteiro
                if (double.TryParse(inputValue.Text, out double valor))
                {
                    // Retorna o valor se a conversão for bem-sucedida
                    // Console.WriteLine(valor);
                    return valor;
                }
                else
                {
                    // Retorna 0 se a conversão falhar
                    return 0;
                }
            }
            public void buttonComun(object sender, EventArgs e)
            {
                double valor = 0;
                inputValue.Text = valor.ToString();
                OnInputValueChanged?.Invoke((int)valor);
            }

            public void buttonIMC(object sender, EventArgs e)
            {
                double valor = 1;
                inputValue.Text = valor.ToString();
                OnInputValueChanged?.Invoke((int)valor);
            }
            public void buttonConfiguracao(object sender, EventArgs e)
            {
                double valor = 2;
                inputValue.Text = valor.ToString();
                OnInputValueChanged?.Invoke((int)valor);
            }




        }


        // public class MenuHistorico : Panel
        // {
        //     private dbScriptSybc dbScript;

        //     public Panel menu_item_painel = new Panel();

        //     public MenuHistorico(dbScriptSybc dbScript)
        //     {
        //         this.dbScript = dbScript;
        //         this.BackColor = Color.FromArgb(52, 73, 94);
        //         this.Dock = DockStyle.Right;
        //         this.Width = 200;

        //         // Configuração visual do título do histórico
        //         Label label_Historico_menu = new Label();
        //         label_Historico_menu.Text = "Histórico";
        //         label_Historico_menu.Font = new Font("ArialBlack", 25, FontStyle.Regular);
        //         label_Historico_menu.TextAlign = ContentAlignment.MiddleCenter;
        //         label_Historico_menu.Width = 200;
        //         label_Historico_menu.Height = 50;
        //         label_Historico_menu.ForeColor = Color.White;


        //         // Botão para fechar o menu
        //         Button btnFechar = new Button();
        //         btnFechar.Text = "X";
        //         btnFechar.ForeColor = Color.White;
        //         btnFechar.Location = new Point(0, 50);
        //         btnFechar.BackColor = Color.FromArgb(192, 57, 43);
        //         btnFechar.FlatStyle = FlatStyle.Flat;
        //         btnFechar.Font = new Font("ArialBlack", 16, FontStyle.Regular);
        //         btnFechar.FlatAppearance.BorderSize = 0;
        //         btnFechar.Width = 200;
        //         btnFechar.Height = 50;
        //         btnFechar.Click += BtnMenuHistorico_Click;

        //         menu_item_painel.Location = new Point(0, 110);
        //         menu_item_painel.Size = new Size(200, 370);
        //         menu_item_painel.BackColor = Color.White;


        //         this.Controls.Add(label_Historico_menu);
        //         this.Controls.Add(btnFechar);
        //         this.Controls.Add(menu_item_painel);

        //         // Assinar evento personalizado para atualizar o histórico
        //         RenderizarTelas.AtualizacaoHistorico += AtualizarHistorico;

        //         // Exibir o histórico inicial
        //         AtualizarHistorico();
        //     }

        //     private void BtnMenuHistorico_Click(object sender, EventArgs e)
        //     {
        //         this.Width = 0; // Fecha o menu lateral
        //     }

        //     public void openMenuHistorico(int largura){
        //             this.Width = largura;
        //     }

        //     private void AtualizarHistorico()
        //     {
        //         // Limpar os controles existentes de histórico
        //         foreach (Control control in Controls.OfType<Label>().ToList())
        //         {
        //             Controls.Remove(control);
        //             control.Dispose();
        //         }

        //         // Obter o histórico de cálculos
        //         List<(string, double)> historico = dbScript.getHistorico();

        //         // Exibir o histórico na interface do usuário
        //         int yOffset = 120; // Posição vertical para exibir os itens do histórico

        //         foreach (var item in historico)
        //         {
        //             Label historicoLabel = new Label();
        //             historicoLabel.Text = $"Cálculo: {item.Item1}, Resultado: {item.Item2}";
        //             historicoLabel.ForeColor = Color.Black;
        //             historicoLabel.Location = new Point(10, yOffset); // Posição na interface
        //             historicoLabel.AutoSize = true; // Ajusta automaticamente o tamanho do controle
        //             menu_item_painel.Controls.Add(historicoLabel);
        //             yOffset += 30; // Incremento para a próxima posição vertical
        //             // menu_item_painel.Controls.Add(historico);
        //         }
        //     }
        // }


        public class MenuHistorico : Panel
        {
            private dbScriptSybc dbScript;

            public Panel menu_item_painel = new Panel();

            public MenuHistorico(dbScriptSybc dbScript)
            {
                this.dbScript = dbScript;
                this.BackColor = Color.FromArgb(52, 73, 94);
                this.Dock = DockStyle.Right;
                this.Width = 200;

                // Configuração visual do título do histórico
                Label label_Historico_menu = new Label();
                label_Historico_menu.Text = "Histórico";
                label_Historico_menu.Font = new Font("ArialBlack", 25, FontStyle.Regular);
                label_Historico_menu.TextAlign = ContentAlignment.MiddleCenter;
                label_Historico_menu.Width = 200;
                label_Historico_menu.Height = 50;
                label_Historico_menu.ForeColor = Color.White;


                // Botão para fechar o menu
                Button btnFechar = new Button();
                btnFechar.Text = "X";
                btnFechar.ForeColor = Color.White;
                btnFechar.Location = new Point(0, 50);
                btnFechar.BackColor = Color.FromArgb(192, 57, 43);
                btnFechar.FlatStyle = FlatStyle.Flat;
                btnFechar.Font = new Font("ArialBlack", 16, FontStyle.Regular);
                btnFechar.FlatAppearance.BorderSize = 0;
                btnFechar.Width = 200;
                btnFechar.Height = 50;
                btnFechar.Click += BtnMenuHistorico_Click;

                menu_item_painel.Location = new Point(0, 110);
                menu_item_painel.Size = new Size(200, 370);
                menu_item_painel.BackColor = Color.White;


                this.Controls.Add(label_Historico_menu);
                this.Controls.Add(btnFechar);
                this.Controls.Add(menu_item_painel);

                // Assinar evento personalizado para atualizar o histórico
                RenderizarTelas.AtualizacaoHistorico += AtualizarHistorico;

                RenderizarTelas.AtualizacaoHistoricoLimpo += AtualizarHistoricoLimpo;

                // Exibir o histórico inicial
                AtualizarHistorico();
                historyEmpyt();
            }

            private void historyEmpyt()
            {
                // Verifica se o painel de histórico está vazio
                bool historicoVazio = (menu_item_painel.Controls.Count == 0);

                // Remove qualquer mensagem existente de "Histórico vazio"
                foreach (Control control in menu_item_painel.Controls)
                {
                    if (control is Label && control.Text == "Histórico vazio.")
                    {
                        menu_item_painel.Controls.Remove(control);
                        control.Dispose();
                        break; // Sai do loop assim que encontrar e remover a mensagem
                    }
                }

                // Se o histórico estiver vazio, adiciona a mensagem
                if (historicoVazio)
                {
                    Label lblHistoricoVazio = new Label();
                    lblHistoricoVazio.Text = "Histórico vazio.";
                    lblHistoricoVazio.ForeColor = Color.Black;
                    lblHistoricoVazio.AutoSize = true;
                    menu_item_painel.Controls.Add(lblHistoricoVazio);
                }
            }


            private void BtnMenuHistorico_Click(object sender, EventArgs e)
            {
                this.Width = 0; // Fecha o menu lateral
            }

            public void openMenuHistorico(int largura)
            {
                this.Width = largura;
            }

            private void AtualizarHistorico()
            {

                // Limpar os controles existentes de histórico
                foreach (Control control in Controls.OfType<Label>().ToList())
                {
                    Controls.Remove(control);
                    control.Dispose();
                }

                historyEmpyt();

                // Obter o histórico de cálculos
                List<(string, double)> historico = dbScript.getHistorico();

                // Exibir o histórico na interface do usuário
                int yOffset = 10; // Posição vertical para exibir os itens do histórico

                foreach (var item in historico)
                {
                    Label historicoLabel = new Label();
                    historicoLabel.Text = $"Cálculo: {item.Item1}, Resultado: {item.Item2}";
                    historicoLabel.ForeColor = Color.Black;
                    historicoLabel.Location = new Point(10, yOffset); // Posição na interface
                    historicoLabel.AutoSize = true; // Ajusta automaticamente o tamanho do controle
                    menu_item_painel.Controls.Add(historicoLabel);
                    yOffset += 30; // Incremento para a próxima posição vertical
                    // menu_item_painel.Controls.Add(historico);
                }
            }

            private void AtualizarHistoricoLimpo()
            {
                Console.Write("Vamos Atualizar o Historico Estamos Aqui...");

                // Remove os controles existentes de histórico
                menu_item_painel.Controls.Clear();

                // Obter o histórico de cálculos
                List<(string, double)> historico = dbScript.getHistorico();

                // Exibir o histórico na interface do usuário
                int yOffset = 10; // Posição vertical para exibir os itens do histórico

                foreach (var item in historico)
                {
                    Label historicoLabel = new Label();
                    historicoLabel.Text = $"Cálculo: {item.Item1}, Resultado: {item.Item2}";
                    historicoLabel.ForeColor = Color.Black;
                    historicoLabel.Location = new Point(10, yOffset); // Posição na interface
                    historicoLabel.AutoSize = true; // Ajusta automaticamente o tamanho do controle
                    menu_item_painel.Controls.Add(historicoLabel);
                    yOffset += 30; // Incremento para a próxima posição vertical
                }

                // Verifica se o painel de histórico está vazio
                historyEmpyt();
            }

        }


        public class Ferramentas : UserControl
        {
            private PictureBox picBox;
            private FlowLayoutPanel menu;

            private MenuLateral _menuLateral; // campo para armazenar a instância de MenuLateral

            Label padrao = new Label();
            private MenuHistorico _menuHistorico;

            Process myProcess = new Process();

            
            public Ferramentas(MenuLateral menuLateral, MenuHistorico menuHistorico)
            {

                _menuLateral = menuLateral;
                _menuHistorico = menuHistorico;

                // Configurações do UserControl
                int larguraControl = 35;
                this.Size = new Size(380, 100);
                this.Location = new Point(10, 0);


                // Botão "Sobre"
                Button sobre = new Button();
                sobre.Text = "Sobre";
                sobre.Height = larguraControl - 12;
                sobre.Font = new System.Drawing.Font("ArialBlack", 10, FontStyle.Regular);
                sobre.ForeColor = Color.White;
                sobre.FlatStyle = FlatStyle.Flat; // Define o estilo da borda como plano
                sobre.FlatAppearance.BorderSize = 0; // Remove a borda do botão
                sobre.BackColor = Color.Transparent; // Define a cor de fundo como transparente
                sobre.Click += btnSobre_addMenu; // Manipulador do evento MouseEnter

                // Menu Drop
                menu = new FlowLayoutPanel();
                menu.FlowDirection = FlowDirection.LeftToRight;
                menu.Size = new Size(380, larguraControl);
                menu.ForeColor = Color.White; // Cor do texto
                menu.BackColor = Color.FromArgb(36, 34, 34); // Cor de fundo cinza claro
                menu.Padding = new Padding(2);
                menu.Controls.Add(sobre);

                Button menuOp = new Button();
                // menuOp.Text = "Menu";
                menuOp.Location = new System.Drawing.Point(0, 60);
                menuOp.Click += openMenu_Click; // Evento de clique para a Opção 2
                menuOp.Size = new Size(50, 40);


                padrao.Text = "Padrão";
                padrao.Size = new Size(280, 100);
                padrao.Location = new Point(50, 60);
                // padrao.BackColor = Color.Magenta;
                padrao.TextAlign = ContentAlignment.TopCenter;
                padrao.Font = new Font("ArialBlack", 25, FontStyle.Regular);

                // Criação do botão para histórico
                Image imgIconHistoy = Image.FromFile("./Icons/history.png");
                Image imgIconHistoyRedimensionada = imgIconHistoy.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                Button menuHistory = new Button();
                menuHistory.Size = new Size(50, 40);
                menuHistory.Image = imgIconHistoyRedimensionada;
                menuHistory.ImageAlign = ContentAlignment.MiddleCenter;
                menuHistory.Cursor = Cursors.Hand;
                menuHistory.Location = new Point(330, 60);
                menuHistory.Click += openMenuHistorico;


                Image imgIconMenu = Image.FromFile("./Icons/menu.png");
                Image imgIconRedimensionada = imgIconMenu.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                menuOp.Image = imgIconRedimensionada;



                // PictureBox
                picBox = new PictureBox();
                picBox.Size = new Size(100, 50); // Defina o tamanho conforme desejado
                picBox.SizeMode = PictureBoxSizeMode.Zoom;
                picBox.Visible = false; // Inicialmente invisível
                picBox.BackColor = Color.Green;

                // Label 1
                Label linkLabel1 = new Label();
                linkLabel1.Text = "GitHub";
                linkLabel1.ForeColor = Color.White; // Cor do texto
                linkLabel1.Cursor = Cursors.Hand; // Altera o cursor para indicar que é clicável
                linkLabel1.Font = new Font(linkLabel1.Font, FontStyle.Underline); // Sublinhado
                linkLabel1.Location = new Point(5, 5); // Posição da label
                linkLabel1.Click += linkLabel_Click; // Manipulador do evento Click

                // Adicionando a linha de separação
                Label separatorLabel = new Label();
                separatorLabel.BackColor = Color.White;
                separatorLabel.Size = new Size(90, 1); // Tamanho da linha
                separatorLabel.Location = new Point(5, 20); // Posição da linha

                // Label 2
                Label linkLabel2 = new Label();
                linkLabel2.Text = "Versão";
                linkLabel2.ForeColor = Color.White; // Cor do texto
                linkLabel2.Cursor = Cursors.Hand; // Altera o cursor para indicar que é clicável
                linkLabel2.Font = new Font(linkLabel1.Font, FontStyle.Underline); // Sublinhado
                linkLabel2.Location = new Point(5, 25); // Posição da label
                linkLabel2.Click += linkLabel_Click; // Manipulador do evento Click

                // Adicionando as labels e o separador à PictureBox
                picBox.Controls.Add(linkLabel1);
                picBox.Controls.Add(separatorLabel);
                picBox.Controls.Add(linkLabel2);

                // Adicionando os controles ao UserControl
                this.Controls.Add(picBox);
                this.Controls.Add(menu);
                this.Controls.Add(padrao);
                this.Controls.Add(menuOp);
                this.Controls.Add(menuHistory);

                // Adicionando um manipulador de evento de clique para o UserControl
                this.MouseClick += UserControl_MouseClick;

                // Ouvir pelo evento AtualizacaoLabel
                RenderizarTelas.AtualizacaoLabel += AtualizarLabel;

            }

            public void AtualizarLabel()
            {

                // Console.WriteLine("Option atualizado para: " + RenderizarTelas.Option);

                // Verificar se a instância da Label não é nula antes de atualizar
                if (padrao != null)
                {
                    // Atualizar o texto da Label com base na opção atual
                    if (RenderizarTelas.Option == 0)
                    {
                        padrao.Text = "Padrão";
                    }
                    else if (RenderizarTelas.Option == 1)
                    {
                        padrao.Text = "IMC";
                    }
                    else if (RenderizarTelas.Option == 2)
                    {
                        padrao.Text = "Configuração";
                    }
                    // Adicione mais condições conforme necessário para outras opções
                }
            }

            private void btnSobre_addMenu(object sender, EventArgs e)
            {
                // Torna a PictureBox visível quando o mouse entra no botão "Sobre"
                picBox.Visible = true;
                // Define a posição da PictureBox em relação ao botão "Sobre"
                picBox.Location = new Point(5, 30);
            }

            private void linkLabel_Click(object sender, EventArgs e)
            {
                // Oculta a PictureBox quando um link é clicado
                try
                {
                    // true is the default, but it is important not to set it to false
                    myProcess.StartInfo.UseShellExecute = true;
                    myProcess.StartInfo.FileName = "https://github.com/scriptsync/SYNC-CALCULATOR";
                    myProcess.Start();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }

                picBox.Visible = false;
            }

            private void UserControl_MouseClick(object sender, MouseEventArgs e)
            {
                // Oculta a PictureBox se o clique for fora dela
                if (!picBox.Bounds.Contains(e.Location))
                {
                    picBox.Visible = false;
                }
            }

            private void openMenu_Click(object sender, EventArgs e)
            {
                _menuHistorico.openMenuHistorico(0);
                _menuLateral.openMenu(200);
            }

            private void openMenuHistorico(object sender, EventArgs e)
            {
                _menuLateral.openMenu(0);
                _menuHistorico.openMenuHistorico(200);
            }
        }


        public class RenderizarTelas : UserControl
        {
            public static event Action AtualizacaoHistorico; // Evento estático para atualização do histórico
            public static event Action AtualizacaoHistoricoLimpo; // Evento estático para atualização do histórico que foi Limpo
            public static event Action AtualizacaoLabel; // Evento estático para atualização da Label
            public static int Option { get; private set; } = 0; // Propriedade estática para armazenar a opção atual

            private MenuLateral _menuLateral;
            private int option;

            public RenderizarTelas(MenuLateral menuLateral)
            {
                _menuLateral = menuLateral;
                _menuLateral.OnInputValueChanged += UpdateOption;

                this.Location = new Point(0, 100);
                this.Size = new Size(400, 450);

                // Renderiza a tela inicial
                RenderizarTela();
            }

            private void UpdateOption(int newValue)
            {
                option = newValue;  // Atualize a propriedade de instância
                RenderizarTelas.Option = newValue;  // Atualize a propriedade estática
                RenderizarTela();  // Renderize a tela com base na nova opção
            }

            private void RenderizarTela()
            {
                this.Controls.Clear(); // Limpar os controles existentes

                if (option == 0)
                {
                    dbScriptSybc dbScript = new dbScriptSybc("criar");

                    Calculadora_Comun.buttons_area buttonsarea = new Calculadora_Comun.buttons_area(dbScript);
                    this.Controls.Add(buttonsarea);

                    // Subscrever ao evento OperacaoHistoricoRealizada para acionar a atualização do histórico
                    buttonsarea.OperacaoHistoricoRealizada += (sender, e) =>
                    {
                        // Verifica se o evento de atualização do histórico está registrado
                        AtualizacaoHistorico?.Invoke();
                    };

                    AtualizacaoLabel?.Invoke();
                }
                else if (option == 1)
                {

                    Calculadora_IMC.calc_imc Calculadora_imc = new Calculadora_IMC.calc_imc();
                    this.Controls.Add(Calculadora_imc);

                    AtualizacaoLabel?.Invoke();

                }
                else if (option == 2)
                {
                    Configuracao configuracao = new Configuracao();
                    this.Controls.Add(configuracao);

                    configuracao.HistoricoLimpoAtualizar += (sender, e) =>
                    {
                        // Verifica se o evento de atualização do histórico está registrado
                        AtualizacaoHistoricoLimpo?.Invoke();
                    };

                    AtualizacaoLabel?.Invoke();
                }
            }
        }


            // Criar uma instância da classe Servidor
            Servidor meuServidor = new Servidor();
        private void InitializeComponent()
        {

            this.Icon = new Icon("./Icons/calc.ico");
            this.components = new Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 550);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            this.Text = "Calculadora ScriptSync Solutions";


            // Iniciar o servidor Python
            meuServidor.iniciarServidor();

            // RenderizarMenu
            MenuLateral menuLateral = new MenuLateral();
            menuLateral.openMenu(0);

            // dbScriptSybc dbScript = new dbScriptSybc("criar");
            MenuHistorico menuHistorico = new MenuHistorico(dbScript);

            menuHistorico.openMenuHistorico(0);

            RenderizarTelas renderizarTelas = new RenderizarTelas(menuLateral);
            // Ferramentas
            Ferramentas ferramentas = new Ferramentas(menuLateral, menuHistorico);



            this.Controls.Add(menuLateral);
            this.Controls.Add(menuHistorico);
            this.Controls.Add(ferramentas);
            this.Controls.Add(renderizarTelas);


        }
        private bool shouldPromptOnClose = true;
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (shouldPromptOnClose && e.CloseReason == CloseReason.UserClosing)
            {
                meuServidor.encerrarServidor();
            }

            base.OnFormClosing(e);
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            shouldPromptOnClose = false; // Desativa o prompt ao fechar pelo botão 'X'
            this.Close();
        }


        // Adicione este método para limpar os recursos
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
