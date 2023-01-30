using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class objectpool : MonoBehaviour
{
    public static objectpool spawn;

    public List<GameObject> pooledObjects = new List<GameObject>();
    public int amountTopool;

    [SerializeField] private GameObject groundsprefab;

    private void Awake()
    {
        if(spawn == null)
        {
            Debug.Log("spawn is null");
            spawn = this;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
       
        for (int i = 0; i < amountTopool; i++)
        {
            GameObject obj = Instantiate(groundsprefab);
            Debug.Log("Grounds Created");    
            obj.SetActive(false);
            Debug.Log("deactivated");
            pooledObjects.Add(obj);
        }
        
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountTopool; i++) {
            
            if (!pooledObjects[i].activeInHierarchy)
            {
                Debug.Log($"Object Pulled");
                Debug.Log($"{pooledObjects[i].name}");
                return pooledObjects[i];
            }
        }
        return null;
    }

    
}
