using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] private int energy;

    [SerializeField] private PlayerSO pj1;
    [SerializeField] private PlayerSO pj2;
    [SerializeField] private PlayerSO pj3;

    [SerializeField] private TMP_Text energyText;
    [SerializeField] private List<ShowLife> pj;
    [SerializeField] private GameObject[] pjGameObjects;
    [SerializeField] private List<Enemies> enemies;

    [SerializeField] private GameObject[] enemiesGameObject;

     private float enemiesVel;
     private float pjVel;
    [SerializeField] private bool turn;
    private bool turnEnemy;
    [SerializeField] private GameObject dropZone;

   

    

    public int Energy { get => energy; set => energy = value; }
   
    private void Start()
    {

        if (pj3 != null)
        {
            Energy= pj1.energy+pj2.energy+pj3.energy;
            pjVel=(pj1.vel+pj2.vel+pj3.vel)/3;

        }
        else if (pj2==null)
        {
            Energy = pj1.energy;
            pjVel = pj1.vel;
        }
        else if (pj3==null)
        {
            Energy = pj1.energy + pj2.energy;
            pjVel = (pj1.vel+pj2.vel)/2;
        }
        pjGameObjects = GameObject.FindGameObjectsWithTag("PJ");
        for (int i = 0; i < pjGameObjects.Length; i++)
        {

            pj.Add(pjGameObjects[i].GetComponent<ShowLife>());
        }

        enemiesGameObject = GameObject.FindGameObjectsWithTag("Enemy");
      

         for (int i = 0; i < enemiesGameObject.Length; i++)
          {
              
             enemies.Add(enemiesGameObject[i].GetComponent<Enemies>());
          }
        
        for (int i = 0;i < enemies.Count; i++)
        {
            enemiesVel += enemies[i].enemyStats.vel;
            
           
        }
        enemiesVel/= enemies.Count;
        if (enemiesVel > pjVel)
        {
            turn = false;
            turnEnemy = true;
        }
        else if (enemiesVel <= pjVel)
        {
            turn=true;
            turnEnemy = false;
        }
        
    }
    private void Update()
    {
        energyText.text=energy.ToString();
        if (turn)
        {

        }
        else
        {
            if (turnEnemy)
            {
                StartCoroutine(EnemyTurn());
            }
        }
    }
    public void PassTurn()
    {
       
        if (turn)
        {
            dropZone.SetActive(false);
            turn=false;
            turnEnemy = true;
        }
    }
    
    private IEnumerator EnemyTurn()
    {
        turnEnemy = false;
        yield return new WaitForSeconds(0.2f);


       for (int i = 0; i < enemies.Count; i++)
        {
            
            var a = pj[Random.Range(0, pj.Count )];
            enemies[0].UseHability(a);
           

            yield return new WaitForSeconds(0.2f);

        }
       
    }
}
