using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    Player player;
    Powers power;
    public Text playerHPtext;
    public int currentLevel;

    public Text cooldownText;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        power = FindObjectOfType<Powers>();

    }

    // Update is called once per frame
    void Update()
    {
        int roundedHP = (int)Mathf.Round(player.currentHP);
        playerHPtext.text = roundedHP.ToString();

        cooldownText.text = "Cooldown: "+CalculateCooldown(power.fireActiveTime).ToString();


    }

    public int CalculateCooldown(float fireActiveTime)
    {
        int cooldown = 30-((int)Mathf.Round(fireActiveTime));
        if (cooldown <=0)
        {
            return 0;
        }

        return cooldown;
    }
}
