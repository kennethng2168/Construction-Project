using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UIElements;

public class Chatbot : MonoBehaviour
{
    [SerializeField]
    private VisualTreeAsset m_UxmlAsset = default;

    private VisualElement m_Root;
    private TextInputBaseField<string> m_Chatbox;

    private void Awake()
    {
        this.m_Root = this.m_UxmlAsset.Instantiate();
        this.m_Chatbox = this.m_Root.Q<TextInputBaseField<string>>("chatbox");
        this.m_Chatbox.value = "test";
    }

    private void Update()
    {
        
    }
}
