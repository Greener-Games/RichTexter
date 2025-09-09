# RichTexter

RichTexter is a lightweight and easy-to-use library for Unity that simplifies the process of working with rich text. It provides a fluent API for building complex rich text strings, saving you from the hassle of manually writing and debugging rich text tags.

## Features

- **Fluent API:** Chain method calls together to create complex rich text strings with ease.
- **Comprehensive Formatting:** Supports all common rich text tags in Unity, including:
  - Bold
  - Italic
  - Size
  - Color (Hex or `Color` object)
  - Underline
  - Strikethrough
  - Superscript
  - Subscript
- **Efficient:** Uses a `StringBuilder` internally for efficient string concatenation.
- **Easy to Integrate:** Simply add the `RichTexter.cs` script to your project and start using it.

## How to Use

To use RichTexter, simply create a new instance of the `RichTexter` class and start chaining method calls to build your string. When you're done, you can get the final rich text string by calling the `ToString()` method.

### Example

```csharp
using GG.RichTexter;
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    public Text uiText;

    void Start()
    {
        RichTexter richText = new RichTexter()
            .AddBoldText("This is bold text. ")
            .AddItalicText("This is italic text. ")
            .AddSizedText(30, "This text is size 30. ")
            .AddColorText(Color.red, "This text is red. ")
            .AddUnderlineText("This text is underlined. ")
            .AddStrikethroughText("This text has a strikethrough. ")
            .AddSuperscriptText("This is superscript. ")
            .AddSubscriptText("This is subscript.");

        uiText.text = richText.ToString();
    }
}
```

This will produce the following output in your UI Text element:

**This is bold text.** *This is italic text.* <size=30>This text is size 30.</size> <color=#FF0000FF>This text is red.</color> <u>This text is underlined.</u> <s>This text has a strikethrough.</s> <sup>This is superscript.</sup> <sub>This is subscript.</sub>

## Installation

1.  Download the `RichTexter.cs` file from this repository.
2.  Add the file to your Unity project.
3.  You're ready to go! You can now use the `GG.RichTexter.RichTexter` class in your scripts.
