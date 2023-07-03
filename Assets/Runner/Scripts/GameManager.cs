using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    public Text uiDistance;

    public int nextSceneDistance = 600; // 다음 씬으로 전환할 거리
    [SerializeField] RectTransform fader;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        int dist = Mathf.RoundToInt(player.transform.position.z) - 60; // 거리 계산
        uiDistance.text = dist.ToString() + " m";

        if (dist >= nextSceneDistance)
        {
            fader.gameObject.SetActive(true);
            LeanTween.scale(fader, Vector3.zero, 0f);
            LeanTween.scale(fader, new Vector3(1, 1, 1), 0.5f).setOnComplete(() =>
            {
                SceneManager.LoadScene("Ending");
            });
        }
    }
}
