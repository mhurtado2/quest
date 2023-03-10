using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            Robe TheRobe = new();
            TheRobe.Colors = new List<string>() {"red", "white", "blue"};
            TheRobe.LengthOfRobe = 69;

              Hat shinyHat = new();
            shinyHat.ShininessLevel = 6;

            Prize prize = new Prize("Gold Coin");

             Console.Write("What is your name: ");
            string Username= Console.ReadLine().Trim();
            Adventurer theAdventurer = new Adventurer(Username, TheRobe, shinyHat);

            void ChallengeGame (Adventurer theAdventurer)
            {

            Console.WriteLine(theAdventurer.GetDescription()); //get description is a method of the adventurer must call adventurer

            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                4, 20
            );
            Challenge threePlusTwo = new Challenge("3 + 2?", 5, 10);
            Challenge onePlusTwo = new Challenge("1 + 2?", 3, 10);

            //add here too
            //and here

            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            // Make a new "Adventurer" object using the "Adventurer" class
            // Console.Write("What is your name: ");
            // string Username= Console.ReadLine().Trim();
            // Adventurer theAdventurer = new Adventurer(Username);

            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                threePlusTwo,
                onePlusTwo
                //another challenge
                //another one
            };

            List<Challenge> selectChallenges = new List<Challenge>{};
            while(selectChallenges.Count < 6)
            {
                Random random = new Random();
                int randomChallenges = random.Next(0,6);
                if(!selectChallenges.Contains(challenges[randomChallenges]))
                {
                    selectChallenges.Add(challenges[randomChallenges]);
                }
            }

            // Loop through all the challenges and subject the Adventurer to them
            foreach (Challenge challenge in selectChallenges) //changed from challenges
            {
                challenge.RunChallenge(theAdventurer);
            }

            // This code examines how Awesome the Adventurer is after completing the challenges
            // And praises or humiliates them accordingly
            if (theAdventurer.Awesomeness >= maxAwesomeness)
            {
                Console.WriteLine("YOU DID IT! You are truly awesome!");
            }
            else if (theAdventurer.Awesomeness <= minAwesomeness)
            {
                Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
            }
            else
            {
                Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
            }

            }
            ChallengeGame(theAdventurer);

            while(true)
            {
            prize.ShowPrize(theAdventurer);
            Console.WriteLine($"do you wish to go again: {theAdventurer.Name} ");
            string repeatQuest = Console.ReadLine().ToLower().Trim();
            if (repeatQuest == "y"){
                ChallengeGame(theAdventurer);
             }
             else{
                    break;
             }
            }
            
        }
    }
}