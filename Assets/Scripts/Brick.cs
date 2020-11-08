using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private int numHits = 1;
    [SerializeField] private int points = 1000;
    [SerializeField] private Vector3 rotator;

    Material origMaterial, HitMaterial;
    Renderer render;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(rotator * (transform.position.x + transform.position.y) * 0.1f);
        render = GetComponent<Renderer>();
        origMaterial = render.sharedMaterial;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotator * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other) {
        --numHits;
        if( numHits <= 0) {
            GameManager.Instance.score += points;
            Destroy(gameObject);
        }
        
        render.sharedMaterial = HitMaterial;

        //System delay, calls after 0.05 seconds 
        Invoke("RestoreMaterial", 0.05f);
    }

    void RestoreMaterial() {
        render.sharedMaterial = origMaterial;
    }
}
