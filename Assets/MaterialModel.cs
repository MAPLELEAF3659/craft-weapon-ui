using Assets;
using System.Collections.Generic;
using UnityEngine;

public class MaterialModel : MonoBehaviour
{
    public List<MaterialItemInfo> materialItems;

    public int targetMaterialItemIndex;
    public int[] craftMaterialItemIndex;
    public int resultLevel;
    public int resultGrade;
    public string resultSkillDescription;

    public MaterialSelectionView materialSelectionView;
    public CraftView craftView;
    public ResultPreviewView resultPreviewView;
    public ResultView resultView;

    private void Start()
    {
        for (int i = 0; i < materialItems.Count; i++)
        {
            materialItems[i].index = i;
            materialItems[i].damage = materialItems[i].grade * 120 + materialItems[i].level * 2 + 10;
        }

        ClearIndexs();
        materialSelectionView.UpdateMaterialSelections(materialItems);
    }

    public void SetMaterial(int index)
    {
        if (targetMaterialItemIndex == -1)
        {
            SetTargetMaterial(index);
        }
        else
        {
            SetCraftMaterial(index);
        }
    }

    void SetTargetMaterial(int index)
    {
        targetMaterialItemIndex = index;
        materialItems[targetMaterialItemIndex].isSelected = true;
        resultLevel = materialItems[targetMaterialItemIndex].level;
        resultGrade = materialItems[targetMaterialItemIndex].grade;
        resultSkillDescription = materialItems[targetMaterialItemIndex].skillDescription;

        craftView.UpdateTargetMaterialView(materialItems[index]);
        materialSelectionView.UpdateMaterialSelections(materialItems);
    }

    void SetCraftMaterial(int index)
    {
        if (craftMaterialItemIndex[0] != -1 && craftMaterialItemIndex[1] != -1)
        {
            return;
        }

        int craftIndex = craftMaterialItemIndex[0] == -1 ? 0 : 1;
        craftMaterialItemIndex[craftIndex] = index;
        materialItems[craftMaterialItemIndex[craftIndex]].isSelected = true;
        resultLevel += materialItems[index].level;
        if (resultLevel > 50)
        {
            resultLevel -= 50;
            resultGrade += 1;
        }
        if (resultGrade == 2)
        {
            resultSkillDescription = "傷害改為持續扣血";
        }

        craftView.UpdateCraftMaterialView(materialItems[index], craftIndex);
        if (craftIndex == 1)
        {
            LockOtherMaterial();
        }
        materialSelectionView.UpdateMaterialSelections(materialItems);
        resultPreviewView.UpdateResultPreview(materialItems[targetMaterialItemIndex], resultLevel, resultGrade, resultSkillDescription);
    }

    void LockOtherMaterial()
    {
        for (int i = 0; i < materialItems.Count; i++)
        {
            if (!materialItems[i].isSelected)
            {
                materialItems[i].isLocked = true;
            }
        }
    }

    public void Craft()
    {
        if (craftMaterialItemIndex[0] == -1 && craftMaterialItemIndex[1] == -1)
        {
            return;
        }

        int originDamage = materialItems[targetMaterialItemIndex].damage;
        int originGrade = materialItems[targetMaterialItemIndex].grade;
        materialItems[targetMaterialItemIndex].level = resultLevel;
        materialItems[targetMaterialItemIndex].grade = resultGrade;
        materialItems[targetMaterialItemIndex].damage = resultGrade * 120 + resultLevel * 2 + 10;
        materialItems[targetMaterialItemIndex].skillDescription = resultSkillDescription;
        resultView.UpdateResult(materialItems[targetMaterialItemIndex], originGrade, originDamage);
        if (craftMaterialItemIndex[0] != -1)
            materialItems.RemoveAt(craftMaterialItemIndex[0]);
        if (craftMaterialItemIndex[1] != -1)
            materialItems.RemoveAt(craftMaterialItemIndex[1]);
        for (int i = 0; i < materialItems.Count; i++)
        {
            materialItems[i].index = i;
        }

        ClearIndexs();
        ClearSelection();
        craftView.Clear();
        resultPreviewView.Clear();
        materialSelectionView.UpdateMaterialSelections(materialItems);
        resultView.Show();
    }

    void ClearIndexs()
    {
        targetMaterialItemIndex = -1;

        for (int i = 0; i < craftMaterialItemIndex.Length; i++)
        {
            craftMaterialItemIndex[i] = -1;
        }
    }

    void ClearSelection()
    {
        foreach (MaterialItemInfo materialItemInfo in materialItems)
        {
            materialItemInfo.isSelected = false;
            materialItemInfo.isLocked = false;
        }
    }
}
