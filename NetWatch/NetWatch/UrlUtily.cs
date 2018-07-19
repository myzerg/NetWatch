/*
 * 获取指定URL 的HTML内容
 * author:myzerg@126.com
 * date:20180701
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetWatch
{
    class UrlUtily
    {
        public static string GetUrltoHtml(string Url,  string type = "UTF-8")
        {
            try
            {
                System.Net.HttpWebRequest r = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(Url);
                r.AllowAutoRedirect = true;
                r.KeepAlive = false;
                r.ServicePoint.Expect100Continue = false;
                r.ServicePoint.UseNagleAlgorithm = false;
                r.ServicePoint.ConnectionLimit = 65500;
                r.AllowWriteStreamBuffering = false;
                r.Proxy = null;
                System.Net.CookieContainer c = new System.Net.CookieContainer();
                r.CookieContainer = c;
                System.Net.HttpWebResponse res = r.GetResponse() as System.Net.HttpWebResponse;
                System.IO.StreamReader s = new System.IO.StreamReader(res.GetResponseStream(), System.Text.Encoding.GetEncoding(type));
                string retsult = s.ReadToEnd();
                res.Close();
                r.Abort();
                return retsult;

            }
            catch (System.Exception ex)
            {
                //errorMsg = ex.Message;
                return ex.Message;
            }
        }

    }
}
