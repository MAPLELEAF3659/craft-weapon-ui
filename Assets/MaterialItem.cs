using UnityEngine;

namespace Assets
{
    [System.Serializable]
    public class MaterialItemInfo
    {
        public int index;
        public string name;
        public int level;
        public int grade;
        public int damage;
        public string skillDescription;
        public Sprite sprite;
        public bool isLocked;
        public bool isSelected;
    }
}
