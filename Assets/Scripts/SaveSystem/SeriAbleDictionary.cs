using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SeriAbleDictionary<TKey,TValue> : Dictionary<TKey, TValue>,ISerializationCallbackReceiver
{
    [SerializeField] private List<TKey> keys = new List<TKey>();
    [SerializeField] private List<TValue> values = new List<TValue>();
    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();

        foreach(KeyValuePair<TKey, TValue> pair in this)
        {
            keys.Add(pair.Key);
            values.Add(pair.Value);
        }
    }
    public void OnAfterDeserialize()
    {
        this.Clear();

        if(keys.Count !=values.Count)
        {
            Debug.LogError("키와 밸류의 크기가 일치하지 않습니다.");
        }

        for(int i=0; i<keys.Count; i++)
        {
            this.Add(keys[i], values[i]);
        }
    }

}
