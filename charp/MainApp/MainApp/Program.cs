// See https://aka.ms/new-console-template for more information
using ConsoleTools;

internal class Program
{
    enum TableEnum
    {
        Brand,
        Model,
        Extra
    }
    private static void Main(string[] args)
    {
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

    private static void Delete(TableEnum brand)
    {
        throw new NotImplementedException();
    }

    private static void Update(TableEnum brand)
    {
        throw new NotImplementedException();
    }

    private static void Add(TableEnum brand)
    {
        throw new NotImplementedException();
    }

    private static void List(TableEnum brand)
    {
        throw new NotImplementedException();
    }
}
