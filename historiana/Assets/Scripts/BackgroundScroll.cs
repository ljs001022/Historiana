using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

    Material mat;
    float currentYoffset = 0;
    float speed = 0.4f;
    private void Awake()
    {
        
    }
    // Use this for initialization
    void Start () {
        mat = GetComponent<SpriteRenderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        currentYoffset += speed * Time.deltaTime;
        mat.mainTextureOffset = new Vector2(0, currentYoffset);
	}
}
