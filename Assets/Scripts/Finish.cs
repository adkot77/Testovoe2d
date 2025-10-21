using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            int nextLevelIndex=SceneManager.GetActiveScene().buildIndex + 1;
            if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextLevelIndex);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
            
        }
    }
}
