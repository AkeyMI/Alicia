using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atmosphere : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SpaceShip"))
        {
            GravityManager.Instance.SetGravity(this.gameObject, other.gameObject);
        }

        if(other.CompareTag("Player"))
        {
            GravityManager.Instance.SetAliceGravity(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("SpaceShip"))
        {
            GravityManager.Instance.SetZeroGravity();
            FindObjectOfType<PalancaNave>().ResetPalanca();
        }
    }
}
