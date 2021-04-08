using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float invokeDelay = 1f;
    [SerializeField] AudioClip crashSFX = null;
    [SerializeField] AudioClip successSFX = null;

    AudioSource rocketAudioSource = null;

    bool isTransitioning = false;

    void Start()
    {
        rocketAudioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isTransitioning) return;

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

        rocketAudioSource.Stop();
        rocketAudioSource.PlayOneShot(successSFX);

        Invoke("LoadNextLevel", invokeDelay);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;

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
