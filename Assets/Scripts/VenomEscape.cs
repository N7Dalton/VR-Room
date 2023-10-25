using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomEscape : MonoBehaviour
{
   
    public GameObject Spawn1;
  
    public GameObject Venom;
    public bool venomInCage;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("VenomEscapeEvent", 1,1);
       
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
       if (!venomInCage)
        {
          transform.position = new Vector3(130, 311, -187);
        }
        
    }
}
