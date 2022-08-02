using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    [SyncVar]
    [SerializeField] private float speed = 3f;
    [SerializeField] private Rigidbody rigidbody;

    private void Start()
    {
        if (isClient && isLocalPlayer)
        {
            InputPlayer.instance.SetPlayer(this);
        }
    }

    [Command]
    public void Move(Vector3 input)
    {
        var moveDirection = input * speed;
        rigidbody.velocity = moveDirection;
    }

    public void MoveLocal(Vector3 input)
    {
        var moveDirection = input * speed;
        rigidbody.velocity = moveDirection;
    }
}
