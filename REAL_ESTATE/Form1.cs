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

        List<dataAddress> address_ALL = new List<dataAddress>();    //원본
        List<dataAddress> address_1 = new List<dataAddress>();      //시/도
        List<dataAddress> address_2 = new List<dataAddress>();      //시/군/구

        public Form1()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            readAddressFromTXT();
            set_cb_1();     //시/도 콤보박스
            set_cb_2();     //시/군/구 콤보박스
        }
        
        public void readAddressFromTXT()
        {
            string CurDiretory = System.Environment.CurrentDirectory;
            //Console.WriteLine(CurDiretory);
            string FilePath = string.Format("{0}\\주소데이터.txt", CurDiretory);

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(FilePath,Encoding.Default);

            while ((line = file.ReadLine()) != null)
            {
                //System.Console.WriteLine(line);
                string[] split_temp = line.Split(',');

                dataAddress temp = new dataAddress();
                temp.법정동코드 = split_temp[0];
                temp.법정동명 = split_temp[1];
                temp.폐지여부 = split_temp[2];
                temp.법정동코드_5자리 = split_temp[3];

                address_ALL.Add(temp);
            }
            file.Close();
        }


        public void set_cb_1()
        {
            //전체 데이터에서 시/도 데이터만 추출하여 리스트에 넣는다.
            foreach (dataAddress data in address_ALL)
            {
                if (data.법정동코드.Contains("00000000") && data.폐지여부 == "존재")
                {
                    address_1.Add(data);
                }

                //세종틀별자치시 예외 처리
                if (data.법정동명 == "세종특별자치시")
                {
                    address_1.Add(data);
                }
                //세종틀별자치시 예외 처리
            }
            //전체 데이터에서 시/도 데이터만 추출하여 리스트에 넣는다.

            //시/도 데이터 정렬
            var address_1_sorted = from data in address_1 orderby data.법정동명 ascending select data.법정동명;
            cb_1.Items.Add(" :: 시/도 :: ");
            foreach (string list in address_1_sorted)
            {
                cb_1.Items.Add(list);
            }
            cb_1.SelectedIndex = 0;
            //시/도 데이터 정렬
        }

        public void set_cb_2(List<dataAddress> datas = null)
        {
            if (datas == null)
            {
                cb_2.Items.Add(" :: 시/군/구 :: ");
                cb_2.SelectedIndex = 0;
            }
            else
            {

            }
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            List<dataItem> zzz = CallAPI.callWebRequest("http://openapi.molit.go.kr/OpenAPI_ToolInstallPackage/service/rest/RTMSOBJSvc/getRTMSDataSvcAptTradeDev?serviceKey=v6UmuoRyMk3IPiiJL315ErO%2FvbVLbs8UI2h%2FQ%2BSSixULwnOXzQZy7yvOcyL%2FrTFfSyJzFUiBLpN3smZrsu1mAg%3D%3D&pageNo=1&numOfRows=10&LAWD_CD=11110&DEAL_YMD=201512&");


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

        private void cb_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            address_2.Clear();
            if (cb_1.SelectedIndex == 0)
            {
                //시/도 선택, cb_2 초기화 시킴
                cb_2.Items.Clear();
                cb_2.Items.Add("  :: 시/군/구 :: ");
                cb_2.SelectedIndex = 0;
            }
            else
            {
                string selectedText = cb_1.Text;

                foreach (dataAddress data in address_ALL)
                {
                    if (data.법정동명 == selectedText)
                    {
                        continue;
                    }

                    if (data.법정동명.Contains(selectedText) && data.폐지여부 == "존재")
                    {
                        address_2.Add(data);
                    }
                }

                //시/도 데이터 정렬
                var address_2_sorted = from data in address_2 orderby data.법정동명 ascending select data.법정동명;
                cb_2.Items.Clear();
                cb_2.Items.Add("  :: 시/군/구 :: ");
                foreach (string list in address_2_sorted)
                {
                    cb_2.Items.Add(list.Replace(string.Format("{0} ", selectedText), ""));
                }
                cb_2.SelectedIndex = 0;
                //시/도 데이터 정렬
            }

        }

        private void cb_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_2.SelectedIndex == 0)
            {
                
            }
            else
            {
                /*
                string full_address = string.Format("{0} {1}", cb_1.Text, cb_2.Text);
                dataAddress selectedRegion = address_ALL.Find(x => x.법정동명 == full_address);

                Console.WriteLine(full_address);
                Console.WriteLine(selectedRegion.법정동코드_5자리);
                */
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string full_address = string.Format("{0} {1}", cb_1.Text, cb_2.Text);
            dataAddress selectedRegion = address_ALL.Find(x => x.법정동명 == full_address);

            Console.WriteLine(full_address);
            Console.WriteLine(selectedRegion.법정동코드_5자리);
        }
    }
}
