using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventManager : MonoBehaviour
{
    public static event Action ExampleEvent;

    private void Start()
    {
        
    }
    private void Update()
    {
        if(ExampleEvent != null)
        {
            ExampleEvent();
        }
    }

   
}
