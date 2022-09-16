// See https://aka.ms/new-console-template for more information
using ConsoleTools;
using MainApp.Logic.Classes;
using MainApp.Models.DBModels;
using MainApp.Repository.Class;

internal class Program
{
    static BrandLogic brandLogic;
    static ModelLogic modelLogic;
    static ExtrasLogic extrasLogic;
    enum TableEnum
    {
        Brand,
        Model,
        Extra
    }
    private static void Main(string[] args)
    {
        BikeDbContext ctx = new BikeDbContext();

        BrandRepository brandRepository = new BrandRepository(ctx);
        ModelRepository modelRepository = new ModelRepository(ctx);
        ExtrasRepository extrasRepository = new ExtrasRepository(ctx);

        brandLogic = new BrandLogic(brandRepository);
        modelLogic = new ModelLogic(modelRepository); 
        extrasLogic = new ExtrasLogic(extrasRepository);

        ConsoleMenu brandSubMenu = new ConsoleMenu(args, 1)
            .Add("List", () => List(TableEnum.Brand))
            .Add("Add", () => Add(TableEnum.Brand))
            .Add("Update", () => Update(TableEnum.Brand))
            .Add("Delete", () => Delete(TableEnum.Brand))
            .Add("Back", ConsoleMenu.Close);

        ConsoleMenu modelSubMenu = new ConsoleMenu(args, 1)
            .Add("List", () => List(TableEnum.Model))
            .Add("Add", () => Add(TableEnum.Model))
            .Add("Update", () => Update(TableEnum.Model))
            .Add("Delete", () => Delete(TableEnum.Model))
            .Add("Back", ConsoleMenu.Close);

        ConsoleMenu extraSubMenu = new ConsoleMenu(args, 1)
            .Add("List", () => List(TableEnum.Extra))
            .Add("Add", () => Add(TableEnum.Model))
            .Add("Update", () => Update(TableEnum.Model))
            .Add("Delete", () => Delete(TableEnum.Model))
            .Add("Back", ConsoleMenu.Close);

        ConsoleMenu menu = new ConsoleMenu(args, 0)
            .Add("Brand", () => brandSubMenu.Show())
            .Add("Model", () => modelSubMenu.Show())
            .Add("Extra", () => extraSubMenu.Show())
            .Add("Exit", ConsoleMenu.Close);

        menu.Show();
    }

    private static void Delete(TableEnum myEnum)
    {
        switch (myEnum)
        {
            default:
            case TableEnum.Brand:
                Console.WriteLine("Delete data from BrandTable.");
                Console.Write("Id:");
                int id = int.Parse(Console.ReadLine());
                brandLogic.Delete(id);
                break;
            case TableEnum.Model:
                break;
            case TableEnum.Extra:
                break;
        }
    }

    private static void Update(TableEnum myEnum)
    {
        switch (myEnum)
        {
            default:
            case TableEnum.Brand:
                Console.WriteLine("Updtating data to BrandTable.");
                var brands = brandLogic.GetAll();
                Console.WriteLine("Id \t BrandName");
                foreach (var item in brands)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Which data you want to modify");
                Console.Write("Id:");
                int id = int.Parse(Console.ReadLine());
                Console.Write("new BrandName:");
                string brandName = Console.ReadLine();
                var newBrand = brandLogic.Read(id);
                newBrand.BrandName = brandName;
                brandLogic.Update(newBrand);
                break;
            case TableEnum.Model:
                break;
            case TableEnum.Extra:
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
                case TableEnum.Brand:
                    Console.WriteLine("Adding data to BrandTable.");
                    Console.Write("BrandName:");
                    string brandName = Console.ReadLine();
                    brandLogic.Create(new Brand(brandName));
                    break;
                case TableEnum.Model:
                    break;
                case TableEnum.Extra:
                    break;
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }

    private static void List(TableEnum myEnum)
    {
        switch (myEnum)
        {
            default:
            case TableEnum.Brand:
                var brands = brandLogic.GetAll();
                Console.WriteLine("Id \t BrandName");
                foreach (var item in brands)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
                break;
            case TableEnum.Model:
                var models = modelLogic.GetAll();
                Console.WriteLine("BrandId \t ModelId \t ModelName \t Type \t\t BasePrice");
                foreach (var item in models)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
                break;
            case TableEnum.Extra:
                var extras = extrasLogic.GetAll();
                Console.WriteLine("ModelId \t ExtraId \t ExtraName \t Price");
                foreach (var item in extras)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
                break;
        }
    }
}
