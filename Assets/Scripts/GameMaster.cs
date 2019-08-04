using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    [HideInInspector]
    public int maxScore = 0;
    public GameObject playerRef;
    public List<GameObject> enemies;

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

    public void EndGame() {
        Initiate.Fade("00 Main Menu", Color.black, 1f);
    }

    public void checkEndCondition() {
        //Debug.Log("Enemy count " + enemies.Count);
        if ((enemies.Count == 0 && SceneManager.GetActiveScene().name == "Game 2")|| playerRef.GetComponent<Character>().Health<= 0) {
            enemies.Clear();

            if (playerRef != null && playerRef.GetComponent<Character>().Health> 0) {
                UIController.Instance.successText.SetActive(true);
                GameMaster.Instance.maxScore += 2;
            }
            else {
                UIController.Instance.failureText.SetActive(true);
            }
            Invoke("EndGame", 3);
        }
    }

    private void Update() {
    }
}
