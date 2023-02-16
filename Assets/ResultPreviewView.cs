using Assets;
using UnityEngine;
using UnityEngine.UI;

public class ResultPreviewView : MonoBehaviour
{
    public Image resultPreviewImg;
    public Text resultPreviewLevel;
    public Text resultPreviewGrade;
    public Text resultPreviewDescription;

    void Start()
    {
        Clear();
    }

    public void UpdateResultPreview(MaterialItemInfo targetMaterialItemInfo, int resultLevel, int resultGrade,string resultSkillDescription)
    {
        resultPreviewImg.gameObject.SetActive(true);
        resultPreviewImg.sprite = targetMaterialItemInfo.sprite;
        resultPreviewLevel.text = "LV." + resultLevel.ToString("00");
        resultPreviewGrade.text = GradeMatch(resultGrade);

        resultPreviewDescription.text =
            targetMaterialItemInfo.name + "\n" +
            "攻擊力 " + targetMaterialItemInfo.damage + " -> " + (resultGrade * 120 + resultLevel * 2 + 10) + "\n" +
            "品質 " + GradeMatch(targetMaterialItemInfo.grade) + " -> " + GradeMatch(resultGrade) + "\n" +
            resultSkillDescription;
    }

    public void Clear()
    {
        resultPreviewImg.sprite = null;
        resultPreviewImg.gameObject.SetActive(false);
        resultPreviewLevel.text = "";
        resultPreviewGrade.text = "";
        resultPreviewDescription.text = "選擇想合成的裝備吧！！";
    }

    string GradeMatch(int grade)
    {
        switch (grade)
        {
            case 0:
                return "劣質";
            case 1:
                return "普通";
            case 2:
                return "優秀";
            default:
                return null;
        }
    }
}
