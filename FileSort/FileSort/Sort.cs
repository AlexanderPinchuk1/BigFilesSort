using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace FileSort
{
    public class Sort
    {
        private const int ONE_MB_IN_BYTES = 1024 * 1024;
        private const string TXT_EXTENSION = ".txt";

        private readonly string FilePathForSort;
        private readonly string FilePathForResult;

        private readonly List<string> ListOfFilePaths;

        public Sort(string filePathForSort, string filePathForResult)
        {
            FilePathForSort = filePathForSort;
            FilePathForResult = filePathForResult;
            ListOfFilePaths = new List<string>();
        }

        public void Execution()
        {
            FileSplitting();
            SortLinesInFiles();
            MergeSort();
        }

        private void FileSplitting()
        {
            using StreamReader streamReader = new StreamReader(FilePathForSort);

            List<String> text = new List<string>();
            bool endOfFile = false;

            while (!endOfFile)
            {
                int size = 0;
                while (size < ONE_MB_IN_BYTES * 100)
                {
                    string line = streamReader.ReadLine();
                    if (line == null)
                    {
                        endOfFile = true;
                        break;
                    }
                    size += line.Length * sizeof(char);
                    text.Add(line);
                }
                string filePath = GetNewFilePath();
                File.WriteAllLines(filePath, text, Encoding.Unicode);
                ListOfFilePaths.Add(filePath);
                text.Clear();
            }

        }

        private void SortLinesInFiles()
        {
            foreach (string filePath in ListOfFilePaths)
            {
                SortLinesInFile(filePath);
            }
        }

        private void SortLinesInFile(string filePath)
        {
            string[] fileText = File.ReadAllLines(filePath, Encoding.Unicode);
            Array.Sort(fileText);
            File.WriteAllLines(filePath, fileText, Encoding.Unicode);
        }

        private string GetNewFilePath()
        {
            string filePath = "";
            bool flag = true;
            while (flag)
            {
                filePath = GetRandomString() + TXT_EXTENSION;
                if (!File.Exists(filePath))
                {
                    flag = false;
                }
            }
            return filePath;
        }
        private string GetRandomString()
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, random.Next(1, 5)).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void MergeSort()
        {
            while (ListOfFilePaths.Count != 1)
            {
                MergeTwoFiles(ListOfFilePaths[0], ListOfFilePaths[1]);
                DeleteFirstTwoFiles();
            }
            OverwriteResultingFile();
        }

        private void MergeTwoFiles(string firtFilePath, string secondFilePath)
        {
            string newFilePath = GetNewFilePath();

            using var firstStreamReader = new StreamReader(firtFilePath, Encoding.Unicode);
            using var secondStreamReader = new StreamReader(secondFilePath, Encoding.Unicode);
            using var streamWriter = new StreamWriter(new FileStream(newFilePath, FileMode.Create), Encoding.Unicode);

            string lineFromFirstFile = firstStreamReader.ReadLine();
            string lineFromSecondFile = secondStreamReader.ReadLine();

            while ((lineFromFirstFile != null) && (lineFromSecondFile != null))
            {
                if (String.Compare(lineFromFirstFile, lineFromSecondFile) <= 0)
                {
                    streamWriter.WriteLine(lineFromFirstFile);
                    lineFromFirstFile = firstStreamReader.ReadLine();
                }
                else
                {
                    streamWriter.WriteLine(lineFromSecondFile);
                    lineFromSecondFile = secondStreamReader.ReadLine();
                }
            }

            if (lineFromSecondFile != null)
            {
                streamWriter.WriteLine(lineFromSecondFile);
                WriteTheRestOfTheFile(secondStreamReader, streamWriter);
            }
            else if (lineFromFirstFile != null)
            {
                streamWriter.WriteLine(lineFromFirstFile);
                WriteTheRestOfTheFile(firstStreamReader, streamWriter);
            }

            ListOfFilePaths.Add(newFilePath);
        }

        private void DeleteFirstTwoFiles()
        {
            File.Delete(ListOfFilePaths[0]);
            File.Delete(ListOfFilePaths[1]);
            ListOfFilePaths.RemoveRange(0, 2);
        }

        private void OverwriteResultingFile()
        {
            File.Move(ListOfFilePaths[0], FilePathForResult, true);
        }

        private void WriteTheRestOfTheFile(StreamReader streamReader, StreamWriter streamWriter)
        {
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                streamWriter.WriteLine(line);
            }
        }
    }
}

