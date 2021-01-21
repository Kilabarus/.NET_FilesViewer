using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _2.FilesInDrivesStatistic
{
    // Каталог
    public class Directory
    {
        // Событие-уведомление формы о том, что все каталоги и файлы были прочитаны
        public event Action<Directory> SubDirectoriesAndFilesDiscoveredEvent;

        // Название папки и полный путь до неё
        public string DirName, AbsolutePath;
        // Подкаталоги каталога
        public List<Directory> SubDirectories;
        // Названия файлов каталога
        public List<string> FileNames;

        // Статистика по файлам в каталоге - тип файлов и количество файлого такого типа
        public Dictionary<FileAttributes, int> filesTypesCounts;

        public Directory(string dirName, string absolutePath)
        {
            DirName = dirName;
            AbsolutePath = absolutePath;

            SubDirectories = new List<Directory>();
            FileNames = new List<string>();

            filesTypesCounts = new Dictionary<FileAttributes, int>();
            Array fileAttributes = Enum.GetValues(typeof(FileAttributes));

            foreach (var v in fileAttributes)
            {
                filesTypesCounts.Add((FileAttributes)v, 0);
            }
        }

        // Получение подкаталогов и файлов каталога
        public void GetDirectoriesAndFiles()
        {            
            if (!String.IsNullOrEmpty(AbsolutePath))
            {
                try
                {
                    SubDirectories.Clear();
                    FileNames.Clear();

                    foreach (string dirName in RSDNDirectory.GetDirectories(AbsolutePath))
                    {
                        if (!dirName.Equals(".") && !dirName.Equals(".."))
                        {
                            SubDirectories.Add(new Directory(dirName, AbsolutePath + "\\" + dirName));
                        }
                    }

                    Array fileAttributes = Enum.GetValues(typeof(FileAttributes));

                    foreach (var v in fileAttributes)
                    {
                        filesTypesCounts[(FileAttributes)v] = 0;
                    }

                    foreach (string fileName in RSDNDirectory.GetInternal(AbsolutePath, filesTypesCounts))
                    {
                        FileNames.Add(fileName);
                    }

                    SubDirectoriesAndFilesDiscoveredEvent?.Invoke(this);
                }
                catch (Win32Exception e)
                {
                    MessageBox.Show(e.Message);                    
                }
            }
        }
    }
}
