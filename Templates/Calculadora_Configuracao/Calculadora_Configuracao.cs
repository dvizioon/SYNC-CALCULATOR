using System;
using System.Runtime.InteropServices;

using Calculadora_C_.DbScripAsync;

namespace Calculadora_C_.Configuracoes
{


    public class Configuracao : UserControl
    {
        public event EventHandler HistoricoLimpoAtualizar;
        private Button btnLimparHistorico;
        private dbScriptSybc dbScript = new dbScriptSybc("criar");

        public Configuracao()
        {
            // Configurações da janela principal

            this.Size = new Size(380, 600); // Aumentei um pouco a largura

            // Panel para conter o FlowLayoutPanel com barra de rolagem
            Panel scrollPanel = new Panel();
            scrollPanel.Dock = DockStyle.Fill;
            this.Controls.Add(scrollPanel);

            // FlowLayoutPanel para organizar os controles verticalmente
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.FlowDirection = FlowDirection.TopDown;
            // panel.BackColor = Color.Red; // Cor de fundo vermelha
            panel.Size = new Size(380, 600);

            scrollPanel.Controls.Add(panel);

            // Adicionando a barra de rolagem vertical ao Panel
            scrollPanel.AutoScroll = true;
            scrollPanel.VerticalScroll.Visible = true;
            scrollPanel.VerticalScroll.Enabled = true;

            // Botão para "Limpar Histórico"
            btnLimparHistorico = new Button();
            btnLimparHistorico.Text = "Limpar Histórico";
            btnLimparHistorico.AutoSize = true;
            btnLimparHistorico.Size = new Size(360, 70);
            btnLimparHistorico.Font = new System.Drawing.Font("ArialBlack", 16, FontStyle.Regular);
            btnLimparHistorico.Click += BtnLimparHistorico_Click;
            panel.Controls.Add(btnLimparHistorico);

            // Centraliza os controles dentro do FlowLayoutPanel
            foreach (Control control in panel.Controls)
            {
                control.Anchor = AnchorStyles.None;
                control.Margin = new Padding(10);
            }
        }

        private void BtnLimparHistorico_Click(object sender, EventArgs e)
        {
            dbScript.limparHistorico();
            MessageBox.Show("Histórico limpo!");
            OnOperacaoHistoricoRealizada();
        }

        public void OnOperacaoHistoricoRealizada()
        {
            // Verifica se há inscritos no evento e dispara-o
            Console.WriteLine("Pode Atualizar o Historico Já foi Limpo...");
            HistoricoLimpoAtualizar?.Invoke(this, EventArgs.Empty);
        }

    }
}
