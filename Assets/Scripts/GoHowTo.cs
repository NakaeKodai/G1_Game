using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoHowTo : MonoBehaviour
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
        howto.SetActive(true);
        title.SetActive(false);
    }
}
