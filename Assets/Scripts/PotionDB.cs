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

    public enum Luminosity
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
        public Luminosity Lunimosity;

        public Potion(string herb, string liquid, string solid, Temperature temp, Luminosity lunimosity)
        {
            Herb = herb;
            Liquid = liquid;
            Solid = solid;
            Temp = temp;
            Lunimosity = lunimosity;
        }

        public override bool Equals(object obj)
        {
            return obj is Potion potion &&
                   Herb == potion.Herb &&
                   Liquid == potion.Liquid &&
                   Solid == potion.Solid &&
                   Temp == potion.Temp &&
                   Lunimosity == potion.Lunimosity;
        }

        public override int GetHashCode()
        {
            int hashCode = 1518817350;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Herb);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Liquid);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Solid);
            hashCode = hashCode * -1521134295 + Temp.GetHashCode();
            hashCode = hashCode * -1521134295 + Lunimosity.GetHashCode();
            return hashCode;
        }
    }

    // Apprentice, Magician and Master Postions
    public static List<List<Potion>> Potions = new List<List<Potion>>()
    {
        new List<Potion>()
        {
            new Potion("","","",Temperature.Cold, Luminosity.Bright),
            new Potion("","","",Temperature.Cold, Luminosity.Bright),
            new Potion("","","",Temperature.Cold, Luminosity.Bright),
            new Potion("","","",Temperature.Cold, Luminosity.Bright),
            new Potion("","","",Temperature.Cold, Luminosity.Bright),
            new Potion("","","",Temperature.Cold, Luminosity.Bright),
            new Potion("","","",Temperature.Cold, Luminosity.Bright)
        },

        new List<Potion>()
        {
            new Potion("","","",Temperature.Cold, Luminosity.Bright),
            new Potion("","","",Temperature.Cold, Luminosity.Bright),
            new Potion("","","",Temperature.Cold, Luminosity.Bright),
            new Potion("","","",Temperature.Cold, Luminosity.Bright),
            new Potion("","","",Temperature.Cold, Luminosity.Bright),
            new Potion("","","",Temperature.Cold, Luminosity.Bright),
            new Potion("","","",Temperature.Cold, Luminosity.Bright)
        },

        new List<Potion>()
        {
            new Potion("","","",Temperature.Cold, Luminosity.Bright),
            new Potion("","","",Temperature.Cold, Luminosity.Bright),
            new Potion("","","",Temperature.Cold, Luminosity.Bright),
            new Potion("","","",Temperature.Cold, Luminosity.Bright),
            new Potion("","","",Temperature.Cold, Luminosity.Bright),
            new Potion("","","",Temperature.Cold, Luminosity.Bright),
            new Potion("","","",Temperature.Cold, Luminosity.Bright)
        }
    };
}
