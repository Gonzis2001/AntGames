using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        DraggableCard draggable = eventData.pointerDrag.GetComponent<DraggableCard>();
        if (draggable != null)
        {
            if (draggable.deckmanager.GetComponent<CombatManager>().Energy >= draggable.card.Cost)
            {
                Debug.Log("Carta soltada en la zona de juego");
                draggable.PlayCard();
            }
            else
            {
                // Si no hay suficiente energía, reestablecer la posición de la carta
                draggable.GetComponent<RectTransform>().anchoredPosition = draggable.OriginalPosition;
            }
        }
    }
}