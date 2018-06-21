using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;

    List<Vector2> points;

    public void UpdateLine(Vector2 mousePos){
        if(points == null){
            points = new List<Vector2>();
            SetPoint(mousePos);
            return;
        }

        if (Vector2.Distance(points.Last() , mousePos) > .1f)
            SetPoint(mousePos);

    }

    private void SetPoint(Vector2 p)
    {
        points.Add(p);

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, p);

        if(points.Count > 1){
            edgeCollider.points = points.ToArray();
        }
    }

    public void clearLine(){
        if (points == null) return;
        lineRenderer.positionCount = 0;
        points.Clear();
        edgeCollider.Reset();
    }
}
