
using UnityEngine;

public class Destroy : MonoBehaviour
{
    GroundSpawn groundSpawn;
    // Start is called before the first frame update
    void Start()
    {
      groundSpawn = GameObject.FindObjectOfType<GroundSpawn>();
    }

    private void OnTriggerExit(Collider other)
    {
       groundSpawn.SpawnGround();
       Destroy(gameObject, 2);
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
