using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private MoveDirection m_Direction = MoveDirection.Idle;

    public CharController characterController;
	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if(Input.GetKeyDown(KeyCode.D))
        {
            characterController.Move(MoveDirection.Right);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            characterController.Move(MoveDirection.Left);
        }
        else if (Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.A) == false)
        {
            characterController.Move(MoveDirection.Idle);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.D))
            {
                m_Direction = MoveDirection.Right;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                m_Direction = MoveDirection.Left;               
            }
            else
            {
                m_Direction = MoveDirection.Idle;
            }

            characterController.Jump(m_Direction);
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            characterController.LightPunch();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            characterController.MediumPunch();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            characterController.HeavyPunch();
        }
    }
}
