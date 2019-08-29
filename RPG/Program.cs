using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;
using System.Reflection;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {   //sons
            Char som = new Char();
            string dramatic, knight, wizard, rosh, sad, victory;
            dramatic =  som.FilesPath("Dramatic Event Sound Effect.wav");
            knight = som.FilesPath("KNİGHT 1.wav");
            wizard = som.FilesPath("İCE WİZARD 4.wav");
            rosh = som.FilesPath("Roshan_Slam.wav");
            sad = som.FilesPath("sad violin-[AudioTrimmer.com].wav");
            victory = som.FilesPath("Duel_victory (online-audio-converter.com).wav");
          
            SoundPlayer simpleSound = new SoundPlayer(dramatic);
            SoundPlayer heroAttack = new SoundPlayer(knight);
            SoundPlayer mageAttack = new SoundPlayer(wizard);
            SoundPlayer dragonAttack = new SoundPlayer(rosh);
            SoundPlayer loserSound = new SoundPlayer(sad);
            SoundPlayer winnerSound = new SoundPlayer(victory);
            //fim dos sons
            
            Boss ead = new Boss();
            Hero hero = new Hero();
            Mage mage = new Mage();
            hero.Classe = "Herói";
            hero.Forca = 30;
            hero.Pontuacao = 120;
            hero.Vivo = true;
            mage.Classe = "Mago";
            mage.Forca = 15;
            mage.Pontuacao = 70;
            mage.Vivo = true;
            ead.Nome = "Earthy Abysmal Dragon";
            ead.Vivo = true;
            ead.Pontuacao = 600;
            ead.Forca = 60;
            ead.Classe = "Monstro";

            Console.WriteLine("Informe os nome do Herói: ");
            hero.Nome = Console.ReadLine();
            Console.WriteLine("\nInforme os nome do Mago");
            mage.Nome = Console.ReadLine();
            
            Console.WriteLine("\nTeste se seu herói está em forma");
            int i = 0, choice = 0;
            while (i != 2)
            {
            OptionsHero:
                Console.WriteLine("Digite 1 para andar, 2 para pular e 3 para correr!");
                choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        i = hero.Andar();
                        break;
                    case 2:
                        i = hero.Pular();
                        break;
                    case 3:
                        i = hero.Correr();
                        break;
                    default:
                        Console.WriteLine("Ação inválida");
                        goto OptionsHero;
                }
            }
            Console.WriteLine("\nO Herói correu e você o perdeu de vista!");

            i = 0;
            choice = 0;
            Console.WriteLine("\nTeste se seu mago está em forma");
            while (i != 2)
            {
            OptionsMage:
                Console.WriteLine("Digite 1 para andar, 2 para pular e 3 para correr!");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        i = mage.Andar();
                        break;
                    case 2:
                        i = mage.Pular();
                        break;
                    case 3:
                        i = mage.Correr();
                        break;
                    default:
                        Console.WriteLine("Ação inválida");
                        goto OptionsMage;
                }
                //i = 2;
            }
            Console.WriteLine("\n--------------O Mago correu e encontrou o herói parado, assustado e encarando algo, o que seria?!-------------");
           
            simpleSound.Play();
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("O que é isso????? Você gastou tempo demais e não percebeu onde chegou!!!");
            Console.WriteLine("-----------------------------------A wild Earthy Abysmal Dragon, EAD, appears!------------------------------------------");
            Console.WriteLine("\nLute com ele e tente sair vitorioso para salvar seu semestre!!!");
            //Início da combate
            Combat:
            while (ead.Vivo && (hero.Vivo || mage.Vivo))
            {
                Console.WriteLine("---------------------------INICIO DE TURNO, PRESSIONE QUALQUER TECLA PARA CONTINUAR--------------------------");

                Console.ReadKey();

                int dano = 0;

                if (hero.Vivo)
                {
                    Console.WriteLine("O herói tem {0} pts de vida!", hero.Pontuacao);
                }
                else
                {
                    Console.WriteLine("O herói está morto!");
                }
                if (mage.Vivo)
                {
                    Console.WriteLine("O mago tem {0} pts de vida!", mage.Pontuacao);
                }
                else
                {
                    Console.WriteLine("O mago está morto!");
                }
                Console.WriteLine("O monstro tem {0} de pts de vida", ead.Pontuacao);

                Console.WriteLine("---------------------------FASE DE BATALHA, PRESSIONE QUALQUER TECLA PARA CONTINUAR--------------------------");

                Console.ReadKey();

                //ação do heroi
                if (hero.Vivo)
                {
                HeroFight:
                    Console.WriteLine("\nEscolha a ação do herói {0}", hero.Nome);
                    Console.WriteLine("1 para ataque físico \n2 para Super Força\n3 para Lâmina de dois gumes!", hero.Nome);
                    choice = 0;
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            dano = hero.Attack();
                            ead.Pontuacao = ead.Pontuacao - dano;
                           
                            heroAttack.Play();
                            Console.WriteLine("herói {0} atacou, causando {1} de dano!", hero.Nome, dano);
                            break;
                        case 2:
                            hero.Ult();
                            break;
                        case 3:
                            dano = hero.LaminaDeDoisGumes();
                            ead.Pontuacao = ead.Pontuacao - dano;
                            break;
                        default:
                            Console.WriteLine("Escolha uma ação válida!");
                            goto HeroFight;

                    }


                }
                else
                {
                    Console.WriteLine("O herói {0} está morto!", hero.Nome);
                }

                //ação do mago
                if (mage.Vivo)
                {
                MageTurn:
                    Console.WriteLine("\n\nEscolha a ação do mago {0}", mage.Nome);
                    Console.WriteLine("1 para ataque físico\n2 para Tesouro Escondido(só pode ser usado 1 vez)\n3 para poder de ataque(só pode ser usado 1 vez)\n4 para poder de cura", hero.Nome);
                    choice = 0;
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            dano = mage.Attack();
                            ead.Pontuacao = ead.Pontuacao - dano;
                            
                            mageAttack.Play();
                            Console.WriteLine("O mago {0} atacou, causando {1} de dano!", mage.Nome, dano);
                            break;
                        case 2:
                            mage.HiddenTreasure();
                            break;
                        case 3:
                            dano = mage.MagePower();
                            ead.Pontuacao = ead.Pontuacao - dano;
                            break;
                        case 4:
                            mage.Ult();
                            break;
                        default:
                            Console.WriteLine("Ação escolhida inválida!");
                            goto MageTurn;
                    }


                }
                else
                {
                    Console.WriteLine("O mago {0} está morto!! não pode fazer ações!", mage.Nome);
                }

                //ação do monstro

                Console.WriteLine("\nO monstro {0} prepara seu ataque!---pressione uma tecla para continuar!", ead.Nome);
                Console.ReadKey();
                if (ead.Vivo)
                {
                    Console.WriteLine("\n\nO monstro {0} está cego de raiva e escolhe aleatóriamente um dos dois para lançar seu ataque!", ead.Nome);
                    Random random = new Random();
                    int rdm = 0;
                MonsterTurn:
                   
                    rdm = random.Next(0, 3);
                    switch (rdm)
                    {
                        case 0:
                            if (mage.Vivo)
                            {
                                dano = ead.Attack();
                                mage.Pontuacao = mage.Pontuacao - dano;
                               
                                dragonAttack.Play();
                                Console.WriteLine("O monstro ataca o mago {0}, causando {1} de dano!", mage.Nome, dano);
                            }
                            else
                            {
                                Console.WriteLine("O monstro errou o ataque!");
                            }


                            break;
                        case 1:
                            if (hero.Vivo)
                            {
                                dano = ead.Attack();
                                hero.Pontuacao = hero.Pontuacao - dano;
                                dragonAttack.Play();
                                Console.WriteLine("O monstro ataca o herói {0}, causando {1} de dano!", hero.Nome, dano);
                            }
                            else
                            {
                                Console.WriteLine("O monstro errou o ataque!");
                            }

                            break;


                        case 2:
                            Console.WriteLine("EAD lançou Confusion, os aliados não conseguem entender nada tiram os próprios pontos de vida!!.");
                            ead.Nani();
                            if (hero.Vivo)
                            {
                                dano = hero.Attack();
                                hero.Pontuacao = hero.Pontuacao - dano;
                            }
                            if (mage.Vivo)
                            {
                                dano = mage.Attack();
                                mage.Pontuacao = mage.Pontuacao - dano;
                            }
                            break;
                        default:
                            goto MonsterTurn;
                    }
                }
                hero.IsAlive();
                if (!hero.Vivo)
                {
                    hero.Ult();//se o herói estiver morto mas ainda possuir o poder especial, ele ativará e voltará ao jogo.
                }
                mage.IsAlive();
                ead.IsAlive();
            }
            Console.WriteLine("--------------------------------------Chega o fim da batalha-------------------------------------------");
            Console.ReadKey();
            Console.Clear();

            /*hero.IsAlive();
            mage.IsAlive();
            ead.IsAlive();*/
            

            if (ead.Vivo)
            {
               
                loserSound.Play();
                Console.WriteLine("O monstro {0}, EAD, fez mais duas vítimas!!!", ead.Nome);
            }
            else
            {
                if (hero.Vivo && mage.Vivo)
                {
                    winnerSound.Play();
                    Console.WriteLine("Um milagre aconteceu! Os dois saíram vivos da carnificina e derrotaram {0}, o destruidor de semestres!", ead.Nome);
                }
                else if (!hero.Vivo)
                {
                    winnerSound.Play();
                    Console.WriteLine("Apenas o mago {0}, bruxo que é, saiu vivo!", mage.Nome);

                }
                else if (!mage.Vivo)
                {
                    winnerSound.Play();
                    Console.WriteLine("Apenas o herói {0} saiu vivo no combate!", hero.Nome);
                }
                else
                {
                    loserSound.Play();
                    Console.WriteLine("O monstro {0}, em seu último suspiro, lançou um golpe contundente e matou o último dos aventureiros!! Todos morreram!", ead.Nome);
                }
            }

            Console.ReadKey();

            Console.WriteLine("Deseja batalhar novamente?\n1 para sim\n2 para não");
            int question = 0;
            question = int.Parse(Console.ReadLine());
            switch (question)
            {
                case 1:
                    ead.Vivo = true;
                    ead.Pontuacao = 400;
                    mage.Vivo = true;
                    mage.Pontuacao = 70;
                    hero.Vivo = true;
                    hero.Pontuacao = 120;
                    goto Combat;
                default:
                    break;
            }
        }
    }
}
