using UnityEngine;
using System.Collections;

public class MasterLock : MonoBehaviour {

   /// Nummers van de Puzzel hier inslepen
   public GameObject numberObj1 ;
   public GameObject numberObj2 ;
   public GameObject numberObj3 ;
   public GameObject numberObj4 ;
   public GameObject numberObj5 ;

   /// Variables voor het vasthouden van nummers die opgevraagt worden
   private int num1 ;
   private int num2 ;
   private int num3 ;
   private int num4 ;
   private int num5 ;

   /// CodeSlot Combinatie instellen
   public int pwn1 = 0 ;
   public int pwn2 = 0 ;
   public int pwn3 = 0 ;
   public int pwn4 = 0 ;
   public int pwn5 = 0 ;

   /// Boolean voor het vergelijken van Num 1 met pwn 1 ect.
   public bool check1 ;
   public bool check2 ;
   public bool check3 ;
   public bool check4 ;
   public bool check5 ;

	void Start () {}
	
	void Update () {

        /// Opvragen van het theNumber variable uit het Numbers script.
        num1 = numberObj1.GetComponent<number>().theNumber;
        num2 = numberObj2.GetComponent<number>().theNumber;
        num3 = numberObj3.GetComponent<number>().theNumber;
        num4 = numberObj4.GetComponent<number>().theNumber;
        num5 = numberObj5.GetComponent<number>().theNumber;


        // als number 1 gelijk staat aan password 1 true
        if (num1 == pwn1)
        {
            check1 = true;
        }
        else
        {
            check1 = false;
        }

        if (num2 == pwn2)
        {
            check2 = true;
        }
        else
        {
            check2 = false;
        }
        if (num3 == pwn3)
        {
            check3 = true;
        }
        else
        {
            check3 = false;
        }
        if (num4 == pwn4)
        {
            check4 = true;
        }
        else
        {
            check4 = false;
        }
        if (num5 == pwn5)
        {
            check5 = true;
        }
        else
        {
            check5 = false;
        }



        //Check of check12345 true zijn
        if (check1 && check2 && check3 && check4 && check5)
        {

        Debug.Log("12345 True");
        // uit tevoeren code
     }
   }
}
