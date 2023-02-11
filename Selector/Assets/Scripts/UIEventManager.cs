using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boat
{
    public class UIEventManager : MonoBehaviour
    {
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

            for (int i = 0; i < 20; i++)
            {
                foreach (GameObject backGround in gameManager.backGrounds)
                {
                    Vector3 pos = backGround.transform.position;
                    backGround.transform.position = new Vector3(
                        gameManager.Direction ? pos.x + 1 : pos.x - 1, pos.y, pos.z);
                }

                yield return new WaitForSeconds(0.01f);
            }
            yield break;
        }
        #endregion
    }
}
