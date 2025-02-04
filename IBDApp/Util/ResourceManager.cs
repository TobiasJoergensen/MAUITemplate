using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBDApp.Util
{
    public sealed class ResourceManager
    {
        private static ResourceManager? instance;
        private ResourceDictionary? _colourDictionary;
        private ResourceDictionary? _stylesDictionary;

        private ResourceManager() { 
            ICollection<ResourceDictionary>? mergedDictionaries = Application.Current?.Resources?.MergedDictionaries;

            if (mergedDictionaries != null) {
                foreach (ResourceDictionary dictionary in mergedDictionaries) {
                    if (dictionary.Source.ToString().Contains("Colours")) { 
                        _colourDictionary = dictionary;
                    }
                    else if (dictionary.Source.ToString().Contains("Styles")) {  
                        _stylesDictionary = dictionary;
                    }
                }
            }
        }

        public static ResourceManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ResourceManager();
                }
                return instance;
            }
        }

        /// <summary>
        /// Get a colour from the static colour dictionary.
        /// </summary>
        /// <param name="colourName">Name of the colour in the dictionary.</param>
        /// <returns>Returns a color if found. Null if not.</returns>
        public Color? GetColour(string colourName)
        {
            try
            {
                if (_colourDictionary != null) {
                    _colourDictionary.TryGetValue(colourName, out var colourObj);
                    Color colour = (Color)colourObj;
                    return colour;
                }
            }
            catch (Exception ex) { 
                Debug.WriteLine(ex);
            }

            return null;
        }

        /// <summary>
        /// Get a style from the static style dictionary.
        /// </summary>
        /// <param name="styleName">Name of the style in the dictionary.</param>
        /// <returns>Returns a style if found. Null if not.</returns>
        public Style? GetStyle(string styleName)
        {
            try
            {
                if (_stylesDictionary != null)
                {
                    _stylesDictionary.TryGetValue(styleName, out var styleObj);
                    Style style = (Style)styleObj;
                    return style;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return null;
        }
    }
}
