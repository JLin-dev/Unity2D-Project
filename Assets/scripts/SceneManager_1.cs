using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
public class SceneManager_1 : MonoBehaviour
{
    FlowerSystem fs;
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
