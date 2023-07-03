using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] RectTransform fader;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fader.gameObject.SetActive(true);
            LeanTween.scale(fader, Vector3.zero, 0f);
            LeanTween.scale(fader, new Vector3(1, 1, 1), 0.5f).setOnComplete(() =>
            {
                SceneManager.LoadScene("Puzzle");
            });
        }
    }
}
