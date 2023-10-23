using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;

namespace ThirukuralAPI.Models
{
    public class Porulatakkam
    {
        public static string FilePath = HostingEnvironment.MapPath("~/ThirukuralA2Z\\EnumIyal");
        public List<IyalDetails> அறத்துப்பால் { get; set; }
        public List<IyalDetails> பொருட்பால் { get; set; }
        public List<IyalDetails> காமத்துப்பால் { get; set; }


        public Porulatakkam(List<IyalDetails> அறத்துப்பால், List<IyalDetails> பொருட்பால், List<IyalDetails> காமத்துப்பால்)
        {
            this.அறத்துப்பால் = அறத்துப்பால்;
            this.பொருட்பால் = பொருட்பால்;
            this.காமத்துப்பால் = காமத்துப்பால்;
        }

        public static Porulatakkam GetPorulatakkam()
        {
            List<IyalDetails> FirstSection = new List<IyalDetails>();
            List<IyalDetails> SecondSection = new List<IyalDetails>();
            List<IyalDetails> ThirdSection = new List<IyalDetails>();
            string[] EnumIyal = File.ReadAllLines(FilePath);

            for (int i = 0; i < 4; i++)
            {
                string[] keys = EnumIyal[i].Split('=');
                string key = keys[0];
                int value = Convert.ToInt32(keys[1]);
                FirstSection.Add(new IyalDetails(key,value, value * 10));
            }

            for(int i = 5; i < 12;i++)
            {
                string[] keys = EnumIyal[i].Split('=');
                string key = keys[0];
                int value = Convert.ToInt32(keys[1]);
                SecondSection.Add(new IyalDetails(key, value, value * 10));
            }

            for(int i = 11; i  < 13;i++)
            {
                string[] keys = EnumIyal[i].Split('=');
                string key = keys[0];
                int value = Convert.ToInt32(keys[1]);
                ThirdSection.Add(new IyalDetails(key, value, value * 10));
            }

            Porulatakkam porulatakkam = new Porulatakkam(FirstSection, SecondSection, ThirdSection);

            return porulatakkam;
        }
    }
}
