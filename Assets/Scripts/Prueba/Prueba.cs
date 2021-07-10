using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
    [SerializeField] float tiltingForce = 10f;

    private Vector3 rotationInput;
    private Vector3 rotationVelocity;

    private void Update()
    {
        float tiltX = Input.GetAxisRaw("Vertical");
        float tiltZ = Input.GetAxisRaw("Horizontal");

        rotationInput = new Vector3(tiltZ, 0f, tiltX);
        rotationVelocity = rotationInput.normalized * tiltingForce;

        if (!Mathf.Approximately(tiltX, 0f) || !Mathf.Approximately(tiltZ, 0f))
        {
            transform.Rotate(rotationVelocity);
        }
    }
}
