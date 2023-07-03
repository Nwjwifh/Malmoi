using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class DragAndDrop_ : MonoBehaviour
{
    public GameObject EndMenu;
    public GameObject SelectedPiece;
    int OIL = 1;
    public int PlacedPieces = 0;

    public AudioSource puzzleCompleteSound; // AudioSource 변수 추가

    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform != null && hit.transform.CompareTag("Puzzle"))
            {
                piceseScript puzzlePiece = hit.transform.GetComponent<piceseScript>();
                if (puzzlePiece != null && !puzzlePiece.InRightPosition)
                {
                    SelectedPiece = hit.transform.gameObject;
                    puzzlePiece.Selected = true;
                    SelectedPiece.GetComponent<SortingGroup>().sortingOrder = OIL;
                    OIL++;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (SelectedPiece != null)
            {
                piceseScript puzzlePiece = SelectedPiece.GetComponent<piceseScript>();
                if (puzzlePiece != null)
                {
                    puzzlePiece.Selected = false;

                    if (puzzlePiece.InRightPosition)
                    {
                        PlacedPieces++;
                    }
                }
                SelectedPiece = null;
            }
        }

        if (SelectedPiece != null)
        {
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedPiece.transform.position = new Vector3(MousePoint.x, MousePoint.y, 0);
        }

        if (PlacedPieces > 0)
        {
            // 퍼즐이 올바른 위치에 맞춰질 때마다 소리 재생
            if (puzzleCompleteSound != null)
            {
                puzzleCompleteSound.Play();
            }
        }

        if (PlacedPieces == 36)
        {
            EndMenu.SetActive(true);
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Game");
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("Main2");
    }
}
