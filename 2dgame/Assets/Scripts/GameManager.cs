using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    [SerializeField] private Health _playerHealth;
    [SerializeField] private Image _healthBar;
    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private GameObject _gameOverText;
    [SerializeField] private GameObject _secondaryCam;

    [Header("GameOver")]
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;

    void Start()
    {
        Time.timeScale = 1f;
        if(instance)
            Destroy(this);
        else
            instance = this;

        //_playerHealth.deathEvent.AddListener(PlayerDeath);
        //_playerHealth.hitEvent.AddListener(PlayerHit);
    }

    // Update is called once per frame
    public void PlayerDeath()
    {
        Debug.Log("Player death");
        //Destroy(_playerHealth.gameObject);
        _gameOverText.SetActive(true);
        //set up score
        var hs = PlayerPrefs.GetInt("highScore", 0);
        if (score > hs)
        {
            hs = score;
        }
        PlayerPrefs.SetInt("highScore", hs);
        _scoreText.text = score.ToString();
        _highScoreText.text = hs.ToString();

        //_secondaryCam.SetActive(true);
        Time.timeScale = 0f;
    }
    public void PlayerHit()
    {
        Debug.Log("Player hit");
    }
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
