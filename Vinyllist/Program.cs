using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vinyllist
{
    class Program
    {

        static void Main(string[] args)
        {
            VinylRecordManager.LoadVinylListFromFile();
            Console.WriteLine("Välkommen till vinyllistan!\n");
            ChooseMenuItem();

        }

        private static void StartMenu()
        {
            Console.WriteLine("Välj ett av följande alternativ\n");

            Console.WriteLine("1. Öppna vinyllistan");
            Console.WriteLine("2. Lägg till vinylskiva");
            Console.WriteLine("3. Redigera vinyllistan");
            Console.WriteLine("4. Ta bort vinylskivor från listan");
            Console.WriteLine("5. Spara och avsluta");
            Console.WriteLine("6. Avsluta");
        }

        private static void ChooseMenuItem()
        {
            bool endProgram = false;

            do
            {
                StartMenu();
                int option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    OpenVinylList();
                }
                else if (option == 2)
                {
                    AddVinylRecord();
                }
                else if (option == 3)
                {
                    ChooseVinylRecordToEdit();
                }
                else if (option == 4)
                {
                    DeleteVinylRecord();
                }
                else if (option == 5)
                {
                    VinylRecordManager.SaveVinylListToFile();
                    endProgram = true;
                }
                else if (option == 6)
                {
                    endProgram = true;
                }
                else
                {
                    Console.WriteLine("Du måste välja mellan alternativ 1, 2, 3, 4, 5 eller 6!");
                }
                Console.Clear();

            } while (endProgram == false);
        }

        private static void OpenVinylList()
        {
            Console.Clear();
            for (int i = 0; i < VinylRecordManager.VinylList.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + VinylRecordManager.VinylList[i].VinylAlbum);
            }

            Console.WriteLine("Välj album att visa: ");
            int recordToView = int.Parse(Console.ReadLine());
            VinylRecordManager.ViewVinylRecord(recordToView - 1);
        }

        private static void AddVinylRecord()
        {
            Console.Clear();
            VinylRecordManager.AddVinylRecord();
        }
        
        private static void ChooseVinylRecordToEdit()
        {
            Console.Clear();
            for (int i = 0; i < VinylRecordManager.VinylList.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + VinylRecordManager.VinylList[i].VinylAlbum);
            }

            Console.WriteLine("Välj album att redigera");

            int albumToEdit = int.Parse(Console.ReadLine());
            EditVinylRecord(albumToEdit - 1);
            return;
        }

        private static void EditVinylRecord(int albumToEdit)
        {
            Console.Clear();
            Console.WriteLine("Vad vill du redigera?\n");
            Console.WriteLine("1. Artist");
            Console.WriteLine("2. Album");
            Console.WriteLine("3. Årtal\n");
            Console.WriteLine("Tryck 4 för att gå tillbaka till startmenyn ");

            int optionEdit = int.Parse(Console.ReadLine());


            do
            {


                if (optionEdit == 1)
                {
                    VinylRecordManager.EditArtist(albumToEdit);
                    return;
                }
                else if (optionEdit == 2)
                {
                    VinylRecordManager.EditAlbum(albumToEdit);
                    return;
                }
                else if (optionEdit == 3)
                {
                    VinylRecordManager.EditYear(albumToEdit);
                    return;
                }
                else if (optionEdit == 4)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Välj mellan 1, 2, 3, eller 4!");
                }

            } while (true);

        }
      

        private static void DeleteVinylRecord()
        {
            Console.Clear();
            for (int i = 0; i < VinylRecordManager.VinylList.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + VinylRecordManager.VinylList[i].VinylAlbum);
            }

            Console.WriteLine("Välj album att ta bort");

            int albumToRemove = int.Parse(Console.ReadLine());
            VinylRecordManager.RemoveVinylRecord(albumToRemove - 1);
            return;
        }




    }
}
