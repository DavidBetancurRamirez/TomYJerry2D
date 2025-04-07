using UnityEngine;

public class TomEats : MonoBehaviour {
  public float growYAmount = 0.2f;
  public float growXAmount = 0.2f;    // Horizontal scale increase
  public float maxHeight = 3f;        // Max vertical scale
  public float minWidth = 0.4f;       // Min horizontal scale

  public int miceEaten = 0;
  public Transform bodyTransform;

  public AudioClip eatSound;
  private AudioSource audioSource;

  private void Start() {
    audioSource = GetComponent<AudioSource>();
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Jerry")) {
      Destroy(other.gameObject);
      miceEaten++;

      if (eatSound != null && audioSource != null) {
        audioSource.PlayOneShot(eatSound);
      }

      if (bodyTransform != null) {
        Vector3 newScale = bodyTransform.localScale;

        newScale.y = Mathf.Min(newScale.y + growYAmount, maxHeight); // Grow tall
        newScale.x = Mathf.Min(newScale.x + growXAmount, maxHeight); // Grow wide

        bodyTransform.localScale = newScale;
      }
    }
  }
}
