using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Xml.Serialization;

namespace Generator
{
    public class FileGenerator
    {
        private const int NUM_BYTES_IN_GBYTE = 1024 * 1024 * 1024;
       
        
        private readonly int MaxNumSymbolInStr;
        private readonly string FilePath;

        private readonly Random RandomValue;

        public FileGenerator(string filePath, int maxNumSymbolInStr)
        {
            RandomValue = new Random();
            FilePath = filePath;
            MaxNumSymbolInStr = maxNumSymbolInStr;
        }
        public void Generate()
        {
            FileStream fileStream = new FileStream(FilePath, FileMode.Create);
            using StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Unicode);
            while (fileStream.Length < NUM_BYTES_IN_GBYTE)
            {
                streamWriter.WriteLine(GetRandomString());
            }

        }

        private string GetRandomString()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, RandomValue.Next(1, MaxNumSymbolInStr)).Select(s => s[RandomValue.Next(s.Length)]).ToArray());
        }
    }
}
