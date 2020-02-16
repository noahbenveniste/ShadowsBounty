﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureCollider : MonoBehaviour
{
    int score = 0;

    private void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Treasure"))
        {
            other.gameObject.SetActive(false);
            score += other.gameObject.GetComponent<TreasureMaster>().value;
        }

        Debug.Log("Score: " + score);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("score", score);
    }
}
