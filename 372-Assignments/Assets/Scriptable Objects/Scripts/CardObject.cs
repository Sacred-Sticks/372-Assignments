using UnityEngine;

[CreateAssetMenu(fileName = "Amogus", menuName = "Cards/Amogus")]
public class CardObject : ScriptableObject
{
    [SerializeField] private string title;
    [SerializeField] private string description;
    [SerializeField] private Sprite sprite;

    public string Title
    {
        get => title;
    }
    public string Description
    {
        get => description;
    }
    public Sprite Sprite
    {
        get => sprite;
    }

    public override string ToString()
    {
        return $"{title} is {description}";
    }
}
