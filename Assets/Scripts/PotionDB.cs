using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PotionDB
{
    public enum Temperature
    {
        Cold,
        Moderate,
        Hot
    }

    public enum Lunimosity
    {
        Bright,
        Dark
    }

    public enum Results
    {
        Nothing,
        Success,
        Unstable
    }

    public class Potion
    {
        // Ingredients
        public string Herb;
        public string Liquid;
        public string Solid;

        // Conditions
        public Temperature Temp;
        public Lunimosity Lunimosity;

        public Potion(string herb, string liquid, string solid, Temperature temp, Lunimosity lunimosity)
        {
            Herb = herb;
            Liquid = liquid;
            Solid = solid;
            Temp = temp;
            Lunimosity = lunimosity;
        }
    }

    // Apprentice, Magician and Master Postions
    public static List<List<Potion>> Potions = new List<List<Potion>>()
    {
        new List<Potion>()
        {
            new Potion("","","",Temperature.Cold, Lunimosity.Bright),
            new Potion("","","",Temperature.Cold, Lunimosity.Bright),
            new Potion("","","",Temperature.Cold, Lunimosity.Bright),
            new Potion("","","",Temperature.Cold, Lunimosity.Bright),
            new Potion("","","",Temperature.Cold, Lunimosity.Bright),
            new Potion("","","",Temperature.Cold, Lunimosity.Bright),
            new Potion("","","",Temperature.Cold, Lunimosity.Bright)
        },

        new List<Potion>()
        {
            new Potion("","","",Temperature.Cold, Lunimosity.Bright),
            new Potion("","","",Temperature.Cold, Lunimosity.Bright),
            new Potion("","","",Temperature.Cold, Lunimosity.Bright),
            new Potion("","","",Temperature.Cold, Lunimosity.Bright),
            new Potion("","","",Temperature.Cold, Lunimosity.Bright),
            new Potion("","","",Temperature.Cold, Lunimosity.Bright),
            new Potion("","","",Temperature.Cold, Lunimosity.Bright)
        },

        new List<Potion>()
        {
            new Potion("","","",Temperature.Cold, Lunimosity.Bright),
            new Potion("","","",Temperature.Cold, Lunimosity.Bright),
            new Potion("","","",Temperature.Cold, Lunimosity.Bright),
            new Potion("","","",Temperature.Cold, Lunimosity.Bright),
            new Potion("","","",Temperature.Cold, Lunimosity.Bright),
            new Potion("","","",Temperature.Cold, Lunimosity.Bright),
            new Potion("","","",Temperature.Cold, Lunimosity.Bright)
        }
    };
}
