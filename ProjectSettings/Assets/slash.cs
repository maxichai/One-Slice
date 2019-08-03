using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slash : MonoBehaviour
{
    private Vector2 screenBounds;
    public gameObject player;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.4f;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.GetComponent.mousePosition(), speed);
    }
}
