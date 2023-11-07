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
        private bool IsStreamWork=true;//флаг отключения полсе записи или счиитывания
        //streamreader, streamwriter , file.

        //создаем большой файл и записываем его по указанному пути
        public void BigFileWriter(string path, int countWriteRow, int rowCharCount)
        {
            using (StreamWriter streamWriter = new StreamWriter(path, false))
            {
                Console.WriteLine("Write file begin");
                //заполняем строку символами в строках
                for (int i = 0; i < countWriteRow; i++)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int j = 0; j < rowCharCount; j++)
                    {
                        sb.Append("a");
                    }
                    sb.Append("\n");
                    //записываем в файл  
                    streamWriter.Write(sb.ToString());
                    CountWriteRow = i;
                }
                IsStreamWork = false;
                streamWriter.Close();
                Console.WriteLine("Write file complit");
            }
        }
        //кол-во записанных сток
        public void GetCountWriteRow()
        {
            IsStreamWork = true;
            DateTime time = DateTime.Now;
            while(IsStreamWork)
            {
                Console.WriteLine($"{DateTime.Now - time}ms {CountWriteRow} bit");
                Thread.Sleep(200);
            }
            Console.WriteLine($"{DateTime.Now - time}ms {CountWriteRow} bit");
        }
        //кол-во считанных строк
        public void GetCountReadRow()
        {
            IsStreamWork = true;
            DateTime time = DateTime.Now;
            while (IsStreamWork)
            {
                Console.WriteLine($"{DateTime.Now - time}ms {CountReadRow} bit");
                Thread.Sleep(100);
            }
            Console.WriteLine($"{DateTime.Now - time}ms {CountReadRow} bit");
        }

        //чтение файла построчно
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
                return readResult;
            }

        }
    }
}
