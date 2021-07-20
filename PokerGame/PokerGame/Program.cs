using System;
using System.Threading;

namespace PokerGame
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Sarah Qiao - Modified Poker Game: this game is very similar to real life poker, but without the money being spent! 
             * You will start off with 100 pucks (poker bucks) and are given two cards from the deck. 
             * You are facing off with a random opponent who starts with two different cards than you. 
             * Your opponent will go first and will either fold his/her cards or bet some pucks. 
             * If your opponent chooses to bet, then it will be your turn. 
             * You have the choice to match, raise, or fold. 
             * If you match, you will match the bet your opponent made. 
             * If you choose to raise, you can choose the amount you want to raise. 
             * If you choose to fold, you will have the option to either continue the game (with the same number of pucks,) or quit the match. 
             * The order of hands from worst to best in this game are: High Card, Pair, Two Pair, Three of a Kind, Flush, Full House, Four of a Kind, Royal Flush.
             * Whoever had the best hand will win the round. The only time you can see your opponent's cards is if you or they bet all in and at the end of the game before the winner is announced.
             * The game will continue until either of you have bet all in and lost all your pucks, but you have the option to quit at the end of every round.
             * */

            string name = "Sarah";
            int num = -1;
            string flopNum = ""; //these are the flop cards' properties
            string flopNum2 = "";
            string flopNum3 = "";
            string flopSuit = "";
            string flopSuit2 = "";
            string flopSuit3 = "";

            string turnNum = ""; //these are the turn card's properties
            string turnSuit = "";

            string riverNum = ""; //these are the river card's properties
            string riverSuit = "";

            string opponentSuit = ""; //These are the properties of the opponent's cards
            string opponentNum = "";
            string opponentSuit2 = "";
            string opponentNum2 = "";

            //The numbers are strings for other methods to work easier since you cannot convert an int to a string, but it can go the other way.

            int opponentPucks = 100; //This is the starting amount of pucks
            int userPucks = 100;

            Console.WriteLine("Welcome to the");
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("    ____                         _________");
            Thread.Sleep(300);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   |    |       | /                  |                                                      |");
            Thread.Sleep(300);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   |    |  ___  |/    __             |    ___                    __           __        _|_ |");
            Thread.Sleep(300);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   |____| |   | |_   |__| |___       |   |   | |   | |___ |___   __| |__ __  |__| |___   |  |");
            Thread.Sleep(300);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   |      |___| |  | |__  |          |   |___| |___| |    |   | |__| |  |  | |__  |   |  |  o");
            Console.WriteLine();
            Console.ResetColor();
            Thread.Sleep(300);

            Console.WriteLine("What is your name?");
            name = Console.ReadLine();

            Rules(name);

            Console.Write("It is you versus ");
            Console.WriteLine(Opponent(ref num));
            Console.ResetColor();

            Thread.Sleep(1000);
            Console.WriteLine("Watch out because they have the best poker face around!");
            
            Thread.Sleep(2000);
            Opponent(ref num);
            Console.WriteLine("'Press enter to face me, " + name + "!'");
            Console.ReadLine();
            Console.Clear();

            OpponentPlay(ref num, ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2, ref opponentPucks, ref userPucks, name);
        }

        //Methods are listed in order of display.

        //The Rules Method allows the user a choice to read the rules
        static void Rules(string name)
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.WriteLine("Hello, " + name + " would you like to read the 12 rules of this Modified Poker game?");
                string userInput = Console.ReadLine();

                if (userInput == "y" || userInput == "yes")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("1. Modified Poker Game: this game is very similar to real life poker, but without the money being spent!");
                    Console.ReadLine();
                    Console.WriteLine("2. You will start off with 100 pucks (poker bucks) and are given two cards from the deck.");
                    Console.ReadLine();
                    Console.WriteLine("3. You are facing off with a random opponent who starts with two different cards than you.");
                    Console.ReadLine();
                    Console.WriteLine("4. Your opponent will go first and will either fold his / her cards or bet some pucks.");
                    Console.ReadLine();
                    Console.WriteLine("5. If your opponent chooses to bet, then it will be your turn.");
                    Console.ReadLine();
                    Console.WriteLine("6. You have the choice to match, raise, or fold.");
                    Console.ReadLine();
                    Console.WriteLine("7. If you match, you will match the bet your opponent made.");
                    Console.ReadLine();
                    Console.WriteLine("8. If you raise, you can choose the amount you want to raise.");
                    Console.ReadLine();
                    Console.WriteLine("9. If you fold, you will have the option to either continue the game (with the same number of pucks,) or quit the game.");
                    Console.ReadLine();
                    Console.WriteLine("10. The order of hands from worst to best in this game are: High Card, Pair, Two Pair, Three of a Kind, Flush, Full House, Four of a Kind, Royal Flush.");
                    Console.ReadLine();
                    Console.WriteLine("11. Whoever had the best hand will win the round. You will be able to see your opponent's cards if they bet all in and at the end of the round.");
                    Console.ReadLine();
                    Console.WriteLine("12. The tournament will continue until either of you have bet all in and lost all your pucks, but you have the option to quit at the end of every round.");
                    Console.ReadLine();
                    Console.WriteLine("Press enter when you're ready to play!");
                    Console.ReadLine();
                    Console.ResetColor();
                    keepGoing = false;
                    Console.Clear();
                }
                else if (userInput == "n" || userInput == "no")
                {
                    Thread.Sleep(1000);
                    keepGoing = false;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Please enter 'yes' or 'no'");
                    Console.WriteLine();
                }
            }
        }

        //The Opponent Method chooses the opponent and the colour of the opponent's text
        static string Opponent(ref int num)
        {
            if (num == -1)
            {
                Random opponent = new Random();
                num = opponent.Next(5);

                if (num == 1)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    return "(:|) Bob";
                }
                else if (num == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    return "(:V) Kathy";
                }
                else if (num == 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    return "(:C) Desdemona";
                }
                else if (num == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    return "(:D) Sunny";
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    return "(:{) Barnaby";
                }
            }
            else //This else statement is made so that the characters and their colours and not randomized every time this method is called (often called to get their names to display)
            {
                if (num == 1)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    return "(:|) Bob";
                }
                else if (num == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    return "(:V) Kathy";
                }
                else if (num == 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    return "(:C) Desdemona";
                }
                else if (num == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    return "(:D) Sunny";
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    return "(:{) Barnaby";
                }
            }
        }

        //The UserCards method gets the user's cards from the deck
        static string[] UserCards(ref string userSuit, ref string userSuit2, ref string userNum, ref string userNum2, string[] cards, string name)
        {
            Console.ResetColor();
            string suit = "";
            string number = "";

            Console.Write("Shuffling the deck");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.WriteLine(".");
            Thread.Sleep(1000);

            Console.WriteLine(name + ", you got: ");
            Thread.Sleep(1000);

            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            string[] NewCards = UsedCard(ref suit, ref number, cards); //This part makes sure that there are no duplicates during the game
            userSuit = suit;
            userNum = number;
            string name1 = ConvertToName(number);
            Console.Write("The " + name1 + " of " + suit);

            NewCards = UsedCard(ref suit, ref number, NewCards);
            userSuit2 = suit;
            userNum2 = number;
            string name2 = ConvertToName(number);
            Console.WriteLine(" and the " + name2 + " of " + suit);
            Console.ResetColor();
            return NewCards;
        }

        //The Flop Method shows the flop (first three cards)
        static string[] Flop(ref string flopNum, ref string flopSuit, ref string flopNum2, ref string flopSuit2, ref string flopNum3, ref string flopSuit3, string[] cards)
        {
            string suit = "";
            string number = "";

            Thread.Sleep(2000);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("This is the Flop:");
            Thread.Sleep(1000);

            string[] newCards = UsedCard(ref suit, ref number, cards); //Same with the previous method, the cards will not be repeated by doing this
            string name = ConvertToName(number);
            Console.WriteLine("The " + name + " of " + suit);
            flopNum = number;
            flopSuit = suit;
            Thread.Sleep(1000);

            newCards = UsedCard(ref suit, ref number, newCards);
            string name1 = ConvertToName(number);
            Console.WriteLine("The " + name1 + " of " + suit);
            flopNum2 = number;
            flopSuit2 = suit;
            Thread.Sleep(1000);

            newCards = UsedCard(ref suit, ref number, newCards);
            string name2 = ConvertToName(number);
            Console.WriteLine("The " + name2 + " of " + suit);
            flopNum3 = number;
            flopSuit3 = suit;
            Thread.Sleep(1000);

            Console.ResetColor();

            return newCards;
        }

        //The OpponentPlay Method decides if the opponent will bet or fold (first round only)
        static void OpponentPlay(ref int num, ref string flopNum, ref string flopSuit, ref string flopNum2, ref string flopSuit2, ref string flopNum3, ref string flopSuit3,
            ref string turnNum, ref string turnSuit, ref string riverNum, ref string riverSuit,
            ref string opponentSuit, ref string opponentNum, ref string opponentSuit2, ref string opponentNum2, ref int opponentPucks, ref int userPucks,
            string name)
        {
            //This is where all the cards are stored so that every time there is a new game it resets the cards.
            string[] cards = new string[52];

            cards[0] = "Spades 2  ";   cards[1] = "Clubs 2  ";   cards[2] = "Hearts 2  ";   cards[3] = "Diamonds 2  ";
            cards[4] = "Spades 3  ";   cards[5] = "Clubs 3  ";   cards[6] = "Hearts 3  ";   cards[7] = "Diamonds 3  ";
            cards[8] = "Spades 4  ";   cards[9] = "Clubs 4  ";   cards[10] = "Hearts 4  ";  cards[11] = "Diamonds 4  ";
            cards[12] = "Spades 5  ";  cards[13] = "Clubs 5  ";  cards[14] = "Hearts 5  ";  cards[15] = "Diamonds 5  ";
            cards[16] = "Spades 6  ";  cards[17] = "Clubs 6  ";  cards[18] = "Hearts 6  ";  cards[19] = "Diamonds 6  ";
            cards[20] = "Spades 7  ";  cards[21] = "Clubs 7  ";  cards[22] = "Hearts 7  ";  cards[23] = "Diamonds 7  ";
            cards[24] = "Spades 8  ";  cards[25] = "Clubs 8  ";  cards[26] = "Hearts 8  ";  cards[27] = "Diamonds 8  ";
            cards[28] = "Spades 9  ";  cards[29] = "Clubs 9  ";  cards[30] = "Hearts 9  ";  cards[31] = "Diamonds 9  ";
            cards[32] = "Spades 10 ";  cards[33] = "Clubs 10 ";  cards[34] = "Hearts 10 ";  cards[35] = "Diamonds 10 ";
            cards[36] = "Spades 11 ";  cards[37] = "Clubs 11 ";  cards[38] = "Hearts 11 ";  cards[39] = "Diamonds 11 ";
            cards[40] = "Spades 12 ";  cards[41] = "Clubs 12 ";  cards[42] = "Hearts 12 ";  cards[43] = "Diamonds 12 ";
            cards[44] = "Spades 13 ";  cards[45] = "Clubs 13 ";  cards[46] = "Hearts 13 ";  cards[47] = "Diamonds 13 ";
            cards[48] = "Spades 14 ";  cards[49] = "Clubs 14 ";  cards[50] = "Hearts 14 ";  cards[51] = "Diamonds 14 ";

            while (true)
            {
                string userMove = "";
                string number = "";

                string suit = "";
                string suit2 = "";

                string userSuit = "";
                string userNum = "";

                string userSuit2 = "";
                string userNum2 = "";

                int pot = 0;
                int count = 1;

                string[] newCards = UserCards(ref userSuit, ref userSuit2, ref userNum, ref userNum2, cards, name);
                Console.WriteLine();
                newCards = Flop(ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3, newCards);

                int iflopNum = Convert.ToInt32(flopNum); //i stands for the integer version of the number
                int iflopNum2 = Convert.ToInt32(flopNum2);
                int iflopNum3 = Convert.ToInt32(flopNum3);

                if (num == 1) //This is used so that the opponent still has the same colour for all of their moves.
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                else if (num == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (num == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }

                newCards = UsedCard(ref suit, ref number, newCards);
                opponentSuit = suit;
                opponentNum = number;
                int inumber = Convert.ToInt32(number);

                newCards = UsedCard(ref suit, ref number, newCards);
                opponentSuit2 = suit;
                opponentNum2 = number;
                int inumber2 = Convert.ToInt32(number);

                if (inumber < 7 && inumber2 < 7)
                {
                    Console.WriteLine(Opponent(ref num) + " folds");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else
                {
                    if (inumber == inumber2 || inumber == iflopNum || inumber == iflopNum2 || inumber == iflopNum3 || inumber2 == iflopNum || inumber2 == iflopNum2 || inumber2 == iflopNum3)
                    {
                        int opponentBet = opponentPucks / 5; //These bet values are decided by getting a percentage of the opponent's pucks depending on the likelihood of them winning with their hand.
                        if (opponentBet > userPucks)
                        {
                            opponentBet = opponentPucks;
                        }
                        opponentPucks -= opponentBet;
                        if (opponentPucks < 0)
                        {
                            opponentBet += opponentPucks;
                            opponentPucks = 0;

                            string opponentName = ConvertToName(opponentNum);
                            string opponentName2 = ConvertToName(opponentNum2);
                            Console.WriteLine(Opponent(ref num) + " bet all in");
                            Thread.Sleep(1000);
                            Console.WriteLine(Opponent(ref num) + "'s cards are:");
                            Console.Write("The " + opponentName + " of " + opponentSuit);
                            Console.WriteLine(" and the " + opponentName2 + " of " + opponentSuit2);

                            Pot(opponentBet, ref pot);
                            UserPlay(ref userSuit, ref userSuit2, ref userNum, ref userNum2, 
                                ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                                ref userMove, ref count, ref num, ref pot, opponentBet, ref opponentPucks, ref userPucks, newCards, name);
                        }
                        else
                        {
                            Console.WriteLine(Opponent(ref num) + " bet " + opponentBet + " pucks");
                            Pot(opponentBet, ref pot);
                            UserPlay(ref userSuit, ref userSuit2, ref userNum, ref userNum2, 
                                ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                                ref userMove, ref count, ref num, ref pot, opponentBet, ref opponentPucks, ref userPucks, newCards, name);
                        }
                    }
                    else if ((suit == suit2 && suit == flopSuit) || (suit == suit2 && suit == flopSuit2) || (suit == suit2 && suit == flopSuit3))
                    {
                        int opponentBet = opponentPucks / 2;
                        if (opponentBet > userPucks)
                        {
                            opponentBet = opponentPucks;
                        }
                        opponentPucks -= opponentBet;
                        if (opponentPucks < 0)
                        {
                            opponentBet += opponentPucks;
                            opponentPucks = 0;

                            string opponentName = ConvertToName(opponentNum);
                            string opponentName2 = ConvertToName(opponentNum2);
                            Console.WriteLine(Opponent(ref num) + " bet all in");
                            Thread.Sleep(1000);
                            Console.WriteLine(Opponent(ref num) + "'s cards are:");
                            Console.Write("The " + opponentName + " of " + opponentSuit);
                            Console.WriteLine(" and the " + opponentName2 + " of " + opponentSuit2);

                            Pot(opponentBet, ref pot);
                            UserPlay(ref userSuit, ref userSuit2, ref userNum, ref userNum2, 
                                ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                                ref userMove, ref count, ref num, ref pot, opponentBet, ref opponentPucks, ref userPucks, newCards, name);
                        }
                        else
                        {
                            Console.WriteLine(Opponent(ref num) + " bet " + opponentBet + " pucks");
                            Pot(opponentBet, ref pot);
                            UserPlay(ref userSuit, ref userSuit2, ref userNum, ref userNum2, 
                                ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                                ref userMove, ref count, ref num, ref pot, opponentBet, ref opponentPucks, ref userPucks, newCards, name);
                        }
                    }
                    else
                    {
                        int opponentBet = opponentPucks / 10;
                        if (opponentBet > userPucks)
                        {
                            opponentBet = opponentPucks;
                        }
                        opponentPucks -= opponentBet;
                        if (opponentPucks < 0)
                        {
                            int minBet = opponentBet + opponentPucks;
                            opponentPucks += opponentBet;
                            opponentPucks -= minBet;

                            Console.WriteLine(Opponent(ref num) + " bet " + minBet + " pucks");
                            Pot(opponentBet, ref pot);
                            UserPlay(ref userSuit, ref userSuit2, ref userNum, ref userNum2, 
                                ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                                ref userMove, ref count, ref num, ref pot, opponentBet, ref opponentPucks, ref userPucks, newCards, name);
                        }
                        else
                        {
                            Console.WriteLine(Opponent(ref num) + " bet " + opponentBet + " pucks");
                            Pot(opponentBet, ref pot);
                            UserPlay(ref userSuit, ref userSuit2, ref userNum, ref userNum2, 
                                ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                                ref userMove, ref count, ref num, ref pot, opponentBet, ref opponentPucks, ref userPucks, newCards, name);
                        }
                    }
                }
            }
        }

        //The UserPlay Method allows user to choose their move
        static void UserPlay(ref string userSuit, ref string userSuit2, ref string userNum, ref string userNum2, 
            ref string flopNum, ref string flopSuit, ref string flopNum2, ref string flopSuit2, ref string flopNum3, ref string flopSuit3,
            ref string turnNum, ref string turnSuit, ref string riverNum, ref string riverSuit,
            ref string opponentSuit, ref string opponentNum, ref string opponentSuit2, ref string opponentNum2,
            ref string userMove, ref int count, ref int num, ref int pot, int opponentBet, ref int opponentPucks, ref int userPucks, string[] newCards, string name)
        {
            int userScore = 0;
            int opponentScore = 0;

            if (opponentPucks > 0)
            {
                Console.ResetColor();
                Console.WriteLine(name + ", you have three choices: Match, Raise, or Fold");
                Console.WriteLine("You have " + userPucks + " pucks (Poker Bucks)");

                while (true)
                {
                    if (count == 3)
                    {
                        if (userPucks == 0)
                        {
                            Console.WriteLine("You have already bet all in");

                            Console.ResetColor();
                            Winner(ref userSuit, ref userSuit2, ref userNum, ref userNum2,
                              ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                              ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                              ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                              ref pot, ref num, ref userPucks, ref opponentPucks, name);
                        }
                        else
                        {
                            userMove = Console.ReadLine().ToLower();

                            if (userMove == "match" || userMove == "m")
                            {
                                userPucks -= opponentBet;
                                Pot(opponentBet, ref pot);
                                if (userPucks == 0)
                                {
                                    Console.WriteLine("You went all in");
                                }

                                Console.ResetColor();
                                Winner(ref userSuit, ref userSuit2, ref userNum, ref userNum2,
                                  ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                  ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                  ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                                  ref pot, ref num, ref userPucks, ref opponentPucks, name);
                            }
                            if (userMove == "raise" || userMove == "r")
                            {
                                while (true)
                                {
                                    Console.WriteLine();
                                    Thread.Sleep(1000);
                                    Console.WriteLine("How much would you like to raise? (please enter an integer value)");

                                    int raise = Convert.ToInt32(Console.ReadLine());
                                    if (raise <= opponentBet)
                                    {
                                        Console.WriteLine("Please enter a puck value greater than the opponent's");
                                    }
                                    else if (raise > userPucks)
                                    {
                                        Console.WriteLine("Please enter a puck value that you have (you have " + userPucks + " pucks)");
                                    }
                                    else if (raise > opponentPucks)
                                    {
                                        Console.WriteLine("The opponent only has " + opponentPucks + " pucks to bet");
                                    }
                                    else
                                    {
                                        userPucks -= raise;
                                        Pot(raise, ref pot);
                                        if (userPucks == 0)
                                        {
                                            Console.ResetColor();
                                            Console.WriteLine("You bet all in");
                                            Thread.Sleep(1000);
                                            Console.WriteLine("Opponent bet all in as well");
                                            opponentPucks -= raise;
                                            Pot(raise, ref pot);
                                            Thread.Sleep(1000);

                                            string opponentName = ConvertToName(opponentNum);
                                            string opponentName2 = ConvertToName(opponentNum2);
                                            Console.WriteLine("Opponent's cards are:");
                                            Console.Write("The " + opponentName + " of " + opponentSuit);
                                            Console.WriteLine(" and the " + opponentName2 + " of " + opponentSuit2);
                                        }
                                        if (count == 3)
                                        {
                                            Console.ResetColor();
                                            Winner(ref userSuit, ref userSuit2, ref userNum, ref userNum2,
                                              ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                              ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                              ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                                              ref pot, ref num, ref userPucks, ref opponentPucks, name);
                                        }
                                        else
                                        {
                                            Console.ResetColor();
                                            Winner(ref userSuit, ref userSuit2, ref userNum, ref userNum2,
                                              ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                              ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                              ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                                              ref pot, ref num, ref userPucks, ref opponentPucks, name);
                                        }
                                    }
                                }
                            }
                            if (userMove == "fold" || userMove == "f")
                            {
                                opponentPucks += pot;

                                ResetGame(ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2, ref userPucks, ref opponentPucks, userScore, opponentScore,
                                     ref pot, ref num, ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                     ref turnNum, ref turnSuit, ref riverNum, ref riverSuit, ref name);
                            }
                            else
                            {
                                Console.WriteLine("Please enter either 'match,' 'raise,' or 'fold'");
                            }
                        }
                    }
                    else
                    {
                        if (userPucks == 0)
                        {
                            Console.ResetColor();
                            Console.WriteLine("You already went all in");

                            OpponentNext(ref userSuit, ref userSuit2, ref userNum, ref userNum2,
                                ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                                ref count, ref num, ref userMove, ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                opponentBet, opponentBet, ref opponentPucks, ref userPucks, ref pot, newCards, name);
                        }
                        userMove = Console.ReadLine().ToLower();

                        if (userMove == "match" || userMove == "m")
                        {
                            userPucks -= opponentBet;
                            Pot(opponentBet, ref pot);

                            if (userPucks == 0)
                            {
                                Console.WriteLine("You went all in");
                            }

                            OpponentNext(ref userSuit, ref userSuit2, ref userNum, ref userNum2,
                                ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                                ref count, ref num, ref userMove, ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                opponentBet, opponentBet, ref opponentPucks, ref userPucks, ref pot, newCards, name);
                        }
                        else if (userMove == "raise" || userMove == "r")
                        {
                            while (true)
                            {
                                Console.WriteLine();
                                Thread.Sleep(1000);
                                Console.WriteLine("How much would you like to raise? (please enter an integer value)");

                                int raise = Convert.ToInt32(Console.ReadLine());
                                if (raise <= opponentBet)
                                {
                                    Console.WriteLine("Please enter a puck value greater than the opponent's");
                                }
                                else if (raise > userPucks)
                                {
                                    Console.WriteLine("Please enter a puck value that you have (you have " + userPucks + " pucks)");
                                }
                                else
                                {
                                    userPucks -= raise;
                                    Pot(raise, ref pot);
                                    if (userPucks == 0)
                                    {
                                        Console.WriteLine("You bet all in");
                                    }
                                    if (count == 3)
                                    {
                                        Console.ResetColor();
                                        Winner(ref userSuit, ref userSuit2, ref userNum, ref userNum2,
                                          ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                          ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                          ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                                          ref pot, ref num, ref userPucks, ref opponentPucks, name);
                                    }
                                    else
                                    {
                                        OpponentNext(ref userSuit, ref userSuit2, ref userNum, ref userNum2,
                                          ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                          ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                                          ref count, ref num, ref userMove, ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                          raise, opponentBet, ref opponentPucks, ref userPucks, ref pot, newCards, name);
                                    }
                                }
                            }
                        }
                        else if (userMove == "fold" || userMove == "f")
                        {
                            opponentPucks += pot;

                            ResetGame(ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2, ref userPucks, ref opponentPucks, userScore, opponentScore,
                                 ref pot, ref num, ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                 ref turnNum, ref turnSuit, ref riverNum, ref riverSuit, ref name);
                        }
                        else
                        {
                            Console.WriteLine("Please enter either 'match,' 'raise,' or 'fold'");
                        }
                    }
                }
            }
            else
            {
                while (true)
                {
                    if (userPucks > 0)
                    {
                        if (count == 2)
                        {
                            Console.WriteLine("Will you bet all in as well?");
                            string userInput = Console.ReadLine();

                            if (userInput == "y" || userInput == "yes")
                            {
                                int raise = userPucks;
                                userPucks -= raise;
                                Pot(raise, ref pot);

                                OpponentNext(ref userSuit, ref userSuit2, ref userNum, ref userNum2,
                                             ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                             ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                                             ref count, ref num, ref userMove, ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                             raise, opponentBet, ref opponentPucks, ref userPucks, ref pot, newCards, name);
                            }
                            else if (userInput == "n" || userInput == "no")
                            {
                                Console.WriteLine(name + ", you chose to fold.");

                                ResetGame(ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2, ref userPucks, ref opponentPucks, userScore, opponentScore,
                                     ref pot, ref num, ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                     ref turnNum, ref turnSuit, ref riverNum, ref riverSuit, ref name);
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid response");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Will you bet all in as well?");
                            string userInput = Console.ReadLine();

                            if (userInput == "y" || userInput == "yes")
                            {
                                int raise = userPucks;
                                userPucks -= raise;
                                Pot(raise, ref pot);

                                Console.ResetColor();
                                Winner(ref userSuit, ref userSuit2, ref userNum, ref userNum2,
                                  ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                  ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                  ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                                  ref pot, ref num, ref userPucks, ref opponentPucks, name);
                            }
                            else if (userInput == "n" || userInput == "no")
                            {
                                Console.WriteLine("You chose to fold.");

                                ResetGame(ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2, ref userPucks, ref opponentPucks, userScore, opponentScore,
                                     ref pot, ref num, ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                     ref turnNum, ref turnSuit, ref riverNum, ref riverSuit, ref name);
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid response");
                            }
                        }
                    }
                    else
                    {
                        Console.ResetColor();
                        if (count == 2)
                        {
                            int raise = 0;

                            Console.WriteLine("You already bet all in");
                            OpponentNext(ref userSuit, ref userSuit2, ref userNum, ref userNum2,
                                ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                                ref count, ref num, ref userMove, ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                raise, opponentBet, ref opponentPucks, ref userPucks, ref pot, newCards, name);
                        }
                        else
                        {
                            Console.WriteLine("You already bet all in");
                            Console.ResetColor();
                            Winner(ref userSuit, ref userSuit2, ref userNum, ref userNum2,
                                  ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                  ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                  ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                                  ref pot, ref num, ref userPucks, ref opponentPucks, name);
                        }
                    }
                }
            }
            
        }

        //The OpponentNext Method allows Opponent to bet more for the next two rounds based on their cards
        static void OpponentNext(ref string userSuit, ref string userSuit2, ref string userNum, ref string userNum2, 
            ref string flopNum, ref string flopSuit, ref string flopNum2, ref string flopSuit2, ref string flopNum3, ref string flopSuit3,
            ref string opponentSuit, ref string opponentNum, ref string opponentSuit2, ref string opponentNum2,
            ref int count, ref int num, ref string userMove, ref string turnNum, ref string turnSuit, ref string riverNum, ref string riverSuit, 
            int userBet, int oldBet, ref int opponentPucks, ref int userPucks, ref int pot, string[] newCards, string name)
        {
            if (num == 1)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            else if (num == 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (num == 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }

            string suit = "";
            string number = "";
            int opponentBet = 0;

            int integerFlop = Convert.ToInt32(flopNum);
            int integerFlop2 = Convert.ToInt32(flopNum2);
            int integerFlop3 = Convert.ToInt32(flopNum3);
            int integerOpponent = Convert.ToInt32(opponentNum);
            int integerOpponent2 = Convert.ToInt32(opponentNum2);

            if (userMove == "raise" || userMove == "r")
            {
                opponentBet = userBet - oldBet;
                opponentPucks -= opponentBet;

                if (opponentPucks > 0)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(Opponent(ref num) + " matches");
                    Pot(opponentBet, ref pot);
                }
                else
                {
                    if (userMove.Contains("flag") == false)
                    {
                        opponentBet += opponentPucks;
                        opponentPucks = 0;
                        Thread.Sleep(1000);

                        string opponentName = ConvertToName(opponentNum);
                        string opponentName2 = ConvertToName(opponentNum2);
                        Console.WriteLine(Opponent(ref num) + " bet all in");
                        Thread.Sleep(1000);
                        Console.WriteLine(Opponent(ref num) + "'s cards are:");
                        Console.Write("The " + opponentName + " of " + opponentSuit);
                        Console.WriteLine(" and the " + opponentName2 + " of " + opponentSuit2);

                        Pot(opponentBet, ref pot);
                        userMove = userMove.Insert(0, "flag "); //This flag is added so that the line is not repeated again later
                    }
                }
            }

            if (count == 1) //count is used to count the number of rounds after the Flop since they are different. 1 means that it is the Turn and 2 means that it is the River.
            {
                string userName = ConvertToName(userNum);
                string userName2 = ConvertToName(userNum2);
                Console.ResetColor();
                Console.WriteLine();
                Thread.Sleep(1000);
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Remember your cards are: the " + userName + " of " + userSuit + " and the " + userName2 + " of " + userSuit2);
                Console.WriteLine();
                Console.ResetColor();
                Console.WriteLine();
                Thread.Sleep(1000);
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("This is the Turn:");
                Thread.Sleep(1000);

                newCards = UsedCard(ref suit, ref number, newCards);
                string cardName = ConvertToName(number);
                turnNum = number;
                turnSuit = suit;
                Console.Write("The " + cardName + " of " + suit);
                Console.ResetColor();
                Console.WriteLine();

                if (num == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                else if (num == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (num == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }

                if (opponentPucks < 0)
                {
                    opponentBet += opponentPucks;
                    opponentPucks = 0;

                    string opponentName = ConvertToName(opponentNum);
                    string opponentName2 = ConvertToName(opponentNum2);
                    Console.WriteLine(Opponent(ref num) + " bet all in");
                    Thread.Sleep(1000);
                    Console.WriteLine(Opponent(ref num) + "'s cards are:");
                    Console.Write("The " + opponentName + " of " + opponentSuit);
                    Console.WriteLine(" and the " + opponentName2 + " of " + opponentSuit2);

                    Pot(opponentBet, ref pot);
                    count++;
                    UserPlay(ref userSuit, ref userSuit2, ref userNum, ref userNum2,
                        ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                        ref turnNum, ref turnSuit, ref riverNum, ref riverSuit, 
                        ref opponentSuit,ref opponentNum, ref opponentSuit2, ref opponentNum2,
                        ref userMove, ref count, ref num, ref pot, opponentBet, ref opponentPucks, ref userPucks, newCards, name);
                }
                else if (opponentPucks > 0)
                {
                    if (integerFlop == integerOpponent || integerFlop2 == integerOpponent || integerFlop3 == integerOpponent || integerFlop == integerOpponent2 || integerFlop2 == integerOpponent2 || integerFlop3 == integerOpponent2)
                    {
                        opponentBet = (opponentPucks / 5) + 5;
                        if (opponentBet > userPucks)
                        {
                            opponentBet = opponentPucks;
                        }
                        opponentPucks -= opponentBet;
                        if (opponentPucks <= 0)
                        {
                            opponentBet += opponentPucks;
                            opponentPucks = 0;

                            string opponentName = ConvertToName(opponentNum);
                            string opponentName2 = ConvertToName(opponentNum2);
                            Console.WriteLine(Opponent(ref num) + " bet all in");
                            Thread.Sleep(1000);
                            Console.WriteLine(Opponent(ref num) + "'s cards are:");
                            Console.Write("The " + opponentName + " of " + opponentSuit);
                            Console.WriteLine(" and the " + opponentName2 + " of " + opponentSuit2);

                            Pot(opponentBet, ref pot);
                            count++;
                            UserPlay(ref userSuit, ref userSuit2, ref userNum, ref userNum2,
                                ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                                ref userMove, ref count, ref num, ref pot, opponentBet, ref opponentPucks, ref userPucks, newCards, name);
                        }
                        else
                        {
                            Console.WriteLine(Opponent(ref num) + " bet " + opponentBet + " pucks");
                            Pot(opponentBet, ref pot);
                            count++;
                            UserPlay(ref userSuit, ref userSuit2, ref userNum, ref userNum2,
                                ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                ref opponentSuit, ref opponentNum, ref opponentSuit2,ref opponentNum2,
                                ref userMove, ref count, ref num, ref pot, opponentBet, ref opponentPucks, ref userPucks, newCards, name);
                        }
                    }
                    else if (opponentSuit == opponentSuit2 && opponentSuit == flopSuit || (opponentSuit == opponentSuit2 && opponentSuit == flopSuit2) || (opponentSuit == opponentSuit2 && opponentSuit == flopSuit))
                    {
                        opponentBet = (opponentPucks / 15) + 5;
                        if (opponentBet > userPucks)
                        {
                            opponentBet = opponentPucks;
                        }
                        opponentPucks -= opponentBet;
                        if (opponentPucks <= 0)
                        {
                            opponentBet += opponentPucks;
                            opponentPucks = 0;

                            string opponentName = ConvertToName(opponentNum);
                            string opponentName2 = ConvertToName(opponentNum2);
                            Console.WriteLine(Opponent(ref num) + " bet all in");
                            Thread.Sleep(1000);
                            Console.WriteLine(Opponent(ref num) + "'s cards are:");
                            Console.Write("The " + opponentName + " of " + opponentSuit);
                            Console.WriteLine(" and the " + opponentName2 + " of " + opponentSuit2);

                            Pot(opponentBet, ref pot);
                            count++;
                            UserPlay(ref userSuit, ref userSuit2, ref userNum, ref userNum2,
                                ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                                ref userMove, ref count, ref num, ref pot, opponentBet, ref opponentPucks, ref userPucks, newCards, name);
                        }
                        else
                        {
                            Console.WriteLine(Opponent(ref num) + " bet " + opponentBet + " pucks");
                            Pot(opponentBet, ref pot);
                            count++;
                            UserPlay(ref userSuit, ref userSuit2, ref userNum, ref userNum2,
                                ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                                ref userMove, ref count, ref num, ref pot, opponentBet, ref opponentPucks, ref userPucks, newCards, name);
                        }
                    }
                    else
                    {
                        opponentBet = (opponentPucks / 10) + 5;
                        if (opponentBet > userPucks)
                        {
                            opponentBet = opponentPucks;
                        }
                        opponentPucks -= opponentBet;
                        if (opponentPucks <= 0)
                        {
                            opponentBet += opponentPucks;
                            opponentPucks = 0;

                            string opponentName = ConvertToName(opponentNum);
                            string opponentName2 = ConvertToName(opponentNum2);
                            Console.WriteLine(Opponent(ref num) + " bet all in");
                            Thread.Sleep(1000);
                            Console.WriteLine(Opponent(ref num) + "'s cards are:");
                            Console.Write("The " + opponentName + " of " + opponentSuit);
                            Console.WriteLine(" and the " + opponentName2 + " of " + opponentSuit2);

                            Pot(opponentBet, ref pot);
                            count++;
                            UserPlay(ref userSuit, ref userSuit2, ref userNum, ref userNum2,
                                ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                                ref userMove, ref count, ref num, ref pot, opponentBet, ref opponentPucks, ref userPucks, newCards, name);
                        }
                        else
                        {
                            Console.WriteLine(Opponent(ref num) + " bet " + opponentBet + " pucks");
                            Pot(opponentBet, ref pot);
                            count++;
                            UserPlay(ref userSuit, ref userSuit2, ref userNum, ref userNum2,
                                ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                                ref userMove, ref count, ref num, ref pot, opponentBet, ref opponentPucks, ref userPucks, newCards, name);
                        }
                    }
                }
                else
                {
                    Console.WriteLine(Opponent(ref num) + " has already bet all in");
                    count++;
                    UserPlay(ref userSuit, ref userSuit2, ref userNum, ref userNum2, 
                        ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                        ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                        ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                        ref userMove, ref count, ref num, ref pot, opponentBet, ref opponentPucks, ref userPucks, newCards, name);
                }
            }
            else if (count == 2)
            {
                string userName = ConvertToName(userNum);
                string userName2 = ConvertToName(userNum2);
                Console.ResetColor();
                Console.WriteLine();
                Thread.Sleep(1000);
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Remember your cards are: the " + userName + " of " + userSuit + " and the " + userName2 + " of " + userSuit2);
                Console.WriteLine();
                Console.ResetColor();
                Console.WriteLine();
                Thread.Sleep(1000);
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("This is the River:");
                Thread.Sleep(1000);

                newCards = UsedCard(ref suit, ref number, newCards);
                string cardName = ConvertToName(number);
                riverNum = number;
                riverSuit = suit;
                Console.Write("The " + cardName + " of " + suit);
                Console.ResetColor();
                Console.WriteLine();

                if (num == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                else if (num == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (num == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }

                if (opponentPucks < 0)
                {
                    opponentBet += opponentPucks;
                    opponentPucks = 0;

                    string opponentName = ConvertToName(opponentNum);
                    string opponentName2 = ConvertToName(opponentNum2);
                    Console.WriteLine(Opponent(ref num) + " bet all in");
                    Thread.Sleep(1000);
                    Console.WriteLine(Opponent(ref num) + "'s cards are:");
                    Console.Write("The " + opponentName + " of " + opponentSuit);
                    Console.WriteLine(" and the " + opponentName2 + " of " + opponentSuit2);

                    Pot(opponentBet, ref pot);
                    count++;
                    UserPlay(ref userSuit, ref userSuit2, ref userNum, ref userNum2,
                        ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                        ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                        ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                        ref userMove, ref count, ref num, ref pot, opponentBet, ref opponentPucks, ref userPucks, newCards, name);
                }
                else if (opponentPucks > 0)
                {
                    if ((opponentSuit == turnSuit && opponentSuit2 == turnSuit) || (opponentSuit == riverSuit && opponentSuit2 == riverSuit))
                    {
                        opponentBet = (opponentPucks / 4) + 5;
                        if (opponentBet > userPucks)
                        {
                            opponentBet = opponentPucks;
                        }
                        opponentPucks -= opponentBet;
                        if (opponentPucks <= 0)
                        {
                            opponentBet += opponentPucks;
                            opponentPucks = 0;

                            string opponentName = ConvertToName(opponentNum);
                            string opponentName2 = ConvertToName(opponentNum2);
                            Console.WriteLine(Opponent(ref num) + " bet all in");
                            Thread.Sleep(1000);
                            Console.WriteLine(Opponent(ref num) + "'s cards are:");
                            Console.Write("The " + opponentName + " of " + opponentSuit);
                            Console.WriteLine(" and the " + opponentName2 + " of " + opponentSuit2);

                            Pot(opponentBet, ref pot);
                            count++;
                            UserPlay(ref userSuit, ref userSuit2, ref userNum, ref userNum2,
                                ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                                ref userMove, ref count, ref num, ref pot, opponentBet, ref opponentPucks, ref userPucks, newCards, name);
                        }
                        else
                        {
                            Console.WriteLine(Opponent(ref num) + " bet " + opponentBet + " pucks");
                            Pot(opponentBet, ref pot);
                            count++;
                            UserPlay(ref userSuit, ref userSuit2, ref userNum, ref userNum2,
                                ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                                ref userMove, ref count, ref num, ref pot, opponentBet, ref opponentPucks, ref userPucks, newCards, name);
                        }
                    }
                    else
                    {
                        opponentBet = (opponentPucks / 10) + 5;
                        if (opponentBet > userPucks)
                        {
                            opponentBet = opponentPucks;
                        }
                        opponentPucks -= opponentBet;
                        if (opponentPucks <= 0)
                        {
                            opponentBet += opponentPucks;
                            opponentPucks = 0;

                            string opponentName = ConvertToName(opponentNum);
                            string opponentName2 = ConvertToName(opponentNum2);
                            Console.WriteLine(Opponent(ref num) + " bet all in");
                            Thread.Sleep(1000);
                            Console.WriteLine(Opponent(ref num) + "'s cards are:");
                            Console.Write("The " + opponentName + " of " + opponentSuit);
                            Console.WriteLine(" and the " + opponentName2 + " of " + opponentSuit2);

                            Pot(opponentBet, ref pot);
                            count++;
                            UserPlay(ref userSuit, ref userSuit2, ref userNum, ref userNum2,
                                ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                                ref userMove, ref count, ref num, ref pot, opponentBet, ref opponentPucks, ref userPucks, newCards, name);
                        }
                        else
                        {
                            Console.WriteLine(Opponent(ref num) + " bet " + opponentBet + " pucks");
                            Pot(opponentBet, ref pot);
                            count++;
                            UserPlay(ref userSuit, ref userSuit2, ref userNum, ref userNum2,
                                ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                                ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                                ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                                ref userMove, ref count, ref num, ref pot, opponentBet, ref opponentPucks, ref userPucks, newCards, name);
                        }
                    }
                }
                else
                {
                    Console.WriteLine(Opponent(ref num) + " has already bet all in");
                    count++;
                    UserPlay(ref userSuit, ref userSuit2, ref userNum, ref userNum2,
                        ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                        ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                        ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2,
                        ref userMove, ref count, ref num, ref pot, opponentBet, ref opponentPucks, ref userPucks, newCards, name);
                }
            }
        }

        //The Winner Method chooses who is the winner based on their cards and the cards on the table
        static void Winner(ref string userSuit, ref string userSuit2, ref string userNum, ref string userNum2,
            ref string flopNum, ref string flopSuit, ref string flopNum2, ref string flopSuit2, ref string flopNum3, ref string flopSuit3,
            ref string turnNum, ref string turnSuit, ref string riverNum, ref string riverSuit,
            ref string opponentSuit, ref string opponentNum, ref string opponentSuit2, ref string opponentNum2,
            ref int pot, ref int num, ref int userPucks, ref int opponentPucks, string name)
        {
            //The ranking is: -1 = High Card, 0 = Royal Flush, 1 = 4 of a Kind, 2 = Full House, 3 = Flush, 4 = 3 of a Kind, 5 = 2 Pair, 6 = Pair.
            string userHand = "";
            string opponentHand = "";
            int opponentCheck = -1;
            int userCheck = -1;

            int userScore = 0;
            int opponentScore = 0;

            int userOnePair = 26; //the hand values are seperated by 26 so that if both players get a pair or the same high card, it looks at the two cards' value (2-14)
            int userTwoPair = 53;
            int userThreeKind = 80;
            int userFlush = 107;
            int userFullHouse = 134;
            int userFourKind = 161;
            int userRoyals = 188;

            int opponentOnePair = 26;
            int opponentTwoPair = 53;
            int opponentThreeKind = 80;
            int opponentFlush = 107;
            int opponentFullHouse = 134;
            int opponentFourKind = 161;
            int opponentRoyals = 188;

            bool usertwo = false; //These booleans were created to acknowledge multiple pairs or 3 of a kinds made by the first and second card
            bool userthree = false;
            bool opponenttwo = false;
            bool opponentthree = false;

            bool keepGoing = true;

            int userInteger = Convert.ToInt32(userNum);
            int userInteger2 = Convert.ToInt32(userNum2);
            int opponentInteger = Convert.ToInt32(opponentNum);
            int opponentInteger2 = Convert.ToInt32(opponentNum2);

            int flopInteger = Convert.ToInt32(flopNum);
            int flopInteger2 = Convert.ToInt32(flopNum2);
            int flopInteger3 = Convert.ToInt32(flopNum3);
            int turnInteger = Convert.ToInt32(turnNum);
            int riverInteger = Convert.ToInt32(riverNum);

            if (opponentPucks > 0)
            {
                string opponentName = ConvertToName(opponentNum);
                string opponentName2 = ConvertToName(opponentNum2);
                Console.WriteLine(Opponent(ref num) + "'s cards are:");
                Console.Write("The " + opponentName + " of " + opponentSuit);
                Console.WriteLine(" and the " + opponentName2 + " of " + opponentSuit2);
            }

            //flush
            if (userSuit == userSuit2)
            {
                int count = 0;
                string isFlush = flopSuit + " " + flopSuit2 + " " + flopSuit3 + " " + turnSuit + " " + riverSuit + " ";
                int length = userSuit.Length;

                if (isFlush.Contains(userSuit))
                {
                    while (keepGoing)
                    {
                        int index1 = isFlush.IndexOf(userSuit, 0);

                        if (count == 3)
                        {
                            userScore += userFlush;

                            int royalsNum = userInteger + userInteger2 + flopInteger + flopInteger2 + flopInteger3 + turnInteger + riverInteger;

                            if (royalsNum >= 59)
                            {
                                userScore += userRoyals;
                                userCheck = 0;
                                userHand = "Royal Flush!";
                            }
                            if (userCheck == -1)
                            {
                                userScore += userInteger;
                                userScore += userInteger2;
                                userHand = "Flush.";
                                userCheck = 3;
                            }
                            keepGoing = false;
                        }
                        else if (isFlush.Contains(userSuit))
                        {
                            count++;
                            isFlush = isFlush.Remove(index1, length);
                        }
                        else
                        {
                            keepGoing = false;
                        }
                    }
                }
            }
            if (opponentSuit == opponentSuit2)
            {
                int count = 0;
                string isFlush = flopSuit + " " + flopSuit2 + " " + flopSuit3 + " " + turnSuit + " " + riverSuit + " ";
                int length = opponentSuit.Length;

                if (isFlush.Contains(opponentSuit))
                {
                    while (keepGoing)
                    {
                        int index1 = isFlush.IndexOf(opponentSuit, 0);

                        if (count == 3)
                        {
                            userScore += opponentFlush;

                            int royalsNum = opponentInteger + opponentInteger2 + flopInteger + flopInteger2 + flopInteger3 + turnInteger + riverInteger;
                            if (royalsNum >= 59)
                            {
                                userScore += opponentRoyals;
                                opponentCheck = 0;
                                opponentHand = "Royal Flush!";
                            }
                            if (opponentCheck == -1)
                            {
                                opponentScore += opponentInteger;
                                opponentScore += opponentInteger2;
                                opponentHand = "Flush.";
                                opponentCheck = 3;
                            }
                            keepGoing = false;
                        }
                        else if (isFlush.Contains(opponentSuit))
                        {
                            count++;
                            isFlush = isFlush.Remove(index1, length);
                        }
                        else
                        {
                            keepGoing = false;
                        }
                    }
                }
            }

            //pair, three of a kind, four of a kind, or full house
            if (userInteger == userInteger2 || userInteger == flopInteger || userInteger == flopInteger2 || userInteger == flopInteger3 || userInteger == turnInteger || userInteger == riverInteger)
            {
                string isMorePair = " " + userNum2 + " " + flopNum + " " + flopNum2 + " " + flopNum3 + " " + turnNum + " " + riverNum + " ";
                int count = 0;
                int length = isMorePair.Length;

                userScore += userInteger;

                for (int i = 0; i < (length - 2); i++) //This loop counts the number of duplicate cards of the first card there are on the table and in the player's hand.
                {
                    string substring = isMorePair.Substring(i, 1);
                    if (substring == " ")
                    {
                        string pairCheck = isMorePair.Substring(i, 3);
                        if (pairCheck.Trim() == userNum.Trim())
                        {
                            count++;
                        }
                    }
                }
                if (count == 2)
                {
                    if (userCheck == -1 || userCheck >= 5)
                    {
                        userScore += userThreeKind;
                        userScore += userInteger;
                        userScore += userInteger2;
                        userHand = "Three of a Kind.";
                        userCheck = 4;
                    }
                    userthree = true;
                }
                else if (count == 3)
                {
                    if (userCheck != 0)
                    {
                        userScore += userFourKind;
                        userScore += userInteger;
                        userScore += userInteger2;
                        userHand = "Four of a Kind.";
                        userCheck = 1;
                    }
                }
                else
                {
                    if (userCheck == -1)
                    {
                        userScore += userOnePair;
                        userScore += userInteger;
                        userScore += userInteger2;
                        userHand = "Pair.";
                        userCheck = 6;
                        usertwo = true;
                    }
                }
            }
            if (userInteger != userInteger2 && userInteger2 == flopInteger || userInteger2 == flopInteger2 || userInteger2 == flopInteger3 || userInteger2 == turnInteger || userInteger2 == riverInteger)
            {
                string isMorePair = " " + flopNum + " " + flopNum2 + " " + flopNum3 + " " + turnNum + " " + riverNum + " ";
                int count = 0;
                int length = isMorePair.Length;

                userScore += userInteger2;

                for (int i = 0; i < (length - 2); i++) //This loop counts the number of duplicate cards of the second card there are on the table
                {
                    string substring = isMorePair.Substring(i, 1);
                    if (substring == " ")
                    {
                        string pairCheck = isMorePair.Substring(i, 3);
                        if (pairCheck.Trim() == userNum2.Trim())
                        {
                            count++;
                        }
                    }
                }
                if (count == 2)
                {
                    if (usertwo == true)
                    {
                        userScore -= userOnePair;
                        if (userCheck >= 3)
                        {
                            userScore += userFullHouse;

                            userHand = "Full House.";
                            userCheck = 2;
                        }
                    }
                    else
                    {
                        if (userCheck == -1 || userCheck >= 5)
                        {
                            userScore += userThreeKind;

                            userHand = "Three of a Kind.";
                            userCheck = 4;
                        }
                    }
                }
                else
                {
                    if (usertwo == true)
                    {
                        if (userCheck >= 6)
                        {
                            userScore -= userOnePair;
                            userScore += userTwoPair;

                            userHand = "Two Pair.";
                            userCheck = 5;
                        }
                    }
                    else if (userthree == true)
                    {
                        if (userCheck >= 3)
                        {
                            userScore -= userThreeKind;
                            userScore += userFullHouse;

                            userHand = "Full House.";
                            userCheck = 2;
                        }
                    }
                    else
                    {
                        if (userCheck == -1)
                        {
                            userScore += userOnePair;

                            userHand = "Pair.";
                            userCheck = 6;
                        }
                    }
                }
            }

            if (opponentInteger == opponentInteger2 || opponentInteger == flopInteger || opponentInteger == flopInteger2 || opponentInteger == flopInteger3 || opponentInteger == turnInteger || opponentInteger == riverInteger)
            {
                string isMorePair = " " + opponentNum2 + " " + flopNum + " " + flopNum2 + " " + flopNum3 + " " + turnNum + " " + riverNum + " ";
                int count = 0;
                int length = isMorePair.Length;

                opponentScore += opponentInteger;

                for (int i = 0; i < (length - 2); i++)
                {
                    string substring = isMorePair.Substring(i, 1);
                    if (substring == " ")
                    {
                        string pairCheck = isMorePair.Substring(i, 3);
                        if (pairCheck.Trim() == opponentNum.Trim())
                        {
                            count++;
                        }
                    }
                }
                if (count == 2)
                {
                    if (opponenttwo == true)
                    {
                        if (opponentCheck >= 3)
                        {
                            opponentScore -= opponentOnePair;
                            opponentScore += opponentFullHouse;

                            opponentScore += opponentInteger;
                            opponentScore += opponentInteger2;
                            opponentHand = "Full House.";
                            opponentCheck = 2;
                        }
                    }
                    else
                    {
                        if (opponentCheck == -1 || opponentCheck >= 5)
                        {
                            opponentScore += opponentThreeKind;

                            opponentScore += opponentInteger;
                            opponentScore += opponentInteger2;
                            opponentHand = "Three of a Kind.";
                            opponentCheck = 4;
                        }
                    }
                }
                else if (count == 3)
                {
                    if (opponentCheck != 0)
                    {
                        opponentScore += opponentFourKind;

                        opponentScore += opponentInteger;
                        opponentScore += opponentInteger2;
                        opponentHand = "Four of a Kind.";
                        opponentCheck = 1;
                    }
                }
                else
                {
                    if (opponentCheck == -1)
                    {
                        opponentScore += opponentOnePair;

                        opponentScore += opponentInteger;
                        opponentScore += opponentInteger2;
                        opponentHand = "Pair.";
                        opponentCheck = 6;
                        opponenttwo = true;
                    }
                }
            }
            if (opponentInteger != opponentInteger2 && opponentInteger2 == flopInteger || opponentInteger2 == flopInteger2 || opponentInteger2 == flopInteger3 || opponentInteger2 == turnInteger || opponentInteger2 == riverInteger)
            {
                string isMorePair = " " + flopNum + " " + flopNum2 + " " + flopNum3 + " " + turnNum + " " + riverNum + " ";
                int count = 0;
                int length = isMorePair.Length;

                opponentScore += opponentInteger2;

                for (int i = 0; i < (length - 2); i++)
                {
                    string substring = isMorePair.Substring(i, 1);
                    if (substring == " ")
                    {
                        string pairCheck = isMorePair.Substring(i, 3);
                        if (pairCheck.Trim() == opponentNum2.Trim())
                        {
                            count++;
                        }
                    }
                }
                if (count == 2)
                {
                    if (opponenttwo == true)
                    {
                        if (opponentCheck >= 3)
                        {
                            opponentScore -= opponentOnePair;
                            opponentScore += opponentFullHouse;

                            opponentHand = "Full House.";
                            opponentCheck = 2;
                        }
                    }
                    else
                    {
                        if (opponentCheck == -1 || opponentCheck >= 5)
                        {
                            opponentScore += opponentThreeKind;

                            opponentHand = "Three of a Kind.";
                            opponentCheck = 4;
                        }
                    }
                }
                else
                {
                    if (opponenttwo == true)
                    {
                        if (opponentCheck >= 6)
                        {
                            opponentScore -= opponentOnePair;
                            opponentScore += opponentTwoPair;

                            opponentHand = "Two Pair.";
                            opponentCheck = 5;
                        }
                    }
                    else if (opponentthree == true)
                    {
                        if (opponentCheck >= 3)
                        {
                            opponentScore -= opponentThreeKind;
                            opponentScore += opponentFullHouse;

                            opponentHand = "Full House.";
                            opponentCheck = 2;
                        }
                    }
                    else
                    {
                        if (opponentCheck == -1)
                        {
                            opponentScore += opponentOnePair;

                            opponentHand = "Pair.";
                            opponentCheck = 6;
                        }
                    }
                }
            }

            //final tally for higher card
            if (userCheck == -1)
            {
                userScore += userInteger;
                userScore += userInteger2;
                userHand = "Higher Card.";
            }
            if (opponentCheck == -1)
            {
                opponentScore += opponentInteger;
                opponentScore += opponentInteger2;
                opponentHand = "Higher Card.";
            }

            //winner is decided by comparing scores.
            if (userScore > opponentScore)
            {
                if (opponentPucks == 0)
                {
                    Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    Console.WriteLine("|       |                      |         |             |");
                    Console.WriteLine("|       |                      |         |             |");
                    Console.WriteLine(" -_____-                       |         |  o          |");
                    Console.WriteLine("    |     ____                 |    |    |     |____   |");
                    Console.WriteLine("    |    |    |  |    |        |   | |   |  |  |    |");
                    Console.WriteLine("    |    |____|  |____|         |_|   |_|   |  |    |  o");
                    Console.ResetColor();
                    EndGame(ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2, ref userPucks, ref opponentPucks,
                        ref num, ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                        ref turnNum, ref turnSuit, ref riverNum, ref riverSuit, ref name);
                }
                else
                {
                    Thread.Sleep(1000);
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("You won " + pot + " pucks with a " + userHand);
                    Console.ResetColor();
                    ResetGame(ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2, ref userPucks, ref opponentPucks, userScore, opponentScore,
                         ref pot, ref num, ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                         ref turnNum, ref turnSuit, ref riverNum, ref riverSuit, ref name);
                }
            }
            else if (opponentScore > userScore)
            {
                if (userPucks == 0)
                {
                    Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("|       |                      |                            |");
                    Console.WriteLine("|       |                      |                            |");
                    Console.WriteLine(" -_____-                       |                            |");
                    Console.WriteLine("    |     ____                 |        ____    ___   ___   |");
                    Console.WriteLine("    |    |    |  |    |        |       |    |  |___  |___|");
                    Console.WriteLine("    |    |____|  |____|        |_____  |____|  ____| |___   o");
                    Console.ResetColor();
                    EndGame(ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2, ref userPucks, ref opponentPucks,
                        ref num, ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                        ref turnNum, ref turnSuit, ref riverNum, ref riverSuit, ref name);
                }
                else
                {
                    Thread.Sleep(1000);
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("You lose. " + Opponent(ref num) + " won " + pot + " pucks with a " + opponentHand);
                    Console.ResetColor();

                    ResetGame(ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2, ref userPucks, ref opponentPucks, userScore, opponentScore, 
                         ref pot, ref num, ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                         ref turnNum, ref turnSuit, ref riverNum, ref riverSuit, ref name);
                }
            }
            else
            {
                if (userPucks == 0)
                {
                    Thread.Sleep(1000); 
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("                           _________");
                    Console.WriteLine("|       |                      |                    |");
                    Console.WriteLine("|       |                      |                    |");
                    Console.WriteLine(" -_____-                       |       o            |");
                    Console.WriteLine("    |     ____                 |             ___    |");
                    Console.WriteLine("    |    |    |  |    |        |       |    |___|");
                    Console.WriteLine("    |    |____|  |____|        |       |    |___    o");
                    Console.ResetColor();
                    EndGame(ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2, ref userPucks, ref opponentPucks,
                        ref num, ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                        ref turnNum, ref turnSuit, ref riverNum, ref riverSuit, ref name);
                }
                else
                {
                    Thread.Sleep(1000);
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("You tied. You both get your original money back.");
                    Console.ResetColor();
                    EndGame(ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2, ref userPucks, ref opponentPucks,
                        ref num, ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                        ref turnNum, ref turnSuit, ref riverNum, ref riverSuit, ref name);
                }   
            }
        }

        //The ResetGame Method allows the player to continue the game if they fold or end a round. The player can also quit the game at this point
        static void ResetGame(ref string opponentSuit, ref string opponentNum, ref string opponentSuit2, ref string opponentNum2, ref int userPucks, ref int opponentPucks, int userScore, int opponentScore, 
                        ref int pot, ref int num, ref string flopNum, ref string flopSuit, ref string flopNum2, ref string flopSuit2, ref string flopNum3, ref string flopSuit3,
                        ref string turnNum, ref string turnSuit, ref string riverNum, ref string riverSuit, ref string name)
        {
            while (true)
            {
                Console.WriteLine("Would you like to continue?");
                string continueGame = Console.ReadLine().ToLower();

                if (continueGame == "yes" || continueGame == "y")
                {
                    if (opponentScore > userScore)
                    {
                        opponentPucks += pot;
                        Console.Clear();
                        OpponentPlay(ref num, ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                            ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                            ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2, ref opponentPucks, ref userPucks, name);
                    }
                    else if (userScore > opponentScore)
                    {
                        userPucks += pot;
                        Console.Clear();
                        OpponentPlay(ref num, ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                            ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                            ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2, ref opponentPucks, ref userPucks, name);
                    }
                    else
                    {
                        Console.Clear();
                        OpponentPlay(ref num, ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                            ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                            ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2, ref opponentPucks, ref userPucks, name);
                    }
                }
                else if (continueGame == "no" || continueGame == "n")
                {
                    Console.WriteLine("Alright, have a nice day, " + name + "!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Please enter a valid response");
                }
            }
        }

        //The EndGame Method allows the player to end the game once either they or the opponent wins the entire game (not just a round.) The player can choose to play again
        static void EndGame(ref string opponentSuit, ref string opponentNum, ref string opponentSuit2, ref string opponentNum2, ref int userPucks, ref int opponentPucks,
                        ref int num, ref string flopNum, ref string flopSuit, ref string flopNum2, ref string flopSuit2, ref string flopNum3, ref string flopSuit3,
                        ref string turnNum, ref string turnSuit, ref string riverNum, ref string riverSuit, ref string name)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Would you like to play again?");
                string continueGame = Console.ReadLine().ToLower();

                if (continueGame == "yes" || continueGame == "y")
                {
                    userPucks = 100;
                    opponentPucks = 100;
                    Console.Clear();
                    OpponentPlay(ref num, ref flopNum, ref flopSuit, ref flopNum2, ref flopSuit2, ref flopNum3, ref flopSuit3,
                        ref turnNum, ref turnSuit, ref riverNum, ref riverSuit,
                        ref opponentSuit, ref opponentNum, ref opponentSuit2, ref opponentNum2, ref opponentPucks, ref userPucks, name);
                }
                else if (continueGame == "no" || continueGame == "n")
                {
                    Console.WriteLine("Alright, have a nice day, " + name + "!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Please enter a valid response");
                }
            }
        }

        
        //These methods are never displayed

        //The UsedCard Method makes sure that there are no repeated cards
        static string[] UsedCard(ref string suit, ref string number, string[] cards)
        {
            while (true)
            {
                Random pick = new Random();
                int num = pick.Next(0, 52);
                
                if (cards [num] != "used")
                {
                    CardProperties(ref suit, ref number, cards [num]);
                    cards [num] = "used";
                    return cards;
                }
            }
        }

        //The CardProperties Method gets the properties of all of the cards by seperating them from string
        static void CardProperties(ref string suit, ref string number, string card)
        {
            int count = 0;

            int length = card.Length;

            for (int i = 0; i < length; i++)
            {
                string character = card.Substring(i, 1);
                if (character == " " && count == 0)
                {
                    suit = card.Substring(0, i).Trim();
                    number = card.Substring(i, 3).Trim();
                    count++;
                }
            }
        }

        //The ConvertToName method converts values higher than 10 to their card name
        static string ConvertToName(string number)
        {
            if (number == "11")
            {
                return "Jack";
            }
            else if (number == "12")
            {
                return "Queen";
            }
            else if (number == "13")
            {
                return "King";
            }
            else if (number == "14")
            {
                return "Ace";
            }
            else
            {
                return number;
            }
        }

        //The Pot Method stores the amount of pucks bet per round
        static void Pot(int bet, ref int pot)
        {
            pot += bet;

            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("There are " + pot + " pucks in the pot");
            Console.ResetColor();
            Console.WriteLine();
        }

    }
}
