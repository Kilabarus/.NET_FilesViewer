using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

/*
 * Лабораторная №2
 * 
 * Вариант 2
 * Задано устройство (DriveComboBox). 
 * В первом окне (DirectoryListBox) отображается список всех каталогов выбранного устройства. 
 * При выделении каталога в первом окне вывести в первый ListBox список всех файлов этого каталога 
 * и статистику (количество файлов каждого типа: системных, скрытых и т.д.). 
 * Аналогично при выделении каталога в первом ListBoxе, во втором ListBoxе отображается информация о его содержимом. 
 * Так же для второго и третьего ListBoxа.
 *      
 *  Данильченко Роман, 9 гр.
 */

namespace _2.FilesInDrivesStatistic
{
    public partial class Form1 : Form
    {
        // Массив с устройствами
        LogicalDrive[] logicalDrives;        

        // Вспомогательный поток
        Thread subThread;

        // Один из 3 ЛистБоксов, который нужно будет заполнить после получения всех файлов и папок
        ListBox listBoxToFill;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            // Получаем названия (пути) подключенных устройств
            string[] logicalDrivesNames = Environment.GetLogicalDrives();
            logicalDrives = new LogicalDrive[logicalDrivesNames.Length];
            
            // Заполняем массив с устройствами
            for (int i = 0, numOfLogicalDrives = logicalDrivesNames.Length; i < numOfLogicalDrives; ++i)
            {
                logicalDrives[i] = new LogicalDrive(logicalDrivesNames[i]);
            }

            // Добавляем устройства в КомбоБокс
            DriveComboBox.Items.AddRange(logicalDrivesNames);
        }

        private void DriveComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LogicalDrive chosenLogicalDrive = logicalDrives[DriveComboBox.SelectedIndex];

            subThread = new Thread(() => getLogicalDriveSubDirectories(chosenLogicalDrive));
            subThread.Start();
        }        

        public void getLogicalDriveSubDirectories(LogicalDrive chosenLogicalDrive)
        {
            Thread t = new Thread(chosenLogicalDrive.GetDirectories);

            chosenLogicalDrive.SubDirectoriesDiscoveredEvent -= onLogicalDriverSubDirectoriesDiscovered;
            chosenLogicalDrive.SubDirectoriesDiscoveredEvent += onLogicalDriverSubDirectoriesDiscovered;

            t.Start();
            t.Join();
        }

        // Обработчик события получения списка папок на устройстве
        public void onLogicalDriverSubDirectoriesDiscovered(LogicalDrive logicalDrive)
        {
            DirectoryListBox.BeginInvoke(new Action(() => 
            {
                DirectoryListBox.Items.Clear();

                foreach (Directory directory in logicalDrive.SubDirectories)
                {
                    DirectoryListBox.Items.Add(directory.DirName);
                }                
            }));
        }

        private void DirectoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {            
            Directory chosenDirectory = logicalDrives[DriveComboBox.SelectedIndex]
                                            .SubDirectories[DirectoryListBox.SelectedIndex];

            ListBox1.Items.Clear();
            ListBox2.Items.Clear();
            ListBox3.Items.Clear();

            CreateThreadToGetSubDirectoriesAndFilesAndFillListBox(chosenDirectory, ListBox1);
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox1.SelectedIndex >= 1 
                && ListBox1.SelectedIndex <= logicalDrives[DriveComboBox.SelectedIndex]
                                                .SubDirectories[DirectoryListBox.SelectedIndex]
                                                .SubDirectories.Count)
            {
                Directory chosenDirectory = logicalDrives[DriveComboBox.SelectedIndex]
                                                .SubDirectories[DirectoryListBox.SelectedIndex]
                                                .SubDirectories[ListBox1.SelectedIndex - 1];

                ListBox2.Items.Clear();
                ListBox3.Items.Clear();

                CreateThreadToGetSubDirectoriesAndFilesAndFillListBox(chosenDirectory, ListBox2);                
            }            
        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox2.SelectedIndex >= 1
                && ListBox2.SelectedIndex <= logicalDrives[DriveComboBox.SelectedIndex]
                                                .SubDirectories[DirectoryListBox.SelectedIndex]
                                                .SubDirectories[ListBox1.SelectedIndex - 1]
                                                .SubDirectories.Count)
            {
                Directory chosenDirectory = logicalDrives[DriveComboBox.SelectedIndex]
                                                .SubDirectories[DirectoryListBox.SelectedIndex]
                                                .SubDirectories[ListBox1.SelectedIndex - 1]
                                                .SubDirectories[ListBox2.SelectedIndex - 1];

                ListBox3.Items.Clear();

                CreateThreadToGetSubDirectoriesAndFilesAndFillListBox(chosenDirectory, ListBox3);
            }
        }

        private void CreateThreadToGetSubDirectoriesAndFilesAndFillListBox(Directory chosenDirectory, ListBox listBox)
        {
            listBoxToFill = listBox;

            subThread = new Thread(() => getDirectorySubDirectories(chosenDirectory));
            subThread.Start();
        }

        private void getDirectorySubDirectories(Directory chosenDirectory)
        {
            Thread t = new Thread(chosenDirectory.GetDirectoriesAndFiles);

            chosenDirectory.SubDirectoriesAndFilesDiscoveredEvent -= onDirectorySubDirectoriesAndFilesDiscovered;
            chosenDirectory.SubDirectoriesAndFilesDiscoveredEvent += onDirectorySubDirectoriesAndFilesDiscovered;            

            t.Start();
            t.Join();
        }

        // Обработчик события получения списка подпапок и файлов папки 
        public void onDirectorySubDirectoriesAndFilesDiscovered(Directory directory)
        {
            if (InvokeRequired)
            {
                listBoxToFill.BeginInvoke(new Action(() =>
                {
                    // Выводим найденные каталоги
                    listBoxToFill.Items.Add("Папки:");
                    foreach (Directory dir in directory.SubDirectories)
                    {
                        listBoxToFill.Items.Add(dir.DirName);
                    }

                    // Выводим найденные файлы
                    listBoxToFill.Items.Add("");
                    listBoxToFill.Items.Add("Файлы:");
                    foreach (string fileName in directory.FileNames)
                    {
                        listBoxToFill.Items.Add(fileName);
                    }

                    // Выводим статистику
                    listBoxToFill.Items.Add("");
                    listBoxToFill.Items.Add("Статистика:");

                    // Получаем названия констант перечисления типов файлов
                    int i = 0;
                    string[] filesAttributesNames = Enum.GetNames(typeof(FileAttributes));

                    // Названия типов файлов и соответствующие им найденные кол-ва файлов совпадут
                    foreach (var v in directory.filesTypesCounts)
                    {
                        listBoxToFill.Items.Add(filesAttributesNames[i++] + ": " + v.Value);
                    }                    
                }));                
            }            
        }       
    }
}
