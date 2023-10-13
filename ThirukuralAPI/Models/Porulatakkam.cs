using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Hosting;

namespace ThirukuralAPI.Models
{
    public class Porulatakkam
    {
        public static string FilePath = HostingEnvironment.MapPath("~/ThirukuralA2Z\\EnumIyal");

        public Dictionary<string, int> அறத்துப்பால் { get; set; }
        public Dictionary<string, int> பொருட்பால் { get; set; }
        public Dictionary<string, int> காமத்துப்பால் { get; set; }


        public Porulatakkam(Dictionary<string, int> அறத்துப்பால், Dictionary<string, int> பொருட்பால், Dictionary<string, int> காமத்துப்பால்)
        {
            this.அறத்துப்பால் = அறத்துப்பால்;
            this.பொருட்பால் = பொருட்பால்;
            this.காமத்துப்பால் = காமத்துப்பால்;
        }

        public static Porulatakkam GetPorulatakkam()
        {
            List<Dictionary<string, int>> keyValuePairs = new List<Dictionary<string, int>>();
            Dictionary<string, int> FirstSection = new Dictionary<string, int>();
            Dictionary<string, int> SecondSection = new Dictionary<string, int>();
            Dictionary<string, int> ThirdSection = new Dictionary<string, int>();

            string[] EnumIyal = File.ReadAllLines(FilePath);

            for (int i = 0; i < 4; i++)
            {
                string[] keys = EnumIyal[i].Split('=');
                string key = keys[0];
                int value = Convert.ToInt32(keys[1]);
                FirstSection.Add(key,value);
            }

            for(int i = 5; i < 12;i++)
            {
                string[] keys = EnumIyal[i].Split('=');
                string key = keys[0];
                int value = Convert.ToInt32(keys[1]);
                SecondSection.Add(key,value);
            }

            for(int i = 11; i  < 13;i++)
            {
                string[] keys = EnumIyal[i].Split('=');
                string key = keys[0];
                int value = Convert.ToInt32(keys[1]);
                ThirdSection.Add(key,value);
            }

            Porulatakkam porulatakkam = new Porulatakkam(FirstSection, SecondSection, ThirdSection);

            return porulatakkam;
        }
    }
}
