using System;

namespace FuseCodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            FuseGenerator fuseCodeGenerator = new FuseGenerator();

            Console.Write("Programme de génération d'application Fuse Angular\n");

            Console.WriteLine("Entrer le nom de l'application:");
            fuseCodeGenerator.appTitle = Console.ReadLine();
            Console.WriteLine("Entrer le nom de la class:");
            fuseCodeGenerator.classTitle = Console.ReadLine();

            Console.WriteLine("Entrer 'go' pour lancer la génération des fichiers: ");
            while ((Console.ReadLine()) != "go")
            {              
                Console.ReadLine();
            }

            fuseCodeGenerator.Go();
            Console.ReadLine();            
        }
    }
}
