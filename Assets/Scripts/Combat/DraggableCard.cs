using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Card card;
    public Image artworkImage;
    public Image characterArtImage;
    public TMP_Text nameText;
    public TMP_Text descriptionText;
    public TMP_Text costText;
    public TMP_Text tipeText;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Vector2 originalPosition;
    private Canvas canvas;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        originalPosition = rectTransform.anchoredPosition;
    }

    public void InitializeCard(Card newCard)
    {
        card = newCard;
        artworkImage.sprite = card.Art;
        characterArtImage.sprite = card.ArtCharacter;
        nameText.text = card.CardName;
        descriptionText.text = card.CardHability;
        tipeText.text = card.CardType;
        costText.text = card.Cost.ToString();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1.0f;

        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            DropZone dropZone = eventData.pointerCurrentRaycast.gameObject.GetComponent<DropZone>();
            if (dropZone != null)
            {
                dropZone.OnDrop(eventData);
              
                card.Play();
                
                Destroy(gameObject);
            }
            else
            {
                rectTransform.anchoredPosition = originalPosition;
            }
        }
        else
        {
            rectTransform.anchoredPosition = originalPosition;
        }
    }
}