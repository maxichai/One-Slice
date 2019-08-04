using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    public Animator anim;

    public void Attack() {
        anim.SetTrigger("Attack");
    }

    void Update() {
        if (Input.GetMouseButtonUp(0)) {
            Attack();
        }
    }

    private void Start() {
        OnHealthChange();
    }

    public override void OnHealthChange() {
        base.OnHealthChange();
    }

    public override void Die() {
        Debug.Log("Advanced dying");
        Initiate.Fade("00 Main Menu", Color.black, 0.25f);
        base.Die();

    }
}
