using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    private Transform mTargetTransform;
    private float depth = -7f;
    [SerializeField]
    private float CameraMoveSpeed = 1.0f;                   // 越高延遲越低

    void Update()
    {

        CameraMoveSpeed = Player_Control.MoveSpeed;
        if (mTargetTransform != null)
        {
            var targetposition = mTargetTransform.position + new Vector3(0, 0, depth);
            transform.position = Vector3.MoveTowards(transform.position, targetposition, CameraMoveSpeed * Time.deltaTime);
        }

    }

    public void SetTarget(Transform target)
    {

        mTargetTransform = target;
    }
}
