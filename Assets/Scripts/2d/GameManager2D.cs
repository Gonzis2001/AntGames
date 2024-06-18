using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2D : MonoBehaviour
{
    [SerializeField] CombatSO combat;
    [SerializeField] GameObject pj;
   
    private void Awake()
    {

        if (!combat.firstTime)
        {
            combat.positionpj = Vector2.zero;
            combat.id.Clear();
            combat.firstTime = true;
        }
        if (combat.positionpj != null)
        {
            pj.transform.position = new Vector3 (combat.positionpj.x,combat.positionpj.y,pj.transform.position.z);

        }

    }
}
