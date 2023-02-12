using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boat
{
    public class RayCast : MonoBehaviour
    {
        public GameObject[] PearBox = new GameObject[5];
        public float chance = 2f;
        private int idx = 0;
        // Update is called once per frame
        private void Update()
        {
            //On Mouse click
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
                if (hit.collider != null)
                {
                    Debug.Log("It's clicked");
                    EconomicManager.IncreaseMoney();
                    ExpManager.IncreaseEXP();
                    if (Random.Range(0, 100) < chance) //2% È®·ü·Î
                    {
                        Debug.Log("Clicked");
                        PearBox[idx % 5].SetActive(true);
                        idx++;
                    }
                }
            }

        }

    }
}
