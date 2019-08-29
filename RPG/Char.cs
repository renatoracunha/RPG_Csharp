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
    class Char
    {
        #region Atributos
        private int id, pontuacao, forca;
        private bool vivo;
        private string nome, classe;

        public string FilesPath(string mp3)
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string launcherPath = Uri.UnescapeDataString(uri.Path); //launcher.exe
            string launcherDir = Path.GetDirectoryName(launcherPath); //pasta launcher
            string appDir = Path.GetDirectoryName(launcherDir); //pasta x
            string mp3Path = Path.Combine(appDir, "midia", mp3);
            return mp3Path;
        }


        #endregion

        #region propriedades
        public int Id { get => id; set => id = value; }//0 para herói, 1 para mago, 2 para arqueiro
        public int Pontuacao { get => pontuacao; set => pontuacao = value; }
        public int Forca { get => forca; set => forca = value; }
        public string Classe { get => classe; set => classe = value; }//0 para herói, 1 para mago, 2 para arqueiro
        public bool Vivo { get => vivo; set => vivo = value; }
        public string Nome { get => nome; set => nome = value; }
       

        #endregion

        #region Métodos
        public int Andar()
        {
            Console.WriteLine("{0}, o {1}, está andando.", this.Nome, this.Classe);
            return 0;
        }

        public int Correr()
        {
            Console.WriteLine("{0}, o {1}, está correndo.", this.Nome, this.Classe);
            return 2;
        }

        public int Pular()
        {
            Console.WriteLine("{0}, o {1}, está pulando.", this.Nome, this.Classe);
            return 1;
        }
        public void GanharPonto()
        {
            this.pontuacao = Pontuacao + 1;
            Console.WriteLine("{0}, o {1}, ganhou um ponto por derrotar o inimigo.", this.nome, this.classe);
        }
        public void PerderPonto()
        {
            this.pontuacao = Pontuacao - 1;
            Console.WriteLine("{0}, o {1}, perdeu um ponto por fugir do inimigo.", this.nome, this.classe);
        }
        public void IsAlive()
        {
            if (Pontuacao <= 0)
            {
                Vivo = false;
            }
        }
        public int Attack()
        {
            int a = 0, rdm = 0;
            Random random = new Random();
            rdm = random.Next(0, 10);
            a = Forca + Forca * rdm / 10;
            return a;
        }
        #endregion
    }


}
