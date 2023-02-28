using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MapController : XRGrabInteractable
{
    [SerializeField] private Rigidbody m_RigidBody;
    [SerializeField] private Transform m_Transform;
    private Vector3 m_OriginLocalTrans;
    private Quaternion m_OriginLocalRot;

    private void Start()
    {
        this.m_OriginLocalTrans = this.m_Transform.localPosition;
        this.m_OriginLocalRot = this.m_Transform.localRotation;
    }

    private void LateUpdate()
    {
        // this.m_Transform.localRotation = this.m_OriginLocalRot;
        // Vector3 currLocalTrans = this.m_Transform.localPosition;
        // currLocalTrans.y = this.m_OriginLocalTrans.y;
        // this.m_Transform.localPosition = currLocalTrans;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        this.m_Transform.localRotation = this.m_OriginLocalRot;
        Vector3 currLocalTrans = this.m_Transform.localPosition;
        currLocalTrans.y = this.m_OriginLocalTrans.y;
        this.m_Transform.localPosition = currLocalTrans;
    }
}
