using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vinyllist
{
    static class VinylRecordManager
    {
        public static VinylRecord[] VinylList { get; set; } = new VinylRecord[0];

        public static void LoadVinylListFromFile()
        {
            VinylList = FileManager.Load();
        }

        public static void SaveVinylListToFile()
        {
            FileManager.Save(VinylList);
        }

        public static void ViewVinylRecord(int viewRecord)
        {
            Console.Clear();
            Console.WriteLine("Artist: " + VinylList[viewRecord].Artist);
            Console.WriteLine("Album: " + VinylList[viewRecord].VinylAlbum);
            Console.WriteLine("Årtal: " + VinylList[viewRecord].Year);
            Console.ReadKey();
        }

        public static void AddVinylRecord()
        {
            VinylRecord newRecord = new VinylRecord();
            newRecord.Artist = AddArtist();
            newRecord.VinylAlbum = AddAlbum();
            newRecord.Year = AddYear();
            VinylRecord[] updatedlist = new VinylRecord[VinylList.Length + 1];
            VinylList.CopyTo(updatedlist, 0);
            updatedlist[updatedlist.Length - 1] = newRecord;
            VinylList = updatedlist;

        }

        static string AddArtist()
        {
            Console.Clear();
            Console.WriteLine("Artist: ");
            return Console.ReadLine();

        }

        static string AddAlbum()
        {
            Console.Clear();
            Console.WriteLine("Album: ");
            return Console.ReadLine();

        }


        static int AddYear()
        {
            Console.Clear();
            Console.WriteLine("Årtal: ");
            return int.Parse(Console.ReadLine());
        }

        public static void EditArtist(int albumToEdit)
        {
            Console.WriteLine("Nuvarande artist är: " + VinylList[albumToEdit].Artist);
            Console.Write("Redigera: ");
            VinylList[albumToEdit].Artist = Console.ReadLine();
        }

        public static void EditAlbum(int albumToEdit)
        {
            Console.WriteLine("Nuvarande album är: " + VinylList[albumToEdit].VinylAlbum);
            Console.Write("Redigera: ");
            VinylList[albumToEdit].VinylAlbum = Console.ReadLine();
        }

        public static void EditYear(int albumToEdit)
        {
            Console.WriteLine("Nuvarande årtal är: " + VinylList[albumToEdit].Year);
            Console.Write("Redigera: ");
            VinylList[albumToEdit].Year = int.Parse(Console.ReadLine());
        }

        public static void RemoveVinylRecord(int albumToRemove)
        {
            VinylRecord[] updatedList = new VinylRecord[VinylList.Length - 1];

            bool recordToRemoveEncountered = false;

            for (int i = 0; i < VinylList.Length; i++)
            {
                
                if (i != albumToRemove)
                {
                    if (recordToRemoveEncountered)
                    {
                        updatedList[i - 1] = VinylList[i];
                    }
                    else
                    {
                        updatedList[i] = VinylList[i];
                    }
                }
                else
                {
                    recordToRemoveEncountered = true;
                }

            }

            VinylList = updatedList;
        }
    }
}
