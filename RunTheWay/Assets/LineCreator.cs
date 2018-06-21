using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour {
    public GameObject[] btns;


    public GameObject[] linePrefab;

    private GameObject cur_linePrefab;

    private List<GameObject> gos = new List<GameObject>();

    private void Start()
    {
        cur_linePrefab = linePrefab[1];
    }

    Line activeLine;
    bool isLineBegin(){
        return (Input.GetMouseButtonDown(0)) 
            ;//|| (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began);
    }

    bool isLineEnd(){
        return (Input.GetMouseButtonUp(0)) 
            ; //||  (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended);
        
    }

    bool isLineReset()
    {
        return Input.GetMouseButton(2) ||  (Input.touchCount > 2);
    }


	// Update is called once per frame
	void Update () {
        //  if click a button
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            for (int i = 0; i < btns.Length; i++){
                if( btns[i].transform.position.x -.5f < p.x 
                   && btns[i].transform.position.x +.5f > p.x
                   && btns[i].transform.position.y +.5f > p.y 
                   && btns[i].transform.position.y -.5f < p.y
                  ){
                    cur_linePrefab = linePrefab[i];
                    Debug.Log(i);
                    return;
                }

            }
        }

        if(isLineBegin()){
            GameObject gameObject = Instantiate(cur_linePrefab);
            gos.Add(gameObject);
            activeLine = gameObject.GetComponent<Line>();
        }
        if(isLineEnd()){
            activeLine = null;
        }

        if (isLineReset())
        {
            foreach (GameObject go in gos)
            {
                go.GetComponent<Line>().clearLine();
                Destroy(go);
            }
            gos.Clear();
        }
        else
        if(activeLine != null){
            Vector2 Pos;
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);                
            }
            else{
                Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            activeLine.UpdateLine(Pos);
        }

	}
}
