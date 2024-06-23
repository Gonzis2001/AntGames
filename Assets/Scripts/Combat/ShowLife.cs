using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowLife : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;
    
    [SerializeField] private Transform cameras;

    private Canvas canva;
    private Image lifeBar;
    public float hP;
    public float hPmax;
    public int attack;
    public int magic;
    public int defense;
    public int defenseMagic;
    public float exp;
    public int level;
    public int vel;
    public int energy;
    public int defenseBuff;
    public int attackNerf;
    public bool attackNeerfbool;
   [SerializeField] private Animator animator;
    [SerializeField] private Transform hitSpawm;
    [SerializeField] private GameObject hitGameObject;

    public Animator Animator { get => animator; set => animator = value; }

    private void Awake()
    {
    }
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        lifeBar = GetComponentInChildren<Image>();
        canva = GetComponentInChildren<Canvas>();
        cameras = GameObject.Find("Main Camera").transform;
        UpdateStats();
    }

    private void Update()
    {
        lifeBar.fillAmount = hP/hPmax;
        ChangeColorLifeBar();
        canva.transform.LookAt(cameras);
        canva.transform.rotation = new Quaternion(canva.transform.rotation.x, 0, 0, canva.transform.rotation.w);
        animator.SetFloat("Life", hP);
    }
    private void ChangeColorLifeBar()
    {
        
        if (lifeBar.fillAmount >= 0.8f)
        {
            lifeBar.color = Color.green;

        }
        else if (lifeBar.fillAmount>=  0.3f)
        {
            lifeBar.color = Color.yellow;
        }
        else if(lifeBar.fillAmount >=0)
        {
            lifeBar.color = Color.red;
        }
    }
    private void UpdateStats()
    {
        hP = playerSO.hP;
        hPmax = playerSO.hPmax;
        attack = playerSO.attack;
        magic = playerSO.magic;
        defense = playerSO.defense;
        defenseMagic = playerSO.defenseMagic;
        exp = playerSO.exp;
        level = playerSO.level;
        vel = playerSO.vel;
        energy = playerSO.energy;
    }
    public void BuffDown()
    {
        defenseBuff -= 1;
        if (defenseBuff < 0)
        {
            defenseBuff = 0;
            defense = playerSO.defense;
        }
        attackNerf -= 1;
        if (attackNerf < 0)
        {
            attackNeerfbool = false;
            attackNerf = playerSO.attack;
        }
    }
    public void Hit()
    {
       var hitEffect= Instantiate(hitGameObject, hitSpawm.position, Quaternion.identity);
        Destroy(hitEffect,2f);
    }
}
