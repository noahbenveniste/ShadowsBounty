﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ShoppingManager : MonoBehaviour
{
    //PersistentManagerScript Instance;

    [SerializeField] TextMeshProUGUI M_Object;

    [SerializeField] TextMeshProUGUI Message_Object;

    const string OpeningTxt = "Buying some magic?";

    const string BuySuccessTxt = "Good Choose";

    const string BuyFailTxt = "I can count, don't fool me";

    int Bounty;

    DataJSON data;

    // Start is called before the first frame update
    private void Start()
    {
        data = DataJSON.Load();
        //Bounty = PlayerPrefs.GetInt("score");
        Bounty = data.bounty;
        Debug.Log(Bounty);
        //Instance = PersistentManagerScript.Instance;
        //BountyTxt.text = Instance.Bounty.ToString();
        //Instance.SetupBounty();
        //M_Object.text = Instance.Bounty.ToString();
        M_Object.text = Bounty.ToString();
        Message_Object.text = OpeningTxt;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //PersistentManagerScript.Instance.AddBounty(100);
            //BountyTxt.text = Instance.Bounty.ToString();
            //M_Object.text = Instance.Bounty.ToString();
            Bounty += 100;
            Debug.Log("Current: " + Bounty);
            PlayerPrefs.SetInt("score", Bounty);
            M_Object.text = Bounty.ToString();
            Message_Object.text = OpeningTxt;
        }

    }

    public void NextGame()
    {
        //PlayerPrefs.SetInt("score", Bounty);
        DataJSON.Save(data);
        SceneManager.LoadScene("TreasureTesting");
    }

    public void Shopping(int cost, int index)
    {
        if (cost > Bounty)
        {
            Debug.Log("not enough bounty");
            Message_Object.text = BuyFailTxt;
        }
        else
        {
            Bounty -= cost;
            M_Object.text = Bounty.ToString();
            Message_Object.text = BuySuccessTxt;
            data.itemNum[index]++;
        }
    }


}
