using UnityEngine;

public class AlternateToggleActive : MonoBehaviour
{
    [SerializeField] private bool m_State;
    [SerializeField] public GameObject[] m_GameObjects;

    private void Start()
    {
        foreach (GameObject go in this.m_GameObjects)
        {
            go.SetActive(this.m_State);
        }
    }

    public void Toggle()
    {
        this.m_State = !this.m_State;
        foreach (GameObject go in this.m_GameObjects)
        {
            go.SetActive(this.m_State);
        }
    }
}
