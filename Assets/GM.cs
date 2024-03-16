using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public GameObject gameoverPanel;
    public void GameOverPanel_Show()
    {
        gameoverPanel.SetActive(true);
    }
    public void RestartScene()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
