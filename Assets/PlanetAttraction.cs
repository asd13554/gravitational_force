using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetAttraction : MonoBehaviour
{
    public Rigidbody rb;
    private const float G = 6.67f;
    public static List<PlanetAttraction> pAttraction;

    void AttacterFormular( PlanetAttraction other)
    {
        Rigidbody rbOther = other.rb;
        Vector3 direction = rb.position - rbOther.position;

        float distance = direction.magnitude;
        // F = G * ( M1*m2 ) / D^2
        float forceMagnitude = G * (rb.mass * rbOther.mass) / Mathf.Pow(distance, 2);
        
        Vector3 forceDir = direction.normalized * forceMagnitude;
        
        rbOther.AddForce(forceDir);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (var attraction in pAttraction)
        {
            if (attraction != this)
            {
                AttacterFormular(attraction);
            }
        }
    }

    private void OnEnable()
    {
        if (pAttraction == null)
        {
            pAttraction = new List<PlanetAttraction>();
        }
        pAttraction.Add(this);
        
    }

    private void Start()
    {
        //GetComponent<Rigidbody>().AddForce(100,0,0);
    }
}
