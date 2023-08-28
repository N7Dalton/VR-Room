using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeUpdate : MonoBehaviour
{
    [SerializeField] TMP_Text currentTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime.text = DateTime.Now.ToString();
    }
}
