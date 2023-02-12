using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatButtonsManager : MonoBehaviour
{
    [SerializeField] Button[] upgradeButtons;
    [SerializeField] Button[] storyButtons;

    void Update()
    {
        for (int i = 0;i < PlayerPrefs.GetInt("OwnBoat"); i++) 
        {
            upgradeButtons[i].gameObject.SetActive(false);
            storyButtons[i].gameObject.SetActive(true);    
        }
    }
}
