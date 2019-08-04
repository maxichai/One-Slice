using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    bool swung = false;
    public Animator anim;

    public void Attack() {
        anim.SetTrigger("Attack");
    }

    void Update() {
        if (Input.GetMouseButtonUp(0)) {
            if (!swung) {
                Attack();
                swung = true;
            }
        }
    }

    private void Start() {
        //OnHealthChange();
        GameMaster.Instance.playerRef = gameObject;       
    }

    public override void OnHealthChange() {
        base.OnHealthChange();
    }

    public override void Die() {
        //Debug.Log("Advanced dying");
        GameMaster.Instance.checkEndCondition();
        base.Die();
    }
}
