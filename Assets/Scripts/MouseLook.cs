using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private enum RotationAxes 
    { 
        MouseXandY=0, 
        MouseX=1, 
        MouseY = 2
    };

    [SerializeField] private RotationAxes _axes = RotationAxes.MouseXandY;
    [SerializeField] private float _sensitivity = 2f;
    [SerializeField] private float _minRotationValue = -360f;
    [SerializeField] private float _maxRotationValue = 360f;

    private float _rotationX = 0f;
    private float _rotationY = 0f;

    private Quaternion _originalrotation;

    private void OnValidate()
    {
        if (_minRotationValue < -360f)
            _minRotationValue = -360f;

        if (_maxRotationValue > 360f)
            _maxRotationValue = 360f;
    }

    private void Start()
    {
        _originalrotation = transform.localRotation;
    }

    private float ClampAngle (float angle, float minValue, float maxValue)
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, minValue, maxValue);
    }

    private void Update()
    {
        switch (_axes)
        {
            case RotationAxes.MouseX:
                RotateX();
                break;
            case RotationAxes.MouseY:
                RotateY();
                break;
            case RotationAxes.MouseXandY:
                RotateX();
                RotateY();
                break;
        }
    }

    private void RotateX()
    {
        _rotationX += Input.GetAxis("Mouse X") * _sensitivity;
        _rotationX = ClampAngle(_rotationX, _minRotationValue, _maxRotationValue);
        Quaternion xQuaternion = Quaternion.AngleAxis(_rotationX, Vector3.up);
        transform.localRotation = _originalrotation * xQuaternion;
    }

    private void RotateY()
    {
        _rotationY += Input.GetAxis("Mouse Y") * _sensitivity;
        _rotationY = ClampAngle(_rotationY, _minRotationValue, _maxRotationValue);
        Quaternion yQuaternion = Quaternion.AngleAxis(_rotationY, -Vector3.right);
        transform.localRotation = _originalrotation * yQuaternion;
    }

}
