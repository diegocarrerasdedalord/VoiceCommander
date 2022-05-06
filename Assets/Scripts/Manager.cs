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
    public List<Enemy> enemies = new List<Enemy>();

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

    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }
    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
    }
}
