using UnityEngine;
using TMPro;

public class ToggleLightRow : MonoBehaviour
{
    [SerializeField] private Transform[] m_LightRowParents;
    [SerializeField] private TMP_Dropdown m_TMPDropdown;
    [SerializeField] private float m_Intensity;
    private Light[][] m_Lights;
    private bool [] m_LightToggleMode;

    private void Start()
    {
        this.m_Lights = new Light[this.m_LightRowParents.Length][];
        this.m_LightToggleMode = new bool[this.m_LightRowParents.Length];

        for (int r = 0; r < this.m_LightRowParents.Length; r++)
        {
            Transform rowParent = this.m_LightRowParents[r];
            this.m_LightToggleMode[r] = false;
            this.m_Lights[r] = new Light[rowParent.childCount];

            for (int l = 0; l < this.m_Lights[r].Length; l++)
            {
                this.m_Lights[r][l] = rowParent.GetChild(l).GetComponent<Light>();
            }
        }
    }

    public void ToggleLight()
    {
        int selectedRow = this.m_TMPDropdown.value;
        float targetIntensity = this.m_LightToggleMode[selectedRow] ? 0.0f : this.m_Intensity;

        for (int l = 0; l < this.m_Lights[selectedRow].Length; l++)
        {
            this.m_Lights[selectedRow][l].intensity = targetIntensity;
        }

        this.m_LightToggleMode[selectedRow] = !this.m_LightToggleMode[selectedRow];
    }
}
