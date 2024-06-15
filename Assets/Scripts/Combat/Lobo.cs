using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class Lobo : MonoBehaviour
{
    [SerializeField] private EnemySo enemyStats;
    private Canvas canva;
    private Image lifeBar;
    private Transform cameras;
    private void Start()
    {
        lifeBar = GetComponentInChildren<Image>();
        canva = GetComponentInChildren<Canvas>();
        cameras = GameObject.Find("Main Camera").transform;
    }


    private void Update()
    {
        lifeBar.fillAmount = enemyStats.hP / enemyStats.hPmax;
        ChangeColorLifeBar();
        canva.transform.LookAt(cameras);
        canva.transform.rotation = new Quaternion(canva.transform.rotation.x, 0, 0, canva.transform.rotation.w);
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
    public void TakePhysicalDamage(float damage)
    {
        enemyStats.hP -= damage-enemyStats.defense;
    }
    public void TakeMagicDamage(float damage)
    {
        enemyStats.hP -= damage - enemyStats.defenseMagic;
    }
}
