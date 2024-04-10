using Calculadora_C;

namespace Calculadora_C_;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        // Application.Run(new Calculadora_Comun());
        Application.Run(new Calculadora_Geral());
        // Iniciando a tarefa assíncrona e esperando que ela termine
        // Task.Run(async () =>
        // {
        //     await OpenIa.RespostaGPT();
        // }).Wait();


    }
}