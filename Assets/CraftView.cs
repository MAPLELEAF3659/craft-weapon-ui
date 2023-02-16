using Assets;
using UnityEngine;
using UnityEngine.UI;

public class CraftView : MonoBehaviour
{
    public Image targetMaterialImg;
    public Text targetMaterialLevel;
    public Text targetMaterialGrade;

    public Image[] craftMaterialImg;
    public Text[] craftMaterialLevel;
    public Text[] craftMaterialGrade;

    void Start()
    {
        Clear();
    }

    public void UpdateTargetMaterialView(MaterialItemInfo materialItemInfo)
    {
        targetMaterialImg.gameObject.SetActive(true);
        targetMaterialImg.sprite = materialItemInfo.sprite;
        targetMaterialLevel.text = "LV." + materialItemInfo.level.ToString("00");
        switch (materialItemInfo.grade)
        {
            case 0:
                targetMaterialGrade.text = "劣質";
                break;
            case 1:
                targetMaterialGrade.text = "普通";
                break;
            case 2:
                targetMaterialGrade.text = "精良";
                break;
        }
    }

    public void UpdateCraftMaterialView(MaterialItemInfo materialItemInfo, int index)
    {
        craftMaterialImg[index].gameObject.SetActive(true);
        craftMaterialImg[index].sprite = materialItemInfo.sprite;
        craftMaterialLevel[index].text = "LV." + materialItemInfo.level.ToString("00");
        switch (materialItemInfo.grade)
        {
            case 0:
                craftMaterialGrade[index].text = "劣質";
                break;
            case 1:
                craftMaterialGrade[index].text = "普通";
                break;
            case 2:
                craftMaterialGrade[index].text = "精良";
                break;
        }
    }

    public void Clear()
    {
        targetMaterialImg.sprite = null;
        targetMaterialImg.gameObject.SetActive(false);
        targetMaterialLevel.text = "";
        targetMaterialGrade.text = "";
        for (int i = 0; i < craftMaterialImg.Length; i++)
        {
            craftMaterialImg[i].sprite = null;
            craftMaterialImg[i].gameObject.SetActive(false);
            craftMaterialLevel[i].text = "";
            craftMaterialGrade[i].text = "";
        }
    }
}
