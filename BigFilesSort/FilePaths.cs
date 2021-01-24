using System;
using System.Collections.Generic;
using System.Text;

namespace BigFilesSort
{
    class FilePaths
    {
        public string FirstFilePath { get; set; }
        public string SecondFilePath { get; set; }
        public FilePaths(string firstFilePath, string secondFilePath)
        {
            FirstFilePath = firstFilePath;
            SecondFilePath = secondFilePath;
        }
    }
}
