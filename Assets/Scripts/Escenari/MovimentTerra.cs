using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MovimentTerra : MonoBehaviour
{   
    [SerializeField]
    public float velocitatX = 0.1f;
    [SerializeField]
    public float velocitatY = 0.1f;

    void Update()
    {
        float OffsetX = Time.time * velocitatX;
        float OffsetY = Time.time * velocitatY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);
        
    }
    
}
