using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCollider : MonoBehaviour
{
    private PlayerController playerController;


    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
    }
}
