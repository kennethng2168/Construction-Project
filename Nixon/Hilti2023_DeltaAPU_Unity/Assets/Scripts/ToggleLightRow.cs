using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using Defective.JSON;

public class ToggleLightRow : MonoBehaviour
{
    [Header("Firebase Setup")]
    [SerializeField] private string m_URL = "https://hilti-4a670-default-rtdb.asia-southeast1.firebasedatabase.app/";
    [SerializeField] private float m_ReadRequestInterval = 0.1f;

    [Header("Lights")]
    [SerializeField] private Transform[] m_LightRowParents;
    [SerializeField] private TMP_Dropdown m_TMPDropdown;
    [SerializeField] private float m_Intensity;

    private Light[][] m_Lights;
    private bool [] m_LightToggleMode;
    private bool[] m_RequestCoroutinesEnded;

    private void Start()
    {
        this.m_Lights = new Light[this.m_LightRowParents.Length][];
        this.m_LightToggleMode = new bool[this.m_LightRowParents.Length];
        this.m_RequestCoroutinesEnded = new bool[this.m_LightRowParents.Length];

        for (int r = 0; r < this.m_LightRowParents.Length; r++)
        {
            Transform rowParent = this.m_LightRowParents[r];
            this.m_LightToggleMode[r] = false;
            this.m_Lights[r] = new Light[rowParent.childCount];
            this.m_RequestCoroutinesEnded[r] = true;

            for (int l = 0; l < this.m_Lights[r].Length; l++)
            {
                this.m_Lights[r][l] = rowParent.GetChild(l).GetComponent<Light>();
            }
        }

        // this.StartCoroutine(this.RequestToggleLight(1, 1));
        // this.StartCoroutine(this.RequestReadLight(1));
    }

    private void Update()
    {
        for (int r = 0; r < this.m_LightRowParents.Length; r++)
        {
            if (this.m_RequestCoroutinesEnded[r])
            {
                Debug.Log($"Reading light data at row {r}");
                this.StartCoroutine(this.RequestReadLight(r));
            }
        }
    }

    public void ToggleLight()
    {
        // toggle light on or off depending on previous toggle mode (basically flip the mode)
        int selectedRow = this.m_TMPDropdown.value;
        float targetIntensity = this.m_LightToggleMode[selectedRow] ? 0.0f : this.m_Intensity;

        for (int l = 0; l < this.m_Lights[selectedRow].Length; l++)
        {
            this.m_Lights[selectedRow][l].intensity = targetIntensity;
        }

        this.m_LightToggleMode[selectedRow] = !this.m_LightToggleMode[selectedRow];
    }

    private void SetLightRow(int rowIdx, bool toggleMode)
    {
        // set row intensity directly regardless of current toggle mode
        float targetIntensity = toggleMode ? this.m_Intensity : 0.0f;
        for (int l = 0; l < this.m_Lights[rowIdx].Length; l++)
        {
            this.m_Lights[rowIdx][l].intensity = targetIntensity;
        }

        this.m_LightToggleMode[rowIdx] = toggleMode;
    }

    private IEnumerator RequestReadLight(int rowIdx)
    {
        this.m_RequestCoroutinesEnded[rowIdx] = false;

        UnityWebRequest request = UnityWebRequest.Get(this.m_URL + $"row{rowIdx}.json");
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
            request.Dispose();
        } else
        {
            string rawData = request.downloadHandler.text;
            JSONObject lightObj = new JSONObject(rawData);

            bool toggleMode = lightObj["light"].intValue != 0;
            this.SetLightRow(rowIdx, toggleMode);

            request.Dispose();
        }

        yield return new WaitForSeconds(this.m_ReadRequestInterval);
        this.m_RequestCoroutinesEnded[rowIdx] = true;
    }

    private IEnumerator RequestToggleLight(int rowIdx, int toggleStatus)
    {
        string putJsonStr = $"{{ \"light\": {toggleStatus} }}";

        UnityWebRequest request = UnityWebRequest.Put(this.m_URL + $"row{rowIdx}.json", putJsonStr);
        request.SetRequestHeader("Accept", "application/json");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
            request.Dispose();
        } else
        {
            Debug.Log(request.downloadHandler.text);
            request.Dispose();
        }
    }
}
