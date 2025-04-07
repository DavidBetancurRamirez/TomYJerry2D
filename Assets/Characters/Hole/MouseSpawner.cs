using UnityEngine;
using System.Collections;

public class MouseSpawner : MonoBehaviour {
  [Header("Spawn Settings")]
  public GameObject mousePrefab;
  public int maxMice = 5;
  public float minSpawnInterval = 2f;
  public float maxSpawnInterval = 5f;

  [Header("Audio")]
  public AudioClip spawnSound;

  private int currentMice = 0;
  private AudioSource audioSource;

  void Start() {
    audioSource = GetComponent<AudioSource>();
    if (audioSource == null) {
      audioSource = gameObject.AddComponent<AudioSource>();
    }

    StartCoroutine(SpawnRoutine());
  }

  IEnumerator SpawnRoutine() {
    while (true) {
      float delay = Random.Range(minSpawnInterval, maxSpawnInterval);
      yield return new WaitForSeconds(delay);

      if (currentMice < maxMice) {
        SpawnMouse();
      }
    }
  }

  void SpawnMouse() {
    GameObject mouse = Instantiate(mousePrefab, transform.position, Quaternion.identity);
    currentMice++;

    MouseController2D controller = mouse.GetComponent<MouseController2D>();
    if (controller != null) {
      controller.originSpawner = this;
    }

    if (spawnSound != null && audioSource != null) {
      audioSource.PlayOneShot(spawnSound);
    }
  }

  public void DecreaseMouseCount() {
    currentMice = Mathf.Max(0, currentMice - 1);
  }
}
