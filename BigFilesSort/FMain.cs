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

namespace BigFilesSort
{
    public partial class FMain : Form
    {
        public FMain()
        {
            InitializeComponent();
            openFileDialog.Filter = "Text files(*.txt)|*.txt";
            openFileDialog.Title = "Opening file";
            saveFileDialog.Filter = "Text files(*.txt)|*.txt";
            saveFileDialog.Title = "Save file";
        }

        private void ButGenerateFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            string filePath = saveFileDialog.FileName;

            Thread thread = new Thread(new ParameterizedThreadStart(ThreadForGenerateFile));
            thread.Start(filePath);
        }

        private static void ThreadForGenerateFile(object filePath)
        {
            Handler handler = new Handler();
            handler.ButGenerateFileHandler((string)filePath);
        }

        private void ButSortFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            string filePathForSort = openFileDialog.FileName;

            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            string filePathForResult = saveFileDialog.FileName;

            FilePaths filePaths = new FilePaths(filePathForSort, filePathForResult);
            Thread thread = new Thread(new ParameterizedThreadStart(ThreadForSortFile));
            thread.Start(filePaths);
        }
        private static void ThreadForSortFile(object filePaths)
        {
            FilePaths paths = (FilePaths)filePaths;
            Handler handler = new Handler();
            handler.ButSortFileHandler(paths.FirstFilePath, paths.SecondFilePath);
        }

        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
