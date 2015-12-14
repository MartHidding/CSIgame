using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class PuzzleA : MonoBehaviour {
 
    public int puzzleId = 1;

    public GameObject startPos;

    public GameObject num0;
    public GameObject num1;
    public GameObject num2;
    public GameObject num3;
    public GameObject num4;
    public GameObject num5;
    public GameObject num6;
    public GameObject num7;
    public GameObject num8;
    public GameObject num9;

    public GameObject theCode;

    public bool softswitch;

    public bool puzzleStart; 

    public int PuzzleSize = 1;
    public float theDistance;
    public int nextNameNumber;
    public bool UpdateArray = false;
    public int[] codeArrayinput;
    public int[] codeArraySolution;

   
	// Use this for initialization
    void Start()
    {

    }

   
	
	// Update is called once per frame
	void Update () {

        if (puzzleStart)
        {
         
            if (softswitch)
            {
               
                for (int i = 0; i < 5; i++)
                {
                 theDistance = theDistance +2;
                 theCode = (GameObject)Instantiate(num0, new Vector3(theDistance, 0, 0), Quaternion.Euler(0, 180, 0));
                    softswitch = false;
                    theCode.name = "num" + nextNameNumber;
                    theCode.tag = "partofPuzzleA";
                    nextNameNumber++;

                }
            }
        }



        if (UpdateArray)
        {
            UpdateArray = false;
            codeArrayinput = new int[PuzzleSize];
            codeArraySolution = new int[PuzzleSize];
        }
     

        if (codeArrayinput == codeArraySolution)
        {
            Debug.Log("Puzzle Completed");
        }

	}
}

