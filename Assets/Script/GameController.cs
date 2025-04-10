using UnityEngine;

public static class GameController
{
    private static int collectableCount;

    public static bool IsGameOver { 
        get { return collectableCount <= 0; }
    }



    public static void Init()
    {
        collectableCount = 6;
    }

    public static void CollectableCollected()
    {
        collectableCount--;
    }


}
