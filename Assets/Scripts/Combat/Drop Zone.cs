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
            // Implementar la lógica cuando una carta es soltada en esta zona
            Debug.Log("Carta soltada en la zona de juego");

            // Por ejemplo, jugar la carta
            // draggable.PlayCard();
        }
    }
}