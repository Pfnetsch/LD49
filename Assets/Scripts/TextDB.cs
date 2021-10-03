using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextDB
{

    public static List<string> PotionTextsValid = new List<string>()
    {
        "You created … a soft drink! Smells tasty, but unfortunately has no effect.",
        "Well, this combination basically created water.",
        "Somehow you crafted a magical stone, but you need a potion!",
        "Interesting choice of ingredients … which does absolutely nothing.",
        "Oh wow, who knew you could make such a delicious soup. However, this was not the task!",
        "Are you sure you read the recipe correctly? Because I think you didn’t."
    };

    public static List<string> PotionTextsUnstable = new List<string>()
    {
        "Are you trying to kill us?!",
        "If you want to create poison you are in the wrong course.",
        "Never in my life have I seen such a disgustingly looking liquid, throw it away!",
        "Seems like your potion is alive. Better put it in a jar of glass for safety measures.",
        "Come on! We had that in the first class, some might think you´ve learned by now how to make this potion.",
        "Do you want to drag my name through the mud? Do it again!"
    };

}
