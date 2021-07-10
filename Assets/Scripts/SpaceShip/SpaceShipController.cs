using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField] float thrusterForce = 10f;
    [SerializeField] float tiltingForce = 10f;
    [SerializeField] GameObject alice = default;
    [SerializeField] GameObject spawnAlice = default;

    private Vector3 rotationInput;
    private Vector3 rotationVelocity;

    private bool shipOnGround = false;

    public bool ShipOnGround => shipOnGround;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!InOutShipManager.Instance.IsAliceOut)
        {
            FeetOnTheGround();
        }

        if(!GravityManager.Instance.IsOnPLanet)
        {
            SpaceRotation();
        }

        //if(Input.GetKey(KeyCode.E) && shipOnGround && !InOutShipManager.Instance.IsAliceOut)
        //{
        //    GoOut();
        //}
    }

    private void FixedUpdate()
    {
        if (!InOutShipManager.Instance.IsAliceOut)
        {
            if (Input.GetKey(KeyCode.U))
            {
                UpForce();
            }

            if (Input.GetKey(KeyCode.J))
            {
                DownForce();
            }
        }
    }

    public void GoOut()
    {
        Instantiate(alice, spawnAlice.transform.position, Quaternion.identity);
        rb.constraints = RigidbodyConstraints.FreezePosition;
        rb.freezeRotation = true;
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

    public void IsOnGround(bool ground)
    {
        shipOnGround = ground;
    }
}
