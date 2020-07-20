using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace REAL_ESTATE
{
    public static class CallAPI
    {
        private static string targetURL { get; set; }

        //public static XmlNodeList callWebRequest(string url)
        public static List<dataItem> callWebRequest(string url)
        {
            targetURL = url;
            //Console.WriteLine(string.Format("API URL : {0}", targetURL));

            string responseFromServer = string.Empty;
            XmlNodeList Result = null;
            List<dataItem> itemResult = new List<dataItem>();
            try
            {
                WebRequest request = WebRequest.Create(targetURL);
                request.Method = "GET";
                request.ContentType = "application/xml; charset=UTF-8";
                //request.Headers["user-agent"] = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
                using (WebResponse response = request.GetResponse())
                using (Stream dataStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(dataStream))
                {
                    responseFromServer = reader.ReadToEnd();
                }
                //Console.WriteLine(string.Format("API RESULT : {0}", responseFromServer));

                XmlDocument xml = new XmlDocument();
                xml.LoadXml(responseFromServer);

                XmlElement xmlelement = xml.DocumentElement;
                Result =  xmlelement.GetElementsByTagName("item");

                foreach(XmlNode xmlnode in Result)
                {
                    dataItem tempItem = new dataItem();
                    //tempItem.거래금액 = xmlnode.Attributes["거래금액"].InnerText;
                    tempItem.거래금액 = xmlnode.SelectSingleNode("거래금액").InnerText;
                    tempItem.건축년도 = xmlnode.SelectSingleNode("건축년도").InnerText;
                    tempItem.년 = xmlnode.SelectSingleNode("년").InnerText;
                    tempItem.도로명 = xmlnode.SelectSingleNode("도로명").InnerText;
                    tempItem.도로명건물본번호코드 = xmlnode.SelectSingleNode("도로명건물본번호코드").InnerText;
                    tempItem.도로명시군구코드 = xmlnode.SelectSingleNode("도로명시군구코드").InnerText;
                    tempItem.도로명일련번호코드 = xmlnode.SelectSingleNode("도로명일련번호코드").InnerText;
                    tempItem.도로명지상지하코드 = xmlnode.SelectSingleNode("도로명지상지하코드").InnerText;
                    tempItem.도로명코드 = xmlnode.SelectSingleNode("도로명코드").InnerText;
                    tempItem.법정동 = xmlnode.SelectSingleNode("법정동").InnerText;
                    tempItem.법정동본번코드 = xmlnode.SelectSingleNode("법정동본번코드").InnerText;
                    tempItem.법정동부번코드 = xmlnode.SelectSingleNode("법정동부번코드").InnerText;
                    tempItem.법정동시군구코드 = xmlnode.SelectSingleNode("법정동시군구코드").InnerText;
                    tempItem.법정동읍면동코드 = xmlnode.SelectSingleNode("법정동읍면동코드").InnerText;
                    tempItem.법정동지번코드 = xmlnode.SelectSingleNode("법정동지번코드").InnerText;
                    tempItem.아파트 = xmlnode.SelectSingleNode("아파트").InnerText;
                    tempItem.월 = xmlnode.SelectSingleNode("월").InnerText;
                    tempItem.일 = xmlnode.SelectSingleNode("일").InnerText;
                    tempItem.일련번호 = xmlnode.SelectSingleNode("일련번호").InnerText;
                    tempItem.전용면적 = xmlnode.SelectSingleNode("전용면적").InnerText;
                    tempItem.지번 = xmlnode.SelectSingleNode("지번").InnerText;
                    tempItem.지역코드 = xmlnode.SelectSingleNode("지역코드").InnerText;
                    tempItem.층 = xmlnode.SelectSingleNode("층").InnerText;

                    itemResult.Add(tempItem);

                    Console.WriteLine(string.Format("API RESULT : {0}", tempItem.법정동));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            //return Result;
            return itemResult;
        }
    }
}
