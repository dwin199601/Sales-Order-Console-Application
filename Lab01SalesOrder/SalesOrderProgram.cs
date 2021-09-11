using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lab01SalesOrder
{
    class SalesOrderProgram
    {
        static void Main(string[] args)
        {
           
            bool nextItem = true;
            double subTotalPrice = 0;
            double totalPrice = 0;
            double TAX = 12;
            double taxNum = 0;
            int itemNumber = 0;
         
            StringBuilder rceipt = new StringBuilder();
            string itemPrice = "";
            double itemPriceDouble = 0;
            string itemName = "";
            Console.Title = "Sales Order";
            string UserChoose = "";

            while (nextItem && itemNumber < 10)
            {
                try {
                    Console.ResetColor();
                    UserChoose = UserInput();
                    if (UserChoose == "i" || UserChoose == "I")
                    {
                        EnterPriceName(ref itemName, ref itemPrice);
                       
                       
                        itemPriceDouble = double.Parse(itemPrice);
                        rceipt.AppendFormat("{0,-20} {1,10:c}\n", itemName, itemPriceDouble);
                        subTotalPrice += itemPriceDouble;
                        taxNum = subTotalPrice * TAX / 100;
                        totalPrice = subTotalPrice + taxNum;

                        itemNumber +=1;
                        if (itemNumber > 9)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            WriteLine("You have just exceeded the limit of ten orders! You cannot enter more!");
                            ReceiptDisplay(ref rceipt, ref subTotalPrice, ref TAX, ref taxNum, ref totalPrice);
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.White;
                            WriteLine("Thank you for using our app! Have a good day!");
                            ReadLine();
                        }

                    }
                    else if (UserChoose == "p" || UserChoose == "P")
                    {
                    
                        ReceiptDisplay(ref rceipt, ref subTotalPrice, ref TAX, ref taxNum, ref totalPrice);


                    }
                    else if (UserChoose == "q" || UserChoose == "Q")
                    {
                        WriteLine("Thank you for using our store! Have a wonderful day!");
                        nextItem = false;
                        ReadLine();

                    }
                    else
                        WriteLine("The entered value is incorect! Try again");
                
                }
                catch (Exception ex)
            {
                WriteLine("Error: " + ex);
            }
        }
        }

        
        static string UserInput()
        {
            Write("Enter Comand (i - enter item, p - print receipt, q - quit): ");
            string output = ReadLine();
            return output;

        }
        
        static void EnterPriceName(ref string itemName, ref string itemPrice)
        {
            Write("Enter item name: ");
            itemName = ReadLine();
            Write("Enter item price: ");
            itemPrice = ReadLine();
        }

        static void ReceiptDisplay(ref StringBuilder rceipt, ref double subTotalPrice, ref double TAX, ref double taxNum, ref double totalPrice)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            WriteLine("Receipt:");
            WriteLine(rceipt);
            WriteLine();
            WriteLine("\nSubtotal Item Price: {0, 17:C}", subTotalPrice);
            WriteLine("Tax {0:P}: {1,25:C}", TAX / 100, taxNum);
            WriteLine("Total Price: {0,25:C} ", totalPrice);
            Console.ResetColor();
        }
    }
}
