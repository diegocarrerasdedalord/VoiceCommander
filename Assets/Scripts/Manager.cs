using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    Player player;
    Powers power;
    public Text playerHPtext;
    public int currentLevel;
    public List<Enemy> enemies = new List<Enemy>();

    public Text cooldownText;

    public Text manaText;
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

        if(manaText!=null)
        {
            manaText.text = "Mana: " + power.currentMana.ToString();
        }
        

        //cheats to skip levels
        if (Input.GetKeyDown("1"))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown("2"))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown("3"))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown("4"))
        {
            SceneManager.LoadScene(3);
        }
        if (Input.GetKeyDown("5"))
        {
            SceneManager.LoadScene(4);
        }


    }

    public int CalculateCooldown(float fireActiveTime)
    {
        int cd = Mathf.RoundToInt(power.fireCooldown);
        int cooldown = cd-((int)Mathf.Round(fireActiveTime));
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
    public void LoadNextLevel()
    {
            SceneManager.LoadScene(currentLevel + 1);
    }

}
