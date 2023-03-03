using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform m_CamTransform;

    private void Start()
    {
        this.m_CamTransform = Camera.main.transform;
    }

    private void Update()
    {
        this.transform.LookAt(this.m_CamTransform, Vector3.up);
    }
}
