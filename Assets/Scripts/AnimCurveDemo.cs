using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCurveDemo : MonoBehaviour
{
    [SerializeField] AnimationCurve VerticalMovement;
    [SerializeField] float MovementDuration = 15f;
    [SerializeField] float MaxDisplacement = 1f;

    Vector3 InitialPosition;
    float CurrentTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        InitialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the current time
        CurrentTime = Mathf.Repeat(CurrentTime + Time.deltaTime, MovementDuration);

        // calculate and apply the displacement
        float displacement = VerticalMovement.Evaluate(CurrentTime / MovementDuration) * MaxDisplacement;
        transform.position = InitialPosition + Vector3.up * displacement;
    }
}
