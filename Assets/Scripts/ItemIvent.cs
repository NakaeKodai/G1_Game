using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIvent : MonoBehaviour
{

    public GameObject myObject;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            myObject.SetActive(false);
        }
    }
}
