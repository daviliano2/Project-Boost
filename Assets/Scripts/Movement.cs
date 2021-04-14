using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrustPower = 1000f;
    [SerializeField] float rotationPower = 200f;
    [SerializeField] AudioClip thrusterSFX = null;
    [SerializeField] ParticleSystem leftThrusterParticles = null;
    [SerializeField] ParticleSystem rightThrusterParticles = null;
    [SerializeField] ParticleSystem mainThrusterParticles = null;

    Rigidbody rocketRigidbody = null;
    AudioSource rocketAudioSource = null;

    // Start is called before the first frame update
    void Start()
    {
        rocketRigidbody = GetComponent<Rigidbody>();
        rocketAudioSource = GetComponent<AudioSource>();
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
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void StartThrusting()
    {
        if (!mainThrusterParticles.isPlaying)
        {
            mainThrusterParticles.Play();
        }
        rocketRigidbody.AddRelativeForce(Vector3.up * thrustPower * Time.deltaTime);
        if (!rocketAudioSource.isPlaying)
        {
            rocketAudioSource.PlayOneShot(thrusterSFX);
        }
    }

    void StopThrusting()
    {
        mainThrusterParticles.Stop();
        rocketAudioSource.Stop();
    }

    void GetRotation()
    {
        rocketRigidbody.freezeRotation = true; // freeze rotation to be able to manually rotate the rocket
        if (Input.GetKey(KeyCode.A))
        {
            if (!rightThrusterParticles.isPlaying)
            {
                rightThrusterParticles.Play();
            }
            transform.Rotate(Vector3.forward * rotationPower * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (!leftThrusterParticles.isPlaying)
            {
                leftThrusterParticles.Play();
            }
            transform.Rotate(Vector3.back * rotationPower * Time.deltaTime);
        }
        else
        {
            leftThrusterParticles.Stop();
            rightThrusterParticles.Stop();
        }
        rocketRigidbody.freezeRotation = false; // unfreeze rotation so unity's physics system can take over
    }
}
