using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Vector3 mouse;
    public GameObject slashPrefab;
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
            Debug.Log(mouse.x + " " + mouse.y + " " + mouse.z);
            GameObject a = Instantiate(slashPrefab) as GameObject;
            a.transform.position = transform.position;

        }
        
    }
    Vector3 mousePosition()
    {
        return mouse;
    }
}
