using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlyphObjectScript : MonoBehaviour
{
    public SpriteRenderer glyphSprite;

    public Dictionary<string, Sprite> glyphImages = new Dictionary<string, Sprite>();
    public List<GlyphScriptableObject> allGlyphData = new List<GlyphScriptableObject>();

    void SetGlyph(string glyphType)
    {
        glyphSprite.sprite = glyphImages[glyphType];
    }
}
