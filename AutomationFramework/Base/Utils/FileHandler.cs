using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Base.Utils
{
    public class FileHandler
    {        
        private FileInfo[] FileList { get; set; }
        private string DocumentName { get; set; }

        public FileHandler(string documentName)
        {
            DocumentName = documentName;
        }

        public void WaitFileToDownload()
        {
            bool isDownloaded = false;
            FileList = GetFileList();

            while (!isDownloaded)
            {
                var file = FileList.Where(f => f.Name.Contains(DocumentName) && f.Extension.Equals(".docx")).FirstOrDefault();

                if(file != null)
                {                    
                    isDownloaded = true;
                    break;
                }              
                
                FileList = GetFileList();
            }
        }

        private FileInfo[] GetFileList()
        {
            return new DirectoryInfo(Assembly.GetExecutingAssembly().Location).GetFiles();
        }

        public void DeleteDownloadedFile()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            bool isDeleted = false;            

            foreach (var file in FileList)
            {
                if (file.Name.Equals(DocumentName) && isDeleted == false)
                {
                    DeleteFile(file, out isDeleted);
                }
            }
        }

        private void DeleteFile(FileInfo file, out bool isDeleted)
        {
            try
            {
                file.Delete();
                isDeleted = true;
                DocumentName = null;
            }
            catch (IOException e)
            {
                Console.Write(e.StackTrace);
                isDeleted = false;
            }
        }
    }
}
