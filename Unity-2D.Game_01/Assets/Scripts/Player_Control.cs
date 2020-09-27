using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public float MoveSpeed = 3.5f;

    private Vector2 MoveDir;

    private Rigidbody2D mRigidbody2D;
    private Animator mAnimator;
    private SpriteRenderer mSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        mRigidbody2D = GetComponent<Rigidbody2D>();
        mAnimator = GetComponent<Animator>();
        mSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveDir.x = -MoveSpeed;
            mAnimator.SetFloat("Animator_MoveSpeed", 1);
            mSpriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveDir.x = MoveSpeed;
            mAnimator.SetFloat("Animator_MoveSpeed", 1);
            mSpriteRenderer.flipX = false;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            MoveDir = Vector2.zero;
            mAnimator.SetFloat("Animator_MoveSpeed", 0);
        }

        MoveDir.y = mRigidbody2D.velocity.y;
        mRigidbody2D.velocity = MoveDir;
    }
}
