using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="combatSO")]
public class CombatSO : ScriptableObject
{
     public GameObject[] pjPrefabs;
     public GameObject[] enemeisPrefabs;
    public Vector3 positionpj;
    public List<int> id;
    public bool firstTime=true;
    public string escenacargar;
}
