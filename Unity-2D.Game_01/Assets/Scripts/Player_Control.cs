using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public float MoveSpeed = 3.5f;

    private Vector2 MoveDir;

    public KeyCode Keyboard_LEFT = KeyCode.A;
    public KeyCode Keyboard_RIGHT = KeyCode.D;

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
        if (Input.GetKey(Keyboard_LEFT))
        {
            MoveDir.x = -MoveSpeed;
            mAnimator.SetFloat("Animator_MoveSpeed", 1);
            mSpriteRenderer.flipX = true;
        }

        if (Input.GetKey(Keyboard_RIGHT))
        {
            MoveDir.x = MoveSpeed;
            mAnimator.SetFloat("Animator_MoveSpeed", 1);
            mSpriteRenderer.flipX = false;
        }

        if (Input.GetKeyUp(Keyboard_LEFT) ||
            Input.GetKeyUp(Keyboard_RIGHT)  )
        {
            MoveDir = Vector2.zero;
            mAnimator.SetFloat("Animator_MoveSpeed", 0);
        }

        MoveDir.y = mRigidbody2D.velocity.y;
        mRigidbody2D.velocity = MoveDir;
    }
}
