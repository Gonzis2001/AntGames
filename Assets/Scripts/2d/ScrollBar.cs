using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBar : MonoBehaviour
{
    public Scrollbar scrollbar; 
    public RectTransform target; 
    public Vector2 minPosition; 
    public Vector2 maxPosition;

    void Start()
    {
       
        if (scrollbar != null && target != null)
        {
          
            scrollbar.onValueChanged.AddListener(OnScrollbarValueChanged);
        }
    }

    void OnScrollbarValueChanged(float value)
    {
      
        Vector2 newPosition = Vector2.Lerp(minPosition, maxPosition, value);
        target.anchoredPosition = newPosition;
    }

    void OnDestroy()
    {
        
        if (scrollbar != null)
        {
            scrollbar.onValueChanged.RemoveListener(OnScrollbarValueChanged);
        }
    }
}
