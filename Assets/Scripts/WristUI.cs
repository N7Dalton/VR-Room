using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WristUI : MonoBehaviour
{
    public GameObject canvas;
    public GameObject Hand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Hand.transform.localRotation.eulerAngles.z);
        if (Hand.transform.localRotation.eulerAngles.z <= 0 || Hand.transform.localRotation.eulerAngles.z >= -90)
        {
            canvas.SetActive(true);
        }
        else
        {
             canvas.SetActive(false);
        }
    }
}
