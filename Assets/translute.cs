using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class translute : MonoBehaviour
{
    public static translute instance;
    private void Awake()
    {
        print("2222");
        if (instance != null)
        {
            Destroy(instance);
        }
        instance = this;
    }

    public enum tran { same, defenter }
    public tran fangshi;
    public translutepos.pos pos;
    private NavMeshAgent agent;
    public List<string> s = new List<string>();


    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        agent = other.GetComponent<NavMeshAgent>();
        translutepos[] translutepos = FindObjectsOfType<translutepos>();
        for (int i = 0; i < translutepos.Length; i++) {
            if (pos == translutepos[i].p) {
                other.transform.SetPositionAndRotation( translutepos[i].transform.position, Quaternion.identity);
                agent.Stop();
            }
        }
    }
}
