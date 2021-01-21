using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2.FilesInDrivesStatistic
{
    // Устройство
    public class LogicalDrive
    {
        // Событие-уведомление формы о том, что все каталоги были прочитаны
        public event Action<LogicalDrive> SubDirectoriesDiscoveredEvent;

        // Путь к устройству
        public string AbsolutePath;
        // Каталоги устройства
        public List<Directory> SubDirectories;

        public LogicalDrive(string absolutePath)
        {
            AbsolutePath = absolutePath;
            SubDirectories = new List<Directory>();
        }

        // Получение каталогов с устройства
        public void GetDirectories()
        {
            if (!String.IsNullOrEmpty(AbsolutePath))
            {
                try
                {
                    SubDirectories.Clear();

                    foreach (string dirName in RSDNDirectory.GetDirectories(AbsolutePath))
                    {
                        SubDirectories.Add(new Directory(dirName, AbsolutePath + dirName));
                    }

                    SubDirectoriesDiscoveredEvent?.Invoke(this);
                }
                catch (Win32Exception e)
                {
                    MessageBox.Show(e.Message);                   
                }
            }
        }
    }
}
