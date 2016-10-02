using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vinyllist
{
    class FileManager
    {
        public static void Save(VinylRecord[] vinylList)
        {
            string fileContent = "";

            for (int i = 0; i < vinylList.Length; i++)
            {
                fileContent +=
                    vinylList[i].Artist + Environment.NewLine +
                    vinylList[i].VinylAlbum + Environment.NewLine +
                    vinylList[i].Year + Environment.NewLine;
            }

            File.WriteAllText(@"C:\Users\susan\RecordList.txt", fileContent);
        }

        public static VinylRecord[] Load()
        {
            VinylRecord[] loadedVinylList = new VinylRecord[0];

            if (File.Exists(@"C:\Users\susan\RecordList.txt"))
            {
                var vinylListStrings = File.ReadAllLines(@"C:\Users\susan\RecordList.txt");

                loadedVinylList = new VinylRecord[vinylListStrings.Length / 3];

                for (int i = 0; i < vinylListStrings.Length / 3; i++)
                {
                    VinylRecord newRecord = new VinylRecord();
                    newRecord.Artist = vinylListStrings[i * 3];
                    newRecord.VinylAlbum = vinylListStrings[(i * 3) + 1];
                    newRecord.Year = int.Parse(vinylListStrings[(i * 3) + 2]);
                    loadedVinylList[i] = newRecord;
                        
                }

                return loadedVinylList;

            }
            else
            {
                return loadedVinylList;

            }
            

            
        }



    }
}
