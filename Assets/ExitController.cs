using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExitController : MonoBehaviour {

  public Text winText;

  void Start() {
    winText.text = "";
  }

  void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Player")) {
      winText.text = "You Win!";
    }
	}
}
