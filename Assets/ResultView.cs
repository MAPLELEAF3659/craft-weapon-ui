using Assets;
using UnityEngine;
using UnityEngine.UI;

public class ResultView : MonoBehaviour
{
    public Image resultMaterialImg;
    public Text resultLevelText;
    public Text resultGradeText;
    public Text resultDamageUpgradeText;
    public Text resultGradeUpgradeText;
    public Text resultSkillDescriptionText;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void UpdateResult(MaterialItemInfo resultMaterialItemInfo, int originGrade, int originDamage)
    {
        resultMaterialImg.sprite = resultMaterialItemInfo.sprite;
        resultLevelText.text = "LV." + resultMaterialItemInfo.level.ToString("00");
        resultGradeText.text = GradeMatch(resultMaterialItemInfo.grade);
        resultDamageUpgradeText.text = originDamage + " -> " + resultMaterialItemInfo.damage;
        resultGradeUpgradeText.text = GradeMatch(originGrade) + " -> " + GradeMatch(resultMaterialItemInfo.grade);
        resultSkillDescriptionText.text = resultMaterialItemInfo.skillDescription;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
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
