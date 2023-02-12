using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseBoatButton : MonoBehaviour
{
    [SerializeField] int boatLevel;
    [SerializeField] GameObject popUp;
    int boatPrice;

    int purchacedBoat;

    Text boatDescriptText;
    Text boatNameText;
    Text boatPriceText;
    Button button;

    List<Dictionary<string, object>> boatData;

    void Start()
    {
        boatData = CSVReader.Read("BoatData");
        button = GetComponent<Button>();
        button.onClick.AddListener(BoatPurchase);
        popUp.SetActive(false);
        purchacedBoat = PlayerPrefs.GetInt("OwnBoat");

        boatDescriptText = GameObject.Find("ShipDescriptText" + boatLevel).GetComponent<Text>();
        boatNameText = GameObject.Find("ShipNameText" + boatLevel).GetComponent<Text>();
        boatPriceText = GameObject.Find("ShipPriceText" + boatLevel).GetComponent<Text>();

        if (purchacedBoat+1 >= boatLevel)
        {
            boatNameText.text = boatData[boatLevel - 1]["�̸�"].ToString();
            boatDescriptText.text = boatData[boatLevel - 1]["����"].ToString();
            boatPriceText.text = boatData[boatLevel - 1]["����"].ToString();
        }
        else
        {
            boatNameText.text = "???";
            boatDescriptText.text = "???";
            boatPriceText.text = "???";
        }

        boatPrice = Convert.ToInt32(boatData[boatLevel - 1]["����"].ToString());
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("OwnBoat") + 1 == boatLevel)
        {
            boatNameText.text = boatData[boatLevel - 1]["�̸�"].ToString();
            boatDescriptText.text = boatData[boatLevel - 1]["����"].ToString();
            boatPriceText.text = boatData[boatLevel - 1]["����"].ToString();
        }
    }

    void BoatPurchase()
    {
        //��Ʈ ���Ÿ� �õ��� ��
        if (purchacedBoat+1 < boatLevel)
        {
            popUp.SetActive(true);
        }
        if (EconomicManager.DecreaseMoney(boatPrice)) //���� ������ ���¶��
        {

            

            PlayerPrefs.SetInt("OwnBoat", purchacedBoat+1);

            return;
        }
        popUp.SetActive(true);
    }
}
