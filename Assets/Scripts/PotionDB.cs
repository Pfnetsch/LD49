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

    public enum Results
    {
        Good,
        Nothing,
        Explosion
    }

    public class IngredientsAndConditions
    {
        // Ingredients
        public string Herb;
        public string Liquid;
        public string Solid;

        // Conditions
        public Temperature Temp;

        public IngredientsAndConditions(string herb, string liquid, string solid, Temperature temp)
        {
            Herb = herb;
            Liquid = liquid;
            Solid = solid;
            Temp = temp;
        }
    }

    public static Dictionary<IngredientsAndConditions, Results> DB = new Dictionary<IngredientsAndConditions, Results>()
    {
        { new IngredientsAndConditions("","","",Temperature.Cold), Results.Nothing },
        { new IngredientsAndConditions("","","",Temperature.Cold), Results.Nothing },
        { new IngredientsAndConditions("","","",Temperature.Cold), Results.Nothing },
        { new IngredientsAndConditions("","","",Temperature.Cold), Results.Nothing },
        { new IngredientsAndConditions("","","",Temperature.Cold), Results.Nothing },
        { new IngredientsAndConditions("","","",Temperature.Cold), Results.Nothing },
        { new IngredientsAndConditions("","","",Temperature.Cold), Results.Nothing },
        { new IngredientsAndConditions("","","",Temperature.Cold), Results.Nothing },
        { new IngredientsAndConditions("","","",Temperature.Cold), Results.Nothing },
        { new IngredientsAndConditions("","","",Temperature.Cold), Results.Nothing },
        { new IngredientsAndConditions("","","",Temperature.Cold), Results.Nothing },
        { new IngredientsAndConditions("","","",Temperature.Cold), Results.Nothing },
        { new IngredientsAndConditions("","","",Temperature.Cold), Results.Nothing },
        { new IngredientsAndConditions("","","",Temperature.Cold), Results.Nothing },
        { new IngredientsAndConditions("","","",Temperature.Cold), Results.Nothing },
        { new IngredientsAndConditions("","","",Temperature.Cold), Results.Nothing },
        { new IngredientsAndConditions("","","",Temperature.Cold), Results.Nothing }
    };
}
