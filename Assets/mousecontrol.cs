using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousecontrol : MonoBehaviour
{
    private LineRenderer line;
    private Vector3 startpoint;
    private Vector3 endpoint;
    private Vector3 point1;
    private Vector3 point2;
    private Vector3 wordstartposition;
    private Vector3 wordendposition;
    private Vector3 center;
    private Vector3 halfExtents;
    private List<Collider> GetColliders;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        GetColliders = new List<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        //鼠标按下，获取画线的起点，根据射线检测碰撞，得出地图的上框选位置的起点
        if (Input.GetMouseButtonDown(0)) {
            foreach (Collider c in GetColliders) {
                Debug.Log(c);
            }
            GetColliders.Clear();
            line.enabled = true;
            startpoint = Input.mousePosition;
            startpoint.z = 1;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1 << LayerMask.NameToLayer("Ground"))) {
                wordstartposition = hit.point;
            }

        }
        //鼠标长按，获取画线的终点
        if (Input.GetMouseButton(0)) {
            endpoint = Input.mousePosition;
            endpoint.z = 1;
            point1 = new Vector3(startpoint.x, endpoint.y, 1);
            point2 = new Vector3(endpoint.x, startpoint.y, 1);
            trall();
        }
        //鼠标松开，根据射线检测碰撞，得出地图的上框选位置的终点
        if (Input.GetMouseButtonUp(0)) {
            line.enabled = false;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1 << LayerMask.NameToLayer("Ground")))
            {
                wordendposition = hit.point;
            }
            choise();

        }
    }

    public void trall() {
        line.SetPosition(0, Camera.main.ScreenToWorldPoint(startpoint));
        line.SetPosition(1, Camera.main.ScreenToWorldPoint(point2));
        line.SetPosition(2, Camera.main.ScreenToWorldPoint(endpoint));
        line.SetPosition(3, Camera.main.ScreenToWorldPoint(point1));

    }

    public void choise() {
        center = new Vector3((wordendposition.x + wordstartposition.x) * 0.5f, 6f, (wordendposition.z + wordstartposition.z) * 0.5f);
        halfExtents = new Vector3(Mathf.Abs(wordendposition.x-wordstartposition.x)*0.5f,6f, Mathf.Abs(wordendposition.z - wordstartposition.z) * 0.5f);
        Collider[] colliders = Physics.OverlapBox(center, halfExtents);
        foreach (Collider collider in colliders) {
            if (collider.name != "Plane") {
                Debug.Log(collider);
                GetColliders.Add(collider);
            }
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(center, halfExtents*2);
    }
}
