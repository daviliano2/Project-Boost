using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrustPower = 1000f;
    [SerializeField] float rotationPower = 200f;
    Rigidbody rocketRigidbody = null;

    // Start is called before the first frame update
    void Start()
    {
        rocketRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetThrust();
        GetRotation();
    }

    void GetThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rocketRigidbody.AddRelativeForce(Vector3.up * thrustPower * Time.deltaTime);
        }
    }

    void GetRotation()
    {
        rocketRigidbody.freezeRotation = true; // freeze rotation to be able to manually rotate the rocket
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationPower * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rotationPower * Time.deltaTime);
        }
        rocketRigidbody.freezeRotation = false; // unfreeze rotation so unity's physics system can take over
    }
}
