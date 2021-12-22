using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public Vector2 initialVector;
    public Vector2 floatDriftVector;
    public Transform target;
    public Vector3 targetVector;

    public bool startAimedAtTarget = false;
    public bool aimedAtTarget = false;

    public AttackData attackData;

    public Animation animation;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animation>();
        if (target != null)
        {
            targetVector = target.position;
            targetVector.z = transform.position.z;
            aimedAtTarget = true;
        }

        if (startAimedAtTarget && aimedAtTarget)
        {
            Vector2 newInitialVector = targetVector.normalized * initialVector.magnitude;
            rigidbody2D.AddForce(newInitialVector, ForceMode2D.Impulse);
        }
        else
        {
            rigidbody2D.AddForce(initialVector, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            targetVector = target.position;
            targetVector.z = transform.position.z;
            aimedAtTarget = true;
        }

        if (aimedAtTarget)
        {
            //rigidbody2D.AddForce(target.position - transform.position, ForceMode2D.Force);
            rigidbody2D.AddForce(targetVector - transform.position, ForceMode2D.Force);
        }
        else
        {
            rigidbody2D.AddForce(floatDriftVector, ForceMode2D.Force);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            PlayerScript playerScript = collision.gameObject.GetComponent<PlayerScript>();
            Debug.Log(playerScript.currentState);
            playerScript.DealDamage(attackData);
            playerScript.ApplyHitstun(attackData);
            StartDestroyingSelf();
        }
        else
        {
            StartDestroyingSelf();
        }
    }

    void StartDestroyingSelf()
    {
        animation.Play("BubbleExplode");

        // ------OLD APPROACH------
        //gameObject.SetActive(false);
        //Destroy(gameObject, 0.5f);
        // Bubble's GameObject is invisible and inactive, but still present in the Scene
        // for half a second after the impact.
        // Use this time for VFX/SFX stuff for the first implementation (until it's refactored to work less jank).
    }

    void FinishDestroyingSelf()
    {
        gameObject.SetActive(false);
        Destroy(gameObject, 0.5f);
    }
}
