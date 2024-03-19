using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
using System.IO;
using System.Text;
using System;

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
