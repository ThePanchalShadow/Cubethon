using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolSpawn : MonoBehaviour
{
    GameObject Grounds;
    //else
    //Debug.Log($"Ground not availabe");
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Grounds = objectpool.spawn.GetPooledObject();
        Debug.Log("Grounds activated");
        //Grounds.transform.position = Grounds.transform.GetChild(0).transform.position;


        if (Grounds != null)
        {
            Debug.Log($"Ground is not null");
            Debug.Log("Grounds activated");
            Grounds.transform.position = Grounds.transform.GetChild(0).transform.position;
            Debug.Log(Grounds.transform.position);
            Grounds.SetActive(true);
        }
    }
}
