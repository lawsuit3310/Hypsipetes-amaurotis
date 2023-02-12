using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnCanvas : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnCanvasGroup);
    }

    private void OnCanvasGroup()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }
}
