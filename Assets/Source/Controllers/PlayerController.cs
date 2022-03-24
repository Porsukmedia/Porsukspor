using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : ControllerBase
{
    float walkSpeed = 5f;
    Vector2 movement;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] PlayerModel playerModel;

    void Movement()
    {
        movement.x = Input.GetAxis("Horizontal") * walkSpeed * Time.deltaTime;
        movement.y = Input.GetAxis("Vertical") * walkSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
        //animation
    }


    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerModel.OnInteract();
            //interaction
        }
    }

    public override void ControllerUpdate()
    {
        base.ControllerUpdate();
        Movement();
    }

    private void Update()
    {
        if (GameStateController.CurrentState == GameState.Game)
        {
            ControllerUpdate();
        }
    }

}
