using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace Chapter16
{
    public class DirectoryTreeView : TreeView
    {    
        // констурктор строит не полное дерево каталогов
        public DirectoryTreeView()
        {
            RefreshTree();
        }
        public void RefreshTree()
        {
            BeginInit();
            Items.Clear();
            // получаем информ. о дисках.   
            DriveInfo[] drives = DriveInfo .GetDrives();
            foreach (DriveInfo drive in drives)
            {
                char chDrive = drive.Name.ToUpper ()[0];
                DirectoryTreeViewItem item =  new  DirectoryTreeViewItem(drive.RootDirectory);
                // если диск готов выводим метку тома, иначе только тип  
                if (chDrive != 'A' && chDrive !=  'B' && drive.IsReady && drive .VolumeLabel.Length > 0)
                    item.Text = String.Format("{0}  ({1})", drive.VolumeLabel, drive.Name);
                else
                    item.Text = String.Format("{0}  ({1})", drive.DriveType,    drive.Name);   
                // Выбираем картинку для диска.          
       if (chDrive == 'A' || chDrive == 'B')
                    item.SelectedImage = item .UnselectedImage = new BitmapImage(  new Uri("C:/Users/7777/source/repos/Chapter16/Chapter16/35FLOPPY.BMP"));
                else 
                if (drive.DriveType ==  DriveType.CDRom)
                    item.SelectedImage = item .UnselectedImage = new BitmapImage( new Uri("C:/Users/7777/source/repos/Chapter16/Chapter16/CDDRIVE.BMP"));
                else
                    item.SelectedImage = item .UnselectedImage = new BitmapImage(  new Uri("C:/Users/7777/source/repos/Chapter16/Chapter16/DRIVE.BMP"));
                Items.Add(item);
                // зАполняем информацию о каталогах   
                if (chDrive != 'A' && chDrive !=  'B' && drive.IsReady)
                    item.Populate();
            }
            EndInit();
        }    
    }
    }
