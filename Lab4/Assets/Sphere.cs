﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{

    public Color colorChange;
    private Rigidbody rBody;

    public float force = 3;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
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
        gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    private void OnMouseDown()
    {
        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(myRay, out hitInfo))
            rBody.AddForce(-hitInfo.normal * force, ForceMode.Impulse);
    }

}
