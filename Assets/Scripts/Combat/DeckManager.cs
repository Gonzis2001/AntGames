using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField] private List<Card> deck;
    [SerializeField] private List<Card> hand;
    [SerializeField] private List<Card> graveyar;
    [SerializeField] private Transform handTransform;
    [SerializeField] private int numdraw;
   [SerializeField] private GameObject cardPrefab; 
    void Start()
    {
        ShuffleDeck();
        DrawHand();
    }

    void DrawHand()
    {
        if(deck.Count <= 0)
        {
            deck = graveyar;
            graveyar.Clear();
            ShuffleDeck();
        }
        for (int i = 0; i < numdraw; i++) 
        {
            DrawCard();
        }
    }

    void DrawCard()
    {
        if (deck.Count > 0)
        {
            Card drawnCard = deck[0];
            deck.RemoveAt(0);
            hand.Add(drawnCard);

        
            float offsetX = 400f; 
          
            Vector3 newPosition = handTransform.position + Vector3.right * (hand.Count - 1) * offsetX;

         
            GameObject cardUI = Instantiate(cardPrefab, newPosition, Quaternion.identity, handTransform);
            DraggableCard draggableCard = cardUI.GetComponent<DraggableCard>();
            draggableCard.InitializeCard(drawnCard);


        }
        
    }
    void ShuffleDeck()
    {
        System.Random rng = new System.Random();
        int n = deck.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card value = deck[k];
            deck[k] = deck[n];
            deck[n] = value;
        }
    }
}
