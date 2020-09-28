using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public float MoveSpeed = 5.0f;
    public float JumpForce = 450.0f;
    public bool isGrounded = false;

    private Vector2 MoveDir;

    public KeyCode Keyboard_LEFT = KeyCode.A;
    public KeyCode Keyboard_RIGHT = KeyCode.D;
    public KeyCode Keyboard_JUMP = KeyCode.W;
    public KeyCode Keyboard_RUN = KeyCode.LeftShift;

    private Rigidbody2D mRigidbody2D;
    private Animator mAnimator;
    private SpriteRenderer mSpriteRenderer;
    private GameObject groundObject;

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
        mAnimator.SetBool("Animator_isGrounded", isGrounded);

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

        if (Input.GetKeyDown(Keyboard_JUMP) && isGrounded)
        {
            mRigidbody2D.AddForce(Vector2.up * JumpForce);
        }


        MoveDir.y = mRigidbody2D.velocity.y;
        mRigidbody2D.velocity = MoveDir;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tag_Ground"))
        {
            foreach (ContactPoint2D element in collision.contacts)
            {
                if (element.normal.y > 0.25f)
                {
                    isGrounded = true;
                    groundObject = collision.gameObject;
                    break;
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == groundObject)
        {
            groundObject = null;
            isGrounded = false;
        }
    }
}
