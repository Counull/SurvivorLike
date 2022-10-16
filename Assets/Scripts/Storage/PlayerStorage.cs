using QFramework;
using UnityEngine;

namespace Storage {
    
 
    
    
    public class PlayerStorage: IUtility {
        public void SaveInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }

        public int LoadInt(string key, int defaultValue = 0)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }
    }
}