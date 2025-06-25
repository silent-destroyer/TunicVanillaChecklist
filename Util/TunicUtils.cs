using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TunicVanillaChecklist {
    public class TunicUtils {
        public static Dictionary<string, int> AddDictToDict(Dictionary<string, int> primaryDictionary, Dictionary<string, int> secondaryDictionary) {
            foreach (KeyValuePair<string, int> pair in secondaryDictionary) {
                primaryDictionary.TryGetValue(pair.Key, out var count);
                primaryDictionary[pair.Key] = count + pair.Value;
            }
            return primaryDictionary;
        }
    }
}
