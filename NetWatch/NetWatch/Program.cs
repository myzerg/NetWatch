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
        static void Main(string[] args)
        {
            Console.WriteLine("author:myzerg");
            Console.WriteLine("help：修改config中的如下内容");
            Console.WriteLine("watch_url ->监视的网址 当前为:" + NetWatch.Properties.Settings.Default.watch_url);
            Console.WriteLine("wait_second->轮询间隔设定，建议大于1 当前为:" + NetWatch.Properties.Settings.Default.wait_second);
            Console.WriteLine("Let Begin!");
            doNetWatch();
            while (1 == 1) { }

        }
        static async Task doNetWatch()
        {
            int wait_second = NetWatch.Properties.Settings.Default.wait_second;
            StringCollection url_List = NetWatch.Properties.Settings.Default.watch_url;
            await Task.Run(() =>
            {
                while (true)
                {
                    foreach (string url in url_List)
                    {
                        string urlreturn = UrlUtily.GetUrltoHtml(url);
                        Console.WriteLine(urlreturn);
                        Thread.Sleep(wait_second*1000);
                    }
                }
            });
        }
    }
}
