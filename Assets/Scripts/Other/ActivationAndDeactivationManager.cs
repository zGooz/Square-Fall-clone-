
using System.Collections.Generic;
using UnityEngine;


public class ActivationAndDeactivationManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _objectsToActivate = new List<GameObject>();
    [SerializeField]
    private List<GameObject> _objectsToDeactivate = new List<GameObject>();

    public void ActivateObjects()
    {
        foreach (var instance in _objectsToActivate)
        {
            instance.SetActive(true);
        }
    }

    public void DeactivateObjects()
    {
        foreach (var instance in _objectsToDeactivate)
        {
            instance.SetActive(false);
        }
    }
}
