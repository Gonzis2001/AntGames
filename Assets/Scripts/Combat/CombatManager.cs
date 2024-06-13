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
   

   

    #region enemy
    [SerializeField] private int enemyHP;
    [SerializeField] private int enemytAttack;
    [SerializeField] private int enemyMagic;
    [SerializeField] private int enemyDefense;
    [SerializeField] private int enemyDefenseMagic;
    [SerializeField] private int enemyEnergy;
    [SerializeField] private int enemyExp;
    [SerializeField] private int enemylevel;
    [SerializeField] private int enemyVel;

    public int Energy { get => energy; set => energy = value; }
    #endregion
    private void Start()
    {

        if (pj3 != null)
        {
            Energy= pj1.energy+pj2.energy+pj3.energy;

        }
        else if (pj2==null)
        {
            Energy = pj1.energy;
        }
        else if (pj3==null)
        {
            Energy = pj1.energy + pj2.energy;
        }
        
    }
    private void Update()
    {
        energyText.text=energy.ToString();
    }

}
