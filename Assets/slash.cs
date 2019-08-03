using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slash : MonoBehaviour
{
    private Vector2 screenBounds;
    public GameObject player;
    float speed;
    private Collision col;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
        Destroy(gameObject, 15f);
    }
}
