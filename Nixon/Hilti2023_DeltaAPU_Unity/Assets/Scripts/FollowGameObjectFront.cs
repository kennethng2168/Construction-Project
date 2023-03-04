using UnityEngine;

public class FollowGameObjectFront : MonoBehaviour
{
    [SerializeField] private Transform m_TargetTransform;
    [SerializeField] private float m_FrontOffset = 1.0f;
    [SerializeField] private float m_FollowSpeed = 1.0f;

    private void Update()
    {
        Vector3 targetPosition = this.m_TargetTransform.position + this.m_TargetTransform.forward * m_FrontOffset;
        Vector3 currPosition = this.transform.position;
        this.transform.position = Vector3.Lerp(currPosition, targetPosition, Time.deltaTime * m_FollowSpeed);
    }
}
