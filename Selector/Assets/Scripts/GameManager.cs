using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Boat{
    public class GameManager : MonoBehaviour
    {
        public GameObject[] camControllers = new GameObject[2];
        public GameObject[] backGrounds = new GameObject[2];

        //true : gotoLeft, false : gotoRight;
        private bool Direction = true;

        // Start is called before the first frame update
        private void Awake()
        {
            #region It Works in "MainGameScene" Scene
            if (SceneManager.GetActiveScene().name == "MainGameScene")
            {
                int i = 0;
                foreach (GameObject CameraController in GameObject.FindGameObjectsWithTag("CameraController"))
                {
                    //camControllers[0] == left
                    //camControllers[1] == right
                    camControllers[i] = CameraController;
                    i++;
                }

                i = 0;

                foreach (GameObject BackGround in GameObject.FindGameObjectsWithTag("BackGround"))
                {
                    //backGrounds[0] == Beach
                    //backGrounds[1] == Woods
                    backGrounds[i] = BackGround;
                    i++;
                }

                camControllers[0].gameObject.SetActive(false);
            }
            #endregion

        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


        #region method belongs UI
        public void GotoLeft()
        {
            try
            {
                Direction = true;
                camControllers[0].gameObject.SetActive(false);
                camControllers[1].gameObject.SetActive(true);
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
                Direction = false;
                camControllers[0].gameObject.SetActive(true);
                camControllers[1].gameObject.SetActive(false);
                StartCoroutine("BackGroundFadeEffect");

            }
            catch
            {
                Debug.LogError("Unexpected. (2)");
            }
        }
        #endregion

        #region Coroutines
        IEnumerator BackGroundFadeEffect() {

            for (int i = 0; i < 20; i++)
            {
                foreach (GameObject backGround in backGrounds)
                {
                    Vector3 pos = backGround.transform.position;
                    backGround.transform.position = new Vector3(
                        Direction ? pos.x + 1 : pos.x - 1, pos.y, pos.z);
                }

                yield return new WaitForSeconds(0.01f);
            }
            yield break;
        }
        #endregion
    }
}
