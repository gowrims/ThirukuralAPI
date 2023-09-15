using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ThirukuralAPI.Models
{
    public class திருக்குறள்
    {
        public static List<குறள்கள்> திருக்குறள்கள்()
        {
            List<குறள்கள்> திருக்குறள்வரிசை = new List<குறள்கள்>();
            var FilePaths = Directory.GetFiles(Environment.CurrentDirectory + "/ThirukuralA2Z/Thirukural");
            var FileName = FilePaths.Select(s => Path.GetFileName(s)).ToList();
            FileName.Sort();
            for (int i = 0; i < FilePaths.Length; i++)
            {
                string FilePath = Environment.CurrentDirectory + "/ThirukuralA2Z/Thirukural/" + FileName[i] + "";
                string[] thirukural = File.ReadAllLines(FilePath);
                for (int j = 0; j < thirukural.Length; j += 5)
                {
                    திருக்குறள்வரிசை.Add(new குறள்கள்(thirukural[j].Split(' ')[1], thirukural[j + 1] + "" + thirukural[j + 2], thirukural[j + 4]));
                }

            }
            return திருக்குறள்வரிசை;
        }
    }
}