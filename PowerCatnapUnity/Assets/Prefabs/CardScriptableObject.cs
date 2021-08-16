using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/CardScriptableObject", order = 1)]
public class CardScriptableObject : ScriptableObject
{
    public string cardName;
    public CardType cardType;
    public Sprite cardSprite;
}
