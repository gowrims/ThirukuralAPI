using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirukuralAPI.Models
{
    public static class Porulatakkam
    {
        public static List<Dictionary<string, int>> GetPorulatakkam()
        {
            List<Dictionary<string, int>> keyValuePairs = new List<Dictionary<string, int>>();
            Dictionary<string, int> FirstSection = new Dictionary<string, int>();
            Dictionary<string, int> SecondSection = new Dictionary<string, int>();
            Dictionary<string, int> ThirdSection = new Dictionary<string, int>();

            int[] values = (int[])Enum.GetValues(typeof(EnumIyal));
            string[] keys = Enum.GetNames(typeof(EnumIyal));

            for(int i = 0; i < 4; i++) 
            {
                string key = keys[i];
                int value = values[i];
                FirstSection.Add(key,value);
            }

            for(int i = 5; i < 12;i++)
            {
                string key = keys[i];
                int value = values[i];
                SecondSection.Add(key,value);
            }

            for(int i = 11; i  < 13;i++)
            {
                string key = keys[i];
                int value = values[i];
                ThirdSection.Add(key,value);
            }

            keyValuePairs.Add(FirstSection);
            keyValuePairs.Add(SecondSection);
            keyValuePairs.Add(ThirdSection);

            return keyValuePairs;
        }
    }
}
