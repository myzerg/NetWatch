using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;

namespace NetWatch
{
    class Program
    {
        private static int wait_second;
        private static StringCollection url_List;
        static void Main(string[] args)
        {

            Console.WriteLine("{0} command line arguments were specified", args.Length);

            foreach (string arg in args)
            {

                Console.WriteLine(arg);

            }
            //Console.ReadKey();
            Console.WriteLine("author:myzerg");
            Console.WriteLine("help：修改config中的如下内容");
            Console.WriteLine("watch_url ->监视的网址 当前为:" + NetWatch.Properties.Settings.Default.watch_url);
            Console.WriteLine("wait_second->轮询间隔设定，建议大于1 当前为:" + NetWatch.Properties.Settings.Default.wait_second);
            Console.WriteLine("Let Begin!");
            wait_second = NetWatch.Properties.Settings.Default.wait_second;
            url_List = NetWatch.Properties.Settings.Default.watch_url;
            doNetWatch();
            while (1 == 1) { }

        }
        static async Task doNetWatch()
        {
            System.Net.ServicePointManager.DefaultConnectionLimit = 50;
            await Task.Run(() =>
            {
                int i =0;
                while (true)
                {
                    foreach (string url in url_List)
                    {
                        Console.WriteLine("{0} visit {1}", DateTime.Now, url);
                        string urlreturn = UrlUtily.GetUrltoHtml(url);                        
                        Console.WriteLine(urlreturn);
                        i++;
                    }
                    if (i > 800)
                    {
                        i = 0;
                        System.GC.Collect();
                    }
                    ConsoleColor oldcolor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Green;
                    int left = Console.CursorLeft;
                    int top = Console.CursorTop;
                    for (int j = 0; j < wait_second; j++)
                    {
                        Console.SetCursorPosition(left, top);
                        Console.WriteLine(j);
                        Thread.Sleep(1000);
                        //Thread.Sleep(wait_second * 1000);
                    }
                    Console.ForegroundColor = oldcolor;
                        
                }
            });
        }
    }
}
