using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boat{
    public class Pear : RayCast
    {
        Rigidbody2D rigid;
        public int spd = 2;
        private void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            //낙하 속도 제한
            rigid.velocity = Vector2.down * spd;

            if (Input.GetMouseButtonDown(0))
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
                if(hit.collider != null)
                    if (hit.collider.name == "Pear")
                    {
                        Debug.Log("Pear");
                        EconomicManager.IncreaseMoney();
                        ExpManager.IncreaseEXP();

                        hit.collider.gameObject.SetActive(false);
                    }
            }

            if (this.transform.position.y < -7) this.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            this.transform.position = new Vector2(
                Random.Range(-5,9), 6);
        }
    }
}