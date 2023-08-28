using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnUI : MonoBehaviour
{
    public GameObject MaskUI;
    public Transform cam;
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
        Instantiate(MaskUI, cam);
    }
    public void MaskUIOff()
    {
        Destroy(MaskUI);
    }
}
