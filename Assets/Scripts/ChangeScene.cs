using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeScene : MonoBehaviour
{
    public XRGrabInteractable interactable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(interactable.isSelected)
        SceneManager.LoadScene("Main_Room");
    }
}
