using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneNode : MonoBehaviour
{
    int index;
    int gene;

    public void Setup(int i, int g)
    {
        index = i;
        gene = g;
    }

    public void SetGeneInEditor()
    {
        DNAEditor.Instance.SetStrandGene(index, gene);
    }
}
