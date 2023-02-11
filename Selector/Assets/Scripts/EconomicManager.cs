using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EconomicManager
{
    // Start is called before the first frame update
    public static int money = 0;
    public static int scale = 1;

    public static void IncreaseMoney()
    {
        money += scale;
    }
    public static bool DecreaseMoney(int fee)
    {
        bool value = fee <= money ? true : false;
        money -= value ? fee : 0;
        return value;
    }
}
