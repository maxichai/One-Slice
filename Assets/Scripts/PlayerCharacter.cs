using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    public override void OnHealthChange() {
        base.OnHealthChange();

        if (Health <= 0) {
            Initiate.Fade("00 Main Menu", Color.black, 0.5f);
        }
    }
}
