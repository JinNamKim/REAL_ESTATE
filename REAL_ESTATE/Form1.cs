using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace REAL_ESTATE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //XmlNodeList XML_RESULT = CallAPI.callWebRequest("http://openapi.molit.go.kr/OpenAPI_ToolInstallPackage/service/rest/RTMSOBJSvc/getRTMSDataSvcAptTradeDev?serviceKey=v6UmuoRyMk3IPiiJL315ErO%2FvbVLbs8UI2h%2FQ%2BSSixULwnOXzQZy7yvOcyL%2FrTFfSyJzFUiBLpN3smZrsu1mAg%3D%3D&pageNo=1&numOfRows=10&LAWD_CD=11110&DEAL_YMD=201512&");
            List<item> zzz = CallAPI.callWebRequest("http://openapi.molit.go.kr/OpenAPI_ToolInstallPackage/service/rest/RTMSOBJSvc/getRTMSDataSvcAptTradeDev?serviceKey=v6UmuoRyMk3IPiiJL315ErO%2FvbVLbs8UI2h%2FQ%2BSSixULwnOXzQZy7yvOcyL%2FrTFfSyJzFUiBLpN3smZrsu1mAg%3D%3D&pageNo=1&numOfRows=10&LAWD_CD=11110&DEAL_YMD=201512&");


            /*
            int i = 0;
            //foreach(XmlNodeList result in XML_RESULT)
            foreach (XmlNode result in XML_RESULT)
            {
                //Console.WriteLine(result.GetEnumerator()
                string zz = result.Attributes["거래금액"].InnerText;
                Console.WriteLine(zz);


            }
            */

        }
    }
}
