using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    public Color colorChange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseEnter()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = colorChange;
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.gray;
    }
}
