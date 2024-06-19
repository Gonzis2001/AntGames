using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] private int energy;
    private int energyMax;

    [SerializeField] private PlayerSO pj1;
    [SerializeField] private PlayerSO pj2;
    [SerializeField] private PlayerSO pj3;

    [SerializeField] private TMP_Text energyText;
    [SerializeField] private List<ShowLife> pj;
    [SerializeField] private GameObject[] pjGameObjects;
    public  List<Enemies> enemies;

    [SerializeField] private GameObject[] enemiesGameObject;

     private float enemiesVel;
     private float pjVel;
    [SerializeField] private bool turn;
    private bool turnEnemy;
    [SerializeField] private GameObject dropZone;
    private DeckManager deckManager;
    [SerializeField] private GameObject canvasCombat;
    [SerializeField] private GameObject canvasEnd;

   

    

    public int Energy { get => energy; set => energy = value; }
    private void Awake()
    {
        deckManager = GetComponent<DeckManager>();
    }

    private void Start()
    {

        if (pj3 != null)
        {
            Energy= pj1.energy+pj2.energy+pj3.energy;
            energyMax= Energy;
            pjVel=(pj1.vel+pj2.vel+pj3.vel)/3;

        }
        else if (pj2==null)
        {
            Energy = pj1.energy;
            energyMax = Energy;
            pjVel = pj1.vel;
        }
        else if (pj3==null)
        {
            Energy = pj1.energy + pj2.energy;
            energyMax = Energy;
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
        if(enemies.Count <= 0) 
        {
            canvasCombat.SetActive(false);
            canvasEnd.SetActive(true);


        }
    }
    public void PassTurn()
    {

        if (turn)
        {
            dropZone.SetActive(false);
            for (int i = 0; i < pj.Count; i++)
            {
                pj[i].BuffDown();

            }
            turn = false;
            turnEnemy = true;
            int numCartasEliminar = deckManager.hand.Count;
            for (int i = 0; i < numCartasEliminar; i++)
            {
                deckManager.CardToGraveyar(deckManager.hand[0]);
            }
            DraggableCard[] cartasDestruir;
            cartasDestruir = canvasCombat.GetComponentsInChildren<DraggableCard>();
            for (int i = 0; i < cartasDestruir.Length; i++)
            {
                Destroy(cartasDestruir[i].gameObject);
            }



        }

    }

    private IEnumerator EnemyTurn()
    {
        turnEnemy = false;
        yield return new WaitForSeconds(0.2f);


       for (int i = 0; i < enemies.Count; i++)
        {

            ShowLife objetivo = null;
            int intentos = 0;
            while (objetivo == null && intentos < pj.Count)
            {
                ShowLife potentialTarget = pj[Random.Range(0, pj.Count)];
                if (potentialTarget.hP > 0)
                {
                    objetivo = potentialTarget;
                }
                intentos++;
            }

            enemies[i].UseHability(objetivo, enemies[i]);
            enemies[i].BuffDown();

            AnimatorStateInfo initialStateInfo = enemies[i].animator.GetCurrentAnimatorStateInfo(0);

         
            yield return new WaitUntil(() =>
                enemies[i].animator.GetCurrentAnimatorStateInfo(0).fullPathHash != initialStateInfo.fullPathHash);

           
            yield return new WaitUntil(() =>
                enemies[i].animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f);

        }
        dropZone.SetActive(true);
        turn = true;
        turnEnemy = false;
        energy = energyMax;
        deckManager.CanDrawObject = true;
        deckManager.DrawHand();
    }
}
