using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DNAStrand : MonoBehaviour
{

    #region UIDisplay


    public HorizontalLayoutGroup geneButtons;

    [SerializeField]
    GameObject geneButtonGOPrefab;

    #endregion UIDisplay

    private Sprite icon;
    public Sprite Icon
    {
        get
        {
            return icon;
        }
        set
        {
            icon = value;
        }
    }

    public void Start()
    {
        geneticInfo = new int[4];
        geneButtons = transform.GetComponent<HorizontalLayoutGroup>();
        for (int i = 0; i < 4; i++)
        {
            SetLocalGene(i, Random.Range(0, 10));
        }
        SetUpNodes();
        GetComponent<RectTransform>().localScale = Vector3.zero;
    }


    public int[] geneticInfo;

    public void SetEditorGene(int i)
    {
        DNAEditor.Instance.SetStrandGene(i, geneticInfo[i]);
    }

    public void SetLocalGene(int i, int set)
    {
        geneticInfo[i] = set;
    }

    public void SetUpNodes()
    {
        for (int i = 0; i < geneticInfo.Length; i++)
        {
            GameObject geneButtonGO = Instantiate(geneButtonGOPrefab);
            geneButtonGO.GetComponent<GeneNode>().Setup(i, geneticInfo[i]);
            geneButtonGO.transform.SetParent(this.transform);
            geneButtonGO.transform.localPosition = Vector3.zero;

        }


    }




}
