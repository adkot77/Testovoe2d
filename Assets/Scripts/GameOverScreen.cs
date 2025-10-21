using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private AudioClip sfxGameOver;

    private void Awake()
    {
      
        restartButton.onClick.AddListener(RestartGame);        
        mainMenuButton.onClick.AddListener(LoadMainMenu);

        PlayerController player = FindObjectOfType<PlayerController>();
    
        Health health = player.GetComponent<Health>();
            
        health.OnDeath.AddListener( ShowGameOver);           
        

        gameObject.SetActive(false);
    }

    private void RestartGame()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadMainMenu()
    {
        
        SceneManager.LoadScene(0);
    }

    private void ShowGameOver()
    {
        AudioSFX.instance.PlaySFX(sfxGameOver);
        gameObject.SetActive(true);
    
    }

  
}