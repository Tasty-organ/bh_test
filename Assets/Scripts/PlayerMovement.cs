using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SyncVar]
    [SerializeField] private float speed = 3f;
    [SyncVar]
    [SerializeField] private float dashSpeed = 10f;
    [SyncVar]
    [SerializeField] private float dashDuration = 0.5f;
    public bool isUsingDash { get; private set; } = false;

    private void Start()
    {
        if (isClient && isLocalPlayer)
        {
            InputPlayer.instance.SetPlayer(this);
        }
    }

    public void Move(Vector3 input)
    {
        var moveDirection = input * speed;
        rigidbody.velocity = moveDirection;
        MoveOnline(input);
    }

    [Command]
    private void MoveOnline(Vector3 input)
    {
        isUsingDash = false;
        var moveDirection = input * speed;
        rigidbody.velocity = moveDirection;
    }

    
    public async void Dash(Vector3 input)
    {
        isUsingDash = true;
        DashOnline(input);
        var dashDirection = input * dashSpeed;
        rigidbody.velocity = dashDirection;
        await System.Threading.Tasks.Task.Delay((int)(dashDuration * 1000));
        isUsingDash = false;
    }

    [Command]
    private void DashOnline(Vector3 input)
    {
        isUsingDash = true;
        var dashDirection = input * dashSpeed;
        rigidbody.velocity = dashDirection;
    }
}
