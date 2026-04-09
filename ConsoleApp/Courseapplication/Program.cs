using Courseapplication.Helpers;

namespace Courseapplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Helper.PrintConsoleColor(ConsoleColor.Blue, "select one option");
            Helper.PrintConsoleColor(ConsoleColor.Yellow, "1 - Create Group\n2 - Get Group\n3 - GetAll Groups\n4 - Delete Group\n5 - Update Group");
        }
    }
}
