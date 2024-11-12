using TMPro;
using UnityEngine;

public class TextHider : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    public void Disable()
    {
        _textMeshPro.enabled = false;
    }

    public void Enable()
    {
        _textMeshPro.enabled = true;
    }
}