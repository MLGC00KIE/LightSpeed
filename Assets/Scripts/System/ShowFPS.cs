﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowFPS : MonoBehaviour
{
    float deltaTime = 0.0f;
    [SerializeField]
    Text Text;
    float color2;
    float color1;

    void Update(){
        if (PlayerPrefs.GetInt("FPS", 0) == 1){
            deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
            float fps = 1.0f / deltaTime;
            Text.text = fps.ToString("F0") + "FPS";
            color2 = fps / 60;
            color1 = -color2 + 1;
            Text.color = new Color(color1, color2, 0);
        }else{
            Text.text = "";
        }
    }    
}