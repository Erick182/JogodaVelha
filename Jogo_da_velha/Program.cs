using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Jogo_da_velha
{
    public class JogodaVelha
    {

        private char jogadorVez = 'X';
        private int contJogadas = 0;
        private char[,] matrizPrincipal = new char[3, 3];
        private char jogadorX = 'X';
        private char jogadorO = 'O';
        private bool fimJogo = false;
        private bool vitoria = false;
        public static void Main(string[] args)
        
        {
            JogodaVelha game = new JogodaVelha();
            
            
            
            //abaixo o looping até a finalização do jogo
            do
            {
                Console.Clear(); //limpa a tela
                game.imprimir(); //imprime a matriz 
                game.jogada(); //jogador realiza a jogada
                game.imprimir(); //imprime a matriz
                game.Final(); //verifica se acabou o jogo
                //mudança de jogador
                if (game.jogadorVez == game.jogadorX)
                {
                    game.jogadorVez = game.jogadorO;
                }
                else
                {
                    game.jogadorVez = game.jogadorX;
                }

                
            } while (game.fimJogo != true);
        }

        /*private void populaMatriz()
        {
            int i;
            int j;
            for (i = 0; i <= 2; i++)
            {
                for (j=0; j <= 2; j++)
                {
                    matrizPrincipal[i, j] = ' ';
                }
            }
        }*/
        private void Final()
        {
            VitoriaDiagonal(); //verifica se há vitória nas diagonais
            VitoriaLinha(); //verifica se há vitória nas linhas
            VitoriaColuna(); // verifica se há vitória nas colunas

            
            if (contJogadas > 6) //verifica se já ultrapassou as 6 rodadas - entende-se que só há vencedor até a sexta rodada
            {
                Console.WriteLine("O limite de jogadas para que haja um vencedor é 6. Portanto, não é mais possível haver um vencedor");
                fimJogo = true;
                return;
            }
            else if (vitoria == true) //verifica se há um vencedor - isso é tratado nas funções VitoriaDiagonal, VitoriaLinha e VitoriaColuna
            {
                Console.WriteLine("Final de jogo ! O vencedor eh " + jogadorVez); //imprime uma mensagem informando o vencedor
                fimJogo = true;
                return;
            }
            else //se não teve um vencedor ainda e não ultrapassou as 6 rodadas, o jogo continua
            {
                Console.WriteLine("Continuando jogo");
                fimJogo = false;
                return;
            }
        }
        private void jogada()//aqui lê a marcação do campo do jogador X e O
        {
            int l, c;
            char aux;
            
            Console.WriteLine("jogador " + jogadorVez + ", sua vez:");

            //no laço abaixo, verifica a marcação da linha



                do
                {

                Console.WriteLine("Escolha uma linha: ");
                    l = int.Parse(Console.ReadLine());
                    if (l < 0 || l > 2)
                    {
                        Console.WriteLine("O valor digitado tem que ser entre 0 e 2");
                    }

                } while (l < 0 || l > 2);

                //no laço abaixo, verifica a marcação da coluna

                do
                {
                    Console.WriteLine("Escolha uma coluna: ");
                    c = int.Parse(Console.ReadLine());
                    if (c < 0 || c > 2)
                    {
                        Console.WriteLine("O valor digitado tem que ser entre 0 e 2");
                    }
                aux = jogadorVez;

                } while (c < 0 || c > 2);


            if (matrizPrincipal[l, c] == jogadorX || matrizPrincipal[l, c] == jogadorO) //verifica se há marcacao no campo escolhido
            {
                Console.WriteLine("Ja existe uma marcacao no campo escolhido. Favor escolher outro campo");
                jogada();
            }
            else
            {
                MarcarMatriz(l, c);//marca na matriz [l,c]
            }
        }

        private void MarcarMatriz(int l, int c) //marca valor na matriz e soma contador de jogadas
        {
            
            matrizPrincipal[l, c] = jogadorVez;
            contJogadas = contJogadas + 1;
        }

        private void VitoriaDiagonal() //verifica se há vitória nas diagonais
        {
            if (matrizPrincipal[1, 1]==jogadorO || matrizPrincipal[1, 1]==jogadorX) //verifica se há marcação no campo [1,1], tem que haver uma marcação O ou X para prosseguir na verificação
            {
                if (matrizPrincipal[0, 0] == (matrizPrincipal[1, 1]) && matrizPrincipal[1, 1]==(matrizPrincipal[2, 2]))  //verifica se há o mesmo valor na diagonal [0,0],[1,1],[2,2]
                {
                    vitoria = true; //se há o mesmo valor, há vitória
                    return;
                }

                else if (matrizPrincipal[0, 2]==(matrizPrincipal[1, 1]) && matrizPrincipal[2, 0]==(matrizPrincipal[1, 1]))//mesmo processo da anterior, mas verifica a outra diagonal [0,2],[1,1],[2,0]
                {
                    vitoria = true; //se há o mesmo valor, há vitória
                    return;
                }
            }
            else
            {
                vitoria = false; //caso não haja vencedor nas diagonais, continua o jogo
                return;
            }

        }

        private void VitoriaLinha() //verifica se há vitória nas linhas 
        {
            if (matrizPrincipal[0, 1]==jogadorX || matrizPrincipal[0, 1]==jogadorO) //verifica se há uma marcação na linha 0
            {
                if (matrizPrincipal[0, 0]==matrizPrincipal[0, 1] && matrizPrincipal[0, 2]==matrizPrincipal[0, 1]) //compara valores da linha 0
                {
                    vitoria = true; //se há o mesmo valor (O ou X) na linha 0, há vencedor
                    return;
                }
            }
            else if (matrizPrincipal[1, 1]==jogadorX || matrizPrincipal[1, 1]==jogadorO) //verifica se há uma marcação na linha 1
            {
                if (matrizPrincipal[1, 0]==matrizPrincipal[1, 1] && matrizPrincipal[1, 2]==matrizPrincipal[1, 1]) //compara valores da linha 1
                {
                    vitoria = true; //se há o mesmo valor (O ou X) na linha 1, há vencedor
                    return;
                }
            }

            else if (matrizPrincipal[2, 1]==jogadorO || matrizPrincipal[2, 1]==jogadorX) //verifica se há uma marcação na linha 2
            {
                if (matrizPrincipal[2, 0]==matrizPrincipal[2, 1] && matrizPrincipal[2, 2]==matrizPrincipal[2, 1]) //compara valores da linha 2
                {
                    vitoria = true; //se há o mesmo valor (O ou X) na linha 2, há vencedor
                    return;
                }
            }
            else
            {
                vitoria = false; //se não há vencedor nas linhas, o jogo continua
                return;
            }
                       
        }

        private void VitoriaColuna()
        {
            if (matrizPrincipal[1, 0]==jogadorO || matrizPrincipal[1, 0]==jogadorX) //verifica se há marcação na coluna 0
            {
                if (matrizPrincipal[0, 0]==matrizPrincipal[1, 0] && matrizPrincipal[2, 0]==matrizPrincipal[1, 0]) //compara valores da coluna 0
                {
                    vitoria = true;  //se há o mesmo valor (O ou X) na coluna 0, há vencedor
                    return;
                }
            }
            else if (matrizPrincipal[1, 1]==jogadorX || matrizPrincipal[1, 1] ==jogadorO) // verifica se há marcação na coluna 1
            {
                if (matrizPrincipal[0, 1]==matrizPrincipal[1, 1] && matrizPrincipal[2, 1]==matrizPrincipal[1, 1]) //compara valores da coluna 1
                { 
                    vitoria = true; //se há o mesmo valor (O ou X) na coluna 1, há vencedor
                    return;
                }
            }
            else if (matrizPrincipal[1, 2]==jogadorX || matrizPrincipal[1,2]==jogadorO) //verifica se há marcação na coluna 2
            {
                if (matrizPrincipal[0, 2]==matrizPrincipal[1, 2] && matrizPrincipal[2, 2]==matrizPrincipal[1, 2]) //compara valores da coluna 2
                {
                    vitoria = true; //se há o mesmo valor (O ou X) na coluna 2, há vencedor
                    return;
                }
            }
            else
            {
                vitoria = false; //se não há vencedor nas colunas, continua o jogo
                return;
            }            
        }

        
        private void imprimir()
        {

            Console.WriteLine("\t 0 \t 1 \t 2" + "\n");
            Console.WriteLine("0" + "\t " + matrizPrincipal[0, 0] + "\t " + "|" + "\t " + matrizPrincipal[0, 1] + "\t " + "|" + "\t" + matrizPrincipal[0, 2] + "\n");
            Console.WriteLine("1" + "\t " + matrizPrincipal[1, 0] + "\t " + "|" + "\t " + matrizPrincipal[1, 1] + "\t " + "|" + "\t " + matrizPrincipal[1, 2] + "\n");
            Console.WriteLine("2" + "\t " + matrizPrincipal[2, 0] + "\t " + "|" + "\t " + matrizPrincipal[2, 1] + "\t " + "|" + "\t " + matrizPrincipal[2, 2] + "\n\n\n");
                        
        }

    }
}
