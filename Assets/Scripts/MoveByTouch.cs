
using UnityEngine;
using System.Threading.Tasks;


public class MoveByTouch : MonoBehaviour
{
    public Rigidbody rb; // here rigidbody is component we wanr to modify and rb is reference to use it

    public float forwardForce = 2000f;
    public float UpForce = 500f;
    public float SidewaysForce = 500f;
    public bool balltoground = true;
    public Vector3 Velocity = Vector3.zero;

    private Vector2 StartTouch;
    private Vector2 CurrentTouch;
    private Vector2 endTouch;
    private bool Stoptouch = false;

    public float swiperange;
   // public float taprange;

    //Update is called once per frame
    void Update()
    {

        Swipe2();
    }

   void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Ground")
        {
            balltoground = true;
        }
    }


    // FixedUpdate is better when messing with Physics
    void FixedUpdate()
    {
        // Add a Forward Force
        

        //if (Input.GetKey("d"))
        //{
        //    rb.AddForce(SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        //}

        //if (Input.GetKey("a"))
        //{
        //    rb.AddForce(-SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        //}

        //if (Input.GetButtonDown("Jump") && (balltoground))
        //{
        //    rb.AddForce(0, UpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        //    balltoground = false;
        //}

        //if (Input.GetButtonDown("Brake"))
        //{
        //    Velocity = rb.velocity;
        //    Debug.Log(Velocity);
        //    rb.constraints = RigidbodyConstraints.FreezePosition;
        //}

        //if (Input.GetButtonUp("Brake"))
        //{
        //    rb.constraints = RigidbodyConstraints.None;
        //    rb.velocity = Velocity;
        //}

        //if (rb.position.y < -1f)
        //{
        //    FindObjectOfType<GameManager>().EndGame();
        //}


    }


    void Swipe2()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            StartTouch = Input.GetTouch(0).position;
            //Debug.Log(StartTouch);
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            CurrentTouch = Input.GetTouch(0).position;
            Vector2 Distance = CurrentTouch - StartTouch;


            //Debug.Log(CurrentTouch);
            //Debug.Log(Distance);

             if (!Stoptouch)
             {
                if (Distance.y < -swiperange)
                {
                    Debug.Log("Down");
                    Velocity = rb.velocity;
                    rb.constraints = RigidbodyConstraints.FreezePosition;
                    Stoptouch = true;
                }

                else if (Distance.y > swiperange && (balltoground))
                {

                    Debug.Log("up");
                    //rb.AddForce(0, UpForce * Time.deltaTime, 0, ForceMode.VelocityChange);

                    rb.velocity = new Vector3(rb.velocity.x, UpForce , rb.velocity.z);
                    balltoground = false;
                    Debug.Log(balltoground);
                    
                    Stoptouch = true;
                }

                 else if (Distance.x < -swiperange)
                 {
                    Debug.Log("Left");
                    rb.velocity = new Vector3(-SidewaysForce, rb.velocity.y, rb.velocity.z);
                   // rb.AddForce(-SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                    Stoptouch = true;

                 }

                 else if (Distance.x > swiperange)
                 {
                    Debug.Log("Right");
                    rb.velocity = new Vector3(SidewaysForce , rb.velocity.y , rb.velocity.z);
                    //rb.AddForce(SidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                    Stoptouch = true;

                }
             }
         }

        if (Input.touchCount > 1 && Input.GetTouch(1).phase == TouchPhase.Ended)
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.velocity = Velocity;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Stoptouch = false;

            endTouch = Input.GetTouch(0).position;

            Vector2 Distance = endTouch - StartTouch;
            //rb.constraints = RigidbodyConstraints.None;
            //rb.velocity = Velocity;

           
        }

    }

}
