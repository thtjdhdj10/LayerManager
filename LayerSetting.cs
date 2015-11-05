﻿using UnityEngine;
using System.Collections.Generic;

public class LayerSetting : MonoBehaviour {

    const int MaxLayerCount = 32;

    public bool editRealtime = false;

    public bool[] layers = new bool[MaxLayerCount];

    void Awake()
    {
        for(int i = 0; i < MaxLayerCount; ++i)
        {
            layers[i] = false;
        }
    }

    void Start()
    {
        RewriteLayer();
    }

    void Update()
    {
        if(editRealtime == true)
        {
            RewriteLayer();
        }
    }

    private void RewriteLayer()
    {
        int layerMask = 0;

        for (int i = 0; i < MaxLayerCount; ++i)
        {
            if (layers[i] == true)
            {
                layerMask = layerMask | NumberToMask(i);
            }
        }

        gameObject.layer = layerMask;
    }

    //

    static Dictionary<string, int> layerNameNumber = new Dictionary<string, int>();

    LayerSetting()
    {
        for (int i = 0; i < 32; i++)
        {
            string name = LayerMask.LayerToName(i);

            if (name.Length > 0)
            {
                layerNameNumber[name] = i;
            }
        }
    }

    //

    static public bool CheckLayer(int layer, string name)
    {
        if (layerNameNumber.ContainsKey(name) == false)
        {
            Debug.LogWarning(name + " is unvalid layer name");
            return false;
        }

        int number = layerNameNumber[name];

        return CheckBit(layer, number);
    }

    static public bool CheckLayerOr(int layer, params string[] names)
    {
        for (int i = 0; i < names.Length; ++i)
        {
            if (layerNameNumber.ContainsKey(names[i]) == false)
            {
                Debug.LogWarning(names[i] + " is unvalid layer name");
                continue;
            }

            int number = layerNameNumber[names[i]];

            if (CheckBit(layer, number) == true)
                return true;
        }

        return false;
    }

    static public bool CheckLayerAnd(int layer, params string[] names)
    {
        for (int i = 0; i < names.Length; ++i)
        {
            if (layerNameNumber.ContainsKey(names[i]) == false)
            {
                Debug.LogWarning(names[i] + " is unvalid layer name");
                continue;
            }

            int number = layerNameNumber[names[i]];

            if (CheckBit(layer, number) == false)
                return false;
        }

        return true;
    }

    static public void AddLayer(ref int layer, params string[] names)
    {
        for (int i = 0; i < names.Length; ++i)
        {
            int number = layerNameNumber[names[i]];

            AddBit(ref layer, number);
        }
    }

    static public void AddLayer(ref int layer, params int[] number)
    {
        for (int i = 0; i < number.Length; ++i)
        {
            AddBit(ref layer, number[i]);
        }
    }

    static public void RemoveLayer(ref int layer, params string[] names)
    {
        for (int i = 0; i < names.Length; ++i)
        {
            int number = layerNameNumber[names[i]];

            RemoveBit(ref layer, number);
        }
    }

    static public void RemoveLayer(ref int layer, params int[] number)
    {
        for (int i = 0; i < number.Length; ++i)
        {
            RemoveBit(ref layer, number[i]);
        }
    }

    //

    static public void LogicalRightShift(ref int pattern, int shift)
    {
        pattern = unchecked((int)((uint)pattern >> shift));
    }

    static public bool CheckBit(int pattern, int number)
    {
        if (number < 0 || number >= 32)
            return false;

        int mask = NumberToMask(number);

        return System.Convert.ToBoolean(mask & pattern);
    }

    static public void AddBit(ref int pattern, int number)
    {
        if (number < 0 || number >= 32)
            return;

        int mask = NumberToMask(number);

        pattern = pattern | mask;
    }

    static public void RemoveBit(ref int pattern, int number)
    {
        if (number < 0 || number >= 32)
            return;

        int mask = NumberToMask(number);

        mask = -1 ^ mask;

        pattern = pattern & mask;
    }

    static public int StringToMask(string str)
    {
        if (layerNameNumber.ContainsKey(str) == false)
        {
            Debug.LogWarning(str + " is unvalid layer name");
            return 0;
        }

        return NumberToMask(layerNameNumber[str]);
    }

    static public int NumberToMask(int number)
    {
        if (number < 0 || number >= 32)
            return 0;

        int rightMask = -1;
        int leftMask = -1;

        LogicalRightShift(ref rightMask, sizeof(int) * 8 - number);
        leftMask = leftMask << number;

        return rightMask & leftMask;
    }

}