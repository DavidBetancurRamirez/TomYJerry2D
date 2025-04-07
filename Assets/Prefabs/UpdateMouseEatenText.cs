using UnityEngine;
using TMPro;

public class UpdateMouseEatenText : MonoBehaviour {
  public TomEats tomEats;
  private TextMeshProUGUI miceText;

  void Start() {
    miceText = GetComponent<TextMeshProUGUI>();
    if (miceText == null) {
      Debug.LogError("Este script requiere un componente TextMeshProUGUI en el mismo GameObject.");
    }

    if (tomEats == null) {
      Debug.LogError("No se ha asignado una referencia al script TomEats.");
    }
  }

  void Update() {
    if (miceText != null && tomEats != null) {
      miceText.text = $"Mice eaten: {tomEats.miceEaten}";
    }
  }
}
