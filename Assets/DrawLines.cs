using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour
{
    [SerializeField]
    private GameObject lineGeneratorPrefab;
    [SerializeField]
    private GameObject slashPrefab;
    Vector3 mouse;
    Vector3 mouse2;
    GameObject newLineGen;
    LineRenderer lRend;
    // Start is called before the first frame update
    private void Start()
    {
    }

    private void SpawnLineGenerator()
    {
        GameObject newLineGen = Instantiate(lineGeneratorPrefab);
        LineRenderer lRend = newLineGen.GetComponent<LineRenderer>();

        lRend.SetPosition(0, new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            newLineGen = Instantiate(lineGeneratorPrefab);
            lRend = newLineGen.GetComponent<LineRenderer>();
            mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 spawn = new Vector3(mouse.x, mouse.y, -9);
            lRend.SetPosition(0, spawn);
        }
        else if (Input.GetMouseButton(0))
        {
            mouse2 = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            lRend.SetPosition(1, mouse2);

            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Destroy(newLineGen);
            Vector3 spawn = new Vector3(mouse.x, mouse.y, -9);
            mouse2 = lRend.GetPosition(1) - spawn;
            mouse2.Normalize();
            float rot_z = Mathf.Atan2(mouse2.y, mouse2.x) * Mathf.Rad2Deg;
            GameObject a = Instantiate(slashPrefab, spawn, Quaternion.identity);
            a.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            Destroy(a, 0.3f);
        }
    }
}
