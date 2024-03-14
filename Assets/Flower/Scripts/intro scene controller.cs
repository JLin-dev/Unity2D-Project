using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;

public class intro : MonoBehaviour
{
    FlowerSystem fs;
    void Start()
    {
        fs = FlowerManager.Instance.CreateFlowerSystem("default", false);
        fs.SetupDialog();
        fs.ReadTextFromResource("intro");
    }

    
    void Update()
    {
        
    }
}
