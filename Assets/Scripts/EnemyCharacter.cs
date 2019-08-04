using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    Vector3 playerPosition;
    Rigidbody2D rb;   

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameMaster.Instance.playerRef.transform.position;
        rb = GetComponent<Rigidbody2D>();
        GameMaster.Instance.enemies.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //rb.MovePosition((transform.position - player.transform.position)*10);
        
        rb.AddForce((playerPosition - transform.position ) * 1f);
    }

    public override void Die() {
        GameMaster.Instance.maxScore += 1;
        GameMaster.Instance.enemies.Remove(gameObject);
        base.Die();
    }
}
