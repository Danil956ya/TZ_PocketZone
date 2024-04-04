using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pivot : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Transform body;

    public void LookAt(Enemy target)
    {
        Vector3 difference = target.transform.position - transform.position;
        difference.Normalize();
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        if (rotZ < -90 || rotZ > 90)
        {
            Transform @object = _gameObject.transform;
            if (@object.eulerAngles.y == 0)
            {
                transform.localRotation = Quaternion.Euler(180, 0, -rotZ);
            }
            else if (_gameObject.transform.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotZ);
            }
        }
        else
        {
            body.rotation = Quaternion.identity;
        }
    }
}
