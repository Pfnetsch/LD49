using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PotionDB
{
    [System.Flags]
    public enum Temperature
    {
        Cold = 0x1,
        Hot = 0x2,
        Neutral = 0x3
    }

    [System.Flags]
    public enum Luminosity
    {
        None = 0x0,
        Bright = 0x1,
        Dark = 0x2,
        Both = 0x3
    }

    public enum Results
    {
        Nothing,
        Success,
        Unstable
    }

    public class Quest
    {
        public string Name;
        public string Description;
        public string Riddle;
        public int PotionTextureIndex;

        public Quest(string name, string description, string riddle, int potionTextureIndex)
        {
            Name = name;
            Description = description;
            Riddle = riddle;
            PotionTextureIndex = potionTextureIndex;
        }
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
            int hashCode = 1120038190;
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
    public static List<List<(Potion, Quest)>> Potions = new List<List<(Potion, Quest)>>
    {
        new List<(Potion, Quest)>()
        {
            (new Potion("Ti-Ti Seeds","Sunshine Drops","Pin-Pin Mushroom", Temperature.Hot, Luminosity.Both), new Quest("Love Potion", "The times of limp wood and dry desert are over with this potion. Not only will you have men, women and trolls at your feet, but you'll be able to meet all their desires too.", "Three ingredients are needed.\nOne, warm like tears of joy. The other, small like grapes. The last, big at the right moments.\nSome might say, love is always a heated topic", 0)),
            (new Potion("Shaman Jelly","Onion Tears","Horn of a Sea Bat", Temperature.Cold, Luminosity.Both), new Quest("Potion for your stepmother", "If the next family gathering is just around the corner and you need a quick way to keep your stepmother away from you for all eternity, let her take a sip of this potion. However, if she takes just one sip more, she'll be giving you sloppy kisses forever.", "Your stepmother is not your best buddy and you want to get rid of her in a legal way? Then follow these steps:\n 1. Ask her if she quit her diet because you don’t see any changes. This should do the crying.\n 2. Tell her about new magical formulas and technical components where her mind becomes pudding.\n 3. Make it clear that you don’t want to have an affair with her, because she doesn’t arouse your horn.\n 4. Say goodbye with a cool, half-hearted nod.", 1)),
            (new Potion("Wyvern Grass","Wolpertinger Milk","Cobaliti", Temperature.Neutral, Luminosity.Both), new Quest("Dr.Doolittle Potion", "Do you want to know what your cat is really up to, feel like a Disney princess, or simply want to look like a crazy person? This potion is the solution for you.", "All magical creatures are equally worthy.\nNo need for arguments or to ignore somebody.", 2)),
        },
        new List<(Potion, Quest)>()
        {
            (new Potion("Shaman Jelly","Wolpertinger Milk","Crystal Neko Scales", Temperature.Cold, Luminosity.Both), new Quest("Invisibility Potion", "Makes your skin invisible to any prying eyes. But pay attention to the time, after 23 hours the effect ends and you will be seen again as God created you.", "Three ingredients are needed.\nOne doesn’t want to be seen, but the other one does. And for the third one, nobody knows exactly what it is. But they have one thing in common: snootiness.", 3)),
            (new Potion("Wobbly Dobbly Herb","Glacier Water","Hair of Gunther", Temperature.Cold, Luminosity.Both), new Quest("Dance or Die Potion", "In the early 5th century, Gunther and Merlin helped Arthur to win the war against the Saxons by torturing methods that were banned soon after development. With this potion your veins start to freeze and have to be in constant movement or else you die. Nowadays it leads to certain death, since the antidote was lost over time.", "A cold rush shoots through your body. Your blood freezing, you try to dance the cold away. Then you realise, only Gunther can dance hard enough to get you warm.", 4)),
            (new Potion("Angry Dandelion","Sunshine Drops","Mush-Mush Shell", Temperature.Hot, Luminosity.Both), new Quest("Harpy Potion", "When the work day is just horrible and you want to rip off your boss's head and fly away. Become a harpy for a few minutes and see what's possible without remorse and the ability to fly.", "Harpies are usually found where the mountains break through the clouds. \nTheir aggression harshly dependents on the time of the month, but is never zero.", 5)),
        },
        new List<(Potion, Quest)>()
        {
            (new Potion("Holy Beer Herb","Onion Tears","Cobaliti", Temperature.Cold, Luminosity.Bright), new Quest("Hercules Potion", "No jar of pickles and no ridiculously heavy piece of furniture will ever resist your mighty power. However, petting a puppy will also no longer be possible due to your incredible strength.", "One can only be obtained by the best craftsmen who can produce the elixir of life.\nTo obtain the other one something has to cry.\nAnd the last one can only be obtained by the bravest and most patient ones. And don’t forget to search for a waterfall.\nAll ingredients are familiar with the night, but there is a wish for change.", 6)),
            (new Potion("Tussilago Farfara","Lukewarm Lava","Pin-Pin Mushroom", Temperature.Neutral, Luminosity.Dark), new Quest("Potion of disappointment", "Generally considered a bad thing. However, if you are stuck in a desperate situation and you see no way out. Maybe a bit of disappointment can help you come to new conclusions.", "One´s always in the shadow of its hotter sibling.\nThe second is a disappointment of the third and vice versa.\nWhile the second has its hands put into its hips with a questioning look the other one is only erect around a different ingredient, which furthers the disagreement.\nIn the end everything balances itself out in the kettle and everything returns to normal.", 7)),
            (new Potion("Wobbly Dobbly Herb","Glacier Water","Trinity Stone", Temperature.Neutral, Luminosity.Bright), new Quest("Holy Moly Potion", "This potion makes the user holy in every sense. The perfect person. Humble, righteous and caring. Well… Or self-belittling, self-righteous and self-caring. Depends on the reasons for drinking it.", "Tales of holiness are often misleading. Quickly scrambled together after three beers in a decaying tavern. And often have a negative impact, if you don't take them in a light way.", 8)),
        }
    };

    public static bool CheckIfCorrectPotion(Potion questPotion, Potion potion)
    {
        return questPotion.Herb == potion.Herb &&
                questPotion.Liquid == potion.Liquid &&
                questPotion.Solid == potion.Solid &&
                questPotion.Temp.HasFlag(potion.Temp) &&
                questPotion.Luminosity.HasFlag(potion.Luminosity);
    }

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
