using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollide : MonoBehaviour
{    
    [HideInInspector]
    public Character owner;

    private void Start() { //Check if this is the kamikaze dude
        Character c = GetComponent<Character>();
        if (c!= null) {
            owner = c;
        }
    }

    private void TryDestroy(Collider2D collider) {
        Character c = collider.gameObject.GetComponent<Character>();

        if (c != null && owner != null) {
            Debug.Log("Owner: " + owner + ", collided with " + c.name);
            if (c.gameObject != owner.gameObject) {
                Debug.Log("Destroyed: " + c.name);
                c.Health -= 10;
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
