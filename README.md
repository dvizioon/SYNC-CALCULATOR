# 🧮 SYNC-CALCULATOR

Esta é uma calculadora com funcionalidades avançadas, desenvolvida usando várias tecnologias, incluindo C#, Python, SQL e uma IA embutida para tarefas específicas. O projeto visa fornecer uma interface amigável para realizar cálculos, Armazenar, e Execultar.
<div style="display:flex;flex-direction:row;gap:0.3rem">
  <img src="https://github.com/scriptsync/SYNC-CALCULATOR/blob/main/Img/Interface.png?raw=true" alt="" width="300" height="400">
  <img src="https://github.com/scriptsync/SYNC-CALCULATOR/blob/main/Img/menu.png?raw=true" alt="" width="300" height="400">
  <img src="https://github.com/scriptsync/SYNC-CALCULATOR/blob/main/Img/imc.png?raw=true" alt="" width="300" height="400">
</div>
## Funcionalidades

- **Operações Básicas:**
  - Adição, Subtração, Multiplicação, Divisão, Porcentagem
- **Funcionalidades Avançadas:**
  - Cálculo de IMC
- **Integração com IA:**
  - Respostas inteligentes para Entradas específicas (altura, peso,)

## Funcionalidades Gerais
- Criação de Dicas para uma Alimentação Adequedada
- Criação de Calculos Matematicos 

## Funcionalidades do Script
- Guarar Dados
- Geração de PDf
- Respota com IA
- Servidor Req,Res
- Calculos Matematicos 

## Tecnologias Utilizadas

- **C#:**
  - Lógica principal da calculadora
- **Python:**
  - Integração com IA e funcionalidades adicionais
- **SQL:**
  - Armazenamento e recuperação de dados
- **Api:**
  - Flask
- **HTML
  - Página simples do IMC

## Raiz do Projeto
```bash
Calculadora/
│
├── Config/      # Configuração de Banco
│
├── IA/          # Controller da AI 
│
├── Pdf_Genarate/  # Controller de Criação PDF
│
├── InitServer/  # Controller de Processos
│
├── Server --Console/ # Ia Controller Debug from Flask -- CMD
│
├── Server --noConsole/  # Ia Controller Debug from Flask -- NO CMD
│
├── Template/  # Aqui São as Calculadoras Logica e Designer
│   └── Calculadora_Comun 
│   └── Calculadora_Configuracao
│   └── Calculadora_Conversor
│
├── LICENSE 
└── README.md                 
```
<div style="display:flex;flex-direction:row;gap:0.3rem">
  <img src="https://github.com/scriptsync/SYNC-CALCULATOR/blob/main/Img/Captura%20de%20tela%202024-04-10%20003217.png?raw=true" alt="" width="300" height="400">
</div>

## 🚀 Requisitos para Executar

Para executar este projeto, certifique-se de ter os seguintes requisitos instalados:

- **Sistema Operacional**:
  - Windows, Linux

- **SDK e Ferramentas**:
  - [.NET Core SDK](https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/en-us/download))
  - [Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/) ou [Visual Studio Code](https://code.visualstudio.com/) (opcional, mas recomendado para desenvolvimento)

## 🛠️ Como Executar o Projeto

1. Clone este repositório:

   ```bash
   git clone https://github.com/scriptsync/SYNC-CALCULATOR
   dotnet build
   dotnet run
   ```
## 〽️ Como Fazer o Projeto Funcionar

2. Depois Copie Da Pasta Assets:
    ```bash
    Copie a Pasta " icons " e " Personagens " Dentro de Assets para bin\Debug\net8.0-windows ou outra versão que vc estiver usando do .NET
   ```

## Com Esses Passo já feito Escolha o modo de Depuraçao do Servido da IASYNC
3. Escolha o Servidor que vc Quer usar:
   
   - Escolha o Server --Console -> Modo de Desenvolvimento
   - ou
   - Escolha o Server --NoConsole -> Modo Produção

  ```bash
    Dentro do Servido que vc escolheu tem a Pasta " Components "," Config.ini "," Servidor.exe " Copie essas 3 para o
    bin\Debug\net8.0-windows ou outra versão que vc estiver usando do .NET, Sem isso vc não poderar usa a IA
  ```
