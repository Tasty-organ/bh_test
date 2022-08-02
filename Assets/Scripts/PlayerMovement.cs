using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private Rigidbody playerRigidbody;
    [SyncVar]
    [SerializeField] private float speed = 3f;
    [SyncVar]
    [SerializeField] private float dashSpeed = 10f;
    [SyncVar]
    [SerializeField] private float dashDuration = 0.5f;
    private Transform cameraTransform;
    public bool isUsingDash { get; private set; } = false;

    private void Start()
    {
        if (isClient && isLocalPlayer)
        {
            InputPlayer.instance.SetPlayer(this);
            cameraTransform = CameraController.instance.transform;
        }
    }

    public void Move(Vector2 input)
    {
        var moveDirection = GetDirection(input) * speed;
        playerRigidbody.velocity = moveDirection;
        print(playerRigidbody.velocity);
        print(playerRigidbody.velocity.magnitude);
    }


    public async void Dash(Vector2 input)
    {
        isUsingDash = true;
        var dashDirection = GetDirection(input) * dashSpeed;
        playerRigidbody.velocity = dashDirection;
        await System.Threading.Tasks.Task.Delay((int)(dashDuration * 1000));
        isUsingDash = false;
    }

    private Vector3 GetDirection(Vector2 input)
    {
        var dashForward = cameraTransform.forward * input.x;
        var dashRight = cameraTransform.right * input.y;
        return dashRight + dashForward;
    }
}
