using System;
using System.Collections.Generic;
using System.IO;

namespace EyeTrackerComparison
{
    public class Storage
    {
        private Dictionary<string, object> iDictionary = new Dictionary<string, object>();

        public void add(string aKey, object aValue)
        {
            iDictionary[aKey] = aValue;
        }

        public bool get(string aKey, bool aDefault)
        {
            return iDictionary.ContainsKey(aKey) ? Convert.ToBoolean(iDictionary[aKey]) : aDefault;
        }

        public int get(string aKey, int aDefault)
        {
            return iDictionary.ContainsKey(aKey) ? Convert.ToInt32(iDictionary[aKey]) : aDefault;
        }

        public double get(string aKey, double aDefault)
        {
            return iDictionary.ContainsKey(aKey) ? Convert.ToDouble(iDictionary[aKey]) : aDefault;
        }

        public string get(string aKey, string aDefault)
        {
            return iDictionary.ContainsKey(aKey) ? iDictionary[aKey].ToString() : aDefault;
        }

        public void save(string aFileName)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(aFileName))
            {
                foreach (KeyValuePair<string, object> pair in iDictionary)
                {
                    writer.WriteLine("{0}={1}", pair.Key, pair.Value);
                }
            }
        }

        public bool load(string aFileName)
        {
            bool result = true;
            iDictionary.Clear();

            if (!File.Exists(aFileName))
                return false;

            using (StreamReader reader = new System.IO.StreamReader(aFileName))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        iDictionary[parts[0]] = parts[1];
                    }
                }
            }

            return result;
        }
    }
}
