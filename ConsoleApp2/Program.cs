using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Notes
            /*
            byte myByte = 255;      //8 bit maxes out at 255
            char myChar = '2';      // 16 bits, can only be one character 
            short s     = 65;       // 16 bits, short expected to be a number
            int myInt   = 2456687;  // 32 bits, 2147483647 is max, signed= can go negative 
            uint myUInt = 3465463541; // 32 bit, unsigned = has to be a positive full number
            float myFloat = 1.2345f;    // 32 bits
            double myDouble = 1.23456;  //64 bits
            decimal myDecimal = (decimal)1.4444; // 128 bits
            string myString = "Hello World";    // collection of characters, usually refered to as a variable
            bool myBool = true;
            bool myBool2 = false;

            string x = Console.ReadLine();
             Console.WriteLine(x);
             Console.ReadLine(); 


            Console.WriteLine(" Please enter a number between 1 and 10");
            string userResponse = Console.ReadLine();



            int userNumber;
            if (int.TryParse( userResponse,out userNumber) )
            {
                if (userNumber < 1 || userNumber> 10)
                {
                    Console.WriteLine("Sorry that value was outside of the acceptable range.");
                }
                else
                {
                    userNumber *= 2;
                    // same a userNumber = userNumber *2;
                    Console.WriteLine(" the user's multiplied number equals:" + userNumber);

                    Console.WriteLine($"your new number is : {userNumber} which is two times the value");

                }
            }
            else
            {
                Console.WriteLine("Sorry, that was not an acceptable number.");
            }

            Console.WriteLine("Press enter to close.");

            Console.ReadLine();  
            */
            #endregion

            //creates an instance of the NumberGuesser class
            var numberGuesser = new NumberGuesser(); 

            //Change the default max to 200
            numberGuesser.MaximumNumber = 200;

            //Call the InformUser method to ask the user to think of a number
            numberGuesser.InformUser();

            //Call the DiscoverNumber method to continually ask the user a range of values
            numberGuesser.DiscoverNumber();

            //Announce the users number
            numberGuesser.AnnouceResult();

        }
    }
}
