using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Pool<T> where T : MonoBehaviour {
    
    [SerializeField]
    private List<T> availableList;
    
    [SerializeField]
    private List<T> usedList;

    private Func<T> function;
    
    public Pool() {}

    public Pool(Func<T> func, int size) {
        this.function = func;
        this.availableList = new List<T>();
        this.usedList = new List<T>();
        
        for (int i = 0; i < size; i++) {
            this.availableList.Add(this.CreateNewItem());
        }
    }

    public T GetOne() {
        T item;
        
        if (this.availableList.Count > 0) {
            item = this.availableList[0];
            this.availableList.RemoveAt(0);
        } else {
            item = this.CreateNewItem();
        }

        this.usedList.Add(item);
        
        item.gameObject.SetActive(true);
        
        return item;
    }

    public void Destroy(T item) {
        item.gameObject.SetActive(false);
        
        this.availableList.Add(item);
        this.usedList.Remove(item);
    }

    private T CreateNewItem() {
        T item = this.function();
        item.gameObject.SetActive(false);
        return item;
    }
}
