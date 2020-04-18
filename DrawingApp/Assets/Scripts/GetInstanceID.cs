using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInstanceID : MonoBehaviour
{
    private GameObject Controller;
    public List<GameObject> ListOfLines = new List<GameObject>();

    void Start()
    {
        
    //this.name = GetInstanceID().ToString();
    Controller = GameObject.Find("Controller");
    //ListOfLines = Controller.GetComponent;
    print(this.name);

           

        
    }

    
}
