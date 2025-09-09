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
        const string UnderlineId = "u";
        const string StrikethroughId = "s";
        const string SuperscriptId = "sup";
        const string SubscriptId = "sub";

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

        /// <summary>
        /// Bolds the message
        /// </summary>
        /// <param name="message"></param>
        public RichTexter AddBoldText(string message)
        {
            StartRtArea(BoldId);
            value.Append(message);
            EndRtArea(BoldId);
            return this;
        }

        /// <summary>
        /// Italicises the message
        /// </summary>
        /// <param name="message"></param>
        public RichTexter AddItalicText(string message)
        {
            StartRtArea(ItalicId);
            value.Append(message);
            EndRtArea(ItalicId);
            return this;
        }

        /// <summary>
        /// Sizes the message
        /// </summary>
        /// <param name="size"></param>
        /// <param name="message"></param>
        public RichTexter AddSizedText(int size, string message)
        {
            StartRtArea($"{SizeId}={size}");
            value.Append(message);
            EndRtArea(SizeId);
            return this;
        }

        /// <summary>
        /// Underlines the message
        /// </summary>
        /// <param name="message"></param>
        public RichTexter AddUnderlineText(string message)
        {
            StartRtArea(UnderlineId);
            value.Append(message);
            EndRtArea(UnderlineId);
            return this;
        }

        /// <summary>
        /// Strikes through the message
        /// </summary>
        /// <param name="message"></param>
        public RichTexter AddStrikethroughText(string message)
        {
            StartRtArea(StrikethroughId);
            value.Append(message);
            EndRtArea(StrikethroughId);
            return this;
        }

        /// <summary>
        /// Superscripts the message
        /// </summary>
        /// <param name="message"></param>
        public RichTexter AddSuperscriptText(string message)
        {
            StartRtArea(SuperscriptId);
            value.Append(message);
            EndRtArea(SuperscriptId);
            return this;
        }

        /// <summary>
        /// Subscripts the message
        /// </summary>
        /// <param name="message"></param>
        public RichTexter AddSubscriptText(string message)
        {
            StartRtArea(SubscriptId);
            value.Append(message);
            EndRtArea(SubscriptId);
            return this;
        }
    }
}
