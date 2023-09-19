using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnUI : MonoBehaviour
{
    public GameObject MaskUI;
    public Transform cam;
    public float scaleTime = 3f;
    public bool maskOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void MaskUIOn()
    {
        if (MaskUI == null)
        {
            Instantiate(MaskUI, cam);
            maskOn = true;
        }
        else
        {
            Destroy(MaskUI);
            maskOn = false;
        }
       
    }
   
}
