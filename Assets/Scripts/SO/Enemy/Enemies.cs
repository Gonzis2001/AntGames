using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public int exp;
    public Canvas canva;
    private Image lifeBar;
    private Transform cameras;
    public Animator animator;
   [SerializeField] public int buffatacck;
    public AudioSource audioSource;
    private CombatManager combbatManager;
    [SerializeField] private TMP_Text textdamage;
    [SerializeField] private Transform hitSpawm;
    [SerializeField] private GameObject hitGameObject;
    [SerializeField] private GameObject buffimage;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        lifeBar = GetComponentInChildren<Image>();
        canva = GetComponentInChildren<Canvas>();
        
    }
    private void Start()
    {
        cameras = GameObject.Find("Main Camera").transform;
        audioSource = GameObject.Find("GameManager").GetComponent < AudioSource >();
        combbatManager = GameObject.Find("GameManager").GetComponent<CombatManager>();
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
            if (buffatacck > 0&& buffimage!=null)
            {
                buffimage.SetActive(true);
            }
            else if (buffimage != null)
            {
                buffimage.SetActive(false);
            }
        }
        UpdateBuffs();
    }
    private void UpdateStats()
    {
        hP = enemyStats.hP;
        hPmax = enemyStats.hPmax;
        attack = enemyStats.attack;
        magic = enemyStats.magic;
        defense = enemyStats.defense;
        defenseMagic = enemyStats.defenseMagic;
        exp = enemyStats.exp * enemyStats.level;
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
    private void UpdateBuffs()
    {
        if (buffatacck > 0)
        {
            attack = enemyStats.attack * 2;
        }
    }

    public void BuffDown()
    {
        buffatacck -= 1;
        if (buffatacck < 0)
        {
            buffatacck = 0;
            attack=enemyStats.attack;
        }
    }
   
    public void TakeMagicDamage(float damage)
    {
      
        hP = enemyStats.TakeMDamage(damage, hP, enemyStats.defenseMagic,animator,audioSource,textdamage);
        StartCoroutine(enemyStats.MostrateDamgage(damage,hP, enemyStats.defense, textdamage));
        enemyStats.Die(hP, this.gameObject,transform.parent,combbatManager);
        var hitEffect = Instantiate(hitGameObject, hitSpawm.position, Quaternion.identity);
        Destroy(hitEffect, 2f);


    }

    public void TakePhysicaldamage(float damage)
    {
  
        hP = enemyStats.TakePDamage(damage, hP, enemyStats.defense, animator, audioSource,textdamage);
        StartCoroutine(enemyStats.MostrateDamgage(damage,hP ,enemyStats.defense, textdamage));
        enemyStats.Die(hP, this.gameObject, transform.parent, combbatManager);
        var hitEffect = Instantiate(hitGameObject, hitSpawm.position, Quaternion.identity);
        Destroy(hitEffect, 2f);

    }

    public void UseHability(ShowLife pj,Enemies me)
    {
      
         enemyStats.Accion(attack,magic, pj,me);
    }

    
     

}
