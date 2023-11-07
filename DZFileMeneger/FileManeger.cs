using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DZFileMeneger
{
    internal class FileManeger
    {
        private int CountReadRow = 0;
        private int CountWriteRow = 0;
        private bool IsStreamWork=true;
        //streamreader, streamwriter , file.
        public void BigFileWriter(string path, int countWriteRow, int rowCharCount)
        {
            using (StreamWriter streamWriter = new StreamWriter(path, false))
            {
                int countRow = countWriteRow / 20;
                int countTemp = countRow;
                Console.WriteLine("Write file begin");
                for (int i = 0; i < countWriteRow; i++)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int j = 0; j < rowCharCount; j++)
                    {
                        sb.Append("a");
                    }
                    sb.Append("\n");
                    streamWriter.Write(sb.ToString());
                    CountWriteRow = i;
                }
                IsStreamWork = false;
                streamWriter.Close();
                Console.WriteLine("Write file complit");
            }
        }
        public void GetCountWriteRow()
        {
            IsStreamWork = true;
            DateTime time = DateTime.Now;
            while(IsStreamWork)
            {
                Console.WriteLine($"{DateTime.Now - time}ms {CountWriteRow}");
                Thread.Sleep(200);
            }
            Console.WriteLine($"{DateTime.Now - time}ms {CountWriteRow}");
        }
        public void GetCountReadRow()
        {
            IsStreamWork = true;
            DateTime time = DateTime.Now;
            while (IsStreamWork)
            {
                Console.WriteLine($"{DateTime.Now - time}ms {CountReadRow}");
                Thread.Sleep(100);
            }
            Console.WriteLine($"{DateTime.Now - time}ms {CountReadRow}");
        }

        public string BigFileReader(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                Console.WriteLine("Read file begin");
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    CountReadRow++;
                }
                string readResult = $"Count is readed row: {CountReadRow}";
                IsStreamWork = false;
                Console.WriteLine("Read file complit");
               // Console.WriteLine(readResult);

                return readResult;
            }

        }
    }
}
