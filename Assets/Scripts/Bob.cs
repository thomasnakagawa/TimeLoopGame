using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour
{
    [System.Serializable]
    private enum TransformParams
    {
        POSITION, ROTATION, SCALE
    }

    [System.Serializable]
    private enum TransformAxes
    {
        X, Y, Z
    }

    [SerializeField] private float BobAmplitude = 1f;
    [SerializeField] private float BobRate = 1f;
    [SerializeField] private TransformParams TransformParam = TransformParams.POSITION;
    [SerializeField] private TransformAxes TransformAxis = TransformAxes.Y;

    private Vector3 initialTransformValues;

    // Start is called before the first frame update
    void Start()
    {
        switch (TransformParam)
        {
            case TransformParams.POSITION:
                initialTransformValues = transform.localPosition;
                break;
            case TransformParams.ROTATION:
                initialTransformValues = transform.localEulerAngles;
                break;
            case TransformParams.SCALE:
                initialTransformValues = transform.localScale;
                break;
            default:
                throw new System.InvalidOperationException("Invalid transform param");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newTransformValue = initialTransformValues + AxisVector(TransformAxis) * Mathf.Sin(Time.time * BobRate) * BobAmplitude;
        switch (TransformParam)
        {
            case TransformParams.POSITION:
                transform.localPosition = newTransformValue;
                break;
            case TransformParams.ROTATION:
                transform.localEulerAngles = newTransformValue;
                break;
            case TransformParams.SCALE:
                transform.localScale = newTransformValue;
                break;
            default:
                throw new System.InvalidOperationException("Invalid transform param");
        }
    }

    private Vector3 AxisVector(TransformAxes axis)
    {
        switch (axis)
        {
            case TransformAxes.X:
                return Vector3.right;
            case TransformAxes.Y:
                return Vector3.up;
            case TransformAxes.Z:
                return Vector3.forward;
            default:
                throw new System.ArgumentException("Invalid axis");
        }
    }
}