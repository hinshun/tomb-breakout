using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerController : MonoBehaviour {

  public List<Triggerable> triggers;
  public DoorController door;
  public Color activatedColor;

  private List<Triggerable> activated;

	void Start () {
    activated = new List<Triggerable>();
	}

  void CheckSuccess() {
    if (activated.Count == triggers.Count) {
      for (int i = 0; i < activated.Count; i++) {
        if (activated[i] != triggers[i]) {
          DeactivateTriggers();
          return;
        }
      }
      door.Open();
    }
  }

  void DeactivateTriggers() {
    activated.Clear();
    for (int i = 0; i < triggers.Count; i++) {
      triggers[i].Reset();
    }
  }

  public void TriggerActivate(Triggerable trigger) {
    activated.Add(trigger);
    trigger.SetColor(activatedColor);
    CheckSuccess();
  }
}
