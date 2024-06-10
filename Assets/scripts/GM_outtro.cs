using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
using System.IO;
using System.Text;
using System;
using UnityEngine.SceneManagement;
public class GM_outtro : MonoBehaviour
{
    FlowerSystem fs;


    void Start()
    {
        fs = FlowerManager.Instance.CreateFlowerSystem("default", false);
        fs.SetupDialog();
        fs.ReadTextFromResource("outro"); //Åª¨ú³õ´ºintro//
        fs.RegisterCommand("load_scene", (List<string> _params) => {
            SceneManager.LoadScene(_params[0]);
            fs.ReadTextFromResource("SampleScene2");


        });

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            fs.Next();

        }
    }

}
