using UnityEngine;

public class UIController : MonoBehaviour
{

    public MaterialModel materialModel;

    public void SetMaterial(int index)
    {
        materialModel.SetMaterial(index);
    }

    public void Craft()
    {
        materialModel.Craft();
    }
}
