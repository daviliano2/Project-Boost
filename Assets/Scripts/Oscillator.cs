using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;
    float movementFactor;
    const float tau = Mathf.PI * 2; // constant value of 6.283
    float cycles;
    float rawSinWave;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // comparing floats to 0f might lead to error since period could be 0.000001
        // therefore we use Mathf.Epsilon instead. Check Unity docs for reference. 
        // if period is 0 we return to avoid issues when dividing by 0 in the next line (NaN error)
        if (period <= Mathf.Epsilon) return;

        cycles = Time.time / period; // the cycle grows continually over time
        rawSinWave = Mathf.Sin(cycles * tau); // goes from -1 to 1
        movementFactor = (rawSinWave + 1f) / 2f; // we recalculate the value to make it go from 0 to 1 for simplicity

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
