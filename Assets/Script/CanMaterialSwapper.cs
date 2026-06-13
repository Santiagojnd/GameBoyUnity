using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CanVariant
{
    public string variantName;
    public Material labelMaterial;
    public Material capMaterial;
}

public class CanMaterialSwapper : MonoBehaviour
{
    [Header("Can Renderers")]
    public Renderer canRenderer;
    public Renderer batteryRenderer;

    [Header("Can Variants")]
    public List<CanVariant> variants = new List<CanVariant>();

    public System.Action<int, CanVariant> OnVariantChange;

    private int _currentIndex;

    void Start()
    {
        if (variants.Count > 0)
        {
            Apply(0);
        }
    }

    public void NextVariant()
    {
        _currentIndex = (_currentIndex + 1) % variants.Count;

        Apply(_currentIndex);

        OnVariantChange?.Invoke(_currentIndex, variants[_currentIndex]);
    }

    public void PreviousVariant()
    {
        _currentIndex = (_currentIndex - 1 + variants.Count) % variants.Count;

        Apply(_currentIndex);

        OnVariantChange?.Invoke(_currentIndex, variants[_currentIndex]);
    }

    public void SetVariantIndex(int index)
    {
        if (index < 0 || index >= variants.Count)
        {
            Debug.LogError("Index out of range");
            return;
        }

        _currentIndex = index;

        Apply(_currentIndex);

        OnVariantChange?.Invoke(_currentIndex, variants[_currentIndex]);
    }

    public CanVariant CurrentVariant =>
        variants.Count > 0 ? variants[_currentIndex] : null;

    public int CurrentIndex => _currentIndex;

    public int VariantCount => variants.Count;

    public string CurrentVariantName =>
        CurrentVariant?.variantName ?? "";

    void Apply(int index)
    {
        if (index >= variants.Count)
        {
            Debug.LogError("Index out of range");
            return;
        }

        CanVariant v = variants[index];

        Material[] mats =
        {
            v.labelMaterial,
            v.capMaterial
        };

        if (canRenderer != null)
            canRenderer.materials = mats;

        if (batteryRenderer != null)
            batteryRenderer.materials = mats;
    }
}