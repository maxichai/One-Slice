using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Vector3 mouse;
    Vector3 mouse2;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.position);
        mouse = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mouse.x, mouse.y, -9);

        } else if (Input.GetMouseButton(0))
        {
            mouse2 = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            mouse2.Normalize();
            float rot_z = Mathf.Atan2(mouse2.y, mouse2.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);           
        }
        
    }
}
