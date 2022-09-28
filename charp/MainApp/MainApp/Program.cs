// See https://aka.ms/new-console-template for more information
using ConsoleTools;
using MainApp;
using MainApp.Models.DBModels;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;

internal class Program
{
    static RestService rest;
    static string ApiRout = "NoneCrud/HowManyCreting/";


    enum TableEnum
    {
        Warehouse,
        Blacksmith,
        Generalstore,
        Recepie
    }
    private static void Main(string[] args)
    {
        rest = new RestService("http://localhost:5025/", "Blacksmith");
        ConsoleMenu wareSubMenu = new ConsoleMenu(args, 1)
        .Add("List", () => List(TableEnum.Warehouse, true))
        .Add("Add", () => Add(TableEnum.Warehouse))
        .Add("Update", () => Update(TableEnum.Warehouse))
        .Add("Delete", () => Delete(TableEnum.Warehouse))
        .Add("Back", ConsoleMenu.Close);

        ConsoleMenu smithSubMenu = new ConsoleMenu(args, 1)
            .Add("List", () => List(TableEnum.Blacksmith, true))
            .Add("Add", () => Add(TableEnum.Blacksmith))
            .Add("Update", () => Update(TableEnum.Blacksmith))
            .Add("Delete", () => Delete(TableEnum.Blacksmith))
            .Add("NonCrude1", () => NonCrude1(TableEnum.Blacksmith))
            .Add("Back", ConsoleMenu.Close);

        ConsoleMenu storeSubMenu = new ConsoleMenu(args, 1)
            .Add("List", () => List(TableEnum.Generalstore, true))
            .Add("Add", () => Add(TableEnum.Generalstore))
            .Add("Update", () => Update(TableEnum.Generalstore))
            .Add("Delete", () => Delete(TableEnum.Generalstore))
            .Add("Back", ConsoleMenu.Close);
        ConsoleMenu recepieSubMenu = new ConsoleMenu(args, 1)
            .Add("List", () => List(TableEnum.Recepie, true))
            .Add("Add", () => Add(TableEnum.Recepie))
            .Add("Update", () => Update(TableEnum.Recepie))
            .Add("Delete", () => Delete(TableEnum.Recepie))
            .Add("Back", ConsoleMenu.Close);

        ConsoleMenu menu = new ConsoleMenu(args, 0)
            .Add("WareHouse", () => wareSubMenu.Show())
            .Add("Blacksmith", () => smithSubMenu.Show())
            .Add("Generalstore", () => storeSubMenu.Show())
            .Add("Recepie", () => recepieSubMenu.Show())
            .Add("Exit", ConsoleMenu.Close);
        menu.Show();


    }


    private static void NonCrude1(TableEnum myEnum)
    {
        switch (myEnum)
        {
            default:
            case TableEnum.Warehouse:
                break;
            case TableEnum.Blacksmith:
                int materialid = 9;
                //Console.WriteLine(rest.GetSingle<string>(GetApiString(ApiRout, "materialid#itemQuantity", $"{materialid}#{itemQuantity}")));
                //Console.WriteLine(rest.GetSingle<string>("HowManyCreting/materialid, itemQuantity?materialid=1&itemQuantity=3"));
                //foreach (string item in rest.Get<string>("NoneCrud/HowManyCreting/materialid?materialid=9"))
                foreach (string item in rest.Get<string>(GetApiString(ApiRout, "materialid", $"{materialid}")))
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
                break;
            case TableEnum.Generalstore:
                break;
            case TableEnum.Recepie:
                break;
        }
    }

    private static void NonCrude2(TableEnum myEnum)
    {
        switch (myEnum)
        {
            default:
            case TableEnum.Warehouse:
                break;
            case TableEnum.Blacksmith:
                break;
            case TableEnum.Generalstore:
                break;
            case TableEnum.Recepie:
                break;
        }
    }

    private static void NonCrude3(TableEnum myEnum)
    {
        switch (myEnum)
        {
            default:
            case TableEnum.Warehouse:
                break;
            case TableEnum.Blacksmith:
                break;
            case TableEnum.Generalstore:
                break;
            case TableEnum.Recepie:
                break;
        }
    }

    private static string GetApiString(string url, string itemNames, string itemValues)
    {
        string output = url;
        string[] names = itemNames.Split('#');
        string[] values = itemValues.Split('#');
        if (names.Length < 1 || values.Length<1)
        {
            throw new ArgumentException("Item names or vlues not has data");
        }
        else if(names.Length == 1)
        {
            return output += $"{names[0]}?{names[0]}={values[0]}";
        }
        else
        {
            output += names[0];
            for (int i = 1; i < names.Length; i++)
            {

                output += $",{names[i]}";
            }
            output += $"?{names[0]}={values[0]}";
            for (int i = 1; i < values.Length; i++)
            {
                output += $"${names[i]}={values[i]}";
            }
        }
        return output;
    }
    private static void Delete(TableEnum myEnum)
    {
        int id = 0;
        switch (myEnum)
        {
            default:
            case TableEnum.Warehouse:
                Console.WriteLine("Delete data from Warehouse table.");
                Console.Write("Id:");
                id = int.Parse(Console.ReadLine());
                rest.Delete(id, nameof(WareHouse));
                break;
            case TableEnum.Blacksmith:
                Console.WriteLine("Delete data from Blacksmith table.");
                Console.Write("Id:");
                id = int.Parse(Console.ReadLine());
                rest.Delete(id, nameof(Blacksmith));
                break;
            case TableEnum.Generalstore:
                Console.WriteLine("Delete data from Generalstore table.");
                Console.Write("Id:");
                id = int.Parse(Console.ReadLine());
                rest.Delete(id, nameof(Generalstore));
                break;
            case TableEnum.Recepie:
                Console.WriteLine("Delete data from Recepie table.");
                Console.Write("Id:");
                id = int.Parse(Console.ReadLine());
                rest.Delete(id, nameof(Recepie));
                break;
        }
    }

    private static void Update(TableEnum myEnum)
    {
        int id = 0;
        switch (myEnum)
        {
            default:
            case TableEnum.Warehouse:
                Console.WriteLine("Updtating data to Warehouse.");
                List(myEnum, false);
                Console.WriteLine("Which data you want to modify");
                Console.Write("Id:");
                id = int.Parse(Console.ReadLine());
                WareHouse newWare = rest.Get<WareHouse>(id, "warehouse");
                Console.Write("new material name: ");
                newWare.Name = Console.ReadLine();
                Console.Write("new Materialtype: ");
                newWare.MaterialType = Console.ReadLine();
                Console.Write("new price: ");
                newWare.Price = int.Parse(Console.ReadLine());
                Console.Write("new quantity: ");
                newWare.Quantity = int.Parse(Console.ReadLine());
                rest.Put(newWare, nameof(WareHouse));
                break;
            case TableEnum.Blacksmith:
                Console.WriteLine("Updtating data to Blacksmith table.");
                List(myEnum, false);
                Console.WriteLine("Which data you want to modify");
                Console.Write("Id:");
                id = int.Parse(Console.ReadLine());
                Blacksmith newSmith = rest.Get<Blacksmith>(id, "blacksmith");
                Console.Write("new MaterialId:");
                newSmith.MaterialId = int.Parse(Console.ReadLine());
                Console.Write("new Name:");
                newSmith.Name = Console.ReadLine();
                Console.Write("Is dameged?: ");
                newSmith.Damaged = bool.Parse(Console.ReadLine());
                Console.Write("new Price: ");
                newSmith.BasePrice = int.Parse(Console.ReadLine());
                Console.Write("new Quality: ");
                newSmith.Quality = int.Parse(Console.ReadLine());
                rest.Put(newSmith, nameof(Blacksmith));

                break;
            case TableEnum.Generalstore:
                Console.WriteLine("Updtating data to Generalstore.");
                List(myEnum, false);
                Console.WriteLine("Which data you want to modify");
                Console.Write("Id:");
                id = int.Parse(Console.ReadLine());
                Generalstore newStore = rest.Get<Generalstore>(id, "generalstore");
                Console.Write("new MaterialId:");
                newStore.MaterialId = int.Parse(Console.ReadLine());
                Console.Write("new item Name:");
                newStore.Name = Console.ReadLine();
                Console.Write("new Price:");
                newStore.Price = int.Parse(Console.ReadLine());
                Console.Write("new Quality:");
                newStore.Quality = int.Parse(Console.ReadLine());
                Console.Write("new Exparing date(if it not expereing then write null):");
                newStore.ExpiringDate = int.Parse(Console.ReadLine());
                rest.Put(newStore, nameof(Generalstore));
                break;
            case TableEnum.Recepie:
                Console.WriteLine("Updtating data to Recepie table.");
                List(myEnum, false);
                Console.WriteLine("Which data you want to modify");
                Console.Write("Id:");
                id = int.Parse(Console.ReadLine());
                Recepie newRecepie = rest.Get<Recepie>(id, nameof(Recepie));
                Console.Write("new recepie name: ");
                newRecepie.RecepieName = Console.ReadLine();
                Console.Write("new MaterialId: ");
                newRecepie.MaterialId = int.Parse(Console.ReadLine());
                Console.Write("new quantity: ");
                newRecepie.MaterialQuantity = int.Parse(Console.ReadLine());
                rest.Put(newRecepie, nameof(Recepie));
                break;
        }
    }

    private static void Add(TableEnum myEnum)
    {

        switch (myEnum)
        {
            default:
            case TableEnum.Warehouse:
                Console.WriteLine("Adding data to Warehouse table.");
                WareHouse newWare = new WareHouse();
                Console.Write("new material name: ");
                newWare.Name = Console.ReadLine();
                Console.Write("new Materialtype: ");
                newWare.MaterialType = Console.ReadLine();
                Console.Write("new price: ");
                newWare.Price = int.Parse(Console.ReadLine());
                Console.Write("new quantity: ");
                newWare.Quantity = int.Parse(Console.ReadLine());
                rest.Post(newWare, nameof(WareHouse));
                break;
            case TableEnum.Blacksmith:
                Console.WriteLine("Adding data to Blacksmith table.");
                Blacksmith newSmith = new Blacksmith();
                Console.Write("new MaterialId:");
                newSmith.MaterialId = int.Parse(Console.ReadLine());
                Console.Write("new Name:");
                newSmith.Name = Console.ReadLine();
                Console.Write("Is dameged?: ");
                newSmith.Damaged = bool.Parse(Console.ReadLine());
                Console.Write("new Price: ");
                newSmith.BasePrice = int.Parse(Console.ReadLine());
                Console.Write("new Quality: ");
                newSmith.Quality = int.Parse(Console.ReadLine());
                rest.Post(newSmith, nameof(Blacksmith));
                break;
            case TableEnum.Generalstore:
                Console.WriteLine("Adding data to Generalstore table.");
                Generalstore newStore = new Generalstore();
                Console.Write("new MaterialId:");
                newStore.MaterialId = int.Parse(Console.ReadLine());
                Console.Write("new item Name:");
                newStore.Name = Console.ReadLine();
                Console.Write("new Price:");
                newStore.Price = int.Parse(Console.ReadLine());
                Console.Write("new Quality:");
                newStore.Quality = int.Parse(Console.ReadLine());
                Console.Write("new Exparing date(if it not expereing then press enter):");
                int expDate;
                if (int.TryParse(Console.ReadLine(), out expDate))
                    newStore.ExpiringDate = expDate;
                else
                    newStore.ExpiringDate = null;
                rest.Post(newStore, nameof(Generalstore));
                break;
            case TableEnum.Recepie:
                Console.WriteLine("Adding data to Recepie table.");
                Recepie newRecepie = new Recepie();
                Console.Write("new recepie name: ");
                newRecepie.RecepieName = Console.ReadLine();
                Console.Write("new MaterialId: ");
                newRecepie.MaterialId = int.Parse(Console.ReadLine());
                Console.Write("new quantity: ");
                newRecepie.MaterialQuantity = int.Parse(Console.ReadLine());
                rest.Post(newRecepie, nameof(Recepie));
                break;
        }
    }

    private static void List(TableEnum myEnum, bool waitForInput)
    {
        switch (myEnum)
        {
            default:
            case TableEnum.Warehouse:
                List<WareHouse> wares = rest.Get<WareHouse>(nameof(WareHouse));
                Console.WriteLine("Id \t Name \t MaterialType \t Price \t Quantity");
                foreach (var item in wares)
                {
                    Console.WriteLine(item);
                }
                break;
            case TableEnum.Blacksmith:
                List<Blacksmith> smiths = rest.Get<Blacksmith>(nameof(Blacksmith));
                Console.WriteLine("Id \t MaterialId \t Name \t Damaged \t Quality");
                foreach (var item in smiths)
                {
                    Console.WriteLine(item);
                }
                break;
            case TableEnum.Generalstore:
                List<Generalstore> stores = rest.Get<Generalstore>(nameof(Generalstore));
                Console.WriteLine("Id \t MaterialId \t Name \t\t Price \t Quality \t ExpiringDate");
                foreach (var item in stores)
                {
                    Console.WriteLine(item);
                }
                break;
            case TableEnum.Recepie:
                List<Recepie> recepies = rest.Get<Recepie>(nameof(Recepie));
                Console.WriteLine("RecepieId \t RecepieName \t MaterialId \t MaterialQuantity");
                foreach (var item in recepies)
                {
                    Console.WriteLine(item);
                }
                break;
        }
        if (waitForInput)
            Console.ReadLine();
    }
}
        


