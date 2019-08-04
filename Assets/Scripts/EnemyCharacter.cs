using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    Vector3 playerPosition;
    Rigidbody2D rb;
    GameMaster gm;


    // Start is called before the first frame update
    void Start() {
        playerPosition = GameMaster.Instance.playerRef.transform.position;
        rb = GetComponent<Rigidbody2D>();
        gm = GameMaster.Instance;
        gm.enemies.Add(gameObject);

        float x = Random.Range(3f, 7f);
        float y = Random.Range(3f, 6f);

        if (Random.Range(0, 2) > 0) {
            x = -x;
        }

        if (Random.Range(0, 2) > 0) {
            y = -y;
        }

        transform.position = new Vector3(x, y, 0);
        Debug.Log(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //rb.MovePosition((transform.position - player.transform.position)*10);        
//        rb.AddForce((playerPosition - transform.position ) * 1f);
    }

    public override void Die() {
        gm.enemies.Remove(gameObject);
        gm.checkEndCondition();
        base.Die();
    }

}
