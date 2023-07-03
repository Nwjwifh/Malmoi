using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class piceseScript : MonoBehaviour
{
    private Vector3 RightPosition;
    public bool InRightPosition;
    public bool Selected;

    public AudioSource puzzleCompleteSound; // 소리 재생을 위한 AudioSource 변수

    void Start()
    {
        RightPosition = transform.position;
        transform.position = new Vector3(Random.Range(5f, 11f), Random.Range(2.5f, -7));
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, RightPosition) < 0.5f)
        {
            if (!Selected && !InRightPosition)
            {
                transform.position = RightPosition;
                InRightPosition = true;
                GetComponent<SortingGroup>().sortingOrder = 0;
                Camera.main.GetComponent<DragAndDrop_>().PlacedPieces++;

                if (puzzleCompleteSound != null)
                {
                    puzzleCompleteSound.Play(); // 퍼즐이 올바른 위치에 맞춰질 때 소리 재생
                }
            }
        }
    }
}
