using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInputHandler playerInput;
    private PlayerMovement Movement;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInputHandler>();
        var index = playerInput.playerInput;

    }
}
