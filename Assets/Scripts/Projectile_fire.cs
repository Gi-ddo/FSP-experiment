using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_fire : MonoBehaviour
{
    [Header("Generic Variables")]
    public LineRenderer Path;
    public Transform end_point;
    public Transform start_point;
    private Camera cam;
    public LayerMask layer;
    public GameObject cursor_indicator;
    public float fire_rate;
    public float next_fire;
    private Vector3 initial_velocity;
    private Rigidbody rb;
    [Header("Setter Variables")]
    public int Path_length;
    public float time_;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main; // this is cam = GameObject.FindObjectWithTag('Main Camera').GetComponent<Camera>();
        Path.positionCount = Path_length;
    }


    // Returns the launch velocity of the projectile
    Vector3 Calculate_velocity(Vector3 target, Vector3 origin, float time)
    {
        // Total V3 distance of trajection
        Vector3 trajection_distance = target - origin;

        //Distance travelled on XZ plane
        Vector3 distanceXZ = trajection_distance;
        distanceXZ.y = 0f;

        //Distance travelled on Y plane
        float distanceY = trajection_distance.y;

        // The magnitude of the distance travelled on XZ plane
        float XZ_dist_mag = distanceXZ.magnitude;

        // Implementation of formula : Vx = x/t
        float Vxz = XZ_dist_mag / time;

        //Implementation of formula: Vy = y/t +1/2gt^2

        float Vy = distanceY / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceXZ.normalized;
        result = result * Vxz;
        result.y = Vy;

        return result;
    }

    //Returns the distance travalled along the trajctory in the XYZ plane
    Vector3 CalculatePos(Vector3 initial_Velocity, float t)
    {
        Vector3 Vxz = initial_Velocity;
        Vxz.y = 0f;

        // Gets the total distance travelled using kinamatic equations For XZ and Y planes respectively
        Vector3 result = start_point.position + initial_Velocity * t;
        float Y_pos = -0.5f * Mathf.Abs(Physics.gravity.y) * (t*t) + initial_Velocity.y * t + start_point.position.y;
        result.y = Y_pos;

        return result;
    }

   
    void Trajectory_setup()
    {
        Ray cursor_ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(cursor_ray, out hit, 100f, layer))
        {
            // Makes the target cursor appear when we aim
            cursor_indicator.SetActive(true);
            Path.enabled = true;
            cursor_indicator.transform.position = hit.point + hit.normal * 0.1f;
            cursor_indicator.transform.LookAt(hit.point - hit.normal);


            //Makes the laucher and rotate to the direction of the initial velocity
            initial_velocity = Calculate_velocity(hit.point, start_point.position, time_);
            Draw_path(initial_velocity);
            transform.rotation = Quaternion.LookRotation(initial_velocity);


            Shoot();
        }
        else
        {
            cursor_indicator.SetActive(false);
            Path.enabled = false;
        }
    }

    //Function that draws the predicted path arc on the scene
    void Draw_path(Vector3 Vi)
    {
        for (int i = 0; i < Path_length; i++)
        {
            float t_ = i / (float)Path_length;
            Vector3 pos = CalculatePos(Vi, t_);
            Path.SetPosition(i, pos);
        }
    }

    void Shoot()
    {
        Ray cursor_ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(cursor_ray, out hit, 100f, layer))
        {
            initial_velocity = Calculate_velocity(hit.point, start_point.position, time_);
            if (Input.GetMouseButtonDown(0) && Time.time > next_fire)
            {
                next_fire = Time.time + fire_rate;

                //object pooling in action
                GameObject projectile_object = Object_pooler.current.Get_polled_object();
                rb = projectile_object.GetComponent<Rigidbody>();

                if(projectile_object!= null)
                {
                    projectile_object.transform.position = start_point.position;
                    projectile_object.transform.rotation = start_point.rotation;
                    projectile_object.SetActive(true);
                    rb.velocity = initial_velocity;
                }
            }
        }
    }

    void Update()
    {  
        if (Input.GetKey(KeyCode.Mouse1))
        {
           
            Path.enabled = true;
            Trajectory_setup();
        } else
        {
            Shoot();
        } 
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            cursor_indicator.SetActive(false);
            Path.enabled = false;
        }
    }

    

}

    
