using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputButtons : MonoBehaviour
{
    public static Vector3 move()
    {
        Vector3 movePlayer= new Vector3(
            Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")
        );

        return movePlayer;
    }
}
