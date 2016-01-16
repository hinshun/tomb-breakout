using UnityEngine;
using System.Collections;

public class Triggerable : MonoBehaviour {

  private bool activated; 
  private TriggerController controller;
  private Material material;
  private Color originalColor;

	void Start () {
    activated = false;
    controller = transform.parent.GetComponent<TriggerController>();
    material = gameObject.GetComponent<MeshRenderer>().material;
    originalColor = material.color;
	}
	
  void OnTriggerEnter(Collider other) {
    if (!activated && other.CompareTag("Player")) {
      activated = true;

      // light up
      controller.TriggerActivate(this);
    }
  }

  public void SetColor(Color color) {
    material.color = color;
  }

  public void Reset() {
    activated = false;
    SetColor(originalColor);
  }
}
