using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    IDLE,
    RUNNING,
    HITSTUN,
    UNCONSCIOUS,
    BLOCKING,
    CHARGING,
    ATTACKING
}
public class PlayerScript : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public PlayerState currentState = PlayerState.IDLE;
    public int hitstunRemaining = 0;

    public Color neutralColor;
    public Color hitstunColor;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Color currentColor = neutralColor;
        switch (currentState)
        {
            case PlayerState.HITSTUN:
                currentColor = hitstunColor;
                break;
        }
        spriteRenderer.color = currentColor;
    }

    void FixedUpdate()
    {
        ProcessHitstun();
    }

    void ProcessHitstun()
    {
        if (hitstunRemaining >= 0)
        {
            hitstunRemaining--;
            if (hitstunRemaining < 0) // Check only for less than zero, not equal, otherwise 1 hitstun does nothing.
            {
                // Hitstun ends now!
                Debug.Log("Hitstun has been CANCELLED.");
                currentState = PlayerState.IDLE;
                // If hitstun runs out this frame, transition to a neutral state before other inputs are processed,
                // so that buffered/inputted actions can be executed on the first actionable frame
                // immediately following the last frame of hitstun.
            }
        }
    }

    public int DealDamage(AttackData attackData)
    {
        int totalDamageTaken = attackData.damage;
        Debug.Log($"Player took {totalDamageTaken} damage!");
        return totalDamageTaken;
    }

    public int ApplyHitstun(AttackData attackData)
    {
        int totalHitstunApplied = attackData.hitstunToApply;
        if (totalHitstunApplied > 0)
        {
            if (currentState != PlayerState.HITSTUN && currentState != PlayerState.UNCONSCIOUS)
            {
                currentState = PlayerState.HITSTUN;
                hitstunRemaining = totalHitstunApplied;
            }
        }
        return 0;
    }
}
