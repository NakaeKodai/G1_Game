using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoTitle2 : MonoBehaviour
{
    public GameObject title;
    public GameObject howto;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClicked);
    }

    public void OnButtonClicked()
    {
        title.SetActive(true);
        howto.SetActive(false);
    }
}
