using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeletePopUpButton : MonoBehaviour
{
    [SerializeField] GameObject parent;
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(DeletePopUp);
    }

    void DeletePopUp()
    {
        parent.SetActive(false);
    }
}
