using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    public static InputPlayer instance = null;

    [SerializeField] PlayerMovement player;

    private void Awake()
    {
        if (!instance) instance = this;
        else throw new System.Exception();
    }

    public void SetPlayer(PlayerMovement player)
    {
        this.player = player;
        CameraController.instance.SetFollowTarget(player.transform);
    }

    private void Update()
    {
        if (!player || player.isUsingDash) return;
        if (!player.isActiveAndEnabled) return;
        var input = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")).normalized;
        player.Move(input);

        if (Input.GetMouseButtonDown(0) && input != Vector2.zero)
        {
            player.Dash(input);
        }
    }
}
