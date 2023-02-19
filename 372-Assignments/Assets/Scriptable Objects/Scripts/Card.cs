using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(SpriteRenderer))]
public class Card : MonoBehaviour
{
    [SerializeField] private CardObject cardType;
    [Space(20)]
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;
    
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        title.text = cardType.Title;
        description.text = cardType.Description;
        spriteRenderer.sprite = cardType.Sprite;
        Debug.Log(cardType);
    }
}
