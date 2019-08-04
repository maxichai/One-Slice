using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollide : MonoBehaviour
{    
    //[HideInInspector]
    public Character owner;
    public Animator anim;


    private void Start() { //Check if this is the kamikaze dude
        Character c = GetComponent<Character>();
        if (c!= null) {
            owner = c;
        }
    }

    private void TryDestroy(Collider2D collider) {
        Character c = collider.gameObject.GetComponent<Character>();

        if (c != null && owner != null) {
            Debug.Log(name + ", owner: " + owner + ", collided with " + c.name);

            //if (c.gameObject != owner.gameObject) {
            if (c.gameObject == GameMaster.Instance.playerRef) {
                //Debug.Log("Destroyed: " + c.name);
                Debug.Log("Anim " + anim);
                if (anim != null) {
                    anim.SetTrigger("Attack");
                }
                c.Health -= 1;

                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        TryDestroy(collider);
    }
    private void OnTriggerStay2D(Collider2D collider) {
        TryDestroy(collider);
    }
    private void OnTriggerExit2D(Collider2D collider) {
        TryDestroy(collider);
    }
}
