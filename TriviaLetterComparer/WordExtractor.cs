using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaLetterComparer
{
    public class WordExtractor
    {
        private static int READ_LENGTH = 1000;

        public ISet<string> Extract(string filepath)
        {
            using (var fs = new FileStream(filepath, FileMode.Open))
            {
                var words = Extract(fs);
                return words;
            }
        }

        public ISet<string> Extract(Stream fileStream)
        {
            var result = new HashSet<string>();
            var buffer = new byte[fileStream.Length];
            int bufferLength = 0;
            while (fileStream.Position < fileStream.Length)
            {
                int maxReadLength = READ_LENGTH;
                if (READ_LENGTH + fileStream.Position > fileStream.Length)
                {
                    maxReadLength = (int)(fileStream.Length - fileStream.Position);
                }
                bufferLength += fileStream.Read(buffer, bufferLength, maxReadLength);
            }
            string bufferStr = new string(ASCIIEncoding.ASCII.GetChars(buffer, 0, bufferLength));
            var lines = bufferStr.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                result.Add(line);
            }
            return result;
        }
    }
}
