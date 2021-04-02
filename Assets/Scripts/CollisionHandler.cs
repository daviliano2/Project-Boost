using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Start":
            case "Finish":
                Debug.Log("collided with friendly object, all good");
                break;
            default:
                Debug.Log("Collided with something bad, U ded");
                ReloadLevel();
                break;
        }
    }

    void ReloadLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }
}
