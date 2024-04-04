using UnityEngine;
using UnityEngine.UI;

public class Item : ScriptableObject
{
    public string Name;
    public string Description;
    public int Count;
    public int MaxCount;
    public GameObject Prefab;
    public Sprite Icon;
}
