using UnityEngine;

public class GroundSpawn : MonoBehaviour
{

    public GameObject Grounds;
    Vector3 SpawnPoint;

    public int defaultGround;

    public void SpawnGround()
    {
        GameObject temp = Instantiate(Grounds, SpawnPoint, Quaternion.identity);
        SpawnPoint = temp.transform.GetChild(1).transform.position;

    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < defaultGround; i++)
        {
            SpawnGround();
        }

    }
}
