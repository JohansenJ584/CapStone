using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DNAStrand : MonoBehaviour
{

    #region UIDisplay


    public HorizontalLayoutGroup geneButtons;
    public Image strandImage;

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

    public int[] geneticInfo;
    public EntityData entityData;


    public void Start()
    {
        geneButtons = transform.GetComponent<HorizontalLayoutGroup>();
        //GetComponent<RectTransform>().localScale = Vector3.zero;
    }

    public void InitEntityData(EntityData ed)
    {
        entityData = ed;
        geneticInfo = TranslateEntityData(ed);
        strandImage.color = CalculateColor();
        //SetUpNodes();
    }

    Color CalculateColor()
    {

        float r = (float)(geneticInfo[0] * 15) / 255f;
        float g = (float)(geneticInfo[1] * 15) / 255f;
        float b = (float)(geneticInfo[2] * 15) / 255f;
        Color ret = new Color(r, g, b);
        return ret;
    }

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

    public int[] TranslateEntityData(EntityData ed)
    {
        int[] ret = new int[ed.WhatComps.Count];
        for (int i = 0; i < ed.WhatComps.Count; i++)
        {
            ret[i] = ed.WhatComps[i].WhatComponent;
        }
        return ret;
    }




}
