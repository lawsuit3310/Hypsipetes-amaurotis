using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boat
{
    public class UIEventManager : MonoBehaviour
    {
        public GameObject layout;
        public GameObject ShopOpenButton;

        GameManager gameManager;

        private void OnEnable()
        {
            gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        }
        public void GotoLeft()
        {
            try
            {
                gameManager.Direction = true;
                gameManager.camControllers[0].gameObject.SetActive(false);
                gameManager.camControllers[1].gameObject.SetActive(true);
                StartCoroutine("BackGroundFadeEffect");
            }
            catch
            {
                Debug.LogError("Unexpected. (1)");
            }
        }
        public void GotoRight()
        {
            try
            {
                gameManager.Direction = false;
                gameManager.camControllers[0].gameObject.SetActive(true);
                gameManager.camControllers[1].gameObject.SetActive(false);
                StartCoroutine("BackGroundFadeEffect");
            }
            catch
            {
                Debug.LogError("Unexpected. (2)");
            }
        }
        public void Decrease()
        {
            EconomicManager.DecreaseMoney(1);
        }
        #region Coroutines
        IEnumerator BackGroundFadeEffect()
        {
            GameObject[] ShopUI = new GameObject[layout.transform.childCount];
            for (int i = 0; i < layout.transform.childCount; i++)
                ShopUI[i] = layout.transform.GetChild(i).gameObject;

            //GameObject childerns = layout.Rtransform.getchild;
            for (int i = 0; i < 20; i++)
            {
                foreach (GameObject backGround in gameManager.backGrounds)
                {
                    Vector3 pos = backGround.transform.position;
                    Vector3 posUI = ShopOpenButton.transform.position;

                    backGround.transform.position = new Vector3(
                        gameManager.Direction ? pos.x + 1 : pos.x - 1, pos.y, pos.z);

                    ShopOpenButton.transform.position = new Vector3(
                        gameManager.Direction ? posUI.x + 1 : posUI.x - 1, posUI.y, posUI.z);

                    foreach (GameObject UI in ShopUI)
                    {
                        UI.transform.position = new Vector3(
                        gameManager.Direction ? UI.transform.position.x + 1 : UI.transform.position.x - 1, UI.transform.position.y, UI.transform.position.z);
                    }
                }


                yield return new WaitForSeconds(0.01f);
            }
            yield break;
        }
        #endregion
    }
}
