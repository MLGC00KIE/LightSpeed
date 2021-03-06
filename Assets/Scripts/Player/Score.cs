﻿using UnityEngine;

public class Score : MonoBehaviour {
    int PlayerScore;

    void Start(){
        PlayerScore = 0;
    }

    public void AddScore(int Amount){
        PlayerScore += Amount;
        try
        {
            GameObject.Find("Console").GetComponent<Console>().Logger("<color=orange>Points: + <color=cyan>" + Amount + "</color>.\n</color>");
            GameObject.Find("ScoreUI").GetComponent<ScoreNumber>().UpdateScore(PlayerScore);
        }
        catch { }
    }

    public int GetScore()
    {
        return PlayerScore;
    }

}
