using Assets;
using UnityEngine;
using UnityEngine.UI;

public class MaterialManager : MonoBehaviour
{
    public MaterialItemInfo materialInfo;

    public Image materialImg;
    public Image lockedImage;
    public Image selectedImage;

    public Text levelText;
    public Text gradeText;

    private void Start()
    {
        materialImg.sprite = materialInfo.sprite;
        lockedImage.gameObject.SetActive(materialInfo.isLocked);
        selectedImage.gameObject.SetActive(materialInfo.isSelected);
        levelText.text = "LV." + materialInfo.level.ToString("00");
        switch (materialInfo.grade)
        {
            case 0:
                gradeText.text = "劣質";
                break;
            case 1:
                gradeText.text = "普通";
                break;
            case 2:
                gradeText.text = "優秀";
                break;
        }
    }

    public void OnClick()
    {
        if (materialInfo.isLocked)
        {
            return;
        }
        UIController uiController = GameObject.FindGameObjectWithTag("GameController").GetComponent<UIController>();
        uiController.SetMaterial(materialInfo.index);
    }
}
