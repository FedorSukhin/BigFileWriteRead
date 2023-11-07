using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DZFileMeneger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileManeger fileManeger = new FileManeger();
            //создаем потоки записи, чтения и их мониторинга
            
            Thread write = new Thread(()=>fileManeger.BigFileWriter("test1", 10000000, 10));
            Thread writeMonitor = new Thread(fileManeger.GetCountWriteRow);
            writeMonitor.Start();
            write.Start();
            //закрываем потоки
            writeMonitor.Join();
            write.Join();
            Thread.Sleep(1000);
            Thread read = new Thread(() => fileManeger.BigFileReader("test1"));
            Thread readMonitor =new Thread(fileManeger.GetCountReadRow);
            readMonitor.Start();
            read.Start();
            //закрываем потоки
            readMonitor.Join();
            read.Join();
        }
    }
}
