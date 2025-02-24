using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    void Awake()
    {
        //we want to keep the original game session object alive between scenes
        int numScenePersists = FindObjectsByType<ScenePersist>(FindObjectsSortMode.None).Length;
        if (numScenePersists > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetScenePersist()
    {
        Destroy(gameObject);
    }
}
