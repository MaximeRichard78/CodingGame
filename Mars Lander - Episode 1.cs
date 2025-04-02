using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
enum LandingState
{
    Approaching,
    Landing,
    Landed
}

class Landing
{
    private LandingState state = LandingState.Approaching;

    public string GetNextAction(int Y, int vSpeed)
    {
        int targetPower = 0; // Commencer avec les moteurs éteints

        if (state == LandingState.Approaching)
        {
            if (Y < 2000)
            {
                state = LandingState.Landing;
            }
            else if (vSpeed < -20)
            {
                targetPower = 2; // Allumer les moteurs plus tôt avec une poussée modérée
            }
        }

        if (state == LandingState.Landing)
        {
            if (vSpeed <= -39)
            {
                targetPower = 4; // Augmenter la poussée si la vitesse est trop élevée
            }
            else if (vSpeed >= -35)
            {
                targetPower = 3; // Réduire la poussée pour un atterrissage doux
            }
            else
            {
                targetPower = 2; // Maintenir une poussée modérée
            }

            if (Y <= 0 && vSpeed >= -40)
            {
                state = LandingState.Landed;
            }
        }

        if (state == LandingState.Landed)
        {
            targetPower = 0; // Éteindre les moteurs
        }

        return $"0 {targetPower}";
    }
}

class Player
{
    static void Main(string[] args)
    {
        int surfaceN = int.Parse(Console.ReadLine());
        for (int i = 0; i < surfaceN; i++)
        {
            Console.ReadLine(); // Lire les points de la surface
        }

        Landing landing = new Landing();

        while (true)
        {
            var inputs = Console.ReadLine().Split(' ');
            int X = int.Parse(inputs[0]);
            int Y = int.Parse(inputs[1]);
            int hSpeed = int.Parse(inputs[2]); // the horizontal speed (in m/s), can be negative.
            int vSpeed = int.Parse(inputs[3]); // the vertical speed (in m/s), can be negative.           
            int fuel = int.Parse(inputs[4]); // the quantity of remaining fuel in liters.
            int rotate = int.Parse(inputs[5]); // the rotation angle in degrees (-90 to 90).
            int power = int.Parse(inputs[6]); // the thrust power (0 to 4).


            string action = landing.GetNextAction(Y, vSpeed);
            Console.WriteLine(action);
        }
    }
}