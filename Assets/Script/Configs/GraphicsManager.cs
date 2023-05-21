using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class GraphicsManager : MonoBehaviour
{
    public TMP_Dropdown graphicsDropdown;

    // Nomes dos n�veis de qualidade
    private string[] qualityNames = { "Very Low", "Low", "Medium", "High", "Very High", "Ultra" };

    void Start()
    {
        // Define as op��es do dropdown de acordo com os nomes dos n�veis de qualidade
        graphicsDropdown.ClearOptions();
        graphicsDropdown.AddOptions(new List<string>(qualityNames));

        // Define o valor do dropdown de acordo com a configura��o salva
        graphicsDropdown.value = PlayerPrefs.GetInt("GraphicsQuality", QualitySettings.GetQualityLevel());

        // Adiciona um listener para o evento de mudan�a de sele��o do dropdown
        graphicsDropdown.onValueChanged.AddListener(delegate { OnGraphicsDropdownChange(); });
    }

    public void OnGraphicsDropdownChange()
    {
        // Obt�m o valor atual do dropdown
        int graphicsQuality = graphicsDropdown.value;

        // Define o n�vel de qualidade de acordo com o valor do dropdown
        QualitySettings.SetQualityLevel(graphicsQuality, true);

        // Salva o valor do dropdown para ser recuperado posteriormente
        PlayerPrefs.SetInt("GraphicsQuality", graphicsQuality);
        PlayerPrefs.Save();
    }
}
