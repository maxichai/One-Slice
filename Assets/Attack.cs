using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Vector3 mouse;
    Vector3 mouse2;
    public GameObject slashPrefab;
    GameObject a;
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
            Vector3 spawn = new Vector3(mouse.x, mouse.y, -9);
            transform.position = spawn;
        } else if (Input.GetMouseButton(0))
        {
            mouse2 = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            mouse2.Normalize();
            float rot_z = Mathf.Atan2(mouse2.y, mouse2.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        } else if (Input.GetMouseButtonUp(0))
        {
            /*
            mouse2 = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            mouse2.Normalize();
            Vector3 spawn = new Vector3(mouse.x, mouse.y, -9);
            float rot_z = Mathf.Atan2(mouse2.y, mouse2.x) * Mathf.Rad2Deg;
            a = Instantiate(slashPrefab, spawn, Quaternion.identity);
            a.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90); */
        }
    }
}
