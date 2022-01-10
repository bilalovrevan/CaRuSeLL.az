using CaruSell.az_Project.Models;

using System;

using System.IO;

using System.Runtime.Serialization.Formatters.Binary;

using System.Threading.Tasks;


namespace CaruSell.az_Project
{
    internal class Program
    {
        static string fileName = "carsystem.dat";

        static GenericStore<Marka> markaStore = new GenericStore<Marka>();

        static GenericStore<Model> modelStore = new GenericStore<Model>();

        static GenericStore<Cars> carStore = new GenericStore<Cars>();

        [Obsolete]

        static void Main(string[] args)

        {
            int markaid, modelid, carid;

            Console.Title = "CaruSell.az";

            try

            {
                using (var file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read))

                {
                    BinaryFormatter bf = new BinaryFormatter();

                    var db = (CarContext)bf.Deserialize(file);

                    modelStore = db.Models;

                    markaStore = db.Markas;

                    carStore = db.Cars;

                    Marka.SetCounter(markaStore[markaStore.Count - 1].MarkaId);

                    Model.SetCounter(modelStore[modelStore.Count - 1].ModelId);

                    Cars.SetCounter(carStore[carStore.Count - 1].CarId);
                }
            }

            catch (Exception)

            {

            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n\n\n\n\n\n\n\n                                    CaruSell.az Saytina Xosh Gelmisiniz!                                 ");
            Console.ReadLine();
            l1:
            Console.Clear();
            Console.ForegroundColor= ConsoleColor.White;
            PrintMenu();

            switch (Scaner.ReadInteger("Zehmet olmasa menuyu secin: "))

            {

                case 1:

                    Marka g = new Marka();

                    g.Name = Scaner.ReadString("Marka adi: ");

                    markaStore.Add(g);

                    Console.Clear();

                    goto case 4;

                case 2:

                    Console.Clear();

                    GetAllMarka();

                l2:

                    markaid = Scaner.ReadInteger("Marka id: ");

                    var foundMarka = markaStore.Find(g => g.MarkaId == markaid);

                    if (foundMarka == null)

                    {

                        Console.WriteLine("Siyahidan secilmelidir: ");

                        goto l2;
                    }

                    foundMarka.Name = Scaner.ReadString("Marka adi: ");

                    goto case 4;

                case 3:

                    GetAllMarka();
                l3:
                    markaid = Scaner.ReadInteger("Marka id: ");


                    if (!markaStore.Exists(x => x.MarkaId == markaid))

                    {
                        Console.WriteLine("Siyahidan secilmelidir: ");

                        goto l3;
                    }

                    Marka found = markaStore.Find(g => g.MarkaId == markaid);

                    markaStore.Remove(found);

                    goto case 4;

                case 4:

                    Console.Clear();

                    GetAllMarka();

                    Console.Write("Menyuya qayitmaq ucun her hansi duymeni klikleyin");

                    Console.ReadKey();

                    Console.Clear();

                    goto l1;

                case 5:

                    Console.Clear();

                    Console.WriteLine("Siyahidan secin: ");

                    GetAllMarka();


                    Model m = new Model();

                    markaid = Scaner.ReadInteger("Marka id: ");

                    var chooseMarka = markaStore.Find(g => g.MarkaId == markaid);

                    if (chooseMarka == null)

                    {
                        Console.WriteLine("Bu marka movcud deyil,siz yaradin...");
                        goto case 1;
                    }

                    m.MarkaId = chooseMarka.MarkaId;

                    m.Name = Scaner.ReadString("Model adi: ");


                    modelStore.Add(m);

                    Console.Clear();

                    goto l1;

                case 6:

                    Console.Clear();

                    GetAllModel();

                l4:
                    modelid = Scaner.ReadInteger("Model id: ");

                    var foundModel = modelStore.Find(g => g.ModelId == modelid);

                    if (foundModel == null)

                    {
                        Console.WriteLine("Siyahidan secilmelidir: ");
                        goto l4;
                    }

                    foundModel.Name = Scaner.ReadString("Model adi: ");

                    goto case 8;

                case 7:

                    GetAllModel();

                l5:

                    modelid = Scaner.ReadInteger("Model id: ");

                    if (!markaStore.Exists(x => x.MarkaId == modelid))

                    {

                        Console.WriteLine("Siyahidan secilmelidir: ");

                        goto l5;

                    }

                    Model tap = modelStore.Find(g => g.ModelId == modelid);

                    modelStore.Remove(tap);

                    goto case 8;

                case 8:

                    Console.Clear();

                    GetAllModel();

                    Console.Write("Please press any key go to menu");

                    Console.ReadKey();

                    Console.Clear();

                    goto l1;

                case 9:

                    Console.Clear();

                    Console.WriteLine("Siyahidan secin: ");

                    GetAllMarka();

                    Cars c = new Cars();
                    markaid = Scaner.ReadInteger("Marka id: ");

                    var chooseMarka1 = markaStore.Find(g => g.MarkaId == markaid);

                    if (chooseMarka1 == null)

                    {

                        Console.WriteLine("Bu marka movcud deyil zehmet olmasa yaradin");

                        goto case 1;

                    }


                    c.MarkaId = chooseMarka1.MarkaId;

                    c.Name = Scaner.ReadString("Avtomobil adi: ");

                    c.Year = Scaner.ReadInteger("Avtomobilin ilini daxil edin: ");

                    c.VIN = Scaner.ReadString("Avtomobilin ban nomresini daxil edin: ");

                    c.Mator = Scaner.ReadDouble("Avtomobilin mator hecmini daxil edin: ");

                    c.SuretlerQutusu = Scaner.ReadString("Avtomobilin suretler qutusunu daxil edin (Avtomat ve ya mexanika): ");

                    c.Reng = Scaner.ReadString("Avtomobilin rengini daxil edin: ");

                    c.Qiymet = Scaner.ReadDouble("Avtomobilin qiymetini daxil edin: ");

                    carStore.Add(c);

                    Console.Clear();

                    goto case 12;

                case 10:

                    Console.Clear();

                    GetAllCars();

                l6:

                    carid = Scaner.ReadInteger("Avtomobil id: ");

                    var foundCar = carStore.Find(g => g.CarId == carid);

                    if (foundCar == null)

                    {

                        Console.WriteLine("Siyahidan secilmelidir: ");

                        goto l6;

                    }

                    foundCar.Name = Scaner.ReadString("Avtomobil adi: ");
                    foundCar.Year = Scaner.ReadInteger("Avtomobilin ilini daxil edin: ");

                    foundCar.VIN = Scaner.ReadString("Avtomobilin ban nomresini daxil edin: ");

                    foundCar.Mator = Scaner.ReadInteger("Avtomobilin mator hecmini daxil edin: ");

                    foundCar.SuretlerQutusu = Scaner.ReadString("Avtomobilin suretler qutusunu daxil edin (Avtomat ve ya mexanika): ");

                    foundCar.Reng = Scaner.ReadString("Avtomobilin rengini daxil edin: ");

                    foundCar.Qiymet = Scaner.ReadInteger("Avtomobilin qiymetini daxil edin: ");

                    goto case 12;

                case 11:

                    GetAllCars();

                l7:

                    carid = Scaner.ReadInteger("Avtomobil id: ");

                    if (!carStore.Exists(x => x.CarId == carid))

                    {

                        Console.WriteLine("Siyahidan secilmelidir: ");

                        goto l7;

                    }

                    Cars find = carStore.Find(g => g.CarId == carid);

                    carStore.Remove(find);

                    goto case 12;

                case 12:

                    Console.Clear();

                    GetAllCars();

                    Console.Write("Please press any key go to menu");

                    Console.ReadKey();

                    Console.Clear();

                    goto l1;

                case 13:

                    Console.Clear();

                    Console.WriteLine("Melumatlar Saxlanilir....");

                    Task.Delay(1800).Wait();

                    Console.Clear();

                    Console.WriteLine("Melumat uqurla elave edildi !");

                    CarContext db = new CarContext();

                    db.Markas = markaStore;

                    db.Models = modelStore;

                    db.Cars = carStore;

                    using (var file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))

                    {

                        BinaryFormatter bf = new BinaryFormatter();

                        bf.Serialize(file, db);

                    }
                    goto l1;

                case 14:
                    Console.Clear();
                    Console.WriteLine("Cixmaq istediyinizden eminsiz? (He/Yox)");
                    string cavab = Console.ReadLine();
                    if (cavab == "He" || cavab == "he" || cavab == "H" || cavab == "h")
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\n\n\n\n\n\n\n                                                         BYE-BYE");
                        Environment.Exit(0);
                    }
                    else
                        Console.Clear();
                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.WriteLine(" \n \n \n \n \n \n \n  \n \n \n \n  \n                                                           DAVAM");
                    Console.ReadLine();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    goto l1;

                default:

                    Console.WriteLine("Zehmet olmasa menyunu duzgun secin!");

                    goto l1;




            }

        }

        static void PrintMenu()

        {
            Console.WriteLine("1 - Yeni marka elave etmek");

            Console.WriteLine("2 - Markani redakte etmek");

            Console.WriteLine("3 - Markani silmek");

            Console.WriteLine("4 - Markalarin siyahisina baxmaq");

            Console.WriteLine("5 - YeniModel elave etmek");

            Console.WriteLine("6 - Modeli redakte etmek");

            Console.WriteLine("7 - Modeli silmek");

            Console.WriteLine("8 - Modellerin siyahisina baxmaq");

            Console.WriteLine("9 - Yeni masin elave etmek");

            Console.WriteLine("10 - Cari mashini redakte etmek");

            Console.WriteLine("11 - Cari mashini silmek");

            Console.WriteLine("12 - Masinlarin siyahisina baxmaq");

            Console.WriteLine("13 - Yadda saxlamaq");

            Console.WriteLine("14 - Sistemden cixish");

        }
        static void GetAllModel()

        {

            GetAllMarka();

            int markaId = Scaner.ReadInteger("Marka id: ");
            Console.Clear();

            if (markaId > 0)
            {
                var chooseMarka = markaStore.Find(s => s.MarkaId == markaId);

                var chooseItems = modelStore.FindAll(s => s.MarkaId == markaId);

                Console.WriteLine($"## Modellerin siyahisi => {chooseMarka.Name}##");

                foreach (var item in chooseItems)
                {
                    var group = markaStore.Find(g => g.MarkaId == item.MarkaId);

                    Console.WriteLine($"{item}");
                }
            }
            else
            {
                Console.WriteLine("## Markalarin siyahisi ##");
                foreach (var item in modelStore)
                {
                    var marka = modelStore.Find(g => g.MarkaId == item.MarkaId);

                    Console.WriteLine($"{marka.Name}: {item}");
                }
            }

        }
        static void GetAllCars()
        {


            GetAllMarka();


            int markaId = Scaner.ReadInteger("Marka id: ");
            Console.Clear();

            if (markaId > 0)
            {
                var chooseModel = markaStore.Find(s => s.MarkaId == markaId);

                var chooseItems = carStore.FindAll(s => s.MarkaId == markaId);

                Console.WriteLine($"## Avtomobillerin siyahisi ##");

                foreach (var item in chooseItems)
                {
                    var car = carStore.Find(g => g.MarkaId == item.MarkaId);

                    Console.WriteLine($"{item}");
                }
            }
            else
            {
                Console.WriteLine("## Markalarin siyahisi ##");
                foreach (var item in markaStore)
                {
                    var marka = markaStore.Find(g => g.MarkaId == item.MarkaId);

                    Console.WriteLine($"{marka.Name}: {item}");
                }
            }

        }
        static void GetAllMarka()
        {
            Console.WriteLine("## Markalarin siyahisi ##");

            foreach (var item in markaStore)
            {
                Console.WriteLine(item);
            }
        }
      

    }
}
