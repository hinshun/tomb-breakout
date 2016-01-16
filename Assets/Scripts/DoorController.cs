using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {
  public Vector3 OpenPosition;
  private bool open;

  public IEnumerator OpenUp ()
  {
    if (!open) {
      while (transform.position != OpenPosition) {
        transform.position = Vector3.MoveTowards(transform.position, OpenPosition, 0.25f);

        if (Vector3.Distance(transform.position, OpenPosition) <= 0.25f) {
          transform.position = OpenPosition;
          open = true;
        }
        yield return null;
      }
    }
  }

  public void Open() {
    StartCoroutine(OpenUp());
  }
}
