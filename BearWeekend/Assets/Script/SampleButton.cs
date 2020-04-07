using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SampleButton : MonoBehaviour
{

    public Button button;
    public Text nameLabel;
    public Image iconImage;
    public Image coinImage;
    public Text priceText;

    public Text itemTag;
    public Text itemStyle;
    public Text itemIconName;

    private Item item;
    private ShopScrollList scrollList;

    // Use this for initialization
    void Start()
    {
        button.onClick.AddListener(HandleClick);
    }

    public void Setup(Item currentItem, ShopScrollList currentScrollList)
    {
        item = currentItem;
        nameLabel.text = item.itemName;
        iconImage.sprite = item.icon;
        itemTag.text = item.tag;
        itemIconName.text = item.iconName;
        itemStyle.text = item.style;

        priceText.text = item.price.ToString();

        scrollList = currentScrollList;
    }

    public void HandleClick()
    {
        scrollList.SelectedItemCheck(item);
    }
}