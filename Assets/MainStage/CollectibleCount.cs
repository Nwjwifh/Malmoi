using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleCount : MonoBehaviour
{
    Text text;
    int count;

    public GameObject completionText;
    public float hideDelay = 3f;

    public GameObject countUI;
    public GameObject npc1;
    public GameObject npc2;
    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void Start()
    {
        UpdateCount();
    }

    private void OnEnable()
    {
        Collectible.OnCollected += OnCollectibleCollected;
    }

    private void OnDisable()
    {
        Collectible.OnCollected -= OnCollectibleCollected;
    }

    private void OnCollectibleCollected()
    {
        count++;
        UpdateCount();

        if (count >= Collectible.total)
        {
            ShowCompletionText();
            StartCoroutine(HideUIAfterDelay());
        }
    }

    private void UpdateCount()
    {
        text.text = $"{count}/{Collectible.total}";
    }

    private void ShowCompletionText()
    {
        if (completionText != null)
        {
            completionText.SetActive(true);
        }
    }

    private IEnumerator HideUIAfterDelay()
    {
        yield return new WaitForSeconds(hideDelay);

        if (completionText != null)
        {
            completionText.SetActive(false);
            npc1.SetActive(false);
            npc2.SetActive(true);
        }

       countUI.SetActive(false); // 기존 UI 비활성화
    }
}
