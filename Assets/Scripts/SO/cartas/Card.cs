using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
public abstract class Card : ScriptableObject
{
    [SerializeField] private string cardName;
    [SerializeField] private string cardHability;
    [SerializeField] private string cardType;
    [SerializeField] private int cost;
    [SerializeField] private Sprite art;
    [SerializeField] private Sprite artCharacter;
    [SerializeField] private Sprite artType;
    [SerializeField] private Sprite artbackground;
    [SerializeField] private string pj;
    [SerializeField] private ShowLife player;
    public Sprite ArtCharacter { get => artCharacter; set => artCharacter = value; }
    public Sprite Art { get => art; set => art = value; }
    public int Cost { get => cost; set => cost = value; }
    public string CardType { get => cardType; set => cardType = value; }
    public string CardHability{ get => cardHability; set => cardHability = value; }
    public string CardName { get => cardName; set => cardName = value; }
    public string Pj { get => pj; set => pj = value; }
    public ShowLife Player { get => player; set => player = value; }
    public Sprite ArtType { get => artType; set => artType = value; }
    public Sprite Artbackground { get => artbackground; set => artbackground = value; }

    public abstract void Play();

}
