using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform m_CamTransform;
    [SerializeField] private float m_FollowSpeed = 1.0f;

    private void Start()
    {
        this.m_CamTransform = Camera.main.transform;
    }

    private void Update()
    {
        Quaternion currRotation = this.transform.rotation;
        Quaternion targetRotataion = Quaternion.LookRotation(this.m_CamTransform.position - this.transform.position, Vector3.up);
        this.transform.rotation = Quaternion.Slerp(currRotation, targetRotataion, Time.deltaTime * this.m_FollowSpeed);
    }
}
