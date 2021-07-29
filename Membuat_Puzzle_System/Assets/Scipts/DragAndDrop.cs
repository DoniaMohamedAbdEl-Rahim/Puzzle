using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{

    public PiecesClass[] puzzle;
    public PiecesClass[] correctPuzzle;
    [SerializeField]
    Image _placeHolder1;
    [SerializeField]
    Image _placeHolder2;
    [SerializeField]
    AudioManager audioManager;
    void Start()
    {

        float distance = 300.0f;
        float placeholder1_width = _placeHolder1.transform.position.x - (_placeHolder1.transform.position.x - 300);
        float placeholder1_heigh = _placeHolder1.transform.position.y - 400;
        float placeholder2_width = _placeHolder2.transform.position.x - 200;
        float placeholder2_heigh = _placeHolder2.transform.position.y - 400;

        for (int i = 0; i < correctPuzzle.Length; i++)
        {
            correctPuzzle[i].obj.AddComponent<BoxCollider2D>().isTrigger = true;
            //initial position for correct puzzle
            correctPuzzle[i].initialPos = correctPuzzle[i].obj.transform.position;
            //Target position for puzzle is the initial position of the correct puzzle
            puzzle[i].TargetPos = correctPuzzle[i].initialPos;

            if (i % 2 == 0)
            {
                // Debug.Log(i);
                puzzle[i].initialPos.x = placeholder1_width;
                puzzle[i].initialPos.y = placeholder1_heigh;
                puzzle[i].obj.transform.position = puzzle[i].initialPos;
                placeholder1_heigh += distance;
            }
            else
            {
                //  Debug.Log(i);
                puzzle[i].initialPos.x = placeholder2_width;
                puzzle[i].initialPos.y = placeholder2_heigh;
                puzzle[i].obj.transform.position = puzzle[i].initialPos;
                placeholder2_heigh += distance;
            }
            //Debug.Log(puzzle[i].initialPos);
        }

    }


    public void EndDrag()
    {
        for (int i = 0; i < correctPuzzle.Length; i++)
        {
            //  Debug.Log(puzzle[i].initialPos);

            if (Mathf.Abs(correctPuzzle[i].obj.transform.position.magnitude - puzzle[i].obj.transform.position.magnitude) < 20.0f)
            {
                puzzle[i].obj.transform.position = correctPuzzle[i].obj.transform.position;
                audioManager.PlayeSound("Correct");
            }

            else
            {
                puzzle[i].obj.transform.position = puzzle[i].initialPos;
                audioManager.PlayeSound("Wrong");

                // Debug.Log(puzzle[i].initialPos);

                //   Debug.Log(puzzle[i].obj.transform.position);
            }
        }
    }
}
