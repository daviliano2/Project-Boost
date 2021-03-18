using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

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
            Debug.Log("pressing space");
        }
    }

    void GetRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("pressing A");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("pressing D");
        }
    }
}
