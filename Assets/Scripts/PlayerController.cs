using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
  public float speed;
  public AnimationCurve deceleration;

  private Rigidbody rb;

  void Start ()
  {
     rb = GetComponent<Rigidbody>();
  }

  void FixedUpdate ()
  {
    float moveHorizontal = Input.GetAxis ("Horizontal");
    float moveVertical = Input.GetAxis ("Vertical");

    Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

    rb.AddForce(movement * speed);

    if (movement == Vector3.zero) {
      Decelerate();
    }
  }

  void Decelerate() 
  {
    Vector3 rigidVelocity = GetComponent<Rigidbody>().velocity;
    float speedNormalized;

    speedNormalized = Mathf.Clamp01(Mathf.InverseLerp (0, speed, Mathf.Abs(rigidVelocity.x)));
    rigidVelocity.x *= deceleration.Evaluate (speedNormalized);
    speedNormalized = Mathf.Clamp01(Mathf.InverseLerp (0, speed, Mathf.Abs(rigidVelocity.z)));
    rigidVelocity.z *= deceleration.Evaluate(speedNormalized);
    GetComponent<Rigidbody>().velocity = rigidVelocity;
  }
}
