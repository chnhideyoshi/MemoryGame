using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHNHIDEYOSHI
{
    public class Name
    {
        //private string[] name = new string[32];
        public string getname(int i)
        {
            string s="";
            if (i > 32)
            {
                i -= 32;
            }
            switch (i)
            {
                case 1: s = "西西"; break;
                case 2: s = "莎莎"; break;
                case 3: s = "宋宋"; break;
                case 4: s = "廷廷"; break;
                case 5: s = "皮哥"; break;
                case 6: s = "权权"; break;
                case 7: s = "牛子"; break;
                case 8: s = "翠翠"; break;
                case 9: s = "园园"; break;
                case 10: s = "范婕"; break;
                case 11: s = "但波"; break;
                case 12: s = "老皮"; break;
                case 13: s = "魏玮"; break;
                case 14: s = "易爽"; break;
                case 15: s = "舒婷"; break;
                case 16: s = "姜为"; break;
                case 17: s = "昊昊"; break;
                case 18: s = "陈向东"; break;
                case 19: s = "卧嘈怎么又是项权我可能多弄了个"; break;
                case 20: s = "猴子"; break;
                case 21: s = "欢欢"; break;
                case 22: s = "丁梦"; break;
                case 23: s = "石鹏"; break;
                case 24: s = "水王"; break;
                case 25: s = "杀哥"; break;
                case 26: s = "蘑菇"; break;
                case 27: s = "曼曼"; break;
                case 28: s = "潇潇"; break;
                case 29: s = "老泥"; break;
                case 30: s = "彪哥"; break;
                case 31: s = "刘畅"; break;
                case 32: s = "家伟"; break;
                default: s = "woca"; break;
            }
            return s;
        }
    }
}
