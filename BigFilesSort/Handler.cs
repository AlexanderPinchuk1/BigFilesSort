using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BigFilesSort
{
    class Handler
    {
        public void ButGenerateFileHandler(string filePath)
        {
            GenerateFile(filePath);
        }

        private void GenerateFile(string filePath)
        {
            Generator.FileGenerator fileGenerator = new Generator.FileGenerator(filePath,100);
            try
            {
                var dateStartTime = DateTime.Now;
                fileGenerator.Generate();
                MessageBox.Show("Completed!\nCompletion time: " + (DateTime.Now - dateStartTime).Minutes + " min " + (DateTime.Now - dateStartTime).Seconds + " sec", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void ButSortFileHandler(string filePathForSort,string filePathForResult)
        {
            SortFile(filePathForSort, filePathForResult);
        }

        private void SortFile(string filePathForSort, string filePathForResult)
        {
            FileSort.Sort sort = new FileSort.Sort(filePathForSort, filePathForResult);

            try
            {
                var dateStartTime = DateTime.Now;
                sort.Execution();
                MessageBox.Show("Completed!\nCompletion time: " + (DateTime.Now - dateStartTime).Minutes + " min " + (DateTime.Now - dateStartTime).Seconds + " sec", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
