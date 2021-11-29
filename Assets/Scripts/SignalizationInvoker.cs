using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalizationInvoker : MonoBehaviour
{
    [SerializeField] private UnityEvent _onBreakup;
    [SerializeField] private string _thiefTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == _thiefTag)
            _onBreakup?.Invoke();
    }
}
