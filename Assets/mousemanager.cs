using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mousemanager : MonoBehaviour
{
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            try
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit HIT;
                Physics.Raycast(ray, out HIT);
                if (HIT.collider.CompareTag("plane"))
                {
                    agent.Resume();
                    agent.destination = HIT.point;
                }
            }
            catch
            { 
                
            }
        }
    }

}
