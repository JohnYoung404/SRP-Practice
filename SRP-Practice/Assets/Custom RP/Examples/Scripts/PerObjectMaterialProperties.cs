using UnityEngine;

[DisallowMultipleComponent]
public class PerObjectMaterialProperties : MonoBehaviour
{
    static MaterialPropertyBlock block;
    static int baseColorId = Shader.PropertyToID("_BaseColor"),
    cutoffId = Shader.PropertyToID("_Cutoff"),
    metallicId = Shader.PropertyToID("_Metallic"),
	smoothnessId = Shader.PropertyToID("_Smoothness");

    [SerializeField]
    Color baseColor = Color.white;

    [SerializeField, Range(0f, 1f)]
    float cutoff = 0.5f, metallic = 0f, smoothness = 0.5f;

    void Awake()
    {
        OnValidate();
    }

    void Reset()
    {
        baseColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        cutoff = Random.Range(0.4f, 0.6f);
        metallic = Random.Range(0.4f, 0.6f);
        smoothness = Random.Range(0.4f, 0.6f);
    }

    void OnValidate()
    {
        if (block == null)
        {
            block = new MaterialPropertyBlock();
        }

        block.SetColor(baseColorId, baseColor);
        block.SetFloat(cutoffId, cutoff);
        block.SetFloat(metallicId, metallic);
        block.SetFloat(smoothnessId, smoothness);
        GetComponent<Renderer>().SetPropertyBlock(block);
    }
}