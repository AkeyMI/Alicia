using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atmosphere : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        GravityManager.Instance.SetGravity(this.gameObject, other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        GravityManager.Instance.SetZeroGravity();
    }
}
