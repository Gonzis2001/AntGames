using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemies : MonoBehaviour
{

    [SerializeField] public EnemySo enemyStats;
    public float hP;
    public float hPmax;
    public int attack;
    public int magic;
    public int defense;
    public int defenseMagic;
    public int vel;
    private Canvas canva;
    private Image lifeBar;
    private Transform cameras;
    private void Start()
    {
        lifeBar = GetComponentInChildren<Image>();
        canva = GetComponentInChildren<Canvas>();
        cameras = GameObject.Find("Main Camera").transform;
        UpdateStats();
    }


    private void Update()
    {
        if (canva != null)
        {
            lifeBar.fillAmount = hP / hPmax;
            ChangeColorLifeBar();
            canva.transform.LookAt(cameras);
            canva.transform.rotation = new Quaternion(canva.transform.rotation.x, 0, 0, canva.transform.rotation.w);
        }
    }
    private void UpdateStats()
    {
        hP = enemyStats.hP;
        hPmax = enemyStats.hPmax;
        attack = enemyStats.attack;
        magic = enemyStats.magic;
        defense = enemyStats.defense;
        defenseMagic = enemyStats.defenseMagic;
    }
    private void ChangeColorLifeBar()
    {

        if (lifeBar.fillAmount >= 0.8f)
        {
            lifeBar.color = Color.green;

        }
        else if (lifeBar.fillAmount >= 0.3f)
        {
            lifeBar.color = Color.yellow;
        }
        else if (lifeBar.fillAmount >= 0)
        {
            lifeBar.color = Color.red;
        }
    }
   
    public void TakeMagicDamage(float damage)
    {
        hP = enemyStats.TakeMDamage(damage, hP, enemyStats.defenseMagic);
    }

    public void TakePhysicaldamage(float damage)
    {
        
       hP = enemyStats.TakePDamage(damage, hP, enemyStats.defense);
    }
     

}
