using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField] float thrusterForce = 10f;
    [SerializeField] float tiltingForce = 10f;

    private Vector3 rotationInput;
    private Vector3 rotationVelocity;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        FeetOnTheGround();

        if(!GravityManager.Instance.IsOnPLanet)
        {
            SpaceRotation();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.U))
        {
            UpForce();
        }

        if(Input.GetKey(KeyCode.J))
        {
            DownForce();
        }
    }

    private void SpaceRotation()
    {
        float tiltX = Input.GetAxisRaw("Horizontal");
        float tiltZ = Input.GetAxisRaw("Vertical");

        rotationInput = new Vector3(tiltZ, 0f, tiltX);
        rotationVelocity = rotationInput.normalized * tiltingForce;

        if(!Mathf.Approximately(tiltX, 0f) || !Mathf.Approximately(tiltZ, 0f))
        {
            //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + rotationVelocity);

            transform.Rotate(rotationVelocity);
        }
    }

    private void UpForce()
    {
        rb.AddRelativeForce(Vector3.up * thrusterForce * Time.deltaTime);
    }

    private void DownForce()
    {
        rb.AddRelativeForce(-Vector3.up * thrusterForce * Time.deltaTime);
    }

    private void FeetOnTheGround()
    {
        transform.rotation = Quaternion.FromToRotation(transform.up, -Physics.gravity) * transform.rotation;
    }
}
