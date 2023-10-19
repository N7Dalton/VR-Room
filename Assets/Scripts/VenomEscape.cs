using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomEscape : MonoBehaviour
{
   
    public GameObject Spawn1;
  
    public GameObject Venom;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(60);

    }
    public void VenomEscapeEvent()
    {
        Venom.transform.position = Spawn1.transform.position;
        
    }
}
