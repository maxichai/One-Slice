using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    public Animator anim;
    public override void OnHealthChange() {
        base.OnHealthChange();

        if (Health <= 0) {
            Initiate.Fade("00 Main Menu", Color.black, 0.5f);
        }
    }

    public void Attack() {
        anim.SetTrigger("Attack");
    }

    void Update() {
        if (Input.GetMouseButtonUp(0)) {
            Attack();
        }
    }
}
