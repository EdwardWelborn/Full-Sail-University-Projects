using System;
using System.Timers;


namespace animation
{
    class MainClass
    {

        //--------------------
        //Animated Bar Graph
        //--------------------
        //Think, the following examples:
        //...showing a loading proression bar
        //...showing the distance from the start to a goal
        //...showing amount of percentage downloaded


        //To animate the bar graph, we need to know the value of the graph, the size of the graph, the speed we want it to animate, and for how long we want to animate it.
        //To animate it in the console, we can just choose random numbers and draw the graph over and over again.
        //--------------------




        //Timer Variable
        //This creates the actual timer
        //Note this is outside of the Main()
        //Note that we added in "using System.Timers;" at the top
        private static System.Timers.Timer myAnimationTimer;

        //Timer Counter
        //This counter is used to stop the timer when we want it to
        //So, it helps to make the animation go longer/shorter, faster/slower
        //Note this is outside of the Main()
        static int myTimerCounter = 0;


        //Main()
        public static void Main()
        {
            //Create Timer
            SetTimer();

            //If you like, hide the cursor so it does not get in the way of the graph, but be careful...it's invisible so do not make the user do something where they need the curso after you make it invisible.
            Console.CursorVisible = false;

            //This is needed for the timer to work
            //The code needs to stop running, or wait for a response in order to play the animation
            Console.ReadLine();
        }



        //Set Timer Properties
        //Note this is outside of the Main()
        private static void SetTimer()
        {
            //Set time to happen really fast 1,000 = 1 second
            //Start the function every 50/1000 seconds
            myAnimationTimer = new System.Timers.Timer(50);

            //At 50/1000, run this method "OnTimedEvent"
            //Every time it elapses, do it
            myAnimationTimer.Elapsed += OnTimedEvent;

            //Reset timer again after 50/1000, over and over again
            //False means to only run the timer one time
            myAnimationTimer.AutoReset = true;

            //The timer is enabled so it will work
            //False means the timer will not work
            myAnimationTimer.Enabled = true;
        }



        //Timer Method that runs every time the timer elapses
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //Setting the bar graph colors
            var myBackgroundColor = ConsoleColor.Gray;
            var myBarGraphColor = ConsoleColor.Blue;

            //Add one to the timer counter every time it elapses
            myTimerCounter++;

            //Random number for the bar graph animation
            Random myRandomNumber = new Random();

            //This randomly selects a number from 0 to 10 and assigns it to a variable.
            //0 and 10 could be any number, but we want the bar graph to be 10 spaces long
            //...think a rating of 8/10.
            //We will randomize it over and over to get the animation
            var theRating = myRandomNumber.Next(0, 11);

            //Set color for the bar graph
            //We set the color each time because we keep re-drawing the graph
            //We can set the color once here, or set it over and over again in the loop below.
            Console.BackgroundColor = myBarGraphColor;

            //Create bar graph, not the bar graph background
            //We create the bar we want first, and the background second.
            for (int ii = 0; ii <= theRating; ii++)
            {
                //We could run the below code here if we wanted, but we just set it once above instead of each time here.
                //Console.BackgroundColor = myBarGraphColor; 
                //This creates a colored bar graph of spaces, so if you have a 5/10, you will get 5 colored spaces.
                Console.Write(" ");
            }

            //Set total number for the length of the bar graph, which is also the background
            int myTotalNumber = 10;

            //Set bar graph background color
            //We can set the color once here, or set it over and over again in the loop below.
            Console.BackgroundColor = myBackgroundColor;

            //Draw bar graph background
            //The background is not seen around the edges of the bar, or also with the foreground color of the bar. We only see one color at a time.
            //So, we just start drawing the background after the final drawing of the bar graph based on the data.
            //For Example...if we have 5/10, then the bar graph is 1-5 and the background is 6-10.
            for (int iii = theRating; iii <= myTotalNumber; iii++)
            {
                //We could run the below code here if we wanted, but we just set it once above instead of each time here.
                //Console.BackgroundColor = myBackgroundColor;
                //This creates a colored background of spaces, so if you have a 5/10, you will get 5 colored spaces to make the background after the 5 colored spaces that made up the bar.
                Console.Write(" ");
            }

            //Move the cursor back to the left, where it started to draw the animation to begin with.
            //Once we redraw, and redraw, and redraw, it will look animated.
            //We are doing this because we are uisng a Console.Write to stay on the same line, so we move back, and redraw over top of the old one.
            Console.CursorLeft = 0;

            //After a bit of time, stop the animation
            //We change this as well for longer/shorter, faster/slower
            //Right now, the animation, or resetting/redrawing of the graph will happen 50 times, once every 50/1000 seconds.
            if (myTimerCounter == 50)
            {
                //Stop Timer
                myAnimationTimer.Stop();

                //Add in final database variable code here
                //If the database data says 8/10, you would set the variable to 8 here.
                //Once the animation is over, redraw the bar graph one more time with the actual bar graph data


                //Move the cursor down and away from the artwork/bar graph to have menu options, text, etc.
                for (int x = 0; x < 5; x++)
                {
                Console.WriteLine("");
                }

                //Show the cursor again so the user can do what you need them to do.
                Console.CursorVisible = true;

            }
        }
    }
}
