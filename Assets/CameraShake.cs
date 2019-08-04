using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform camTransform;
    private float shakeDuration = 1.0f;
    private float shakeAmount = 0.7f;
    private float decreaseFactor = 1.0f;
    Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        camTransform = Camera.main.transform;
        originalPos = camTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (shakeDuration > 0)
            {
                camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
                shakeDuration -= Time.deltaTime * decreaseFactor;
            } else
            {
                shakeDuration = 0f;
                camTransform.localPosition = originalPos;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(transform.position);
            Debug.Log("Random: " + originalPos + Random.insideUnitSphere * shakeAmount);
        }
        
    }

    public void TriggerShake()
    {
        shakeDuration = 2.0f;
    }
}
