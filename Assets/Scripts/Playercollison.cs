
using UnityEngine;

public class Playercollison : MonoBehaviour
{
    public Movement movement;
    void OnCollisionEnter(Collision collisoninfo)
    {
        if (collisoninfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }

        
    }
}
