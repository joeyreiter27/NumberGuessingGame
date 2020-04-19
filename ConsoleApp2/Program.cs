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


            // ask user to think of number
            Console.Write("Think of a number between 0 and 100"); ;
            Console.ReadLine();

            // defines the initial max number the user can guess
            int max = 100;

            //keep track of the number of guesses
            int guesses = 0;

            //the start guess from
            int guessMin = 0;

            // the start guess to (half of the max)
            int guessMax = max / 2;

            // while the guess isnt the same as the known max value
            while (guessMin != max)
            {
                //Increase guess amount
                guesses++;
                //Ask the user if their number is between the guess range
                Console.WriteLine($"Is your number between {guessMin} and {guessMax}?");
                string response = Console.ReadLine();


                //if the user confirmed their number is within the current range
                //    bool hasReponse  = (response != null && response.Length > 0);
                //   if ( response[0] == 'y' || response[0] == 'Y')
                

                // ? after the variable checks to see if variable != null  .... this ensures your variable is populated with something
                //ToLower() converts the variable to lowercase so it will check both upper and lower in the if statement
                if(response?.ToLower().FirstOrDefault() == 'y' ) 
                {
                    //we know the number is between guessFrom and guessTo
                    //So set the new max number
                    max = guessMax;

                    // change the next guess range to be half of the new max range
                    guessMax = guessMax - (guessMax - guessMin) / 2; 



                }
                // the number is greater than guessMax and less than or equal to Max
                else
                    {
                    //the new min is one above the old maximum
                    guessMin = guessMax + 1;

                    //Guess the bottom half of the new range 
                    int remainingDiff = max - guessMax;

                    // add the remaining diff to the guessMax for your next ask
                    // NOTE: Math.Ceiling will round up the remaining difference to 2, if the difference is 3.
                    guessMax += (int) Math.Ceiling(remainingDiff / 2f);

                    }

                // if we only  have two numbers left we guess one of them
                if (guessMin + 1 == max)
                {
                    //increase guesses by 1
                    guesses++;
                    // guess the minimum
                    Console.WriteLine($"Is your number {guessMin}?");
                    response = Console.ReadLine();

                    if (response?.ToLower().FirstOrDefault() == 'y')
                    {
                        break;  // breaks out of the while loop
                    }
                    else
                    {
                        //assigns your guessMin for the output below, also sets the two equal so the while loop is broken out of
                        guessMin = max; 
                    }

               
                }
           
            }// end of while loop
            Console.WriteLine($"** Your number {guessMin} was guessed in {guesses} guesses.**");
            Console.ReadLine();
        }
    }
}
