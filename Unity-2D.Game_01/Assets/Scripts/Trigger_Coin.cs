﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Coin : MonoBehaviour
{
    public GameObject soundObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Instantiate(soundObject, transform.position, Quaternion.identity);
            GameManager.instance.GetCoin(1);

            Destroy(gameObject);
        }
    }


}
