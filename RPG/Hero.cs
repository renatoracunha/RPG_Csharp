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
    class Hero : Char
    {
        
        
       
        bool heroUlt = true, msgRec = true;
        #region Métodos
        public void Ult()
        {
            if (heroUlt)
            {
                Char som = new Char();
                string heal = som.FilesPath("HEAL SOUND!.wav");
                SoundPlayer healSound = new SoundPlayer(heal);
                Pontuacao = Pontuacao + 100;
                Console.WriteLine("------------------------------O herói ativa seu poder especial invocando mais 100 pts de vida através da RECUPERAÇÃO!----------------------------");
                heroUlt = false;
                healSound.Play();
                Vivo = true;
            }
            else
            {
                if (msgRec) { 
                Console.WriteLine("\n---->O herói já usou a recuperação, agora só no próximo semestre e por um valor absurdo!!");
                msgRec = false;
                }
            }
        }

        public int LaminaDeDoisGumes()
        {
            Char som = new Char();
            string edge = som.FilesPath("double edge.wav");

            SoundPlayer doubleEdge = new SoundPlayer(edge);
            Pontuacao = Pontuacao - 30;
            Console.WriteLine("O herói {0} sacrifica 30 pontos de vida para lançar um ataque devastador no monstro!!", Nome);
            doubleEdge.Play();
            return 80;
        }

        #endregion


    }
}
