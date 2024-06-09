using Flower;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GM_factory : MonoBehaviour
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
        SceneManager.LoadSceneAsync(3);
    }
    void Start()
    {
        fs = FlowerManager.Instance.GetFlowerSystem("default");
        fs.ReadTextFromResource("intro3");
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
