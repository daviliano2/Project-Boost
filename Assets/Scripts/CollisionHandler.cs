using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float invokeDelay = 1f;
    [SerializeField] AudioClip crashSFX = null;
    [SerializeField] AudioClip successSFX = null;
    [SerializeField] ParticleSystem crashParticles = null;
    [SerializeField] ParticleSystem successParticles = null;

    AudioSource rocketAudioSource = null;

    bool isTransitioning = false;
    bool areCollisionsDisabled = true;

    void Start()
    {
        rocketAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        RunDebugActions();
    }

    void RunDebugActions()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            areCollisionsDisabled = !areCollisionsDisabled;
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (isTransitioning || areCollisionsDisabled) return;

        switch (other.gameObject.tag)
        {
            case "Start":
                Debug.Log("collided with friendly object, all good");
                break;
            case "Finish":
                Debug.Log("collided with friendly object, all good");
                StartSuccessSequence();
                break;
            default:
                Debug.Log("Collided with something bad, U ded");
                StartCrashSequence();
                break;
        }
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;

        successParticles.Play();
        rocketAudioSource.Stop();
        rocketAudioSource.PlayOneShot(successSFX);

        Invoke("LoadNextLevel", invokeDelay);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;

        crashParticles.Play();
        rocketAudioSource.Stop();
        rocketAudioSource.PlayOneShot(crashSFX);

        Invoke("ReloadLevel", invokeDelay);
    }

    void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }
}
