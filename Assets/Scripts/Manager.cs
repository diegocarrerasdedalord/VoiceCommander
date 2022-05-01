using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    Player player;
    public Text playerHPtext;
    public int currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        int roundedHP = (int)Mathf.Round(player.currentHP);
        playerHPtext.text = roundedHP.ToString();
    }
}
