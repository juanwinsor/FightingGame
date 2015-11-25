using UnityEngine;
using System.Collections;

public enum FacingDirection
{
    Left, 
    Right
}

public enum MoveDirection
{
    Left,
    Right,
    Idle
}

public class CharController : MonoBehaviour
{
    private Animator m_AnimationController;

    public Vector2 jumpForce = new Vector2(10.0f, 10.0f);

    public bool isOnGround = false;

    private Rigidbody2D m_Body;

    private Vector2 m_MoveDirection;

    //private FacingDirection m_FacingDirection = FacingDirection.Right;

    public float moveSpeed = 1.0f;

    public void Move (MoveDirection inputDirection)
    {
        if (isOnGround)
        {
            if (inputDirection == MoveDirection.Right)
            {
                m_MoveDirection = Vector2.right;
            }
            else if (inputDirection == MoveDirection.Left)
            {
                m_MoveDirection = Vector2.left;
            }
            else
            {
                m_MoveDirection = Vector2.zero;
            }

            m_MoveDirection.x *= moveSpeed;

            m_MoveDirection.y = m_Body.velocity.y;

            m_Body.velocity = m_MoveDirection;

            m_AnimationController.SetFloat("VelocityX", m_MoveDirection.x);
        }
        
    }

    public void Jump (MoveDirection inputDirection)
    {
        if (isOnGround)
        {
            Vector2 force;

            if (inputDirection == MoveDirection.Right)
            {
                force.x = 1.0f * jumpForce.x;
            }
            else if (inputDirection == MoveDirection.Left)
            {
                force.x = -1.0f * jumpForce.x;
            }
            else
            {
                force.x = 0; 
            }

            

            force.y = jumpForce.y;

            m_Body.AddForce(force);

            m_AnimationController.SetFloat("JumpDirection", force.x);

            m_AnimationController.SetTrigger("Jump");
        }
    }
	// Use this for initialization
	void Start ()
    {
        m_Body = transform.GetComponent<Rigidbody2D>();

        m_AnimationController = transform.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        m_AnimationController.SetFloat("VelocityY", m_Body.velocity.y);
	}

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        

        ContactPoint2D[] contacts = collisionInfo.contacts;
        {
            for(int i = 0; i < contacts.Length; ++i)
            {
                Debug.Log(LayerMask.LayerToName(contacts[i].collider.gameObject.layer));

                if (contacts[i].collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    Debug.Log("OnCollisionEnter2D");

                    isOnGround = true;

                    m_AnimationController.SetTrigger("OnGround");
                }
            }
        }

    }

    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        ContactPoint2D[] contacts = collisionInfo.contacts;
        {
            for (int i = 0; i < contacts.Length; ++i)
            {
                if (contacts[i].collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    isOnGround = false;
                }
            }
        }
    }

}
