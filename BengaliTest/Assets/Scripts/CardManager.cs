using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class CardManager : MonoBehaviour
{
    public Card cardPrefab;
    public Sprite[] frontSprites;
    public Transform gridParent;
    public int columns = 4;
    public int rows = 4;

    private List<Card> cards = new List<Card>();
    private int randItem, count;

    [SerializeField] private DynamicGridLayout dynamicGridLayout;

    void Start()
    {
        GenerateBoard();
    }

    void GenerateBoard()
    {
        dynamicGridLayout.rows = rows;
        dynamicGridLayout.columns = columns;
        List<int> ids = new List<int>();
        count = (columns * rows) / 2;
        for (int i = 0; i < count; i++)
        {
            if (count < 8)
                randItem = Random.Range(0, frontSprites.Length);
            else
                randItem = i;
            ids.Add(randItem);
            ids.Add(randItem);
        }

        ids = ids.OrderBy(x => Random.value).ToList();

        for (int i = 0; i < ids.Count; i++)
        {
            Card card = Instantiate(cardPrefab, gridParent);
            card.Init(ids[i]%frontSprites.Length, frontSprites[ids[i]%frontSprites.Length]);
            cards.Add(card);
            card.gameObject.SetActive(true);
        }
    }
}