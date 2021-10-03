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
        public Luminosity Luminosity;

        public Potion(string herb, string liquid, string solid, Temperature temp, Luminosity lumin)
        {
            Herb = herb;
            Liquid = liquid;
            Solid = solid;
            Temp = temp;
            Luminosity = lumin;
        }

        public override bool Equals(object obj)
        {
            return obj is Potion potion &&
                   Herb == potion.Herb &&
                   Liquid == potion.Liquid &&
                   Solid == potion.Solid &&
                   Temp == potion.Temp &&
                   Luminosity == potion.Luminosity;
        }

        public override int GetHashCode()
        {
            int hashCode = 1518817350;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Herb);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Liquid);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Solid);
            hashCode = hashCode * -1521134295 + Temp.GetHashCode();
            hashCode = hashCode * -1521134295 + Luminosity.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "[" + Herb + "," + Liquid + "," + Solid + "][Temperature: " + Temp.ToString() + ", Luminosity: " + Luminosity.ToString() + "]";
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

    public static int NumberOfCorrectIngredients(Potion questPotion, Potion potion, out string wrongOrRightIngredient)
    {
        int count = 0;
        wrongOrRightIngredient = "";
        string rightIngredient = "";
        string wrongIngredient = "";

        if (potion.Herb == questPotion.Herb)
        {
            count++;
            rightIngredient = potion.Herb;
        }
        else
            wrongIngredient = potion.Herb;

        if (potion.Liquid == questPotion.Liquid)
        {
            count++;
            rightIngredient = potion.Liquid;
        }
        else
            wrongIngredient = potion.Liquid;

        if (potion.Solid == questPotion.Solid)
        {
            count++;
            rightIngredient = potion.Solid;
        }
        else
            wrongIngredient = potion.Solid;

        if (count == 1) wrongOrRightIngredient = rightIngredient;
        else if (count == 2) wrongOrRightIngredient = wrongIngredient;

        return count;
    }
}
