        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        ///                                                                                                 ///    
        ///                                   Gemaakt door Mart Hidding                                     ///
        ///                                  Student Informatica Stenden                                    ///
        ///                                           11-11-2015                                            ///
        ///                                                                                                 ///
        ///                           Gemaakt voor Project 4 van het eerste jaar                            ///
        ///                                         Project Innovate                                        ///
        ///                                       marthidding@gmail.com                                     ///                     ///
        ///  XboxController.cs Mapping                                         11-11-2015       Versie: 4   ///
        ///////////////////////////////////////////////////////////////////////////////////////////////////////


using UnityEngine;
using System.Collections;

public class XboxController : MonoBehaviour
{

    ///  Settings Van snelheid
    ///  Horizontal en Rotatespeed dienen als resets in het script
   
    public float PlayerMovementSpeed = 10;
    public float HorizontalSpeed = 10;
    public float PlayerRotationSpeed = 90;
    public float RotateSpeed = 90;

    public bool invertHorizontal = false;
    public bool invertRotate = false;

    public bool disableLeftTrigger = false;  
    public bool disableRightTrigger = false;

    // debugMode aan / uit
    public bool debugMode = false;

    void Start()
    {


    }

    void Update()
    {
        Movement();
        Buttons();
        Axis();


    }

    void Movement()
    {
        // Linker  AnalogStick Unity3D Input Axis Detectie "Input Axis X"
        // Rechter AnalogStick Unity3D Input Axis Detectie "4 (Horizontal), 5 (Vertical)"
        // Denk er aan dat Links en Rechts op de zelfde Axis zitten en aangestuurd worden Met + en - input.
        // Het zelfde geld voor Up en Down.

        //Vertical movement, momenteel op de Z as.
        transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * PlayerMovementSpeed);

        

        // Horizontal movement, momenteel op de X as.
        if (invertHorizontal)
        {
            PlayerMovementSpeed = HorizontalSpeed;
     
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * PlayerMovementSpeed, 0, 0);
        }
        else
        {
            PlayerMovementSpeed = -HorizontalSpeed;
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * PlayerMovementSpeed , 0, 0);
        }

        // Mocht de input na los laten nogsteeds draaien, Raise dan de dead value in de Input manager van de axis
        // in dit voorbeeld heb ik 0.8 gebruikt in de Unity3D input manager om de deadzone aan te duiden.


        if (Input.GetAxisRaw("360_Axis_RightStick_H")> 0.5|| Input.GetAxisRaw("360_Axis_RightStick_H") < -0.5)
         {
             if (invertRotate)
             {
                 PlayerRotationSpeed = RotateSpeed;
                transform.Rotate(0, Input.GetAxisRaw("360_Axis_RightStick_H") * Time.deltaTime * PlayerRotationSpeed, 0);
                Debug.Log(Input.GetAxis("360_Axis_RightStick_H") + "Vertical");
             }
             else
             {
                 PlayerRotationSpeed = -RotateSpeed;
                 transform.Rotate(0, Input.GetAxisRaw("360_Axis_RightStick_H") * Time.deltaTime * PlayerRotationSpeed, 0);
                 Debug.Log(Input.GetAxis("360_Axis_RightStick_H") + "Horizontal" );
             }
   
          
        }
    }
    void Buttons()
    {

        //De XboxController word met Draad herkent, (Wireless heeft issues).
        //Buttons in Unity3D instellen onder //Tabje = Edit>ProjectSettings>Input

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        ///                                                                                                 ///    
        ///                                           Input List                                            ///
        ///                                                                                                 ///
        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        // 360_AButton                       joystick button 0
        // 360_BButton                       joystick button 1   
        // 360_XButton                       joystick button 2
        // 360_YButton                       joystick button 3
        //
        // 360_LeftBumper                    joystick button 4
        // 360_RightBumper                   joystick button 5
        //
        // 360_BackButton                    joystick button 6
        // 360_StartButton                   joystick button 7
        //
        // 360_LeftThumbstickButton          joystick button 8
        // 360_RightThumbstickButton         joystick button 9

        // Linker  Trigger Unity3D Input Axis Detectie "Input Axis 3 (met Positief input op de axis in Script)"
        // Rechter Trigger Unity3D Input Axis Detectie "Input Axis 3 (met Negatief input op de axis in Script)"
        //
        //

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        ///                                                                                                 ///    
        ///                                           Button Mapping                                        ///
        ///                                                                                                 ///
        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        // A Button Unity3D Input Positive Button "joystick button 0"
        if (Input.GetButtonDown("360_AButton") || Input.GetKeyDown("1"))
        {
            if (debugMode) // Debug mode aan/uit voor testen van input met kleur en log.
            {
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                Debug.Log("A Button");
            }
        }

        // B Button Unity3D Input Positive Button "joystick button 1"
        if (Input.GetButtonDown("360_BButton") || Input.GetKeyDown("2"))
        {
            if (debugMode) // Debug mode aan/uit voor testen van input met kleur en log.
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                Debug.Log("B Button");
            }
        }

        // X Button Unity3D Input Positive Button "joystick button 2"
        if (Input.GetButtonDown("360_XButton") || Input.GetKeyDown("3"))
        {
            if (debugMode) // Debug mode aan/uit voor testen van input met kleur en log.
            {
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
                Debug.Log("X Button");
            }
        }

        // Y Button Unity3D Input Positive Button "joystick button 3"
        if (Input.GetButtonDown("360_YButton") || Input.GetKeyDown("4"))
        {
            if (debugMode) // Debug mode aan/uit voor testen van input met kleur en log.
            {
                gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                Debug.Log("Y Button");
            }
        }

        // Left Bumper Unity3D Input Positive Button "joystick button 4"
        if (Input.GetButtonDown("360_LeftBumper"))
        {
            if (debugMode)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.cyan;
                Debug.Log("Left Bumper!");
            }
        }

        // Right Bumper Unity3D Input Positive Button "joystick button 5"
        if (Input.GetButtonDown("360_RightBumper"))
        {
            if (debugMode)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.magenta;
                Debug.Log("Right Bumper!");
            }
        }

        // Back Button Unity3D Input Positive Button "joystick button 6"
        if (Input.GetButtonDown("360_BackButton"))
        {
            if (debugMode)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.white;
                Debug.Log("Back Button!");
            }
        }

        // Start Button Unity3D Input Positive Button "joystick button 7"
        if (Input.GetButtonDown("360_StartButton"))
        {
            if (debugMode)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.black;
                Debug.Log("Start Button!");
            }
        }
        // Left ThumbStick Unity3D Input Positive Button "joystick button 8"
        if (Input.GetButtonDown("360_LeftThumbstickButton"))
        {
            if (debugMode)
            {


                Color NColor = new Color(100, 1, 150, 1);

                gameObject.GetComponent<Renderer>().material.color = NColor;
                Debug.Log("Left Thumbstick!");

            }
        }

        // Right ThumbStick Unity3D Input Positive Button "joystick button 9"
        if (Input.GetButtonDown("360_RightThumbstickButton"))
        {
            if (debugMode)
            {


                Color NColor = new Color(10, 10, 10, 10);

                gameObject.GetComponent<Renderer>().material.color = NColor;
                Debug.Log("Right Thumbstick");

            }
        }
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                                                                                                 ///    
    ///                          Axis Mapping  - Axis AnalogSticks en Bumper Triggers                   ///
    ///                                                                                                 ///
    ///////////////////////////////////////////////////////////////////////////////////////////////////////

    void Axis()
    {

        // Linker Trigger Unity3D Input Axis Detectie "Input Axis 3"
        if (!disableLeftTrigger)
        {
            if (Input.GetAxis("360_LeftTrigger") == 1)
            {
                if (debugMode)
                {
                    Color NColor = new Color(170, 20, 10, 1);

                    gameObject.GetComponent<Renderer>().material.color = NColor;
                    Debug.Log("L-Trigger");
                }
            }
        }
        // Rechter Trigger Unity3D Input Axis Detectie "Input Axis 3"
        // Zorg er voor dat de Input Negatief herkent word zoals hier onder -1
        // Dit komt omdat de Triggers de zelfde Axis Gebruiken voor 2 knoppen.
          if (!disableRightTrigger){
        if (Input.GetAxis("360_RightTrigger") == -1)
        {
            if (debugMode)
            {
                Color NColor = new Color(70, 220, 120, 0);

                gameObject.GetComponent<Renderer>().material.color = NColor;
                Debug.Log("R-Trigger");
            }
        }
      }

         ///////////////////////////////////////////////////////////////////////////////////////////////////////
         ///                                                                                                 ///    
         ///                                    Axis Mapping  -  Dpad                                        ///
         ///                                                                                                 ///
         ///////////////////////////////////////////////////////////////////////////////////////////////////////

         // Dpad Horizontal Unity3D Input Axis Detectie "Input Axis 6"
         // Zorg er voor dat de Input Negatief herkent word zoals hier onder -1
         // Links // Dpad //
         if (Input.GetAxis("360_Axis_Dpad_H") == -1)
         {
             if (debugMode)
             {



                 Debug.Log("Dpad_Links");
             }
         }

        // Dpad Horizontal Unity3D Input Axis Detectie "Input Axis 6"
        // Zorg er voor dat de Input Negatief herkent word zoals hier onder -1
        // Rechts // Dpad //
         if (Input.GetAxis("360_Axis_Dpad_H") == 1)
        {
            if (debugMode)
            {
                

              
                Debug.Log("Dpad_Rechts");
            }
        }

         // Dpad Vertical Unity3D Input Axis Detectie "Input Axis 7"
         // Zorg er voor dat de Input Negatief herkent word zoals hier onder -1
         // Omhoog // Dpad //
         if (Input.GetAxis("360_Axis_Dpad_V") == 1)
         {
             if (debugMode)
             {


               
                 Debug.Log("Dpad_Omhoog");
             }
         }
         // Dpad Vertical Unity3D Input Axis Detectie "Input Axis 7"
         // Zorg er voor dat de Input Negatief herkent word zoals hier onder -1
         // Omlaag // Dpad //
         if (Input.GetAxis("360_Axis_Dpad_V") == -1)
         {
             if (debugMode)
             {



                 Debug.Log("Dpad_Omlaag");
             }
         }


    }
}


    ///////////////////////////////////////////////////////////////////////////////////////////////////////
    ///                                                                                                 ///    
    ///                                           Mart Hidding                                          ///
    ///                                      voor educatief gebruik                                     ///
    ///                                         11 November 2015                                        ///
    ///                                                                                                 ///
    ///////////////////////////////////////////////////////////////////////////////////////////////////////
    
