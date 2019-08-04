using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    Vector3 playerPosition;
    Rigidbody2D rb;
    GameMaster gm;


    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameMaster.Instance.playerRef.transform.position;
        rb = GetComponent<Rigidbody2D>();
        gm = GameMaster.Instance;
        gm.enemies.Add(gameObject);

        transform.position = new Vector3(Random.Range(-7, 7), Random.Range(-6, 6), 0);        
    }

    // Update is called once per frame
    void Update()
    {
        //rb.MovePosition((transform.position - player.transform.position)*10);        
        rb.AddForce((playerPosition - transform.position ) * 1f);
    }

    public override void Die() {
        gm.maxScore += 1;
        gm.enemies.Remove(gameObject);
        gm.checkEndCondition();
        base.Die();
    }

}
