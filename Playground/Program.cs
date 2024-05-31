using System;
using System.IO;

namespace MarkdownBrowser
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = "C:\\Users\\mbmui\\OneDrive\\Obsidian\\Systempunk - DEV";
            string[] files = Directory.GetFiles(currentDirectory, "*.md", SearchOption.AllDirectories);

            Console.WriteLine("Bem-vindo ao Navegador de Markdown!");
            Console.WriteLine("Diretório atual: " + currentDirectory);
            Console.WriteLine("Arquivos e pastas Markdown encontrados:");

            for (int i = 0; i < files.Length; i++)
            {
            Console.WriteLine($"{i + 1}. {files[i]}");
            }

            while (true)
            {
            Console.WriteLine();
            Console.WriteLine("Digite o número do arquivo ou pasta que deseja abrir (ou 's' para sair):");
            string input = Console.ReadLine();

            if (input.ToLower() == "s")
            {
                break;
            }

            if (int.TryParse(input, out int fileIndex) && fileIndex >= 1 && fileIndex <= files.Length)
            {
                string selectedPath = files[fileIndex - 1];

                if (File.Exists(selectedPath))
                {
                string fileContent = File.ReadAllText(selectedPath);

                Console.WriteLine();
                Console.WriteLine("Conteúdo do arquivo:");
                Console.WriteLine(fileContent);
                }
                else if (Directory.Exists(selectedPath))
                {
                currentDirectory = selectedPath;
                files = Directory.GetFiles(currentDirectory, "*.md", SearchOption.AllDirectories);

                Console.WriteLine();
                Console.WriteLine("Diretório atual: " + currentDirectory);
                Console.WriteLine("Arquivos e pastas Markdown encontrados:");

                for (int i = 0; i < files.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {files[i]}");
                }
                }
            }
            else
            {
                Console.WriteLine("Opção inválida. Por favor, tente novamente.");
            }
            }

            Console.WriteLine("Obrigado por usar o Navegador de Markdown. Até logo!");
        }
    }
}