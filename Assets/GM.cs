using Flower;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    FlowerSystem fs;
    public GameObject gameoverPanel;
    public void GameOverPanel_Show()
    {
        FindObjectOfType<Audio_Set>().PlaySfx(3);
        gameoverPanel.SetActive(true);
    }
    public void RestartScene()
    {
        SceneManager.LoadSceneAsync(1);
    }
    
    void Start()
    {
        fs = FlowerManager.Instance.GetFlowerSystem("default");
        fs.ReadTextFromResource("intro2");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            fs.Next();

        }
    }
}
