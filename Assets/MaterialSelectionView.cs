using Assets;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSelectionView : MonoBehaviour
{
    public GameObject content;
    public GameObject materialItem;
    public void UpdateMaterialSelections(List<MaterialItemInfo> materialItems)
    {
        GameObject[] materialViews = GameObject.FindGameObjectsWithTag("Material");
        foreach (GameObject materialView in materialViews)
        {
            Destroy(materialView);
        }

        foreach (MaterialItemInfo materialItemInfo in materialItems)
        {
            materialItem.GetComponent<MaterialManager>().materialInfo = materialItemInfo;
            Instantiate(materialItem, content.transform);
        }
    }
}
