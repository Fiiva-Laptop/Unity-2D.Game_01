using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Flag : MonoBehaviour
{
    public GameObject[] activeObjects;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < activeObjects.Length; i++)
        {
            Debug.Log("Coin " + i + ": Disable");
            activeObjects[i].SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            for (int i=0; i<activeObjects.Length; i++)
            {
                Debug.Log("Coin " + i + ": Enable");
                activeObjects[i].SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
