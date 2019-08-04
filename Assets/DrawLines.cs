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
    GameObject rayTarget;
    // Start is called before the first frame update
    Boolean swung = false;

    private void Start()
    {
    }

    private void SpawnLineGenerator()
    {
        GameObject newLineGen = Instantiate(lineGeneratorPrefab);
        LineRenderer lRend = newLineGen.GetComponent<LineRenderer>();

        lRend.SetPosition(0, new Vector3(0, 0, 0));
    }

    public void Swing() {
        if (Input.GetMouseButtonDown(0)) {
            newLineGen = Instantiate(lineGeneratorPrefab);
            lRend = newLineGen.GetComponent<LineRenderer>();
            mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 spawn = new Vector3(mouse.x, mouse.y, -9);
            lRend.SetPosition(0, spawn);
        }
        else if (Input.GetMouseButton(0)) {
            mouse2 = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            lRend.SetPosition(1, mouse2);
        }
        else if (Input.GetMouseButtonUp(0)) {
            swung = true;
            Destroy(newLineGen);
            Vector3 spawn = new Vector3(mouse.x, mouse.y, -9);
            mouse2 = lRend.GetPosition(1) - spawn;
            mouse2.Normalize();
            float rot_z = Mathf.Atan2(mouse2.y, mouse2.x) * Mathf.Rad2Deg;
            GameObject a = Instantiate(slashPrefab, spawn, Quaternion.identity);
            a.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            Destroy(a, 0.3f);
            // Bit shift the index of the layer (8) to get a bit mask
            int layerMask = 1 << 8;

            // This would cast rays only against colliders in layer 8.
            // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
            layerMask = ~layerMask;
            // Does the ray intersect any objects excluding the player layer
            RaycastHit2D hit = Physics2D.Raycast(mouse, mouse2, 100);
            RaycastHit2D hit2 = Physics2D.Raycast(mouse, mouse2 * -1, 100);
            // Debug.DrawRay(mouse, mouse2*100, Color.blue, 10f);
            // Debug.DrawRay(mouse, mouse2 * -100, Color.blue, 10f);
            if (hit.collider != null) {
                Debug.Log("Detected someone!");
                RaycastHit2D[] hitarr = Physics2D.RaycastAll(mouse, mouse2, 100, layerMask);
                Debug.Log("I see " + hitarr.Length + " targets.");
                for (int i = 0; i < hitarr.Length; i++) {
                    rayTarget = hitarr[i].collider.gameObject;
                    Debug.Log("Destroying " + rayTarget.name + ".");
                    Character c = rayTarget.GetComponent<Character>();
                    c.Health -= 10;
                }
            }
            if (hit2.collider != null) {
                //Debug.Log("Detected someone!");
                RaycastHit2D[] hitarr2 = Physics2D.RaycastAll(mouse, mouse2 * -1, 100, layerMask);
                //Debug.Log("I see " + hitarr2.Length + " targets.");
                for (int i = 0; i < hitarr2.Length; i++) {
                    rayTarget = hitarr2[i].collider.gameObject;
                    //Debug.Log("Destroying " + rayTarget.name + ".");
                    Character c = rayTarget.GetComponent<Character>();
                    c.Health -= 10;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!swung) {
            Swing();
        }        
    }
}
