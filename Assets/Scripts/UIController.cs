using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject successText;
    public GameObject failureText;

    private static UIController _instance;
    public static UIController Instance {
        get {
            return _instance;
        }

    }

    private void Start() {

        if (UIController.Instance != null) {
            Destroy(this);
        }
        else {
            _instance = this;
        }
    }
}
