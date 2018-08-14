using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList
{
    class Program
    {
        static void Main(string[] args)
        {//----variables----
            List<string> groceries = new List<string>();
            int mainMenu = 0;
            do
            {
                Console.WriteLine("please select an option by numerical value");
                Console.WriteLine("1 add item to list");
                Console.WriteLine("2 view list");
                Console.WriteLine("3 remove item from list");
                Console.WriteLine("4 update items on list");
                Console.WriteLine("5 exit");
                mainMenu = Convert.ToInt32(Console.ReadLine());
                switch (mainMenu)
                {
                    case 1:
                        AddItem(Prompt("what would you like to add?"),
                            Convert.ToInt32(Prompt("how many would you like to add?")), groceries);
                        break;
                    case 2:
                        ViewList(groceries);
                        Console.ReadKey();
                        break;
                    case 3:
                        RemoveItem(Prompt("what would you like to remove?"),
                            Convert.ToInt32(Prompt("how many would you like to remove?")), groceries);
                        break;
                    case 4:
                        UpdateItem(groceries);
                        break;
                    default:
                        Console.WriteLine("please enter valid menu option!");
                        break;
                }
                Console.Clear();
            } while (mainMenu != 5);
        }
        //----method add item----
        public static void AddItem(string item, int numItem, List<string> groceries)
        {
            for (int index = 0; index < numItem; index++)
            {
                groceries.Add(item);
            }
        }
        //------it counts the occurences of the item in the list-------------
        public static int GetQty(List<string> groceries, string item)
        {
            int qty = 0;
            foreach (string product in groceries)
            {
                if (product == item)
                {
                    qty++;
                }
            }
            return qty;
        }
        //----method view list---
        public static void ViewList(List<string> groceries)
        {
            string prevItem = "";
            Console.WriteLine("Item          Qty");
            Console.WriteLine("_________________");
            foreach (string item in groceries)
            {
                if (item != prevItem)
                {
                    Console.WriteLine(item + "            " + GetQty(groceries, item));
                }
                prevItem = item;
            }
        }
        //----method remove item----
        public static void RemoveItem(string deleteItem, int deleteNum, List<string> groceries)
        {
            for (int index = 0; index < deleteNum; index++)
            {
                groceries.Remove(deleteItem);
            }
        }
        //----update item----
        public static void UpdateItem(List<string> groceries)
        {
            string item = Prompt("which item do you want to update");
            Console.WriteLine("what would you like to do");
            Console.WriteLine("1 change number of items");
            int opt = Convert.ToInt32(Prompt("2 change name of items"));
            if (opt == 1)
            {
                UpdateQty(groceries, item);
            }
            else if (opt == 2)
            {
                UpdateName(groceries, item);
            }
        }
        private static void UpdateName(List<string> groceries, string item)
        {
            string newItem = Prompt("what is your item's new name?");
            for (int index = 0; index < groceries.Count; index++)
            {
                if (item == groceries[index])
                {
                    groceries[index] = newItem;
                }
            }
        }
        private static void UpdateQty(List<string> groceries, string item)
        {
            int numItem = Convert.ToInt32(Prompt("whats your new Qty"));
            if (numItem > GetQty(groceries, item))
            {
                int diff = numItem - GetQty(groceries, item);
                AddItem(item, diff, groceries);
            }
            else
            {
                int diff = GetQty(groceries, item) - numItem;
                RemoveItem(item, diff, groceries);
            }
        }
        public static string Prompt(string input)
        {
            Console.WriteLine(input);
            return Console.ReadLine();

        }
    }
}