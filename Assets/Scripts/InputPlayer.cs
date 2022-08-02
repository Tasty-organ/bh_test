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
    }

    private void Update()
    {
        if (!player||player.isUsingDash) return;

        var input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        player.Move(input);
        player.MoveLocal(input);

        if (Input.GetMouseButtonDown(0) && input != Vector3.zero)
        {
            player.Dash(input);
            player.DashLocal(input);
        }
    }
}
