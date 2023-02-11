using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExpManager
{
    // Start is called before the first frame update
    public static int Exp = 0;
    public static int Level = 1;
    public static int scale = 1;
    public static int ExpMax = 10;

    public static void IncreaseEXP()
    {
        Exp += scale;
        //Debug.Log($"Level : {Level} \nEXP : {Exp}");
        if (Exp == ExpMax) LevelUP();
    }

    public static void LevelUP()
    {
        Exp = 0;
        Level += 1;
    }
}
