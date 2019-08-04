using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public float fadeSpeed = 0.5f;
    public float minTime = 0.1f;
    public float maxTime = 5f;

    public void transition(string sceneName) {
        Initiate.Fade(sceneName, Color.black, fadeSpeed);
    }
    public void transitionRandom(string sceneName) {
        Initiate.Fade(sceneName, Color.black, Random.Range(minTime, maxTime));
    }
}
