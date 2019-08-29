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
    class Mage : Char
    {
        
        bool magePwr = true, mageTreasure = true;

        #region Métodos
        public void Ult()
        {
            if (Vivo)
            {
                Char som = new Char();
                string heal = som.FilesPath("HEAL SOUND!.wav");

                SoundPlayer healSound = new SoundPlayer(heal);
                Pontuacao = Pontuacao + 10;
                Console.WriteLine("O Mago usou seu poder de cura para ganhar 10 pts de vida!");
                
                healSound.Play();
            }
            else
            {
                Console.WriteLine("O Mago está morto, ação inválida");
            }
        }

        public void HiddenTreasure()
        {
            if (Vivo && mageTreasure)
            {
                Char som = new Char();
                string heal = som.FilesPath("HEAL SOUND!.wav");

                SoundPlayer healSound = new SoundPlayer(heal);
                Pontuacao = Pontuacao + 100;
                Console.WriteLine("O Mago usou seu tesouro para ganhar 100 pts de vida!");
                healSound.Play();
                mageTreasure = false;
            }
            else if (!Vivo)
            {
                Console.WriteLine("O Mago está morto, ação inválida");
            }
            else
            {
                Console.WriteLine("O Mago já usou seu tesouro escondido uma vez! Perdeu o turno procurando!");

            }
        }

        public int MagePower()
        {
            if (magePwr)
            {
                Char som = new Char();
                string explosion = som.FilesPath("Explosion-[AudioTrimmer.com].wav");

                SoundPlayer simpleSound = new SoundPlayer(explosion);

                Console.WriteLine("O Mago ataca usando cópia de uma magia que ele leu na internet e aplicou no mostro!");
                magePwr = false;
                simpleSound.Play();
                return 90;
            }
            else
            {
                Console.WriteLine("A mágia já foi copiada uma vez, o monstro notou!! Causou 0 de dano e você perdeu a ação!");
                return 0;
            }
        }
        #endregion
    }
}
