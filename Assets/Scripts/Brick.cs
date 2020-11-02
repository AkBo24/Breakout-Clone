using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private int numHits = 1;
    [SerializeField] private int points;

    
    // Start is called before the first frame update
    void Start()
    {
        // numHits = 1;
        points  = 100;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other) {
        if( --numHits <= 0)
            Destroy(gameObject);
    }
}
