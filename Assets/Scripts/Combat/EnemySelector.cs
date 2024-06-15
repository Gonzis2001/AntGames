using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySelector : MonoBehaviour
{
    private GameObject selectedEnemy;
    [SerializeField] private GameObject selectedPrefab;
    private GameObject selectedPrefabActive;
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detecta el clic izquierdo del ratón
        {
            SelectEnemy();
        }
    }

    void SelectEnemy()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject clickedObject = hit.collider.gameObject;

            // Verifica si el objeto clicado es un enemigo
            if (clickedObject.CompareTag("Enemy"))
            {
                if (selectedEnemy != null)
                {
                    DeselectCurrentEnemy();
                }

                selectedEnemy = clickedObject;
                HighlightSelectedEnemy(selectedEnemy);
            }
        }
    }

    void HighlightSelectedEnemy(GameObject enemy)
    {
        if(selectedPrefabActive != null)
        {
            Destroy(selectedPrefabActive);
        }
        selectedPrefabActive = Instantiate(selectedPrefab, enemy.transform.parent.position,Quaternion.identity);
        
        Collider enemyCollider = enemy.GetComponent<Collider>();
        Vector3 enemySize = enemyCollider.bounds.size;
        float rangeMax=0;
        if (enemySize.x >= enemySize.y)
        {
            rangeMax = enemySize.x;
        }
        else if (enemySize.y > enemySize.x)
        {
            rangeMax = enemySize.y;
        }
        selectedPrefabActive.transform.localScale = new Vector3(rangeMax , 1f, rangeMax) ;
        selectedPrefabActive.transform.SetParent(selectedEnemy.transform);  
    }

    void DeselectCurrentEnemy()
    {
       
        selectedEnemy = null;
    }
}
