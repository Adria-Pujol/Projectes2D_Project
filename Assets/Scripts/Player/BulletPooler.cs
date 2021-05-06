using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class BulletPooler : MonoBehaviour
    {
        //Singleton
        public static BulletPooler instance;

        //Code
        public List<ObjectPool> poolsList;
        private Dictionary<string, Queue<GameObject>> _poolDictionary;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            _poolDictionary = new Dictionary<string, Queue<GameObject>>();

            //Create the pool
            foreach (var p in poolsList)
            {
                var poolObject = new Queue<GameObject>();

                //Instantiate the obj of the pool deactive
                for (var i = 0; i < p.poolSize; i++)
                {
                    var obj = Instantiate(p.prefab);
                    obj.SetActive(false);
                    poolObject.Enqueue(obj);
                }

                _poolDictionary.Add(p.nameOfObjPool, poolObject);
            }
        }

        //Take an obj from the pool and spawn it
        public GameObject SpawnFromPool(string nameOfObjPool, Vector2 pos, Quaternion rotation)
        {
            if (_poolDictionary.ContainsKey(nameOfObjPool))
            {
                var objToSpawn = _poolDictionary[nameOfObjPool].Dequeue();

                objToSpawn.SetActive(true);
                objToSpawn.transform.position = pos;
                objToSpawn.transform.rotation = rotation;

                _poolDictionary[nameOfObjPool].Enqueue(objToSpawn);
                return objToSpawn;
            }

            Debug.LogWarning("Pool with the name: " + nameOfObjPool + " does not exist.");
            return null;
        }

        [Serializable]
        public class ObjectPool
        {
            public string nameOfObjPool;
            public GameObject prefab;
            public int poolSize;
        }
    }
}