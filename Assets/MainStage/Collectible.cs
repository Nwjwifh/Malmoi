using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public static event Action OnCollected;

    public static int total;

    public AudioSource audioSource;

    void Awake() => total++;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollected?.Invoke();
            StartCoroutine(PlayAudioAndDestroy());
        }
    }

    private IEnumerator PlayAudioAndDestroy()
    {
        audioSource.Play();

        yield return new WaitForSeconds(audioSource.clip.length);

        Destroy(gameObject);
    }
}
