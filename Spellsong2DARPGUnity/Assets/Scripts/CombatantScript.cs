using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CombatantState
{
    IDLE,
    RUNNING,
    HITSTUN,
    UNCONSCIOUS,
    BLOCKING,
    CHARGING,
    ATTACKING
}

public class CombatantScript : MonoBehaviour
{
    // Class responsibilities:
    // - Movement
    // - Health
    // - Being targeted
    // - State
    // Responsibilities to think about later/elsewhere:
    // - Targeting others with skills/abilities/attacks

    // Configuration / etc.
    public bool playerControlled = false;

    // State variables
    public Vector2 inputMovement = new Vector2();
    public int health = 100;
    public CombatantState currentState = CombatantState.IDLE;

    // Static values
    public float moveForce = 10f;
    public float dashForce = 20f;

    // References to components/objects
    public Rigidbody2D rigidbody;
    public SpriteRenderer spriteRenderer;
    //public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
