using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalizationInvoker : MonoBehaviour
{
    [SerializeField] private AlarmLight[] _alarmLights;
    [SerializeField] private Transform _pointInside;

    private Vector3 _insideVector;

    private void Start()
    {
        _insideVector = _pointInside.position - transform.position;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            if (SomebodyEntered(other.transform.position) == true)
                foreach (var light in _alarmLights)
                    light.StartBlinking();
            else
                foreach (var light in _alarmLights)
                    light.StopBlinking();
        }
    }

    private bool SomebodyEntered(Vector3 thiefPosition)
    {
        return Vector3.Dot(thiefPosition - transform.position, _insideVector) > 0;
    }
}
