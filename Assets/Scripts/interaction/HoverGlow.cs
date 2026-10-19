using UnityEngine;

public class HoverGlow : MonoBehaviour
{
    [SerializeField] private Renderer objectRenderer;

    [Header("Glow Settings")]
    [SerializeField] private Color glowColor = Color.cyan;
    [SerializeField] private float glowIntensity = 0f;
    [SerializeField] private float hoverIntensity = 2f;
    [SerializeField] private float transitionSpeed = 8f;

    private Material material;
    private float targetIntensity;

    private void Awake()
    {
        if (objectRenderer == null)
            objectRenderer = GetComponent<Renderer>();

        material = objectRenderer.material;

        material.EnableKeyword("_EMISSION");
        targetIntensity = 0f;
    }

    private void Update()
    {
        glowIntensity = Mathf.Lerp(
            glowIntensity,
            targetIntensity,
            Time.deltaTime * transitionSpeed
        );

        material.SetColor(
            "_EmissionColor",
            glowColor * glowIntensity
        );
    }

    public void SetGlow(bool enabled)
    {
        targetIntensity = enabled ? hoverIntensity : 0f;
    }
}