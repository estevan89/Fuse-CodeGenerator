using System;
using System.IO;
using System.Text;

namespace FuseCodeGenerator
{
    public class FuseGenerator
    {
        public string appTitle { get; set; }
        public string classTitle { get; set; }
        public int nbLines { get; set; }

        private readonly string _folderName = @"FuseGenerator\";
        private readonly string _folderPath = @"C:\Projets\";
        private readonly string _author = "Estevan Vernez";

        public FuseGenerator()
        {
        }

        public void Go()
        {
            CreateFile();
            //CreateLines();
        }

        /// <summary>
        /// Nom du fichier avec le dossier
        /// </summary>
        /// <returns></returns>
        private string FileName()
        {
            if (this.appTitle.Length <= 0)
            {
                throw new Exception("Le chemin ou le nom de l'application n'est pas correctement renseignée");
            }
            return _folderPath + _folderName + "\\" + appTitle + ".txt";
        }

        /// <summary>
        /// Création des dossiers nécessaires
        /// </summary>
        private void CreateFolder(string folderName)
        {            
            // If directory does not exist, create it. 
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
        }

        /// <summary>
        /// Création du fichier physique sur le disque
        /// (Éventuellement le dossier aussi)
        /// </summary>
        private void CreateFile()
        {
            try
            {
                string basePath = _folderPath + _folderName;
                // Creation du dossier de base s'il n'est pas existant
                CreateFolder(basePath);
                Console.WriteLine("Create: " + basePath);

                // Création du dossier de l'application
                basePath = basePath + appTitle + "\\";
                CreateFolder(basePath);
                Console.WriteLine("Create: " + basePath);
                
                // Création du dossier list
                CreateFolder(basePath + "Item");
                Console.WriteLine("Create: " + basePath + "Item");
                CreateFolder(basePath + "List");
                Console.WriteLine("Create: " + basePath + "List");

                // Création du fichier 
                using (StreamWriter sw = File.CreateText(basePath + appTitle + ".module.ts"))
                {
                    sw.WriteLine(Content.WriteBaseModule(appTitle, classTitle));
                }


                File.Create(basePath + "\\List\\" + "list.component.html");
                File.Create(basePath + "\\List\\" + "list.component.scss");
                File.Create(basePath + "\\List\\" + "list.component.ts");
                File.Create(basePath + "\\List\\" + "list.model.ts");
                File.Create(basePath + "\\List\\" + "list.service.ts");
                Console.Write("Création des fichiers List.");

                File.Create(basePath + "\\Item\\" + "item.component.html");
                File.Create(basePath + "\\Item\\" + "item.component.scss");
                File.Create(basePath + "\\Item\\" + "item.component.ts");
                File.Create(basePath + "\\Item\\" + "item.model.ts");
                File.Create(basePath + "\\Item\\" + "item.service.ts");
                Console.Write("Création des fichiers Item.");

                

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// Création des lignes du fichier
        /// </summary>
        private void CreateLines()
        {
            try
            {
                string fileName = FileName();

                // Create a new file     
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.WriteLine("New file created: {0}", DateTime.Now.ToString());
                    sw.WriteLine("Author: Mahesh Chand");
                    sw.WriteLine("Add one more line ");
                    sw.WriteLine("Add one more line ");
                    sw.WriteLine("Done! ");
                }

                // Open the stream and read it back.   
                // Write file contents on console. 
                /*using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }*/
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
