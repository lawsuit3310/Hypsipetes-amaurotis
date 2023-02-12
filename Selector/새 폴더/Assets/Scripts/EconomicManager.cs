using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EconomicManager
{
    // Start is called before the first frame update
    public static int money = 100000;
    public static int scale = 1;

    public static void IncreaseMoney()
    {
        money += scale;

        Debug.Log("money : " + money);
    }
    public static bool DecreaseMoney(int fee)
    {
        if ((money - fee) < 0)
        {
            return false;
        }
        money -= fee;
        return true;

        //bool value = fee <= money ? false : true;
        //money -= value ? fee : 0;

        //Debug.Log("money : " + money);

        //return value;
    }
}
