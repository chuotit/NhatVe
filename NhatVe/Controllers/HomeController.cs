using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using NhatVe.Models;

namespace NhatVe.Controllers
{
    public class dataRequest
    {
        public string departureDate { get; set; }
        public string returnDate { get; set; }
        public int adultCount { get; set; }
        public int childCount { get; set; }
        public int infantCount { get; set; }
        public bool isRoundTrip { get; set; }
    }
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //var client = new HttpClient();
            //client.BaseAddress = new Uri("https://ssl.12bay.vn/api/v1/VN/iSearch/");
            //var response = client.PostAsJsonAsync("SGN/HAN", data).Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    Console.Write("Success");
            //}
            //else
            //    Console.Write("Error");

            //=========================================
            // Search ticket
            //var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://ssl.12bay.vn/api/v1/VN/iSearch/SGN/HAN");
            //httpWebRequest.ContentType = "application/json";
            //httpWebRequest.Method = "POST";

            //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            //{
            //    string json = "{\"departureDate\":\"2018-11-08\"," +
            //        "\"returnDate\":\"2018-11-11\"," +
            //        "\"adultCount\":1," +
            //        "\"childCount\":0," +
            //        "\"infantCount\":0," +
            //        "\"isRoundTrip\":false}";

            //    streamWriter.Write(json);
            //    streamWriter.Flush();
            //    streamWriter.Close();
            //}

            //var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            //{
            //    var result = streamReader.ReadToEnd();
            //}

            //=========================================
            // Search pricesBoardOfWeek
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://ssl.12bay.vn/api/v1/AirLines/PricesBoard/Week");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"departureDate\":\"2018-11-08\",\"returnDate\":\"2018-11-11\",\"isRoundTrip\":false,\"source\":\"WEB\",\"originCode\":\"SGN\",\"destinationCode\":\"HAN\"}";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }

            //=========================================


            //dataRequest data = new dataRequest { departureDate = "2018-11-08", returnDate = "2018-11-11", adultCount = 1, childCount = 0, infantCount = 0, isRoundTrip = false };
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ssl.12bay.vn/api/v1/VN/iSearch/SGN/HAN");

            //request.Method = "POST";
            //request.ContentType = "application/x-www-form-urlencoded";
            ////string postData = "departureDate=2018-11-08&returnDate=2018-11-11&adultCount=1&childCount=0&infantCount=0&isRoundTrip=false";
            //byte[] bytes = Encoding.UTF8.GetBytes(data);
            //request.ContentLength = bytes.Length;

            //Stream requestStream = request.GetRequestStream();
            //requestStream.Write(bytes, 0, bytes.Length);

            //WebResponse response = request.GetResponse();
            //Stream stream = response.GetResponseStream();
            //StreamReader reader = new StreamReader(stream);

            //var result = reader.ReadToEnd();
            //stream.Dispose();
            //reader.Dispose();

            //=======================================================


            //ASCIIEncoding encoding = new ASCIIEncoding();
            ////string data = string.Format("{departureDate:'2018-11-08',returnDate:'2018-11-11',adultCount:1,childCount:0,infantCount:0,isRoundTrip:false}");
            //string data = "departureDate='2018-11-08'&returnDate='2018-11-11'&adultCount:1&childCount:0&infantCount:0&isRoundTrip:false";
            //byte[] bytes = encoding.GetBytes(data);
            ////HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create("https://www.bestprice.vn/get-vnisc-sid.html?sid=76FCE960A45E3BCF2E560FDB5F197A101541008861&From=H%C3%A0+N%E1%BB%99i+%28HAN%29&From_Code=HAN&To=H%E1%BB%93+Ch%C3%AD+Minh+%28SGN%29&To_Code=SGN&Depart=28%2F11%2F2018&Return=&Type=oneway&ADT=1&CHD=0&INF=0&is_domistic=1&Airline=BL%2CVN%2CVJ");
            //HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create("https://ssl.12bay.vn/api/v1/VN/iSearch/SGN/HAN");
            //httpRequest.Method = "POST";
            //httpRequest.ContentType = "application/x-www-form-urlencoded";
            //httpRequest.ContentLength = bytes.Length;
            //UTF8Encoding enc = new UTF8Encoding();
            //using (Stream stream = httpRequest.GetRequestStream())
            //{
            //    stream.Write(enc.GetBytes(data), 0, data.Length);
            //}
            //WebResponse wr = httpRequest.GetResponse();
            //Stream receiveStream = wr.GetResponseStream();
            //StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
            //dynamic content = Newtonsoft.Json.Linq.JObject.Parse(reader.ReadToEnd());
            //wr.Close();
            //reader.Close();

            //var htmlDoc = new HtmlDocument();
            //htmlDoc.LoadHtml(result);

            ////var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//div[@id='rows_content_depart']");
            //var listAir = htmlDoc.DocumentNode.SelectNodes("//div[@id='rows_content_depart']/div[@class='bpv-list-item clearfix']").ToList();
            //var items = new List<object>();
            //foreach (var item in listAir)
            //{
            //    var itemNode = item;
            //    var id = itemNode.Attributes["id"].Value;
            //    var departprice = itemNode.Attributes["departprice"].Value;
            //    var departairline = itemNode.Attributes["departairline"].Value;
            //    var departtime = itemNode.Attributes["departtime"].Value;
            //    var departcode = itemNode.Attributes["departcode"].Value;
            //    var departtimefrom = itemNode.Attributes["departtimefrom"].Value;
            //    var departtimeto = itemNode.Attributes["departtimeto"].Value;
            //    var departflightclass = itemNode.Attributes["departflightclass"].Value;
            //    var departdayfrom = itemNode.Attributes["departdayfrom"].Value;
            //    var departmonthfrom = itemNode.Attributes["departmonthfrom"].Value;
            //    var departdayto = itemNode.Attributes["departdayto"].Value;
            //    var departmonthto = itemNode.Attributes["departmonthto"].Value;
            //    var departflightrclass = itemNode.Attributes["departflightrclass"].Value;
            //    var departflightstop = itemNode.Attributes["departflightstop"].Value;
            //    var departseg = itemNode.Attributes["departprice"].Value;
            //    var departis_ticket_promo = itemNode.Attributes["departis_ticket_promo"].Value;
            //    var departseat = itemNode.Attributes["departseat"].Value;
            //    var departselected_value = itemNode.Attributes["departselected_value"].Value;
            //    var departlast_update = itemNode.Attributes["departlast_update"].Value;
            //    var departdatefrom = itemNode.Attributes["departdatefrom"].Value;
            //    var departdateto = itemNode.Attributes["departdateto"].Value;
            //    var departpriceadt = itemNode.Attributes["departpriceadt"].Value;
            //    var departpricechd = itemNode.Attributes["departpricechd"].Value;
            //    var departpriceinf = itemNode.Attributes["departpriceinf"].Value;
            //    var departpricetotal = itemNode.Attributes["departpricetotal"].Value;
            //    var departpriceadttax = itemNode.Attributes["departpriceadttax"].Value;
            //    var departpricechdtax = itemNode.Attributes["departpricechdtax"].Value;
            //    var departpriceinftax = itemNode.Attributes["departpriceinftax"].Value;
            //    var departpricetax = itemNode.Attributes["departpricetax"].Value;

            //    items.Add(new
            //    {
            //        id,
            //        departprice,
            //        departairline,
            //        departtime,
            //        departcode,
            //        departtimefrom,
            //        departtimeto,
            //        departflightclass,
            //        departdayfrom,
            //        departmonthfrom,
            //        departdayto,
            //        departmonthto,
            //        departflightrclass,
            //        departflightstop,
            //        departseg,
            //        departis_ticket_promo,
            //        departseat,
            //        departselected_value,
            //        departlast_update,
            //        departdatefrom,
            //        departdateto,
            //        departpriceadt,
            //        departpricechd,
            //        departpriceinf,
            //        departpricetotal,
            //        departpriceadttax,
            //        departpricechdtax,
            //        departpriceinftax,
            //        departpricetax
            //    });
            //}

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
