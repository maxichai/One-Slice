using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform camTransform;
    private float shakeDuration = 0f;
    private float shakeAmount = 0.2f;
    private float decreaseFactor = 2.0f;
    Vector3 originalPos;

    bool swung = false;
    // Start is called before the first frame update
    void Awake()
    {
        camTransform = Camera.main.transform;
        originalPos = camTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeDuration > 0)
        {
            Vector3 position = new Vector3(originalPos.x + Random.Range(0.0f, 1.0f) * shakeAmount, originalPos.y, originalPos.z);
            camTransform.localPosition = position;
            Debug.Log("Camera shake: " + camTransform.localPosition);
            shakeDuration -= Time.deltaTime * decreaseFactor;
        } else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
            if (Input.GetMouseButtonUp(0) && !swung && GameMaster.Instance.playerRef != null)
            {
                shakeDuration = 1.0f;
                swung = true;
            }
        }
    }

    public void TriggerShake()
    {
        shakeDuration = 2.0f;
    }
}
