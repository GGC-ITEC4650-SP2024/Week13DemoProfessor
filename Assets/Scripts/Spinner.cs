using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public Vector3 spin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // FixedUpdate is called once per physics caluclation (frame)
    void FixedUpdate()
    {
        transform.eulerAngles += spin * Time.fixedDeltaTime;
    }
}
