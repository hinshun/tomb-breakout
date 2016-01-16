using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Triggerable : MonoBehaviour {
  public List<Moveable> moveables;

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
      ToggleMoveables();
      controller.TriggerActivate(this);
    }
  }

  public void SetColor(Color color) {
    material.color = color;
  }

  public void Reset() {
    activated = false;
    SetColor(originalColor);
    ToggleMoveables();
  }

  public void ToggleMoveables() {
    foreach (Moveable moveable in moveables) {
      moveable.Toggle();
    }
  }
}
