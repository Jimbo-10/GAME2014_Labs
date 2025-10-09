using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreText;
    
    int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ChangeScore(int scoreChangeAmount)
    {
        score += scoreChangeAmount;
        string scoreMessage = "Score: " + score;
        scoreText.text = scoreMessage;
    }
}
