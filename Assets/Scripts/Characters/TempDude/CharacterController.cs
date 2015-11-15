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

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D m_Body;

    private Vector2 m_MoveDirection;

    //private FacingDirection m_FacingDirection = FacingDirection.Right;

    public float moveSpeed = 1.0f;

    public void Move (MoveDirection inputDirection)
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
    }
	// Use this for initialization
	void Start ()
    {
        m_Body = transform.GetComponent<Rigidbody2D>();    
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
