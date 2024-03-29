﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    public bool swung = false;
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
        GameMaster.Instance.maxScore = 0; //resets your kills
        base.Die();
    }
}
