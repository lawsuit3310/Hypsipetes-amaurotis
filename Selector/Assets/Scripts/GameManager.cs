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
        public bool Direction = true;

        private void OnEnable()
        {
            if (GameObject.FindGameObjectsWithTag("GameManager").Length > 1)
            {
                //if the GameManager is already exist, destroy this gameObject
                Destroy(this.gameObject);
            }
        }
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

        #region method belongs UI


        public void LaunchGame()
        {
            Debug.Log(true);
            SceneManager.LoadScene("MainGameScene");
        }
        #endregion

    }
}
