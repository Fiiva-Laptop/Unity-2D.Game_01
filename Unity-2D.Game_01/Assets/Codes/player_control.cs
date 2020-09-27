using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{
    public float MoveSpeed = (float)10;

    private Rigidbody2D mRigidbody2D;
    private Animation Animation;

    // Start is called before the first frame update
    void Start()
    {
        mRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            mRigidbody2D.velocity = new Vector2(-MoveSpeed, 0);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            mRigidbody2D.velocity = Vector2.zero;
        }
            
            
        if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            mRigidbody2D.velocity = new Vector2(MoveSpeed, 0);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            mRigidbody2D.velocity = Vector2.zero;
        }

    }
}
