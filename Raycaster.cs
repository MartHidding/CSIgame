using UnityEngine;
using System.Collections;

public class Raycaster : MonoBehaviour
{

    bool carrying;
    GameObject carriedObject;

    public float distance;
    public float smooth;
    public float x_RotateSpeed;
    public float y_RotateSpeed;
    public float z_RotateSpeed;

    private GameObject objHit;

    public GameObject mainCamera;
    // Use this for initialization

    public number lastTarget;

    public string inspectInfo;
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (carrying)
        {
            carry(carriedObject);
            checkDrop();

        }
        else
        {
            pickup();
            Puzzle();
            Detect();
        }
    }



    void carry(GameObject o)
    {
        o.transform.position = Vector3.Lerp(o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
        // o.transform.rotation = Quaternion.identity;
    }

    void pickup()
    {
        if (Input.GetButtonDown("360_XButton"))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Pickupable p = hit.collider.GetComponent<Pickupable>();
                if (p != null)
                {
                    carrying = true;
                    carriedObject = p.gameObject;
                    //p.gameObject.rigidbody.isKinematic = true;
                    p.gameObject.GetComponent<Rigidbody>().useGravity = false;
                }

            number n = hit.collider.GetComponent<number>();

                if (n != null)
                {
                    Debug.Log("Detected PUzzl");
                }
            }
        }

        if (Input.GetButtonDown("360_BButton"))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;



            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Pickupable p = hit.collider.GetComponent<Pickupable>();
                if (p != null)
                {
                    // Debug.Log(GetComponent<Pickupable>.inspectInfo);
                }
            }
        }

    }

    void checkDrop()
    {
        if (Input.GetButtonDown("360_XButton"))
        {
            dropObject();
        }

        if (Input.GetAxis("360_Axis_Dpad_H") == -1)
        {
            carriedObject.transform.Rotate(0, y_RotateSpeed, 0);
            Debug.Log("rotatingL");
        }
        if (Input.GetAxis("360_Axis_Dpad_H") == 1)
        {
            carriedObject.transform.Rotate(0, -y_RotateSpeed, 0);
            Debug.Log("rotatingR");
        }
        if (Input.GetAxis("360_Axis_Dpad_V") == -1)
        {
            carriedObject.transform.Rotate(0, 0, z_RotateSpeed);
            Debug.Log("rotatingU");
        }

        if (Input.GetAxis("360_Axis_Dpad_V") == 1)
        {
            carriedObject.transform.Rotate(0, 0, -z_RotateSpeed);
            Debug.Log("rotatingD");
        }

    }




    void dropObject()
    {
        carrying = false;
        //carriedObject.gameObject.rigidbody.isKinematic = false;
        carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
        carriedObject = null;
    }


    void Detect()
    {

        int x = Screen.width / 2;
        int y = Screen.height / 2;

        Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;

        

        if (Physics.Raycast(ray, out hit))
        {
            number n = hit.collider.GetComponent<number>();
            lastTarget = n;
            if (n != null)
            {
                Debug.Log("Its a hit!");
                n.selected();
            }
        }
        else
        {
            
            lastTarget.unselected();
            }
        }
      

    
    void Puzzle()
    {


        int x = Screen.width / 2;
        int y = Screen.height / 2;

        Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;
            
        if (Input.GetButtonDown("360_YButton"))
        {
     
            
            if (Physics.Raycast(ray, out hit))
            {

                number n = hit.collider.GetComponent<number>();
               

                if (n != null)
                {
                    Debug.Log("Detected PUzzl");

            
                    n.changeNumber();
                    
                }


                
            }

           
        }
        
    }

}

