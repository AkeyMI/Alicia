using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGround : MonoBehaviour
{
    private SpaceShipController spaceShip;

    private void Start()
    {
        spaceShip = FindObjectOfType<SpaceShipController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            spaceShip.IsOnGround(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            spaceShip.IsOnGround(false);
        }
    }
}
