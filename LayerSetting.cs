using UnityEngine;
using System.Collections.Generic;

using System.Runtime.Serialization;

public class LayerSetting : MonoBehaviour {

    public int layerMask = 0;

//    public bool editRealtime;
    
        // layers 에 접근해서 특정한 레이어를 설정하는 경우
        // 추가해야 되는 컴포넌트가 있음. ex) Targetable

//    private List<bool> layers = new List<bool>();

    public Dictionary<int, int> indexToLayerNumber = new Dictionary<int, int>();

    public bool[] layers = new bool[LayerManager.MaxLayerCount];

    void Awake()
    {
        //for (int i = 0; i < LayerManager.MaxLayerCount; i++)
        //{
        //    string name = LayerMask.LayerToName(i);

        //    if (name.Length > 0)
        //    {
        //        indexToLayerNumber[layers.Count] = i;
        //        layers.Add(false);
        //    }
        //}
    }

    void Start()
    {
//        RewriteLayer();
    }

    void Update()
    {
        //if(editRealtime == true)
        //{
        //    RewriteLayer();
        //}

        if(Input.GetKeyDown(KeyCode.Q))
        {
            for(int i = 0; i < layers.Length; ++i)
            {
                Debug.Log(LayerMask.LayerToName(indexToLayerNumber[i]));
            }
        }
    }

    public void AddLayer(string str)
    {
        int targetLayerNumber = LayerManager.StringToNumber(str);
        
        foreach(var item in indexToLayerNumber)
        {
            if(item.Value == targetLayerNumber)
            {
                layers[item.Key] = true;
                //UpdateLayerMask();
                layerMask = layerMask | LayerManager.NumberToMask(targetLayerNumber);
                return;
            }
        }
    }

    // private void UpdateLayerMask(){}

    //private void RewriteLayer()
    //{
    //    int sumMask = 0;

    //    for (int i = 0; i < layers.Count; ++i)
    //    {
    //        if (layers[i] == true)
    //        {
    //            int layerNumber = indexToLayerNumber[i];
    //            sumMask = sumMask | LayerManager.NumberToMask(layerNumber);
    //        }
    //    }

    //    layerMask = sumMask;
    //}

}
