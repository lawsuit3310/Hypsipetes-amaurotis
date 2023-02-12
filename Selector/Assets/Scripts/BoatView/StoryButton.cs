using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryButton : MonoBehaviour
{
    [SerializeField] int storyInt;
    Button button;

    private void OnEnable()
    {
        button = GetComponent<Button>();
        Debug.Log(button);
        button?.onClick.AddListener(SendStory);
    }


    private void SendStory()
    {
        StorySender.ins.SetStory(storyInt);
        SceneManager.LoadScene("StoryScene");
    }
}