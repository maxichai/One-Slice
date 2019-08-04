using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    [HideInInspector]
    public int maxScore = 0;

    // Start is called before the first frame update
    private static GameMaster _instance;
    public static GameMaster Instance {
        get {
            return _instance;
        }

    }

    private void Start() {

        if (GameMaster.Instance != null) {
            Destroy(this);
        }
        else {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
