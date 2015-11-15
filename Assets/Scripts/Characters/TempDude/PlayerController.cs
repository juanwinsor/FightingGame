using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
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

    }
}
