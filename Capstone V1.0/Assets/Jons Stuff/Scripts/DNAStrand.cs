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

    public int[] geneticInfo;
    public EntityData entityData;


    public void Start()
    {
        geneButtons = transform.GetComponent<HorizontalLayoutGroup>();
        GetComponent<RectTransform>().localScale = Vector3.zero;
    }

    public void InitEntityData(EntityData ed)
    {
        geneticInfo = TranslateEntityData(ed);
        SetUpNodes();
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
