using UnityEngine;

[CreateAssetMenu(fileName = "Glyph", menuName = "ScriptableObjects/GlyphScriptableObject", order = 1)]
public class GlyphScriptableObject : ScriptableObject
{
    public string GlyphName;
    public CardType glyphType;
    public Sprite GlyphSprite;
}
