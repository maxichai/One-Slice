﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSetter : MonoBehaviour
{
    public Text txt; 
    // Start is called before the first frame update
    void Start()
    {
        txt.text = "Ninjas killed: " + GameMaster.Instance.maxScore;
    }
}
