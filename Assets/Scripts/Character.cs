using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private int health = 1;
    private int maxHealth = 1;
    public int Health {
        get {
            return health;
        }
        set {
            health = Mathf.Clamp(value, 0, maxHealth);
            OnHealthChange();
        }
    }

    public int MaxHealth {
        get {
            return maxHealth;
        }
        set {
            maxHealth = Mathf.Clamp(value, 0, int.MaxValue);
            health = Mathf.Clamp(health, 0, maxHealth);
            OnHealthChange();
        }
    }

    public void Damage(int damage) {
        Health -= Mathf.Clamp(damage, 0, int.MaxValue); //should never end up adding health 
    }

    public virtual void OnHealthChange() {
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
