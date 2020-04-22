using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConsoleApp2
{

    /// <summary>
    /// This program askes the user to think of a number, and the program figures that number out in 8 or less guesses
    /// </summary>
    public class NumberGuesser
    {

        #region Public Properties 
        /// <summary>
        /// The largest number the user can pick
        /// </summary>
        public int MaximumNumber { get; set; }    // variable turned into a public property, not given a private set because 

        /// <summary>
        /// The current number of guesses the computer is at
        /// </summary>
        public int CurrentNumberOfGuesses { get; private set; } // dont need to assign your other properties a value here because the program will assign them a new value each time the program is run


        /// <summary>
        /// the current minimum value of the range that the computer is asking
        /// </summary>
        public int GuessMinimum { get; private set; } // ***private set used here so the value can only be set inside of this class***

          /// <summary>
          /// the current max value of the range that the computer is asking
          /// </summary>
        public int GuessMaximum { get; private set; }
        #endregion


        #region .ctor
        /// <summary>
        /// Default constructor
        /// </summary>
        public NumberGuesser()
        {
            //Set default max number 
            this.MaximumNumber = 100;
        }
        #endregion


        #region Methods 
        /// <summary>
        /// Asks the user to think of a number between 0 and max number
        /// </summary>
        public void InformUser()
        {

            // ask user to think of number
            Console.Write($"Think of a number between 0 and {this.MaximumNumber}"); ;
            Console.ReadLine();



        }

        /// <summary>
        /// Asks the user a series of questions to discover the number theyre thinking of
        /// </summary>
        public void DiscoverNumber()
        {

            //clear variable to inital value before any Discover function is used. 
            this.GuessMaximum = this.MaximumNumber / 2;
            this.CurrentNumberOfGuesses = 0;
            this.GuessMinimum = 0;

            while (this.GuessMinimum != this.GuessMaximum)
            {
                //Increase guess amount
                this.CurrentNumberOfGuesses++;

               
                Console.WriteLine($"Is your number between {this.GuessMinimum} and {this.GuessMaximum}?");
                //Records initial user response
                string response = Console.ReadLine();



                //if the user confirmed their number is within the current range
                //    bool hasReponse  = (response != null && response.Length > 0);
                //   if ( response[0] == 'y' || response[0] == 'Y')


                // ? after the variable checks to see if variable !=` null  .... this ensures your variable is populated with something
                //ToLower() converts the variable to lowercase so it will check both upper and lower in the if statement

                if (response != null && response.Length > 0 && (response.FirstOrDefault() == 'n' || response.FirstOrDefault() == 'y'))
                {

                    if (response?.ToLower().FirstOrDefault() == 'y')
                    {
                        //we know the number is between guessFrom and guessTo
                        //So set the new max number
                        this.MaximumNumber = this.GuessMaximum;

                        // change the next guess range to be half of the new max range
                        this.GuessMaximum = this.GuessMaximum - (this.GuessMaximum - this.GuessMinimum) / 2;



                    }
                    // the number is greater than guessMax and less than or equal to Max
                    else
                    {
                        //the new min is one above the old maximum
                        this.GuessMinimum = this.GuessMaximum + 1;

                        //Guess the bottom half of the new range 
                        int remainingDiff = this.MaximumNumber - this.GuessMaximum;

                        // add the remaining diff to the guessMax for your next ask
                        // NOTE: Math.Ceiling will round up the remaining difference to 2, if the difference is 3.
                        this.GuessMaximum += (int)Math.Ceiling(remainingDiff / 2f);

                    }
                }
                else 
                    {
                   var error = MessageBox.Show("You need to answer with a word that either starts with a 'y' or an 'n'.", "ERROR",MessageBoxButton.OK);
                    this.CurrentNumberOfGuesses--;
                     }       


                // if we only  have two numbers left we guess one of them
                if (this.GuessMinimum + 1 == this.MaximumNumber)
                {
                    //increase guesses by 1
                    this.CurrentNumberOfGuesses++;
                    // guess the minimum
                    Console.WriteLine($"Is your number {this.GuessMinimum}?");
                    response = Console.ReadLine();

                    if (response?.ToLower().FirstOrDefault() == 'y')
                    {
                        break;  // breaks out of the while loop
                    }
                    else
                    {
                        //assigns your guessMin for the output below, also sets the two equal so the while loop is broken out of
                        this.GuessMinimum = this.MaximumNumber;
                    }


                }

            }// end of while loop
        }

        /// <summary>
        /// Announces results of guesser
        /// </summary>
        public void AnnouceResult()
        {
            Console.WriteLine($"Your number is: {this.GuessMinimum} and it took {CurrentNumberOfGuesses} guesses to figure it out.");
            Console.ReadLine();
        }
       #endregion
    
    }
      

     
}

