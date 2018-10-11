﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour {

    Vector3 boxSize;
    float boxWidth;

    [SerializeField]
    private float distanceFromBox;
    [SerializeField]
    private float extraDistanceFromBox;
    private Score scoreScript;

    [SerializeField]
    GameObject Lives;

    AudioSource Points;

    bool firstLinePassed;
    bool secondLinePassed;

	// Use this for initialization
	void Start () {
        Points = gameObject.GetComponent<AudioSource>();
        // get box size
        boxSize = GetComponent<Collider>().bounds.size;
        boxWidth = boxSize.x;
        //scoreScript = FindObjectOfType<Score>();
        try
        {
            scoreScript = GameObject.Find("Player").GetComponent<Score>();
        }
        catch
        {
            Debug.Log("PlayerDoesNotExist");
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        RaycastHit hit;

        // check for raycasts hitting to add score to player
        Debug.DrawRay((transform.position + new Vector3(-boxWidth, 0, -distanceFromBox)), new Vector3(boxWidth, 0, 0), Color.red);
        if (Physics.Raycast((transform.position + new Vector3(-boxWidth / 1.5f, 0, -distanceFromBox)), new Vector3(boxWidth / 2, 0, 0), out hit, boxWidth))
        {
            // if it hits player addscore
            if (hit.transform.tag == "Player" && !firstLinePassed)
            {
                Debug.Log(hit.transform.name);
                // add score code thingy
                scoreScript.AddScore(1);
                firstLinePassed = true;
            }
        }


        // check for raycasts hitting to add score to player
        Debug.DrawRay((transform.position + new Vector3(-boxWidth / 1.5f, 0, -extraDistanceFromBox)), new Vector3(boxWidth/2, 0, 0), Color.red);
        if (Physics.Raycast((transform.position + new Vector3(-boxWidth / 1.5f, 0, -extraDistanceFromBox)), new Vector3(boxWidth/2, 0, 0), out hit, boxWidth / 2))
        {

            // if it hits player addscore
            if (hit.transform.tag == "Player" && !secondLinePassed)
            {
                Debug.Log(hit.transform.name);
                // add score thingy for being closer
                
                Points.pitch = Random.Range(1, 2);
                Points.Play();
                scoreScript.AddScore(2);
                secondLinePassed = true;
                Destroy(this);
            }
        }


    }
}
