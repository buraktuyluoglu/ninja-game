using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    public float xMin, xMax;

    // Update is called once per frame
    void Update()
    {
        // Karakterin x koordinatını sınırlar içinde tut
        float x = Mathf.Clamp(transform.position.x, xMin, xMax);
        // Karakterin pozisyonunu güncelle
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
