using System.Text;
using UnityEngine;
using System.Collections;
using GG.Extensions;

namespace GG.RichTexter
{
    public class RichTexter
    {
        const string StartBracket = "<";
        const string EndBracket = ">";
        const string EndCharacter = "/";
    
        const string BoldId = "b";
        const string ItalicId = "i";
        const string SizeId = "size";
        const string ColorId = "color";

        readonly StringBuilder value = new StringBuilder();

        public RichTexter()
        {
            
        }

        public RichTexter(string current)
        {
            value = new StringBuilder(current);
        }
        
        public static RichTexter operator+ (RichTexter text, string message)
        {
            text.AddMessage(message);
            return text;
        }
        
        public override string ToString()
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
        /// Start a section of rich text formatting
        /// </summary>
        /// <param name="richTextCode"></param>
        void StartRtArea(string richTextCode)
        {
            value.Append($"{StartBracket}{richTextCode}{EndBracket}"); 
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
        /// Format the message the selected color
        /// </summary>
        /// <param name="color"></param>
        /// <param name="message"></param>
        public RichTexter AddColorText(Color color, string message)
        {
            return AddColorText(ColorExtensions.ColorToHex(color), message);
        }
        
        /// <summary>
        /// Format the message the selected color
        /// </summary>
        /// <param name="color"></param>
        /// <param name="message"></param>
        public RichTexter AddColorText(string color, string message)
        {
            StartRtArea($"{ColorId}=#{color}");
            value.Append(message);
            EndRtArea(ColorId);
            return this;
        }
    }
}
