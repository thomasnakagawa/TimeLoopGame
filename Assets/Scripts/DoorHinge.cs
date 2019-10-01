using System.Collections;
using System.Collections.Generic;
using OatsUtil;
using UnityEngine;
using GameJuice;

public class DoorHinge : MonoBehaviour
{
    [SerializeField] private float ClosedAngle = 0f;
    [SerializeField] private float OpenAngle = -130f;
    [SerializeField] private float ActivationDistance = 3f;
    [SerializeField] private EasingFunction EasingFunction = default;
    [SerializeField] private float EasingDuration = 1f;

    private bool IsOpen = false;
    private Transform PlayerTransform;
    // Start is called before the first frame update
    void Start()
    {
        PlayerTransform = SceneUtils.FindComponentInScene<FirstPersonController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOpen)
        {
            if (Vector3.Distance(transform.position, PlayerTransform.position) > ActivationDistance)
            {
                IsOpen = false;
                StopAllCoroutines();
                StartCoroutine(Tween.Vector3(
                    transform.localEulerAngles,
                    Vector3.up * ClosedAngle,
                    EasingDuration,
                    EasingFunction.Evaluate,
                    vec => transform.localEulerAngles = vec
                ));
            }
        }
        else if (IsOpen == false)
        {
            if (Vector3.Distance(transform.position, PlayerTransform.position) < ActivationDistance)
            {
                IsOpen = true;
                StopAllCoroutines();
                StartCoroutine(Tween.Vector3(
                    transform.localEulerAngles,
                    Vector3.up * OpenAngle,
                    EasingDuration,
                    EasingFunction.Evaluate,
                    vec => transform.localEulerAngles = vec
                ));
            }
        }
    }
}
