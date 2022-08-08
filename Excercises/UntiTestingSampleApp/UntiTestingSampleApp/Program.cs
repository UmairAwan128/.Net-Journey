using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntiTestingSampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Drop => The Drop Of the : " + FindWordInSentnce("The Drop Of the", "Drop"));
            Console.WriteLine("Drop => The Dro Of the : " + FindWordInSentnce("The Dro Of the", "Drop"));
            Console.WriteLine("Drop => The op Of the Dro : " + FindWordInSentnce("The op Of the Dro", "Drop"));
            Console.WriteLine("Drop => Drop Of the asd : " + FindWordInSentnce("Drop Of the asd", "Drop"));
            Console.WriteLine("Drop => adss DDrop Of the asd : " + FindWordInSentnce("asdss DDrop Of the asd", "Drop"));

            Console.WriteLine("null => The Drop Of the : " + FindWordInSentnce(null, "Drop"));
            Console.WriteLine("Drop => null : " + FindWordInSentnce("The Drop Of the", null));
            Console.WriteLine("null => null: " + FindWordInSentnce(null, null));
        }

        static bool FindWordInSentnce(string sentence, string word)
        {
            if (word != null && sentence != null)
            {
                if (word.Length > 0 && sentence.Length > 0)
                {
                    if (sentence.Length > word.Length)
                    {
                        //return sentence.Contains(word);   //one way

                        int sentenceIndex = 0;
                        bool found = false;
                        //other way
                        for (var i = 0; i < sentence.Length; i++)
                        {
                            if (sentence[i].Equals(word[0]))
                            {
                                sentenceIndex = i + 1;
                                for (var j = 1; j < word.Length; j++)
                                {
                                    var sentChar = sentence[sentenceIndex];
                                    var wordChar = word[j];

                                    if (sentence[sentenceIndex].Equals(word[j]))
                                    {
                                        found = true;
                                        if (sentenceIndex < sentence.Length - 1)
                                        {
                                            sentenceIndex++;
                                        }
                                        else
                                        {
                                            found = false;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        found = false;
                                        break;
                                    }
                                }
                                if (found)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                    else if (sentence.Length == word.Length)
                    {
                        return string.Equals(sentence, word);
                    }
                }
            }
            return false;
        }

        static int AddAIntAndStringNumber(int D, string S)
        {
            if ((D >= 1 && D <= 5) && S != null)
            {
                int secondNumber = 0;
                switch (S)
                {
                    case "one":
                        secondNumber = 1;
                        break;
                    case "two":
                        secondNumber = 2;
                        break;
                    case "three":
                        secondNumber = 3;
                        break;
                    case "four":
                        secondNumber = 4;
                        break;
                    case "five":
                        secondNumber = 5;
                        break;

                }
                if (secondNumber != 0)
                {
                    return D * secondNumber;
                }
            }
            return 0; //invalid input passed 
        }
    }

    public interface IStringMap<TValue> where TValue : class
    {
        /// <summary>Returns number of elements in a map</summary>
        int Count { get; }

        /// <summary>
        /// If <c>GetValue</c> method is called but a given key is not in a map then <c>DefaultValue</c> is returned.
        /// </summary>
        TValue DefaultValue { get; set; }

        /// <summary>
        /// Adds a given key and value to a map.
        /// If the given key already exists in the map, then the value associated with this key should be overridden.
        /// </summary>
        /// <returns>true if the value for the key was overridden, otherwise false</returns>
        /// <exception cref="System.ArgumentNullException">If the key is null</exception>
        /// <exception cref="System.ArgumentException">If the key is an empty string</exception>
        /// <exception cref="System.ArgumentNullException">If the value is null</exception>
        bool AddElement(string key, TValue value);

        /// <summary>
        /// Removes a given key and associated value from a map.
        /// </summary>
        /// <returns>true if the key was in the map and was removed, otherwise false</returns>
        /// <exception cref="System.ArgumentNullException">If the key is null</exception>
        /// <exception cref="System.ArgumentException">If the key is an empty string</exception>
        bool RemoveElement(string key);

        /// <summary>
        /// Returns the value associated with a given key.
        /// </summary>
        /// <returns>The value associated with a given key or <c>DefaultValue</c> if the key does not exist in a map</returns>
        /// <exception cref="System.ArgumentNullException">If the key is null</exception>
        /// <exception cref="System.ArgumentException">If the key is an empty string</exception>
        TValue GetValue(string key);
    }

    // Do not change the name of this class
    public class StringMap<TValue> : IStringMap<TValue>
        where TValue : class
    {
        List<StringMapNode<String, TValue>> items;
        public StringMap()
        {
            items = new List<StringMapNode<string, TValue>>();
        }

        /// <summary> Returns number of elements in a map</summary>
        public int Count => items.Count;

        /// <summary>
        /// If <c>GetValue</c> method is called but a given key is not in a map then <c>DefaultValue</c> is returned.
        /// </summary>
        // Do not change this property
        public TValue DefaultValue { get; set; }

        /// <summary>
        /// Adds a given key and value to a map.
        /// If the given key already exists in a map, then the value associated with this key should be overriden.
        /// </summary>
        /// <returns>true if the value for the key was overriden otherwise false</returns>
        /// <exception cref="System.ArgumentNullException">If the key is null</exception>
        /// <exception cref="System.ArgumentException">If the key is an empty string</exception>
        /// <exception cref="System.ArgumentNullException">If the value is null</exception>
        public bool AddElement(string key, TValue value)
        {
            try
            {
                items.Add(new StringMapNode<string, TValue>(key, value));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Removes a given key and associated value from a map.
        /// </summary>
        /// <returns>true if the key was in the map and was removed otherwise false</returns>
        /// <exception cref="System.ArgumentNullException">If the key is null</exception>
        /// <exception cref="System.ArgumentException">If the key is an empty string</exception>
        public bool RemoveElement(string key)
        {
            try
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].Key == key)
                    {
                        items.RemoveAt(i);
                        break;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the value associated with a given key.
        /// </summary>
        /// <returns>The value associated with a given key or <c>DefaultValue</c> if the key does not exist in a map</returns>
        /// <exception cref="System.ArgumentNullException">If a key is null</exception>
        /// <exception cref="System.ArgumentException">If a key is an empty string</exception>
        public TValue GetValue(string key)
        {
            try
            {
                TValue value = null;
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].Key == key)
                    {
                        value = items[i].Value;
                        break;
                    }
                }
                return value;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

    public class StringMapNode<String, TValue>
    {

        public String Key { get; set; }
        public TValue Value { get; set; }
        public StringMapNode(String key, TValue value)
        {
            Key = key;
            Value = value;
        }

    }
}
