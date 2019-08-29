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
    class Boss : Char
    {
       

        #region Métodos
        public void Nani()
        {
            Char som = new Char();
            string nani = som.FilesPath("Nani.wav");
            SoundPlayer simpleSound = new SoundPlayer(nani);
            simpleSound.Play();
        }

        
        #endregion
    }
}
