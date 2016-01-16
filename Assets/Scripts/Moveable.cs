using UnityEngine;
using System.Collections;

public class Moveable : MonoBehaviour {
  public Vector3 endPosition;
  private bool done;
  private bool moved;
  private Vector3 startPosition;

  void Start() {
    done = false;
    moved = false;
    startPosition = transform.position;
  }

  public IEnumerator MoveCoroutine(Vector3 destination) {
    if (!done) {
      while (transform.position != destination) {
        transform.position = Vector3.MoveTowards(transform.position, destination, 0.25f);

        if (Vector3.Distance(transform.position, destination) <= 0.25f) {
          transform.position = destination;
          done = true;
        }
        yield return null;
      }
    }
  }

  public void Toggle() {
    done = false;
    StopAllCoroutines();
    if (!moved) {
      StartCoroutine(MoveCoroutine(endPosition));
      moved = true;
    } else {
      StartCoroutine(MoveCoroutine(startPosition));
      moved = false;
    }
  }
}
