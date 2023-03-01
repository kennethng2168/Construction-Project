using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MapController : XRGrabInteractable
{
    [SerializeField] private Rigidbody m_RigidBody;
    [SerializeField] private Transform m_Transform;
    [SerializeField] private float m_Damping = 0.9f;
    private Vector3 m_OriginLocalTrans;
    private Quaternion m_OriginLocalRot;

    private Vector3 m_PrevLocalTrans;
    private Vector3 m_Velocity;

    private void Start()
    {
        this.m_OriginLocalTrans = this.m_Transform.localPosition;
        this.m_OriginLocalRot = this.m_Transform.localRotation;

        this.m_PrevLocalTrans = this.m_OriginLocalTrans;
        this.m_Velocity = Vector3.zero;
    }

    public void Update()
    {
        // remove y axis velocity
        this.m_Velocity.y = 0.0f;
        this.m_Transform.localPosition += this.m_Velocity * Time.deltaTime;

        this.m_Velocity = (this.m_Transform.localPosition - this.m_PrevLocalTrans) / Time.deltaTime;
        this.m_PrevLocalTrans = this.m_Transform.localPosition;
        this.m_Velocity *= this.m_Damping;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (Time.deltaTime == 0.0f) return;

        base.ProcessInteractable(updatePhase);

        if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.OnBeforeRender)
        {
            this.m_Transform.localRotation = this.m_OriginLocalRot;
            Vector3 currLocalTrans = this.m_Transform.localPosition;
            currLocalTrans.y = this.m_OriginLocalTrans.y;
            this.m_Transform.localPosition = currLocalTrans;
        }
    }
}
