using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {
    public GameObject bladeTrailPrefab;


    public bool isCutting = false;
    private GameObject currentBladeTrail;
    Rigidbody2D rb;
    private CircleCollider2D circleCollieder;
    Camera cam;

    public float minCuttingVelocity = .001f;
    private Vector2 prePos;

    void Start()
	{
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        circleCollieder = GetComponent<CircleCollider2D>();
	}

	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            StartCutting();    
        }
        else if(Input.GetMouseButtonUp(0))
        {
            StopCutting();
            
        }
        if(isCutting)
        {
            UpdateCut();
        }
	}

    void UpdateCut()
    {
        Vector2 newPos = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPos;

        float velocity = (newPos - prePos).magnitude * Time.deltaTime;
        if(velocity > minCuttingVelocity)
        {
            circleCollieder.enabled = true;
        }else{
            circleCollieder.enabled = false;
        }
        prePos = newPos;
    }

    void StartCutting()
    {
        isCutting = true;
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
        circleCollieder.enabled = false;
    }

    void StopCutting()
    {
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 2f);
        circleCollieder.enabled = false;
    }

}
