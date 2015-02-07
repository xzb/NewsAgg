using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication8.Models;
using System.IO;
using System.Xml.Serialization;
using System.Net;
using System.Xml;

namespace MvcApplication8.Controllers
{
    public class Xml2ModelController : Controller
    {
        private CarContext db = new CarContext();

        //
        // GET: /Xml2Model/

        public ActionResult Index()
        {
            /******************************
             访问rss的地址，读取xml数据
             ******************************/
            rss cars = null;
            //  System.Net.WebClient client = new WebClient();
            //  byte[] page = client.DownloadData("http://rss.nytimes.com/services/xml/rss/nyt/US.xml");
            // string path = System.Text.Encoding.UTF8.GetString(page);
            //string path = "cars.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(rss));

            //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://rss.nytimes.com/services/xml/rss/nyt/US.xml");
            //使用Cookie设置AllowAutoRedirect属性为false,是解决“尝试自动重定向的次数太多。”的核心
            // request.CookieContainer = new CookieContainer();
            // request.AllowAutoRedirect = false;
            //  WebResponse response = (WebResponse)request.GetResponse();
            //  Stream sm = response.GetResponseStream();
            //  System.IO.StreamReader streamReader = new System.IO.StreamReader(sm);
            //将流转换为字符串
            // string html = streamReader.ReadToEnd();
            // streamReader.Close();

            //  TextReader reader = new StreamReader(path);

            XmlReader reader = new XmlTextReader("http://rss.nytimes.com/services/xml/rss/nyt/US.xml");
            cars = (rss)serializer.Deserialize(reader);

            /*var serializer = new XmlSerializer(typeof(rss));
              using (TextReader reader = new StringReader(html))
              {
                  cars = (rss)serializer.Deserialize(reader);
              }*/


            //  reader.Close();


            /******************************
              初始化最新时间newTime
             ******************************/
            DateTime newTime;
            if (db.sources.Find("NYTimes") == null)
            {
                string httpTime = cars.item[cars.item.Length - 1].pubDate;
                newTime = DateTime.Parse(httpTime);
                Models.source src = new Models.source("NYTimes", newTime);
                db.sources.Add(src);
            }
            else
            {
                Models.source src = db.sources.Find("NYTimes");
                newTime = src.newDate.Value;
            }


            /******************************
             循环添加每一条新闻条目，只添加新条目
             ******************************/
            for (var i = cars.item.Length - 1; i >= 0; i--)    //old item store into database first
            {
                string httpTime = cars.item[i].pubDate;
                DateTime time = DateTime.Parse(httpTime);


                // 每次添加新条目前，先与source里的最新时间对比
                if (time <= newTime)       //time值小于最新时间，舍弃
                    continue;
                else
                {
                    Models.source src = db.sources.Find("NYTimes");
                    src.newDate = time;    //更新时间
                }


                Models.item item = new Models.item(cars.item[i], time, "NYTimes");

                db.items.Add(item);               //item include 4 elements
                //db.channel.Add(cars.item[i]);


            }



            db.SaveChanges();
            return View(db.items.ToList());
        }



        //
        // POST: /Xml2Model/Create

    }
}
