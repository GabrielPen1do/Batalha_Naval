using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batalha_Naval
{
    class Program
    {
        static void jogadorComputador(char[,] tabuleiro, string embarcacao, string posicao, int embarcacaoLinha, int embarcacaoColuna)
        {
            int tamanho = 0;
            for (int i = 0; i < tabuleiro.GetLength(0); i++)
            {
                for (int j = 0; j < tabuleiro.GetLength(1); j++)
                {
                    if (embarcacao[0] == 'S')
                    {
                        tabuleiro[embarcacaoLinha, embarcacaoColuna] = 'S';
                    }
                    if (embarcacao[0] == 'P')
                    {
                        tabuleiro[embarcacaoLinha, embarcacaoColuna] = 'P';
                        tamanho = 5;
                    }
                    if (embarcacao[0] == 'E')
                    {
                        tabuleiro[embarcacaoLinha, embarcacaoColuna] = 'E';
                        tamanho = 4;
                    }
                    if (embarcacao[0] == 'C')
                    {
                        tabuleiro[embarcacaoLinha, embarcacaoColuna] = 'C';
                        tamanho = 3;
                    }
                    if (embarcacao[0] == 'H')
                    {
                        tabuleiro[embarcacaoLinha, embarcacaoColuna] = 'H';
                        tamanho = 2;
                    }

                    if (posicao == "h")
                    {
                        if (embarcacao[0] == 'H')
                        {
                            for (int c = embarcacaoColuna; c < embarcacaoColuna + tamanho; c++)
                            {
                                tabuleiro[embarcacaoLinha, c] = 'H';
                            }
                        }
                        if (embarcacao[0] == 'C')
                        {
                            for (int c = embarcacaoColuna; c < embarcacaoColuna + tamanho; c++)
                            {
                                tabuleiro[embarcacaoLinha, c] = 'C';
                            }
                        }
                        if (embarcacao[0] == 'P')
                        {
                            for (int c = embarcacaoColuna; c < embarcacaoColuna + tamanho; c++)
                            {
                                tabuleiro[embarcacaoLinha, c] = 'P';
                            }
                        }
                    }
                }

                if (posicao == "v")
                {
                    if (embarcacao[0] == 'H')
                    {
                        for (int l = embarcacaoLinha; l < embarcacaoLinha + tamanho; l++)
                        {
                            tabuleiro[l, embarcacaoColuna] = 'H';
                        }
                    }
                    if (embarcacao[0] == 'C')
                    {
                        for (int l = embarcacaoLinha; l < embarcacaoLinha + tamanho; l++)
                        {
                            tabuleiro[l, embarcacaoColuna] = 'C';
                        }
                    }
                    if (embarcacao[0] == 'E')
                    {
                        for (int l = embarcacaoLinha; l < embarcacaoLinha + tamanho; l++)
                        {
                            tabuleiro[l, embarcacaoColuna] = 'E';
                        }
                    }
                }
            }
        }
        static void jogadorHumano(string nomeCompleto, char[,] tabuleiro, string embarcacao)
        {

            string[] vetNomeCompleto = nomeCompleto.Split(' ');
            int linha = 0, coluna = 0;
            string posicao = "";
            string nome = vetNomeCompleto[0];
            string iniciais = "";

            for (int i = 1; i < vetNomeCompleto.Length; i++)
            {
                iniciais += vetNomeCompleto[i][0];
            }

            string nickname = ($"{nome}{iniciais}");

            int tamanho = 0;
            int cont = 0;
            bool posicaoValida = true;

            while (cont < 4 || !posicaoValida)
            {

                Console.WriteLine("\nSubmarino:");
                Console.Write($"{nickname} digite a linha (0 a 9): ");
                linha = int.Parse(Console.ReadLine());
                Console.Write($"{nickname} digite a coluna (0 a 9): ");
                coluna = int.Parse(Console.ReadLine());

                if (tabuleiro[linha, coluna] == 'A')
                {
                    tabuleiro[linha, coluna] = 'S';
                    Console.WriteLine();
                    ImprimirTabuleiro(tabuleiro);
                }
                else
                {
                    posicaoValida = false;
                    Console.WriteLine("Essa posição já foi preenchida! Insira novamente! \n");
                }
                cont++;
            }

            cont = 0;
            while (cont < 1 || !posicaoValida)
            {
                Console.WriteLine("\nPorta-Avião:");
                Console.Write($"{nickname} digite a linha (0 a 9): ");
                linha = int.Parse(Console.ReadLine());
                Console.Write($"{nickname} digite a coluna (0 a 9): ");
                coluna = int.Parse(Console.ReadLine());
                Console.Write("Insira a orientação da embarcação (H ou V): ");
                posicao = Console.ReadLine().ToLower();

                if (tabuleiro[linha, coluna] != 'A')
                {
                    posicaoValida = false;
                    Console.WriteLine("Essa posição já foi preenchida! Insira novamente! \n");
                    Console.WriteLine("Porta-Avião:");
                    Console.Write($"{nickname} digite a linha (0 a 9): ");
                    linha = int.Parse(Console.ReadLine());
                    Console.Write($"{nickname} digite a coluna (0 a 9): ");
                    coluna = int.Parse(Console.ReadLine());
                    Console.Write("Insira a orientação da embarcação (H ou V): ");
                    posicao = Console.ReadLine().ToLower();

                }
                else
                {
                    posicaoValida = true;
                    tabuleiro[linha, coluna] = 'P';
                }
                tamanho = 5;
                cont++;

                if (posicao == "h")
                {
                    if (coluna > 5)
                    {
                        posicaoValida = false;
                        tabuleiro[linha, coluna] = 'A';
                        Console.WriteLine("Essa posição é inválida! Insira novamente! \n");
                    }
                    else
                    {
                        for (int c = coluna; c < coluna + tamanho; c++)
                        {
                            tabuleiro[linha, c] = 'P';

                        }
                    }

                }

                if (posicao == "v")
                {
                    if (linha > 5)
                    {
                        posicaoValida = false;
                        tabuleiro[linha, coluna] = 'A';
                        Console.WriteLine("Essa posição é inválida! Insira novamente! \n");
                    }
                    else
                    {
                        for (int c = linha; c < linha + tamanho; c++)
                        {
                            tabuleiro[c, coluna] = 'P';

                        }
                    }
                }
                Console.WriteLine();
                ImprimirTabuleiro(tabuleiro);
            }

            posicaoValida = true;
            cont = 0;
            while (cont < 1 || !posicaoValida)
            {
                cont++;

                Console.WriteLine("\nEncouraçado:");
                Console.Write($"{nickname} digite a linha (0 a 9): ");
                linha = int.Parse(Console.ReadLine());
                Console.Write($"{nickname} digite a coluna (0 a 9): ");
                coluna = int.Parse(Console.ReadLine());
                Console.Write("Insira a orientação da embarcação (H ou V): ");
                posicao = Console.ReadLine().ToLower();

                if (tabuleiro[linha, coluna] != 'A')
                {
                    posicaoValida = false;
                    Console.WriteLine("Essa posição já foi preenchida! Insira novamente! \n");
                    Console.WriteLine("Encouraçado:");
                    Console.Write($"{nickname} digite a linha (0 a 9): ");
                    linha = int.Parse(Console.ReadLine());
                    Console.Write($"{nickname} digite a coluna (0 a 9): ");
                    coluna = int.Parse(Console.ReadLine());
                    Console.Write("Insira a orientação da embarcação (H ou V): ");
                    posicao = Console.ReadLine().ToLower();
                }
                else
                {
                    posicaoValida = true;
                    tabuleiro[linha, coluna] = 'E';
                }
                tamanho = 4;

                if (posicao == "h")
                {
                    if (coluna > 6)
                    {
                        posicaoValida = false;
                        tabuleiro[linha, coluna] = 'A';
                        Console.WriteLine("Essa posição é inválida! Insira novamente! \n");
                    }
                    else
                    {
                        for (int c = coluna; c < coluna + tamanho; c++)
                        {
                            tabuleiro[linha, c] = 'E';
                        }
                    }

                }

                if (posicao == "v")
                {
                    if (linha > 6)
                    {
                        posicaoValida = false;
                        tabuleiro[linha, coluna] = 'A';
                        Console.WriteLine("Essa posição é inválida! Insira novamente! \n");
                    }
                    else
                    {
                        for (int c = linha; c < linha + tamanho; c++)
                        {
                            tabuleiro[c, coluna] = 'E';
                        }
                    }
                }
                Console.WriteLine();
                ImprimirTabuleiro(tabuleiro);
            }

            posicaoValida = true;
            cont = 0;
            while (cont < 2 || !posicaoValida)
            {
                Console.WriteLine("\nCruzador:");
                Console.Write($"{nickname} digite a linha (0 a 9): ");
                linha = int.Parse(Console.ReadLine());
                Console.Write($"{nickname} digite a coluna (0 a 9): ");
                coluna = int.Parse(Console.ReadLine());
                Console.Write("Insira a orientação da embarcação (H ou V): ");
                posicao = Console.ReadLine().ToLower();

                if (tabuleiro[linha, coluna] != 'A')
                {
                    posicaoValida = false;
                    Console.WriteLine("Essa posição já foi preenchida! Insira novamente! \n");
                    Console.WriteLine("Cruzador:");
                    Console.Write($"{nickname} digite a linha (0 a 9): ");
                    linha = int.Parse(Console.ReadLine());
                    Console.Write($"{nickname} digite a coluna (0 a 9): ");
                    coluna = int.Parse(Console.ReadLine());
                    Console.Write("Insira a orientação da embarcação (H ou V): ");
                    posicao = Console.ReadLine().ToLower();
                }
                else
                {
                    posicaoValida = true;
                    tabuleiro[linha, coluna] = 'C';
                }
                if ((coluna > 7 && posicao == "h") || (linha > 7 && posicao == "v"))
                {
                    posicaoValida = false;
                    Console.WriteLine("Essa posição é inválida! Insira novamente! \n");
                }
                else
                {
                    posicaoValida = true;
                }
                tamanho = 3;
                cont++;

                if (posicao == "h")
                {
                    if (coluna > 7)
                    {
                        posicaoValida = false;
                        tabuleiro[linha, coluna] = 'A';
                        Console.WriteLine("Essa posição é inválida! Insira novamente! \n");
                    }
                    else
                    {
                        for (int c = coluna; c < coluna + tamanho; c++)
                        {
                            tabuleiro[linha, c] = 'C';
                        }
                    }

                }

                if (posicao == "v")
                {
                    if (linha > 7)
                    {
                        posicaoValida = false;
                        tabuleiro[linha, coluna] = 'A';
                        Console.WriteLine("Essa posição é inválida! Insira novamente! \n");
                    }
                    else
                    {
                        for (int c = linha; c < linha + tamanho; c++)
                        {
                            tabuleiro[c, coluna] = 'C';
                        }
                    }
                }
                Console.WriteLine();
                ImprimirTabuleiro(tabuleiro);
            }

            posicaoValida = true;
            cont = 0;
            while (cont < 3 || !posicaoValida)
            {
                Console.WriteLine("\nHidro-Avião:");
                Console.Write($"{nickname} digite a linha (0 a 9): ");
                linha = int.Parse(Console.ReadLine());
                Console.Write($"{nickname} digite a coluna (0 a 9): ");
                coluna = int.Parse(Console.ReadLine());
                Console.Write("Insira a orientação da embarcação (H ou V): ");
                posicao = Console.ReadLine().ToLower();
                if (tabuleiro[linha, coluna] != 'A')
                {
                    posicaoValida = false;
                    Console.WriteLine("Essa posição já foi preenchida! Insira novamente! \n");
                    Console.WriteLine("Hidro-Avião:");
                    Console.Write($"{nickname} digite a linha (0 a 9): ");
                    linha = int.Parse(Console.ReadLine());
                    Console.Write($"{nickname} digite a coluna (0 a 9): ");
                    coluna = int.Parse(Console.ReadLine());
                    Console.Write("Insira a orientação da embarcação (H ou V): ");
                    posicao = Console.ReadLine().ToLower();
                }
                else
                {
                    posicaoValida = true;
                    tabuleiro[linha, coluna] = 'H';
                }
                if ((coluna > 8 && posicao == "h") || (linha > 8 && posicao == "v"))
                {
                    posicaoValida = false;
                    Console.WriteLine("Essa posição é inválida! Insira novamente! \n");
                }
                else
                {
                    posicaoValida = true;
                }
                tamanho = 2;
                cont++;

                if (posicao == "h")
                {
                    if (coluna > 8)
                    {
                        posicaoValida = false;
                        tabuleiro[linha, coluna] = 'A';
                        Console.WriteLine("Essa posição é inválida! Insira novamente! \n");
                    }
                    else
                    {
                        for (int c = coluna; c < coluna + tamanho; c++)
                        {
                            tabuleiro[linha, c] = 'H';
                        }
                    }

                }

                if (posicao == "v")
                {
                    if (linha > 8)
                    {
                        posicaoValida = false;
                        tabuleiro[linha, coluna] = 'A';
                        Console.WriteLine("Essa posição é inválida! Insira novamente! \n");
                    }
                    else
                    {
                        for (int c = linha; c < linha + tamanho; c++)
                        {
                            tabuleiro[c, coluna] = 'H';
                        }
                    }
                }
                Console.WriteLine();
                ImprimirTabuleiro(tabuleiro);

            }
        }
        static void Jogada(char[,] tabuleiroComputador, char[,] tabuleiroHumano, string nomeCompleto, char[,] tabuleiroResultado)
        {

            StreamWriter arqEsc = new StreamWriter("jogadas.txt", false, Encoding.UTF8);
            Random r = new Random();
            string[] vetNomeCompleto = nomeCompleto.Split(' ');
            int linha = 0, coluna = 0;
            int pontuacao = 0;
            int pontuacaoCPU = 0;
            char[,] tabuleiroResultadoCPU = new char[10, 10];
            int[,] matHumano = new int[100, 2];
            int[,] matComputador = new int[100, 2];
            string iniciais = "", nome = vetNomeCompleto[0];
            int disparosJogador = 0;
            int disparosComputador = 0;

            for (int i = 1; i < vetNomeCompleto.Length; i++)
            {
                iniciais += vetNomeCompleto[i][0];
            }

            string nickname = $"{nome}{iniciais}";

            Console.WriteLine("\nTabuleiro - Jogador Humano\n");
            InicializarComAgua(tabuleiroResultado);

            Console.WriteLine("\nTabuleiro - Jogador Computador\n");
            InicializarComAgua(tabuleiroResultadoCPU);

            while (pontuacao < 25 && pontuacaoCPU < 25)
            {
                bool acertouEmbarcacao = true;

                while (acertouEmbarcacao && pontuacao < 25)
                {
                    Console.Write($"\n{nickname} insira a linha do ataque: ");
                    linha = int.Parse(Console.ReadLine());
                    Console.Write($"{nickname} insira a coluna do ataque: ");
                    coluna = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    if (linha >= 0 && linha < 10 && coluna >= 0 && coluna < 10)
                    {
                        if (tabuleiroComputador[linha, coluna] == 'S' || tabuleiroComputador[linha, coluna] == 'P' || tabuleiroComputador[linha, coluna] == 'C' || tabuleiroComputador[linha, coluna] == 'E' || tabuleiroComputador[linha, coluna] == 'H')
                        {
                            Console.WriteLine($"\n{nickname} acertou uma embarcação!\n");
                            tabuleiroComputador[linha, coluna] = 'T';
                            tabuleiroResultado[linha, coluna] = 'T';
                            pontuacao++;
                            ImprimirTabuleiro(tabuleiroResultado);
                            matHumano[disparosJogador, 0] = linha;
                            matHumano[disparosJogador, 1] = coluna;
                            disparosJogador++;
                        }
                        else if (tabuleiroResultado[linha, coluna] == 'T' || tabuleiroResultado[linha, coluna] == 'X')
                        {
                            Console.WriteLine($"\n{nickname} essa posição já foi utilizada! Insira outra posição.\n");
                        }
                        else
                        {
                            Console.WriteLine($"\n{nickname} não acertou nenhuma embarcação!\n");
                            tabuleiroResultado[linha, coluna] = 'X';
                            ImprimirTabuleiro(tabuleiroResultado);
                            acertouEmbarcacao = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nPosição inválida! Insira outra posição.\n");
                    }
                }

                acertouEmbarcacao = true;

                while (acertouEmbarcacao && pontuacaoCPU < 25 && pontuacao < 25)
                {
                    linha = r.Next(0, 10);
                    coluna = r.Next(0, 10);

                    if (tabuleiroHumano[linha, coluna] == 'S' || tabuleiroHumano[linha, coluna] == 'P' || tabuleiroHumano[linha, coluna] == 'C' || tabuleiroHumano[linha, coluna] == 'E' || tabuleiroHumano[linha, coluna] == 'H')
                    {
                        Console.WriteLine("\nJogador computador acertou uma embarcação!\n");
                        tabuleiroHumano[linha, coluna] = 'T';
                        tabuleiroResultadoCPU[linha, coluna] = 'T';
                        pontuacaoCPU++;
                        ImprimirTabuleiro(tabuleiroResultadoCPU);
                        matComputador[disparosComputador, 0] = linha;
                        matComputador[disparosComputador, 1] = coluna;
                        disparosComputador++;

                    }
                    else if (tabuleiroResultadoCPU[linha, coluna] == 'T' || tabuleiroResultadoCPU[linha, coluna] == 'X')
                    {
                        Console.WriteLine("\nEssa posição já foi utilizada! Insira outra posição.\n");
                    }
                    else
                    {
                        Console.WriteLine("\nJogador computador não acertou nenhuma embarcação!\n");
                        tabuleiroResultadoCPU[linha, coluna] = 'X';
                        ImprimirTabuleiro(tabuleiroResultadoCPU);
                        acertouEmbarcacao = false;
                    }
                    disparosComputador++;
                }
            }

            if (pontuacao == 25)
            {
                Console.WriteLine($"{nickname} venceu o jogo!");
                for (int i = 0; i < disparosJogador; i++)
                {
                    arqEsc.WriteLine($"Tiro {i + 1}: {matHumano[i, 0]}, {matHumano[i, 1]}");
                }
            }
            else if (pontuacaoCPU == 25)
            {
                Console.WriteLine($"Computador venceu o jogo!");
                for (int i = 0; i < disparosComputador; i++)
                {
                    arqEsc.WriteLine($"Tiro {i + 1}: {matComputador[i, 0]}, {matComputador[i, 1]}");
                }
            }

            arqEsc.Close();
        }

        static void InicializarTabuleiro(char[,] tabuleiro)
        {
            for (int l = 0; l < tabuleiro.GetLength(0); l++)
            {
                for (int c = 0; c < tabuleiro.GetLength(1); c++)
                {
                    tabuleiro[l, c] = 'A';
                }
            }
        }

        static void InicializarComAgua(char[,] tabuleiro)
        {
            for (int l = 0; l < tabuleiro.GetLength(0); l++)
            {
                for (int c = 0; c < tabuleiro.GetLength(1); c++)
                {
                    tabuleiro[l, c] = 'A';
                    Console.Write(tabuleiro[l, c] + " ");
                }
                Console.WriteLine();
            }
        }


        static void ImprimirTabuleiro(char[,] tabuleiro)
        {
            for (int l = 0; l < tabuleiro.GetLength(0); l++)
            {
                for (int c = 0; c < tabuleiro.GetLength(1); c++)
                {
                    Console.Write(tabuleiro[l, c] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            char[,] tabuleiroComputador = new char[10, 10];
            InicializarTabuleiro(tabuleiroComputador);
            string linha;
            string[] embarcacoesCPU;
            string embarcacao = "";
            string posicao;
            int embarcacaoLinha, embarcacaoColuna;
            try
            {
                StreamReader arq = new StreamReader("frotaComputador.txt", Encoding.UTF8);
                linha = arq.ReadLine();

                while (linha != null && linha != " ")
                {
                    embarcacoesCPU = linha.Split(';');
                    embarcacao = embarcacoesCPU[0];
                    posicao = embarcacoesCPU[1];
                    embarcacaoLinha = int.Parse(embarcacoesCPU[2]);
                    embarcacaoColuna = int.Parse(embarcacoesCPU[3]);
                    jogadorComputador(tabuleiroComputador, embarcacao, posicao, embarcacaoLinha, embarcacaoColuna);
                    linha = arq.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();

            string nomeCompleto;
            char[,] tabuleiroHumano = new char[10, 10];
            char[,] tabuleiroResultado = new char[10, 10];
            InicializarTabuleiro(tabuleiroHumano);
            Console.Write("Insira o seu nome completo: ");
            nomeCompleto = Console.ReadLine().ToLower();
            jogadorHumano(nomeCompleto, tabuleiroHumano, embarcacao);


            Jogada(tabuleiroComputador, tabuleiroHumano, nomeCompleto, tabuleiroResultado);


            Console.ReadKey();
        }
    }
}
