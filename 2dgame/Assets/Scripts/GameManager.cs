using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    [SerializeField] private Health _playerHealth;
    [SerializeField] private Image _healthBar;
    [SerializeField] private GameObject _gameOverText;
    [SerializeField] private GameObject _secondaryCam;

    void Start()
    {
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
        Destroy(_playerHealth.gameObject);
        _gameOverText.SetActive(true);
        _secondaryCam.SetActive(true);
        Time.timeScale = 0f;
    }
    public void PlayerHit()
    {
        Debug.Log("Player hit");
    }
}
