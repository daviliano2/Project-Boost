using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Start":
                Debug.Log("collided with friendly object, all good");
                break;
            case "Finish":
                Debug.Log("collided with friendly object, all good");
                LoadNextLevel();
                break;
            default:
                Debug.Log("Collided with something bad, U ded");
                ReloadLevel();
                break;
        }
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
