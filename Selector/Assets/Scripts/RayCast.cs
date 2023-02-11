using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boat
{
    public class RayCast : MonoBehaviour
    {
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
                    EconomicManager.IncreaseMoney();
                }
            }
        }
    }
}
