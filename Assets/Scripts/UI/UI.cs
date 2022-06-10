using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject deathPanel;
    private void OnEnable()
    {
        Snake.OnPlayerDeath += CheckDeath;
        deathPanel.SetActive(false);
    }
    private void OnDisable()
    {
        Snake.OnPlayerDeath -= CheckDeath;
    }
    private void CheckDeath()
    {
        deathPanel.SetActive(true);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }
}
