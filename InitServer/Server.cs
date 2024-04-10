using System;
using System.Diagnostics;

namespace Calculadora_C_.Server
{
    partial class Servidor
    {
        private Process pythonProcess; // Processo para o servidor Python

        public Servidor()
        {
            pythonProcess = null;
        }

        public void iniciarServidor()
        {
            try
            {
                string caminhoExePython = "Servidor.exe";

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = caminhoExePython;

                // Iniciar o processo
                pythonProcess = Process.Start(startInfo);

                Console.WriteLine("Servidor iniciado Com Sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao iniciar o servidor Python: {ex.Message}");
            }
        }

        public void encerrarServidor()
        {
            try
            {
                if (pythonProcess != null && !pythonProcess.HasExited)
                {
                    pythonProcess.Kill(); 
                    pythonProcess.Dispose();
                    Console.WriteLine("Servidor Python encerrado.");

                    string nomeExe = "Servidor.exe";

                    try
                    {
                        // Obtém todos os processos em execução
                        Process[] processos = Process.GetProcesses();

                        // Itera sobre cada processo
                        foreach (Process processo in processos)
                        {
                            try
                            {
                                // Verifica se o nome do executável corresponde ao executável desejado
                                if (string.Equals(processo.ProcessName, nomeExe, StringComparison.OrdinalIgnoreCase))
                                {
                                    // Encerra o processo
                                    processo.Kill();
                                    Console.WriteLine($"Processo {nomeExe} encerrado com sucesso.");
                                }
                            }
                            catch (Exception ex)
                            {
                                // Trata exceções ao tentar encerrar o processo
                                Console.WriteLine($"Erro ao encerrar o processo {processo.ProcessName}: {ex.Message}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Trata exceções ao obter a lista de processos
                        Console.WriteLine($"Erro ao obter lista de processos: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("O servidor Python não está em execução.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao encerrar o servidor Python: {ex.Message}");
            }
        }
    }
}
