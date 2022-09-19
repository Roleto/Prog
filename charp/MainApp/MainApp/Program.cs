// See https://aka.ms/new-console-template for more information
using ConsoleTools;
using MainApp.Logic.Classes;
using MainApp.Models.DBModels;
using MainApp.Repository.Class;

internal class Program
{
    static WarehouseLogic wareLogic;
    static BlacksmithLogic smithLogic;
    static GeneralstoreLogic storeLogic;
    static RecepieLogic recepieLogic;
    enum TableEnum
    {
        Warehouse,
        Blacksmith,
        Generalstore,
        Recepie
    }
    private static void Main(string[] args)
    {
        StrongholdDbContext ctx = new StrongholdDbContext();

        WarehouseRepository wareRepository = new WarehouseRepository(ctx);
        BlacksmithRepository smithRepository = new BlacksmithRepository(ctx);
        GeneralstoreRepository storeRepository = new GeneralstoreRepository(ctx);
        RecepieRepository recepieRepository = new RecepieRepository(ctx);

        wareLogic = new WarehouseLogic(wareRepository); 
        smithLogic = new BlacksmithLogic(smithRepository); 
        storeLogic = new GeneralstoreLogic(storeRepository);
        recepieLogic = new RecepieLogic(recepieRepository);

        ConsoleMenu wareSubMenu = new ConsoleMenu(args, 1)
            .Add("List", () => List(TableEnum.Warehouse, true))
            .Add("Add", () => Add(TableEnum.Warehouse))
            .Add("Update", () => Update(TableEnum.Warehouse))
            .Add("Delete", () => Delete(TableEnum.Warehouse))
            .Add("Back", ConsoleMenu.Close);

        ConsoleMenu smithSubMenu = new ConsoleMenu(args, 1)
            .Add("List", () => List(TableEnum.Blacksmith,true))
            .Add("Add", () => Add(TableEnum.Blacksmith))
            .Add("Update", () => Update(TableEnum.Blacksmith))
            .Add("Delete", () => Delete(TableEnum.Blacksmith))
            .Add("Back", ConsoleMenu.Close);

        ConsoleMenu storeSubMenu = new ConsoleMenu(args, 1)
            .Add("List", () => List(TableEnum.Generalstore,true))
            .Add("Add", () => Add(TableEnum.Generalstore))
            .Add("Update", () => Update(TableEnum.Generalstore))
            .Add("Delete", () => Delete(TableEnum.Generalstore))
            .Add("Back", ConsoleMenu.Close);
        ConsoleMenu recepieSubMenu = new ConsoleMenu(args, 1)
            .Add("List", () => List(TableEnum.Recepie,true))
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
                wareLogic.Delete(id);
                break;
            case TableEnum.Blacksmith:
                Console.WriteLine("Delete data from Blacksmith table.");
                Console.Write("Id:");
                id = int.Parse(Console.ReadLine());
                smithLogic.Delete(id);
                break;
            case TableEnum.Generalstore:
                Console.WriteLine("Delete data from Generalstore table.");
                Console.Write("Id:");
                id = int.Parse(Console.ReadLine());
                storeLogic.Delete(id);
                break;
            case TableEnum.Recepie:
                Console.WriteLine("Delete data from Recepie table.");
                Console.Write("Id:");
                id = int.Parse(Console.ReadLine());
                recepieLogic.Delete(id);
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
                var newWare = wareLogic.Read(id);
                Console.Write("new material name: ");
                newWare.Name = Console.ReadLine();
                Console.Write("new Materialtype: ");
                newWare.MaterialType = Console.ReadLine();
                Console.Write("new price: ");
                newWare.Price = int.Parse(Console.ReadLine());
                Console.Write("new quantity: ");
                newWare.Quantity = int.Parse(Console.ReadLine());
                wareLogic.Update(newWare);
                break;
            case TableEnum.Blacksmith:
                Console.WriteLine("Updtating data to Blacksmith table.");
                List(myEnum, false);
                Console.WriteLine("Which data you want to modify");
                Console.Write("Id:");
                id = int.Parse(Console.ReadLine());
                var newSmith = smithLogic.Read(id);
                Console.Write("new Id:");
                newSmith.Id = int.Parse(Console.ReadLine());
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
                smithLogic.Update(newSmith);

                break;
            case TableEnum.Generalstore:
                Console.WriteLine("Updtating data to Generalstore.");
                List(myEnum, false);
                Console.WriteLine("Which data you want to modify");
                Console.Write("Id:");
                id = int.Parse(Console.ReadLine());
                var newStore = storeLogic.Read(id);
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
                storeLogic.Update(newStore);
                break;
            case TableEnum.Recepie:
                Console.WriteLine("Updtating data to Recepie table.");
                List(myEnum, false);
                Console.WriteLine("Which data you want to modify");
                Console.Write("Id:");
                id = int.Parse(Console.ReadLine());
                var newRecepie = recepieLogic.Read(id);
                Console.Write("new recepie name: ");
                newRecepie.RecepieName = Console.ReadLine();
                Console.Write("new MaterialId: ");
                newRecepie.MaterialId = int.Parse(Console.ReadLine());
                Console.Write("new quantity: ");
                newRecepie.MaterialQuantity = int.Parse(Console.ReadLine());
                recepieLogic.Update(newRecepie);
                break;
        }
    }

    private static void Add(TableEnum myEnum)
    {
        try
        {
            switch (myEnum)
            {
                default:
                case TableEnum.Warehouse:
                    Console.WriteLine("Adding data to Warehouse table.");
                    var newWare = new WareHouse();
                    Console.Write("new material name: ");
                    newWare.Name = Console.ReadLine();
                    Console.Write("new Materialtype: ");
                    newWare.MaterialType = Console.ReadLine();
                    Console.Write("new price: ");
                    newWare.Price = int.Parse(Console.ReadLine());
                    Console.Write("new quantity: ");
                    newWare.Quantity = int.Parse(Console.ReadLine());
                    wareLogic.Create(newWare);
                    break;
                case TableEnum.Blacksmith:
                    Console.WriteLine("Adding data to Blacksmith table.");
                    var newSmith = new Blacksmith();
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
                    smithLogic.Create(newSmith);
                    break;
                case TableEnum.Generalstore:
                    Console.WriteLine("Adding data to Generalstore table.");
                    var newStore = new Generalstore();
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
                    storeLogic.Create(newStore);
                    break;
                case TableEnum.Recepie:
                    Console.WriteLine("Adding data to Recepie table.");
                    var newRecepie = new Recepies();
                    Console.Write("new recepie name: ");
                    newRecepie.RecepieName = Console.ReadLine();
                    Console.Write("new MaterialId: ");
                    newRecepie.MaterialId = int.Parse(Console.ReadLine());
                    Console.Write("new quantity: ");
                    newRecepie.MaterialQuantity = int.Parse(Console.ReadLine());
                    recepieLogic.Create(newRecepie);
                    break;
            } 
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }

    private static void List(TableEnum myEnum, bool waitForInput)
    {
        switch (myEnum)
        {
            default:
            case TableEnum.Warehouse:
                var wares = wareLogic.GetAll();
                Console.WriteLine("Id \t Name \t MaterialType \t Price \t Quantity");
                foreach (var item in wares)
                {
                    Console.WriteLine(item);
                }
                break;
            case TableEnum.Blacksmith:
                var smiths = smithLogic.GetAll();
                Console.WriteLine("Id \t MaterialId \t Name \t Damaged \t Quality");
                foreach (var item in smiths)
                {
                    Console.WriteLine(item);
                }
                break;
            case TableEnum.Generalstore:
                var stores = storeLogic.GetAll();
                Console.WriteLine("Id \t MaterialId \t Name \t Price \t Quality \t ExpiringDate");
                foreach (var item in stores)
                {
                    Console.WriteLine(item);
                }
                break;
            case TableEnum.Recepie:
                var recepies = recepieLogic.GetAll();
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
