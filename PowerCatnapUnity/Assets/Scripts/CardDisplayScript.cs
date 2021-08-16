using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplayScript : MonoBehaviour
{
    public SpriteRenderer cardSprite;

    public Dictionary<CardType, Sprite> cardImages = new Dictionary<CardType, Sprite>();
    public List<CardScriptableObject> allCardData = new List<CardScriptableObject>();

    public void SetCard(CardType cardType)
    {
        cardSprite.sprite = cardImages[cardType];
    }

    private void Awake()
    {
        foreach(CardScriptableObject cardData in allCardData)
        {
            cardImages.Add(cardData.cardType, cardData.cardSprite);
        }
    }
}
