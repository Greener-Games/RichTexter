using System.Text;
using Atkins.Core;
using GG.Extensions;
using UnityEngine;

namespace GG.RichTexter
{
    public class RichTexter
    {
        const string StartBracket = "<";
        const string EndBracket = ">";
        const string EndCharacter = "/";
    
        const string Bold = "b";
        const string Italic = "i";
        const string Size = "size";
        const string Color = "color";

        readonly StringBuilder value = new StringBuilder();
        
        public static RichTexter operator+ (RichTexter text, string message)
        {
            text.AddMessage(message);
            return text;
        }

        /// <summary>
        /// Start a section of rich text formatting
        /// </summary>
        /// <param name="start"></param>
        void StartRtArea(string start)
        {
            value.Append($"{StartBracket}{start}{EndBracket}"); 
        }
    
        /// <summary>
        /// End a section of rich text Formatting
        /// </summary>
        /// <param name="end"></param>
        void EndRtArea(string end)
        {
            value.Append($"{StartBracket}{EndCharacter}{end}{EndBracket}");
        }

        /// <summary>
        /// Get the string out of the formatter
        /// </summary>
        /// <returns></returns>
        public string GetString()
        {
            return value.ToString();
        }

        /// <summary>
        /// Add a chunk of text to the formatter
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public RichTexter AddMessage(string message)
        {
            value.Append(message);
            
            return this;
        }

        /// <summary>
        /// Format the message the selected color
        /// </summary>
        /// <param name="color"></param>
        /// <param name="message"></param>
        public RichTexter AddColor(Color color, string message)
        {
            AddColor(color);
            value.Append(message);
            EndColor();
            return this;
        }

        /// <summary>
        /// Start a color section
        /// </summary>
        /// <param name="c"></param>
        RichTexter AddColor(Color c)
        {
            StartRtArea($"{Color}=#{ColorExtensions.ColorToHex(c)}");

            return this;
        }

        /// <summary>
        /// end a color section
        /// </summary>
        RichTexter EndColor()
        {
            EndRtArea(Color);

            return this;
        }
    }
}
